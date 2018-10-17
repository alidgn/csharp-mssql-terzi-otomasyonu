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
    public partial class Giris : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7LVPDK4; Initial Catalog=terzi; User id=gamuse; password=464648915;");
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            AcceptButton = giris_btn;
        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from kullanicilar where kul_adi='" + kullaniciAdi_txt.Text + "' and sifre='" + sifre_txt.Text + "'";
            SqlDataReader reader = comm.ExecuteReader();


            try
            {
                if (reader.Read())
                {
                    MainForm main = new MainForm(reader["admin"].ToString());
                    this.Hide();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
