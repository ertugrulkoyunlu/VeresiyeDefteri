using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using veresiyeDefterim.usercontrol;
using System.Data.Common;

namespace veresiyeDefterim
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(41, 41, 41);

            Color color = Color.FromArgb(51, 51, 51);
            panel1.BackColor = Color.FromArgb(44, 44, 44);
            panel2.BackColor = Color.FromArgb(44, 44, 44);
            pictureBox4.Image = Properties.Resources.borç_click;
            //textbox renk
            textBox1.BackColor = color;
            textBox_ad.BackColor = color;
            textBox_adres.BackColor = color;
            textBox_eposta.BackColor = color;
            textBox_soyad.BackColor = color;
            textBox_telefon.BackColor = color;
            textBox_borçmiktar.BackColor = color;
            textBox_borçaçıklama.BackColor = color;
            button1.BackColor= color;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            flowLayoutPanel2.BackColor = color;
            panel4.BackColor = Color.FromArgb(44, 44, 44);

            //label renk
            label_isimsoyisim.BackColor = color;
            label_teelefon.BackColor = color;
            label_adrees.BackColor = color;
            label_e_posta.BackColor = color;
            labelSUM.BackColor = color;
            yetki = Form1.isim;

            populateItems();
            populateItems2();
        }

        ///panel kaydırma
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class Musteri
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Telefon { get; set; }
            public string Eposta { get; set; }
            public string Adres { get; set; }
            public string Id { get; set; }
        }
        public class GeçmişBorç
        {
            public string İşlemId { get; set; }
            public string MüşteriId { get; set; }
            public string Açıklama { get; set; }
            public string Fiyat { get; set; }
            public string Tarih { get; set; }
            public string PersonellAd { get; set; }
            public string Durum { get; set; }
        }


        public List<Musteri> GetMusteriler()
        {
            List<Musteri> musteriListesi = new List<Musteri>();

            // Bağlantı dizesi
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb"; 
            // Bağlantı oluşturma
            using (OleDbConnection baglanti = new OleDbConnection(connectionString))
            {
                // SQL sorgusu
                string query = "SELECT Müşteri_Id,İsim, Soyisim, Telefon, eposta, adres FROM MüşteriListesi";
                // Sorgu nesnesi oluşturma
                using (OleDbCommand komut = new OleDbCommand(query, baglanti))
                {
                    // Bağlantı açma
                    baglanti.Open();

                    // Veri okuyucu oluşturma
                    using (OleDbDataReader reader = komut.ExecuteReader())
                    {
                        // Tüm satırları okuyup listeye ekleme
                        while (reader.Read())
                        {
                            Musteri musteri = new Musteri();
                            musteri.Id = reader["Müşteri_Id"].ToString();
                            musteri.Ad = reader["İsim"].ToString();
                            musteri.Soyad = reader["Soyisim"].ToString();
                            musteri.Telefon = reader["Telefon"].ToString();
                            musteri.Eposta = reader["eposta"].ToString();
                            musteri.Adres = reader["adres"].ToString();
                            musteriListesi.Add(musteri);
                        }
                    }
                }
            }



            return musteriListesi;
        }

        public List<GeçmişBorç> GetBorçlar() 
        {
            List<GeçmişBorç> GeçimişBorçListesi=new List<GeçmişBorç>();

            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb"; //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
            // Bağlantı oluşturma
            using (OleDbConnection baglanti = new OleDbConnection(connectionString))
            {
                // SQL sorgusu
                string query = "SELECT * FROM BorçGeçmiş";
                // Sorgu nesnesi oluşturma
                using (OleDbCommand komut = new OleDbCommand(query, baglanti))
                {
                    // Bağlantı açma
                    baglanti.Open();

                    // Veri okuyucu oluşturma
                    using (OleDbDataReader reader = komut.ExecuteReader())
                    {
                        // Tüm satırları okuyup listeye ekleme
                        while (reader.Read())
                        {
                            GeçmişBorç geçmişborç = new GeçmişBorç();
                            geçmişborç.MüşteriId = reader["müşteriId"].ToString();
                            geçmişborç.İşlemId = reader["işlemId"].ToString();
                            geçmişborç.Açıklama = reader["açıklama"].ToString();
                            geçmişborç.Fiyat = reader["fiyat"].ToString();
                            geçmişborç.Tarih = reader["tarih"].ToString();
                            geçmişborç.PersonellAd = reader["personelAdı"].ToString();
                            geçmişborç.Durum = reader["durum"].ToString();
                            GeçimişBorçListesi.Add(geçmişborç);
                        }
                    }
                }
            }



            return GeçimişBorçListesi;

        }
        public class aa
        {
            public string PersonellAdd { get; set; }
            public string MüşteriIdd { get; set; }
            public string İşlemIdd { get; set; }
            public string Açıklamaa { get; set; }
            public string Tarihh { get; set; }
            public string Fiyatt { get; set; }
            public string Durumm { get; set; }
        }
        public async void populateItems2()
        {

            List<aa> list1 = new List<aa>();

            flowLayoutPanel2.Controls.Clear();
            int desiredId = Convert.ToInt32(Idd);
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            OleDbConnection baglanti = new OleDbConnection(connectionString);
            string query1 = "SELECT COUNT(müşteriId) FROM BorçGeçmiş WHERE müşteriId= @desiredId";
            OleDbCommand komut = new OleDbCommand(query1, baglanti);
            //Bağlantı açma
            komut.Parameters.AddWithValue("@desiredId", desiredId);
            baglanti.Open();
            int borçgeçmişSayisi = Convert.ToInt32(komut.ExecuteScalar());

            string connectionStringg = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            OleDbConnection baglantii = new OleDbConnection(connectionStringg);
            string query2 = "SELECT fiyat,durum,müşteriId,işlemId,açıklama FROM BorçGeçmiş WHERE müşteriId= @desiredId";
            OleDbCommand komut2 = new OleDbCommand(query2, baglantii);
            komut2.Parameters.AddWithValue("@desiredId", desiredId);
            baglantii.Open();

            using (OleDbDataReader readerr = komut2.ExecuteReader())
            {
                // Tüm satırları okuyup listeye ekleme
                while (readerr.Read())
                {
                    aa list2 = new aa();
                    list2.MüşteriIdd = readerr["müşteriId"].ToString();
                    list2.İşlemIdd = readerr["işlemId"].ToString();
                    list2.Açıklamaa = readerr["açıklama"].ToString();
                    list2.Fiyatt = readerr["fiyat"].ToString();
                    //list2.Tarihh = readerr["tarih"].ToString();
                    //list2.PersonellAdd = readerr["personelAdı"].ToString();
                    list2.Durumm = readerr["durum"].ToString();
                    list1.Add(list2);
                }
            }



            List<GeçmişBorç> geçmişborçListesi = GetBorçlar();

            listboxtasarımborç[] listbox = new listboxtasarımborç[borçgeçmişSayisi];
            for (int i = 0; i < listbox.Length; i++)
            {
                listbox[i] = new listboxtasarımborç();
                //listbox[i].Width = flowLayoutPanel1.Width;

                listbox[i].BorçMiktar = list1[i].Fiyatt;
                listbox[i].Durumm = list1[i].Durumm;
                listbox[i].müşteriId = list1[i].MüşteriIdd;
                listbox[i].işlemId = list1[i].İşlemIdd;
                listbox[i].Açıklama = list1[i].Açıklamaa;
                if (flowLayoutPanel2.Controls.Count < 0)
                {
                    flowLayoutPanel2.Controls.Clear();
                }
                else
                    flowLayoutPanel2.Controls.Add(listbox[i]);
            }
        }

        public void populateItems()
        {
            flowLayoutPanel1.Controls.Clear();
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            OleDbConnection baglanti = new OleDbConnection(connectionString);
            string query1 = "SELECT COUNT(İsim) FROM MüşteriListesi";
            OleDbCommand komut = new OleDbCommand(query1, baglanti);
            // Bağlantı açma
            baglanti.Open();
            int musteriSayisi = Convert.ToInt32(komut.ExecuteScalar());



            List<Musteri> musteriListesi = GetMusteriler();

            listboxtasarım[] listbox = new listboxtasarım[musteriSayisi];
            for (int i = 0; i < listbox.Length; i++)
            {
                listbox[i] = new listboxtasarım();
                //listbox[i].Width = flowLayoutPanel1.Width;
                listbox[i].İsim = musteriListesi[i].Ad + " " + musteriListesi[i].Soyad;
                listbox[i].Telefon = musteriListesi[i].Telefon;
                listbox[i].Id = musteriListesi[i].Id;
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(listbox[i]);
            }


        }

        public string Idd { get; set; }
        public void ReceiveID(string idd)
        {
            Idd = idd;
            //idd değeri ile bir şeyler yap
            int desiredId = Convert.ToInt32(idd);
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT İsim, Soyisim, Telefon, eposta, adres FROM MüşteriListesi WHERE Müşteri_Id = @desiredId";

                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@desiredId", desiredId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        label_isimsoyisim.Text = reader["İsim"].ToString() + " " + reader["Soyisim"].ToString();
                        label_teelefon.Text = reader["Telefon"].ToString();
                        label_e_posta.Text = reader["eposta"].ToString();
                        label_adrees.Text = reader["adres"].ToString();
                    }
                }
            }
            populateItems2();
        }
        public int resultt { get; set; }
        public string müşteriiıdd { get; set; }
        public void ReceiveID2(string müşteriıd)
        {
            müşteriiıdd = müşteriıd;
            int desiredId = Convert.ToInt32(müşteriıd);
            string conString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            string cmdText = "SELECT Sum(fiyat) FROM BorçGeçmiş WHERE müşteriId= @desireId";
            int result = 0;

            using (OleDbConnection con = new OleDbConnection(conString))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, con))
            {
                cmd.Parameters.AddWithValue("@desiredId", desiredId);
                con.Open();

                var queryResult = cmd.ExecuteScalar();

                if (queryResult != null && queryResult != DBNull.Value)
                {
                    result = Convert.ToInt32(queryResult);
                    resultt= Convert.ToInt32(queryResult);
                }

                //result = Convert.ToInt32(cmd.ExecuteScalar());
            }

            labelSUM.Text ="Güncel borç:"+" "+ result.ToString()+"TL";
        }


            //db ekleme
            private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ad.Text) || string.IsNullOrEmpty(textBox_soyad.Text))
            {
                MessageBox.Show("Lütfen gerekli alanlarını doldurunuz!");
                return;
            }

            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";//"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand komut = new OleDbCommand("insert into MüşteriListesi (İsim,Soyisim,Telefon,eposta,adres) values ('" + textBox_ad.Text.ToString() + "','" + textBox_soyad.Text.ToString() + "','" + textBox_telefon.Text.ToString() + "','" + textBox_eposta.Text.ToString() + "','" + textBox_adres.Text.ToString() + "')", connection);
            komut.ExecuteNonQuery();
            connection.Close();
            populateItems();
            textBox_ad.Clear();
            textBox_soyad.Clear();
            textBox_telefon.Clear();
            textBox_eposta.Clear();
            textBox_adres.Clear();


        }

        //db silme
        private void pictureBox14_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string desireId = Idd;
                string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand komut = new OleDbCommand("DELETE FROM MüşteriListesi WHERE Müşteri_Id = @desireId", connection))
                    {
                        komut.Parameters.AddWithValue("@desireId", desireId);
                        komut.ExecuteNonQuery();
                        connection.Close();
                        label_isimsoyisim.Text = " ";
                        label_teelefon.Text = " ";
                        label_e_posta.Text = " ";
                        label_adrees.Text = " ";
                    }
                }
                populateItems();
            }
            else if (dialogResult == DialogResult.No)
            {
                // kullanıcının Hayır'a bastığında yapılacak işlemler
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.düğme_Hover;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.düğme;
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.Image = Properties.Resources.iptalbuton_hover;
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.Image = Properties.Resources.iptalbuton;
        }
        private void pictureBox20_MouseEnter(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.ekle_hover;
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.ekle;
        }
        private void pictureBox21_MouseEnter(object sender, EventArgs e)
        {
            pictureBox21.Image = Properties.Resources.çıkar_hover;
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            pictureBox21.Image = Properties.Resources.çıkar;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            // X simgesine basıldığında yapılacak işlemler
            if (MessageBox.Show("Uygulamayı kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //e.Cancel = true; // Formun otomatik olarak kapatılmaması için
            }
            else
            {
                this.Close();

                // Formun kapatılması için gerekli işlemler
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox16.Image = Properties.Resources.close_hove;
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox16.Image = Properties.Resources.close;
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.minimize_hover;
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.minimize;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form1'i de kapat
            Application.OpenForms["Form1"].Close();
        }

        private void addUserControl(UserControl uc)
        {
            panel3.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc);
            uc.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            panel3.Controls.Clear();
            pictureBox4.Image = Properties.Resources.borç_click;
            pictureBox9.Image = Properties.Resources.destek;
            pictureBox10.Image = Properties.Resources.ayarlar;
            pictureBox4.Focus();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            destek uc = new destek();
            addUserControl(uc);

            pictureBox4.Image = Properties.Resources.borç;
            pictureBox9.Image = Properties.Resources.destek_click;
            pictureBox10.Image = Properties.Resources.ayarlar;
            pictureBox9.Focus();
        }
        public string Yetkii { get; set; }
        private void pictureBox10_Click(object sender, EventArgs e)
        {


            string desiredId = yetki;
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT Yetki FROM Personel WHERE KullanıcıAdı = @desiredId";

                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@desiredId", desiredId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Yetkii = reader["Yetki"].ToString().ToLower();
                        //label_isimsoyisim.Text = reader["İsim"].ToString() + " " + reader["Soyisim"].ToString();
                        //label_teelefon.Text = reader["Telefon"].ToString();
                        //label_e_posta.Text = reader["eposta"].ToString();
                        //label_adrees.Text = reader["adres"].ToString();
                    }

                }

            }
            if (Yetkii != "admin") 
            {
                MessageBox.Show("Personel listesine giriş yetkiniz bulunmamaktadır.Lütfen yöneticiniz ile iletişime geçiniz");
            }
            else
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();
                pictureBox4.Image = Properties.Resources.borç;
                pictureBox9.Image = Properties.Resources.destek;
                pictureBox10.Image = Properties.Resources.ayarlar_click;
                pictureBox10.Focus();
            }



        }

        private void textBox_ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Tuş işlenmedi
            }
        }

        private void textBox_soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Tuş işlenmedi
            }
        }

        private void textBox_telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayısal karakterlere izin verir
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Yalnızca 11 karakter kabul eder
            if (textBox_telefon.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox_ad.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_soyad.Focus();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox_telefon.Focus();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            textBox_eposta.Focus();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            textBox_adres.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           
           
           if(b!="0") 
            {
                if(textBox1.Text == "") 
                {
                butonoclick();
                    b = "0";
                }

            }

        }
        public string a;
        public string b;
        public async void butonoclick() 
        {
            List<Musteri> musteriListesi = new List<Musteri>();

            // Bağlantı dizesi
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb"; 
            // Bağlantı oluşturma
            using (OleDbConnection baglanti = new OleDbConnection(connectionString))
            {
                // SQL sorgusu
                string query = "SELECT Müşteri_Id,İsim, Soyisim, Telefon, eposta, adres FROM MüşteriListesi Where İsim like'" + textBox1.Text + "%' or Soyisim like'" + textBox1.Text + "%' ";
                // Sorgu nesnesi oluşturma
                using (OleDbCommand komut = new OleDbCommand(query, baglanti))
                {
                    // Bağlantı açma
                    
                    if (a == textBox1.Text) 
                    {
                        MessageBox.Show("Sonuçlar zaten gösteriliyor");
                    }
                    baglanti.Open();
                    a = textBox1.Text;
                    
                    

                    // Veri okuyucu oluşturma
                    using (OleDbDataReader reader = komut.ExecuteReader())
                    {
                        // Tüm satırları okuyup listeye ekleme
                        while (reader.Read())
                        {
                            Musteri musteri = new Musteri();
                            musteri.Id = reader["Müşteri_Id"].ToString();
                            musteri.Ad = reader["İsim"].ToString();
                            musteri.Soyad = reader["Soyisim"].ToString();
                            musteri.Telefon = reader["Telefon"].ToString();
                            musteri.Eposta = reader["eposta"].ToString();
                            musteri.Adres = reader["adres"].ToString();
                            musteriListesi.Add(musteri);
                        }
                    }
                }


                baglanti.Close();

            }

            flowLayoutPanel1.Controls.Clear();
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString2 = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            OleDbConnection baglantii = new OleDbConnection(connectionString2);
            string query1 = "SELECT COUNT(İsim) FROM MüşteriListesi where İsim like'" + textBox1.Text + "%' or Soyisim like'" + textBox1.Text + "%'";
            OleDbCommand komutt = new OleDbCommand(query1, baglantii);
            // Bağlantı açma
            baglantii.Open();
            int musteriSayisi = Convert.ToInt32(komutt.ExecuteScalar());





            listboxtasarım[] listbox = new listboxtasarım[musteriSayisi];
            for (int i = 0; i < listbox.Length; i++)
            {
                listbox[i] = new listboxtasarım();
                //listbox[i].Width = flowLayoutPanel1.Width;
                listbox[i].İsim = musteriListesi[i].Ad + " " + musteriListesi[i].Soyad;
                listbox[i].Telefon = musteriListesi[i].Telefon;
                listbox[i].Id = musteriListesi[i].Id;
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(listbox[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = "1";
            butonoclick();
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            textBox_borçmiktar.Focus();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            textBox_borçaçıklama.Focus();
        }

        private void textBox_borçmiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //db borç ekleme
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            if (string.IsNullOrEmpty(textBox_borçmiktar.Text) )
            {
                MessageBox.Show("Lütfen gerekli alanlarını doldurunuz!");
                return;
            }

            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";//"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand komut = new OleDbCommand("insert into BorçGeçmiş (müşteriId,açıklama,fiyat,durum) values ('" + Idd + "','" + textBox_borçaçıklama.Text.ToString() +" "+today+ "','" + textBox_borçmiktar.Text.ToString() + "','"+ yetki +" "+ "Tarafından borç eklendi"+"')", connection);
            //komut.ExecuteNonQuery();
            int result = komut.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Borç ekleme işlemi başarılı.");
            }
            else
            {
                MessageBox.Show("Borç ekleme işlemi başarısız.");
            }
            connection.Close();
            textBox_borçmiktar.Clear();
            textBox_borçaçıklama.Clear();
            ReceiveID2(müşteriiıdd);
            populateItems2();
        }
        //db borç silme
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (resultt != 0)
            {
                DateTime today = DateTime.Now;
                if (string.IsNullOrEmpty(textBox_borçmiktar.Text))
                {
                    MessageBox.Show("Lütfen gerekli alanlarını doldurunuz!");
                    return;
                }

                string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";//"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand komut = new OleDbCommand("insert into BorçGeçmiş (müşteriId,açıklama,fiyat,durum) values ('" + Idd + "','" + textBox_borçaçıklama.Text.ToString() + " " + today + "','" + "-" + textBox_borçmiktar.Text.ToString() + "','" + yetki + " " + "Tarafından borç silindi" + "')", connection);
                //komut.ExecuteNonQuery();
                int result = komut.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Borç silme işlemi başarılı.");
                }
                else
                {
                    MessageBox.Show("Borç silme işlemi başarısız.");
                }
                connection.Close();
                textBox_borçmiktar.Clear();
                textBox_borçaçıklama.Clear();
                ReceiveID2(müşteriiıdd);
                populateItems2();
            }
            else 
            {
                MessageBox.Show("Eksi bakiye giremezsiniz.");
            }
        }

        public string yetki;
    }
}

