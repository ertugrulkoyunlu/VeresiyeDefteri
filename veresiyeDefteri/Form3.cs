using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using veresiyeDefterim.usercontrol;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace veresiyeDefterim
{
    public partial class Form3 : Form
    {

        private const int CB_SETCUEBANNER = 0x1703;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

        public Form3()
        {
            InitializeComponent();


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


        private void ayarlar_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(41, 41, 41);

            Color color = Color.FromArgb(51, 51, 51);
            textBox_KE_kullanıcıadı.BackColor = color;
            textBox_KE_şifre.BackColor = color;
            textBox_P_personelıd.BackColor = color;
            textBox_P_adısoyadı.BackColor = color;
            textBox_P_şifre.BackColor = color;
            textBox_P_kullanıcıadı.BackColor = color;
            textBox_KE_adısoyadı.BackColor = color;
            ///////////////////////////////
            SendMessage(this.comboBox_yetki.Handle, CB_SETCUEBANNER, 0, "Verilecek yetkiyi seçin");
            SendMessage(this.comboBox_P_yetki.Handle, CB_SETCUEBANNER, 0, "Verilecek yetkiyi seçin");

            comboBox_yetki.Region = new Region(new Rectangle(3, 3, comboBox_yetki.Width - 3, comboBox_yetki.Height - 7));
            comboBox_yetki.BackColor = color;
            comboBox_P_yetki.Region = new Region(new Rectangle(3, 3, comboBox_yetki.Width - 3, comboBox_yetki.Height - 7));
            comboBox_P_yetki.BackColor = color;
            ///////////////////////////////
            label3.BackColor= color;
            label6.BackColor= color;
            label7.BackColor= color;
            label8.BackColor= color;
            label9.BackColor = color;
            label10.BackColor = color;
            label11.BackColor = color;
            label12.BackColor = color;

            flowLayoutPanel1.BackColor = Color.FromArgb(48, 48, 48);
            populateItems();


        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            // X simgesine basıldığında yapılacak işlemler
            if (MessageBox.Show("Personel listesini kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //e.Cancel = true; // Formun otomatik olarak kapatılmaması için
            }
            else
            {
                this.Close();

                // Formun kapatılması için gerekli işlemler
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox21_MouseEnter(object sender, EventArgs e)
        {
            pictureBox21.Image = Properties.Resources.close_hove;
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            pictureBox21.Image = Properties.Resources.close;
        }

        private void pictureBox20_MouseEnter(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.minimize_hover;
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.minimize;
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

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            pictureBox17.Image = Properties.Resources.Tikk;
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            pictureBox17.Image = Properties.Resources.Tikk_hover;
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
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
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
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
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

        public string personelıd { get; set; }
        public void ReceiveID(string ID)
        {
            personelıd = ID;
            //idd değeri ile bir şeyler yap
            int desiredId = Convert.ToInt32(ID);
            //string connectionString = "Data Source=UQR\\SQLEXPRESS;Initial Catalog=müşteri_listesi;Integrated Security=True";
            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT * FROM Personel WHERE PersonelId = @desiredId";

                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@desiredId", desiredId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        label3.Text = reader["PersonelAdı"].ToString();
                        label6.Text = reader["KullanıcıAdı"].ToString();
                        label7.Text = reader["Şifre"].ToString();
                        label8.Text = reader["Yetki"].ToString();
                        textBox_P_personelıd.Text= reader["PersonelId"].ToString();
                        textBox_P_adısoyadı.Text= reader["PersonelAdı"].ToString();
                        textBox_P_kullanıcıadı.Text= reader["KullanıcıAdı"].ToString();
                        textBox_P_şifre.Text= reader["Şifre"].ToString();
                    }
                }
            }
        }
        //db ekleme
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_KE_adısoyadı.Text) || string.IsNullOrEmpty(textBox_KE_kullanıcıadı.Text) || string.IsNullOrEmpty(textBox_KE_şifre.Text) || string.IsNullOrEmpty(comboBox_yetki.Text))
            {
                MessageBox.Show("Lütfen ad ve soyad alanlarını doldurunuz!");
                return;
            }

            string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";//"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\PC\\Desktop\\Musteri\\Musteri\\veresiyeDefterimDB\\veresiyeDefterim.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand komut = new OleDbCommand("insert into Personel (PersonelAdı,KullanıcıAdı,Şifre,Yetki) values ('" + textBox_KE_adısoyadı.Text.ToString() + "','" + textBox_KE_kullanıcıadı.Text.ToString() + "','" + textBox_KE_şifre.Text.ToString() + "','" + comboBox_yetki.Text.ToString() + "')", connection);
            komut.ExecuteNonQuery();
            connection.Close();
            populateItems();
            textBox_KE_adısoyadı.Clear();
            textBox_KE_kullanıcıadı.Clear();
            textBox_KE_şifre.Clear();
        }
        //db silme
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string desireId = personelıd;
                string connectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand komut = new OleDbCommand("DELETE FROM Personel WHERE PersonelId = @desireId", connection))
                    {
                        komut.Parameters.AddWithValue("@desireId", desireId);
                        komut.ExecuteNonQuery();
                        connection.Close();
                        label3.Text = " ";
                        label6.Text = " ";
                        label7.Text = " ";
                        label8.Text = " ";
                    }
                }
                populateItems();
            }
            else if (dialogResult == DialogResult.No)
            {
                // kullanıcının Hayır'a bastığında yapılacak işlemler
            }
        }
        //db güncelleme
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            string desireId = personelıd;
            DialogResult dialogResult = MessageBox.Show("Kaydı güncellemek istediğinize emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string constring = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
                string cmdText = "UPDATE Personel SET PersonelAdı=?, KullanıcıAdı=?, [Şifre]=?, Yetki=? WHERE PersonelId = @desireId";
                using (OleDbConnection con = new OleDbConnection(constring))
                using (OleDbCommand cmd = new OleDbCommand(cmdText, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@p1", textBox_P_adısoyadı.Text);
                    cmd.Parameters.AddWithValue("@p2", textBox_P_kullanıcıadı.Text);
                    cmd.Parameters.AddWithValue("@p3", textBox_P_şifre.Text);
                    cmd.Parameters.AddWithValue("@p4", comboBox_P_yetki.Text);
                    cmd.Parameters.AddWithValue("@desireId", desireId);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Güncelleme işlemi başarılı.");
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız.");
                    }
                }
                populateItems();
            }
            else if (dialogResult == DialogResult.No)
            {
                // kullanıcının Hayır'a bastığında yapılacak işlemler
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            textBox_P_personelıd.Focus();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            textBox_P_adısoyadı.Focus();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            textBox_P_kullanıcıadı.Focus();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            textBox_P_şifre.Focus();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            comboBox_P_yetki.Focus();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            textBox_KE_adısoyadı.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox_KE_kullanıcıadı.Focus();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox_KE_şifre.Focus();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            comboBox_yetki.Focus();
        }
    }
}
