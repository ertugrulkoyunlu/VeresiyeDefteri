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
    public partial class listboxtasarımborç : UserControl
    {
        public listboxtasarımborç()
        {
            InitializeComponent();
            panel1.Click += Panel1_Click;
        }
        private void listboxtasarımborç_Load(object sender, EventArgs e)
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

        private string _durum;
        private string _borçmiktar;
        private string _müşteriıd;
        private string _işlemıd;
        private string _açıklama;

        [Category("tasarım")]
        public string BorçMiktar
        {
            get { return _borçmiktar; }
            set { _borçmiktar = value; label_miktar.Text = value+" "+"TL"; }
        }


        [Category("tasarım")]
        public string Durumm
        {
            get { return _durum; }
            set { _durum = value; label_durum.Text = value; }
        }

        [Category("tasarım")]
        public string müşteriId
        {
            get { return _müşteriıd; }
            set { _müşteriıd = value; }
        }
        [Category("tasarım")]
        public string işlemId
        {
            get { return _işlemıd; }
            set { _işlemıd = value; }
        }
        [Category("tasarım")]
        public string Açıklama
        {
            get { return _açıklama; }
            set { _açıklama = value; label_açıklama.Text = value; }
        }

        private void Panel1_Click(object sender, EventArgs e) 
        {
            //Form2 form = this.FindForm() as Form2;
            //if (form != null)
            //{
            //    string müşteriıd = this.müşteriId;
            //    form.ReceiveID2(müşteriıd);
            //}

            //Form2 form2 = this.FindForm() as Form2;
            //if (form2 != null)
            //{
            //    string işlemıd = this.işlemId;
            //    form2.ReceiveID3(işlemıd);
            //}
        }
    }
}
