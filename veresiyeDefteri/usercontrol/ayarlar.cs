using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static veresiyeDefterim.Form2;

namespace veresiyeDefterim.usercontrol
{
    public partial class ayarlar : UserControl
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(41, 41, 41);

            Color color = Color.FromArgb(51, 51, 51);
            textBox1.BackColor = color;
            textBox2.BackColor = color;
            textBox3.BackColor = color;
            textBox4.BackColor = color;
            textBox5.BackColor = color;
            textBox6.BackColor = color;
            flowLayoutPanel1.BackColor = Color.FromArgb(48,48,48);
            populateItems();


        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {

            pictureBox12.Image = Properties.Resources.iptalbuton;

        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {

            pictureBox12.Image = Properties.Resources.iptalbuton_hover;

        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.düğme;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.düğme_Hover;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class Personel
        {
            public string Ad_soyad { get; set; }
            public string Kullanıcı_adı { get; set; }
            public string Şifre { get; set; }
            public string Yetki { get; set; }
            public string personelId { get; set; }
        }

        public List<Personel> GetPersonel()
        {
            List<Personel> personelListesi = new List<Personel>();

            // Bağlantı dizesi
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb"; //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
            // Bağlantı oluşturma
            using (OleDbConnection baglanti = new OleDbConnection(connectionString))
            {
                // SQL sorgusu
                string query = "SELECT * FROM Personel";
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
                            Personel personel = new Personel();
                            personel.Ad_soyad = reader["PersonelAdı"].ToString();
                            personel.Kullanıcı_adı = reader["KullanıcıAdı"].ToString();
                            personel.Şifre = reader["Şifre"].ToString();
                            personel.Yetki = reader["Yetki"].ToString();
                            personel.personelId = reader["PersonelId"].ToString();
                            personelListesi.Add(personel);
                        }
                    }
                }
            }



            return personelListesi;
        }
        public void populateItems()
        {
            flowLayoutPanel1.Controls.Clear();
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";//"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
            OleDbConnection baglanti = new OleDbConnection(connectionString);
            string query1 = "SELECT COUNT(KullanıcıAdı) FROM Personel";
            OleDbCommand komut = new OleDbCommand(query1, baglanti);
            // Bağlantı açma
            baglanti.Open();
            int musteriSayisi = Convert.ToInt32(komut.ExecuteScalar());




            List<Personel> personelListesi = GetPersonel();

            listboxtasarım[] listbox = new listboxtasarım[musteriSayisi];
            for (int i = 0; i < listbox.Length; i++)
            {
                listbox[i] = new listboxtasarım();
                //listbox[i].Width = flowLayoutPanel1.Width;
                listbox[i].İsim = personelListesi[i].Ad_soyad;
                listbox[i].Telefon = personelListesi[i].Yetki;
                listbox[i].personelId = personelListesi[i].personelId;
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(listbox[i]);
            }



        }
        //private string pID;
        //public string PID
        //{
        //    get { return pID; }
        //    set { pID = value; }
        //}
        //public void kullanıcıbilgi() 
        //{
        //    Form2 form2 = new Form2();
        //    ayarlar myAyarlar = new ayarlar();
        //    myAyarlar.PID = form2.PID;
        //    MessageBox.Show(pID);
        //    //ayarlar.PID = form2.PID;
        //}

        public string pID { get; set; }
        public void ReceiveID2(string PID)
        {
            //    pID= PID;
            //    //idd değeri ile bir şeyler yap
            //    int desiredId = Convert.ToInt32(PID);
            //    //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            //    string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";//"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
            //    using (OleDbConnection connection = new OleDbConnection(connectionString))
            //    {
            //        string sql = "SELECT * FROM Personel WHERE PersonelId = @desiredId";

            //        using (OleDbCommand command = new OleDbCommand(sql, connection))
            //        {
            //            command.Parameters.AddWithValue("@desiredId", desiredId);

            //            connection.Open();
            //            OleDbDataReader reader = command.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                label3.Text = reader["PersonelAdı"].ToString();
            //                label6.Text = reader["Telefon"].ToString();
            //                label7.Text = reader["eposta"].ToString();
            //                label8.Text = reader["adres"].ToString();
            //            }
            //        }
            //    }
        }


    }
}
