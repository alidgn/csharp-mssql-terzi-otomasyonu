using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace terzi
{
    public partial class IletisimEkle : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7LVPDK4; Initial Catalog=terzi; User id=gamuse; password=464648915;");
        SqlCommand cmd = new SqlCommand();
        public IletisimEkle()
        {
            InitializeComponent();
        }

        public string a;
        public int d;
        private void telefon_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);           
        }
        private void IletisimEkle_Load(object sender, EventArgs e)
        {
            AcceptButton = iletisimKaydet_btn;
            telefon_txt.Focus();            
        }

        private void telefon_txt_TextChanged(object sender, EventArgs e)
        {
            if (telefon_txt.TextLength != 11)
                errorProvider1.SetError(telefon_txt,"Lütfen numarayı 11 haneli olacak şekilde giriniz.");
            else { errorProvider1.Clear(); }
        }

        private void iletisimKaydet_Click(object sender, EventArgs e)
        {
            if (telefon_txt.TextLength != 11)
            {
                MessageBox.Show("Telefon Bilgisini Doğru Giriniz.");
                telefon_txt.Focus();
                telefon_txt.SelectAll();
            }
            else
            {
                conn.Open();
                if (eposta_txt.Text == "Boş geçilebilir." || eposta_txt.Text == "")
                {
                    eposta_txt.Text = "username@example.com";
                }
                cmd = new SqlCommand("insert into iletisim (tel_no,eposta) values('" + telefon_txt.Text + "','" + eposta_txt.Text + "')");
                conn.Close();
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("İletişim Bilgileri Eklendi.");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            SqlCommand comm = new SqlCommand();
            string sorgu = "select iletisim_id from iletisim order by iletisim_id";
            comm.CommandText = sorgu;
            try
            {
                conn.Open();
                comm.Connection = conn;
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    d = Convert.ToInt32(dr["iletisim_id"]);
                }
                MainForm mnf = (MainForm)Application.OpenForms["MainForm"];
                mnf.elemanIletisim_combo.Items.Add(d);
                mnf.musteriIletisim_combo.Items.Add(d);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void eposta_txt_Enter(object sender, EventArgs e)
        {
            if (eposta_txt.Text == "Boş geçilebilir.")
            {
                eposta_txt.Text = "";
                eposta_txt.ForeColor = Color.Black;
            }
        }

        private void eposta_txt_Leave(object sender, EventArgs e)
        {
            if (eposta_txt.Text == "")
            {
                eposta_txt.Text = "Boş geçilebilir.";
                eposta_txt.ForeColor = Color.LightGray;
            }
        }

        private void IletisimEkle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
