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
    public partial class destek : UserControl
    {
        public destek()
        {
            InitializeComponent();
        }

        private void destek_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(41, 41, 41);
        }
    }
}
