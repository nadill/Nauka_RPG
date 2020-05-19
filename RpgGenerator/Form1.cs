using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgGenerator
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnNewChar_Click(object sender, EventArgs e)
        {
            FrmCharCreation frame = new FrmCharCreation();

            frame.ShowDialog();
        }

        private void btnLoadChar_Click(object sender, EventArgs e)
        {

        }
    }
}
