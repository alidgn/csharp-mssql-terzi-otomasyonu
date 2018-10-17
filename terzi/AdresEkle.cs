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
    public partial class AdresEkle : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7LVPDK4; Initial Catalog=terzi; User id=gamuse; password=464648915;");
        SqlCommand cmd = new SqlCommand();
        public AdresEkle()
        {
            InitializeComponent();
        }
        
        public string a;
        public int c;
        private void adresEkle_btn_Click(object sender, EventArgs e)
        {
            if (sehir_txt.Text == "" || ilce_txt.Text == "" || mahalle_txt.Text == "" || cadde_txt.Text == "" || bina_txt.Text == "" || postaKodu_txt.Text == "" || ulke_txt.Text == "")
                MessageBox.Show("Lütfen Eksik Alanları Doldurun.");
            else
            {
                conn.Open();
                cmd = new SqlCommand("insert into adresler (sehir,ilce_adi,mahalle_adi,cadde_adi,bina_no,posta_kodu,ulke)  values('" + sehir_txt.Text + "','" + ilce_txt.Text + "','" + mahalle_txt.Text + "','" + cadde_txt.Text + "','" + bina_txt.Text + "'," + postaKodu_txt.Text + ",'" + ulke_txt.Text + "')");
                conn.Close();
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt İşlemi Başarılı");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                
                SqlCommand cmm = new SqlCommand();
                string sorgu = "select adres_no from adresler order by adres_no";
                cmm.CommandText = sorgu;
                try
                {
                    conn.Open();
                    cmm.Connection = conn;
                    SqlDataReader dr = cmm.ExecuteReader();
                    while (dr.Read())
                    {
                        c = Convert.ToInt32(dr["adres_no"]);
                    }
                   // MessageBox.Show(c.ToString());
                    MainForm mnf = (MainForm)Application.OpenForms["MainForm"];
                    mnf.elemanAdres_combo.Items.Add(c);
                    mnf.musteriAdres_combo.Items.Add(c);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                   /* MainForm mnf = new MainForm(a);
                    mnf.textBox1.Text = c.ToString();
                    this.Hide(); */
                }

            }
        }

        
        private void AdresEkle_Load(object sender, EventArgs e)
        {
            AcceptButton = adresEkle_btn;
            ilce_txt.Focus();
            if (sehir_txt.Text == "KÜTAHYA")
                postaKodu_txt.Text = "43000";
        }

        private void postaKodu_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);          
        }

        private void sehir_txt_TextChanged(object sender, EventArgs e)
        {
            postaKodu_txt.ResetText();
            if (sehir_txt.Text == "KÜTAHYA" || sehir_txt.Text == "kütahya" || sehir_txt.Text == "kutahya" || sehir_txt.Text == "KUTAHYA")
                postaKodu_txt.Text = "43000";
        }

        private void AdresEkle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
