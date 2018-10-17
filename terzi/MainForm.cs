using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace terzi
{
    public partial class MainForm : Form
    {
        public void listele(string a)
        {
            SqlDataAdapter adptr = new SqlDataAdapter(a, conn);
            tablo.Clear();
            conn.Open();
            adptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }
   

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7LVPDK4; Initial Catalog=terzi; User id=gamuse; password=464648915; Integrated Security = True;");
        SqlCommand cmd = new SqlCommand();
        public MainForm(String isAdmin)
        {
            InitializeComponent();
            adminControl = isAdmin;
            if (isAdmin != "1")
            {
                tabControl1.TabPages.Remove(kullanici_tab);
                tabControl1.TabPages.Remove(personel_tab);
            }
        }
        public string adminControl;
        //public int b;
        private void MainForm_Load(object sender, EventArgs e)
        {
            string islem = "select sum(ucret) as toplam from urunler";
            conn.Open(); // Bağlantıyı açıyoruz // Sorguyu komuta atıyoruz
            cmd = new SqlCommand(islem, conn);
            ucretTopla1.Text = cmd.ExecuteScalar().ToString();
            sayi1 = Convert.ToInt32(ucretTopla1.Text);
            cmd.ExecuteNonQuery(); // Komutu çalıştırıyoruz
            conn.Close(); // Bağlantıyı mutlaka kapatıyoruz
            toplamKazanc += sayi1;
            string islemm = "select sum(ucret) as toplam from urunFirma";
            conn.Open(); // Bağlantıyı açıyoruz // Sorguyu komuta atıyoruz
            cmd = new SqlCommand(islemm, conn);
            ucretTopla2.Text = cmd.ExecuteScalar().ToString();
            sayi2 = Convert.ToInt32(ucretTopla2.Text);
            cmd.ExecuteNonQuery(); // Komutu çalıştırıyoruz
            conn.Close(); // Bağlantıyı mutlaka kapatıyoruz
            toplamKazanc += sayi2;
            label_ucret.Text = toplamKazanc.ToString() + " TL";
            label23.Text = label_ucret.Text;

            musteriTuru_combo.SelectedIndex = 0;
            musteriAdres_combo.Text = "";
            musteriIletisim_combo.Text = "";
            elemanIletisim_combo.SelectedIndex = 0;
            elemanAdres_combo.SelectedIndex = 0;            

            string cmdText = "select * from urun_adi";
            string kolonAd = "urun_adi";
            Doldur(combo_urunAdi, cmdText, kolonAd);
            cmdText = "select * from urun_turu";
            kolonAd = "urun_turu";
            Doldur(combo_urunTuru, cmdText, kolonAd);
            cmdText = "select * from urun_adi";
            kolonAd = "urun_adi";
            Doldur(combo_urunAdi2, cmdText, kolonAd);
            cmdText = "select * from firma_musterisi";
            kolonAd = "firma_adi";
            Doldur(combo_firmaAdi, cmdText, kolonAd);
            cmdText = "select * from eleman";
            kolonAd = "eleman_adi";
            Doldur(combo_eleman, cmdText, kolonAd);
            //  dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
        }   

        private void ekle_Click(object sender, EventArgs e)
        {
            if (musteriTuru_combo.SelectedItem.ToString() != "Bireysel Müşteri" && musteriTuru_combo.SelectedItem.ToString() != "Firma Müşteri")
            {
                MessageBox.Show("Müşteri Türünü Seçmediniz.");
                musteriTuru_combo.Focus();
            }           
            else
            {
                conn.Open();
                if (musteriTuru_combo.SelectedItem.ToString() == "Bireysel Müşteri")
                {
                    if (ad_txt.Text == "" || soyad_txt.Text == "" || musteriAdres_combo.Text == "" || musteriIletisim_combo.Text == "") 
                        MessageBox.Show("Lütfen Eksik Yerleri Doldurun");
                    cmd = new SqlCommand("insert into bireysel_musteri (musteri_adi,musteri_soyadi,adres_no,iletisim_id)" +
                        "values('" + ad_txt.Text + "','" + soyad_txt.Text + "'," + musteriAdres_combo.Text + "," + musteriIletisim_combo.Text + ")");
                }
                else if (musteriTuru_combo.SelectedItem.ToString() == "Firma Müşteri")
                {
                    if (ad_txt.Text == "" || musteriAdres_combo.Text == "" || musteriIletisim_combo.Text == "")
                        MessageBox.Show("Lütfen Eksik Yerleri Doldurun");
                    else
                    {
                        cmd = new SqlCommand("insert into firma_musterisi (firma_adi,adres_no,iletisim_id)" +
                       "values('" + ad_txt.Text + "'," + musteriAdres_combo.Text + "," + musteriIletisim_combo.Text + ")");
                    }                   
                }
                conn.Close();
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt İşlemi Başarılı");
                    MessageBox.Show("Ürün Bilgileri için yönlendiriliyorsunuz...");
                   
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                  //  musteriAdres_combo.Items.RemoveAt(1);
                   // musteriIletisim_combo.Items.RemoveAt(1);
                   //musteriIletisim_combo.SelectedIndex = 0;
                    //musteriAdres_combo.SelectedIndex = 0;
                    //tabControl1.SelectedIndex = 1;
                    //label15.Text = "";
                }
            }
           
        }

        private void musteriTuru_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (musteriTuru_combo.SelectedItem.ToString() == "Firma Müşteri")
            {
                combo_firmaAdi.Enabled = true;
                label7.Enabled = true;
                ad_label.Text = "Firma Adı :";
                soyad_txt.Enabled = false;
                soyad_label.Enabled = false;
                combo_musteriNo.Enabled = false;
                label6.Enabled = false;
                label5.ForeColor = Color.Green;
                label5.Text = "Devam Edebilirsiniz.";
            }
            else if(musteriTuru_combo.SelectedItem.ToString() == "Bireysel Müşteri")
            {
                label6.Enabled = true;
                combo_musteriNo.Enabled = true;
                ad_label.Text = "Adı :";
                soyad_txt.Enabled = true;
                soyad_label.Enabled = true;
                combo_firmaAdi.Enabled = false;
                label7.Enabled = false;
                label5.ForeColor = Color.Green;
                label5.Text = "Devam Edebilirsiniz.";
            }else
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Lütfen müşteri türünü belirleyiniz.";

            }
        }      
        
        private void adresEkle_btn_Click(object sender, EventArgs e)
        {
            AdresEkle adres = new AdresEkle();
            adres.a = adminControl;
            adres.ShowDialog();
        }

        private void temizle_Click(object sender, EventArgs e)
        {
            ad_txt.Text = "";
            soyad_txt.Text = "";
            musteriTuru_combo.SelectedIndex = 0;
            musteriAdres_combo.Text = "";
            musteriIletisim_combo.Text = "";

        }

        private void iletisimEkle_btn_Click(object sender, EventArgs e)
        {
            IletisimEkle iletisim = new IletisimEkle();
            iletisim.a = adminControl;
            iletisim.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
        ////////////////////////////////////////////
            }            
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            if (yetkiliAdi_txt.Text == "" || yetkiliSoyadi_txt.Text == "" || kullanici_txt.Text == "" || sifre_txt.Text == "")
            {
                MessageBox.Show("Eksik alanları doldurunuz.");
            }
            else
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "insert into kullanicilar (adi, soyadi, kul_adi, sifre, admin)" +
                    " values('" + yetkiliAdi_txt.Text + "','" + yetkiliSoyadi_txt.Text + "','" + kullanici_txt.Text + "','" + sifre_txt.Text + "',0)";

                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt işlemi başarılı...");                    
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
            }
        }
        
        private void elemanAdresEkle_btn(object sender, EventArgs e)
        {
            AdresEkle adres = new AdresEkle();
            adres.a = adminControl;
            adres.ShowDialog();
        }

        private void elemanIletisimEkle_btn_Click(object sender, EventArgs e)
        {
            IletisimEkle ilt = new IletisimEkle();
            ilt.a = adminControl;
            ilt.ShowDialog();
        }

        private void elemanTemizle_btn_Click(object sender, EventArgs e)
        {
            elemanAdi_txt.ResetText();
            elemanSoyadi_txt.ResetText();
            elemanAdres_combo.SelectedIndex = 0;
            elemanIletisim_combo.SelectedIndex = 0;
        }
        public int a;        

        private void elemanEkle_btn_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (elemanAdi_txt.Text == "" || elemanSoyadi_txt.Text == "" || elemanAdres_combo.SelectedIndex != 1 || elemanIletisim_combo.SelectedIndex != 1)
                MessageBox.Show("Eksik yerleri doldurun.");
            else
            {
                cmd = new SqlCommand("insert into eleman(eleman_adi,eleman_soyadi,adres_no,iletisim_id)values('" + elemanAdi_txt.Text + "','" + elemanSoyadi_txt.Text + "'," + elemanAdres_combo.Text + "," + elemanIletisim_combo.Text + ")");
            }
            conn.Close();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eleman başarıyla eklendi");
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
              
                elemanIletisim_combo.SelectedIndex = 0;
                elemanAdres_combo.SelectedIndex = 0;
            }    
        }
        public int d;      
        void Doldur(ComboBox combo, string cmdText, string kolonAd)
        {
            SqlCommand comm = new SqlCommand();
            comm.CommandText = cmdText;
            try
            {
                conn.Open();
                comm.Connection = conn;
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    combo.Items.Add(reader[kolonAd].ToString());
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

        private void btn_urunBilgiKaydet_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (combo_urunAdi.Text == "" || combo_urunTuru.Text == "" || txt_urunSorunu.Text == "")
            {
                MessageBox.Show("Eksik yerleri doldurunuz.");
            }
            else
            {
                combo_urunAdi2.SelectedIndex = combo_urunAdi.SelectedIndex;
                combo_urunAdi2.Enabled = false;
                tabControl1.SelectedIndex = 2;
                cmd = new SqlCommand("insert into urun_bilgisi(urunAdi_id,urunTuru_id,urun_sorunu,sorun_aciklamasi)" +
                    "values(" + combo_urunAdi.SelectedIndex + "," + combo_urunTuru.SelectedIndex + ",'" + txt_urunSorunu + "','" + txt_aciklama + "')");
            }
            conn.Close();            
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();               
                MessageBox.Show("Kayıt İşlemi Başarılı");
            }
            catch(Exception ex)
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
            SqlCommand comm = new SqlCommand();
            string sorgu = "select urunBilgisi_id from urun_bilgisi order by urunBilgisi_id";
            comm.CommandText = sorgu;
            try
            {
                conn.Open();
                comm.Connection = conn;
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    label_urunBilgisi.Text = Convert.ToInt32(dr["urunBilgisi_id"]).ToString();
                }                
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
            if(musteriTuru_combo.Text=="Bireysel Müşteri")
            {

                SqlCommand comm1 = new SqlCommand();
                string srg = "select musteri_id from bireysel_musteri order by musteri_id";
                comm1.CommandText = srg;
                try
                {
                    conn.Open();
                    comm1.Connection = conn;
                    SqlDataReader dr = comm1.ExecuteReader();
                    while (dr.Read())
                    {
                        d = Convert.ToInt32(dr["musteri_id"]);
                    }
                    combo_musteriNo.Items.Add(d);
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
            }
            else if (musteriTuru_combo.Text == "Firma Müşteri")
            {
                combo_firmaAdi.Items.Clear();
                string cmdText = "select * from firma_musterisi";
                string kolonAd = "firma_adi";
                Doldur(combo_firmaAdi, cmdText, kolonAd);
            }
            combo_eleman.Items.Clear();
            string cmddText = "select * from eleman";
            string kolonnAd = "eleman_adi";
            Doldur(combo_eleman, cmddText, kolonnAd);
        }
        private void btn_urunBilgiTemizle_Click(object sender, EventArgs e)
        {
            combo_urunTuru.Text = "";
            combo_urunAdi.Text = "";
            txt_urunSorunu.Text = "";
            txt_aciklama.Text = "";
        }

        private void combo_urunAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_urunTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_urunAdi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_musteriNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_firmaAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void txt_ucret_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void musteriAdres_combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void musteriIletisim_combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public int sayi1, sayi2, toplamKazanc;
        private void btn_urunKaydet_Click(object sender, EventArgs e)
        {
            if (combo_firmaAdi.Enabled == false)
            {
                if (combo_musteriNo.Text == "" || txt_ucret.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
                {
                    MessageBox.Show("Lütfen Eksik Yerleri Doldurunuz.");
                }
                else
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into urunler(urunBilgisi_id,musteri_id,alim_zamani,teslim_zamani,ucret)"+
                        "values("+label_urunBilgisi.Text+","+combo_musteriNo.Text+",'"+dateTimePicker1.Value+"','"+dateTimePicker2.Value+"',"+txt_ucret.Text+")");
                    conn.Close();
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ürün başarıyla eklendi");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open) ;
                    }
                    string islem = "select sum(ucret) as toplam from urunler";
                    conn.Open(); // Bağlantıyı açıyoruz // Sorguyu komuta atıyoruz
                    cmd = new SqlCommand(islem, conn);
                    ucretTopla1.Text = cmd.ExecuteScalar().ToString();
                    sayi1 = Convert.ToInt32(ucretTopla1.Text);
                    cmd.ExecuteNonQuery(); // Komutu çalıştırıyoruz
                    conn.Close(); // Bağlantıyı mutlaka kapatıyoruz
                    toplamKazanc += sayi1;
                    label23.Text = label_ucret.Text;
                  
                }
            }
            else if (combo_musteriNo.Enabled == false)
            {
                if (combo_firmaAdi.Text == "" || txt_ucret.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
                {
                    MessageBox.Show("Lütfen Eksik Yerleri Doldurunuz.");
                }
                else
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into urunFirma(urunBilgisi_id,firma_id,alim_tarihi,teslim_tarihi,ucret)" +
                   "values(" + label_urunBilgisi.Text + "," + combo_firmaAdi.SelectedIndex + ",'" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "'," + txt_ucret.Text + ")");
                    conn.Close();
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ürün başarıyla eklendi");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open) ;
                    }
                    string islem = "select sum(ucret) as toplam from urunFirma";
                    conn.Open(); // Bağlantıyı açıyoruz // Sorguyu komuta atıyoruz
                    cmd = new SqlCommand(islem, conn);
                    ucretTopla2.Text = cmd.ExecuteScalar().ToString();
                    sayi2 = Convert.ToInt32(ucretTopla2.Text);
                    cmd.ExecuteNonQuery(); // Komutu çalıştırıyoruz
                    conn.Close(); // Bağlantıyı mutlaka kapatıyoruz
                    toplamKazanc += sayi2;
                }               
            }           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_ucret.Text = toplamKazanc.ToString() + " TL";
          /*/  if (musteriTuru_combo.Text == "" || musteriTuru_combo.Text == "Müşteri Türünü Seçiniz...")
            {
                if(tabControl1.SelectedIndex != 0)
                {
                    MessageBox.Show("Müşteri Türünü Seçmediniz. Lütfen bir müşteri türü belirleyiniz.");
                    tabControl1.SelectedIndex = 0;
                }
                              
            }*/
        }

        private void btn_urunTemizle_Click(object sender, EventArgs e)
        {
            combo_urunAdi2.ResetText();
            combo_musteriNo.ResetText();
            combo_firmaAdi.ResetText();
            txt_ucret.ResetText();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yetkiliAdi_txt.ResetText();
            yetkiliSoyadi_txt.ResetText();
            kullanici_txt.ResetText();
            sifre_txt.ResetText();
        }
        public void VerileriGöster(string veriler, DataGridView dg)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dg.DataSource = ds.Tables[0];
        }

        public static string gonder ="select a.musteri_id as MusteriId, a.musteri_adi as MusteriAdi,a.musteri_soyadi as MusteriSoyadi,  b.sehir as Sehir,b.ilce_adi as Ilce ,b.mahalle_adi as MahalleAdi, b.cadde_adi as CaddeAdi ,b.bina_no as BinaNo,  " +
               " i.tel_no as Tel ,i.eposta as Eposta from adresler as b inner join bireysel_musteri as a on b.adres_no=a.adres_no inner join iletisim as i on a.iletisim_id=i.iletisim_id ";
        
        public static string gonder2 = "select a.firma_adi as FirmaAdi,  b.sehir as Sehir,b.ilce_adi as Ilce ,b.mahalle_adi as MahalleAdi, b.cadde_adi as CaddeAdi ,b.bina_no as BinaNo,  " +
               " i.tel_no as Tel ,i.eposta as Eposta from adresler as b inner join firma_musterisi as a on b.adres_no=a.adres_no inner join iletisim as i on a.iletisim_id=i.iletisim_id ";


        DataTable tablo =new DataTable();      

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Siliniyor Emin Misiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from urunler where musteri_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("delete from bireysel_musteri where musteri_adi='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    VerileriGöster(gonder, dataGridView1);
                    MessageBox.Show("Silme işlemi gerçekleşti");
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
            }
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            if (radioButton1.Checked == true) {
                SqlDataAdapter adptr = new SqlDataAdapter(gonder + "where musteri_adi like'%" + textBox1.Text + "%'", conn);
                tablo.Clear();
           
                adptr.Fill(tablo);
                dataGridView1.DataSource = tablo;
          
            }
            else if (radioButton2.Checked == true)
            {

                SqlDataAdapter adptr = new SqlDataAdapter(gonder2 + "where firma_adi like'%" + textBox1.Text + "%'", conn);
                tablo.Clear();
                adptr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            conn.Close();
        }  

        private void radioButton1_Click(object sender, EventArgs e)
        {
            VerileriGöster(gonder, dataGridView1);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
          VerileriGöster(gonder2, dataGridView1);
        }

        private void musteriTuru_combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_eleman_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void elemanAdres_combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void elemanIletisim_combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
