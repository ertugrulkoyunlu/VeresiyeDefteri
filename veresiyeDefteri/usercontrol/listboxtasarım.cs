using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veresiyeDefterim.usercontrol
{
    public partial class listboxtasarım : UserControl
    {
        public listboxtasarım()
        {
            InitializeComponent();
            // Panel'e tıklanma olayını ele al
            panel1.Click += Panel1_Click;
        }

        private void listboxtasarım_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(44, 44, 44);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(66, 66, 66);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(44, 44, 44);
        }

        private string _isim;
        private string _telefon;
        private string _ıd;
        private string _personelıd;


        [Category("tasarım")]
        public string İsim
        {
            get { return _isim; }
            set { _isim = value; label_isim.Text = value; }
        }


        [Category("tasarım")]
        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; label_telefon.Text = value; }
        }

        [Category("tasarım")]
        public string Id
        {
            get { return _ıd; }
            set { _ıd = value; }
        }

        [Category("tasarım")]
        public string personelId
        {
            get { return _personelıd; }
            set { _personelıd = value; }
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            //string id = Convert.ToString(Id);

            // ID değerini Form1'e gönder
            Form2 form = this.FindForm() as Form2;
            if (form != null)
            {
                string idd = this.Id;
                form.ReceiveID(idd);
            }

            Form2 form2 = this.FindForm() as Form2;
            if (form2 != null)
            {
                string müşteriıd = this.Id;
                form2.ReceiveID2(müşteriıd);
            }


            Form3 form3 =this.FindForm() as Form3;
            if (form3 != null)
            {
                string ID = this.personelId;
                form3.ReceiveID(ID);
            }
        }
    }
}
