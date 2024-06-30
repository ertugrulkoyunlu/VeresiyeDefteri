using System.Data;
using System.Data.OleDb;

namespace veresiyeDefterim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.mouse_hover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.mouse;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(41, 41, 41);
            Color color = Color.FromArgb(51, 51, 51);
            textBox1.BackColor = color;
            textBox2.BackColor = color;
            textBox1.MaxLength = 30;
            textBox2.MaxLength = 30;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter tuþunu yok say
                pictureBox1_Click(sender, e); // Formu submit etmek için bir butona basýldý varsay
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter tuþunu yok say
                textBox1.Focus(); // textBox1'e odaklan
            }
        }
        public static string isim="";

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            isim=Convert.ToString(textBox2.Text);
            string constring = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=veresiyeDefterim.accdb";
            string cmdText = "select Count(*) from Personel where KullanıcıAdı=? and [Şifre]=?";
            using (OleDbConnection con = new OleDbConnection(constring))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@p1", textBox2.Text);
                cmd.Parameters.AddWithValue("@p2", textBox1.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    await Task.Delay(1000);
                    // Mevcut form gizleniyor
                    this.Hide();
                }

                else
                    MessageBox.Show("Şifre veya kullanıcı adı hatalı");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox2.Focus();
            }
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

        private void pictureBox16_MouseClick(object sender, MouseEventArgs e)
        {
            // X simgesine basýldýðýnda yapýlacak iþlemler
            if (MessageBox.Show("Uygulamayı kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //e.Cancel = true; // Formun otomatik olarak kapatýlmamasý için
            }
            else
            {
                this.Close();
                // Formun kapatýlmasý için gerekli iþlemler
            }
        }

        private void pictureBox15_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

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
    }
}