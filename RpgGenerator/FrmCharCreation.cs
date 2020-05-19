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
    public partial class FrmCharCreation : Form
    {

        public FrmCharCreation()
        {
            InitializeComponent();
        }
        
        public static FrmCharCreation frameLoc = new FrmCharCreation();
        private void FrmCharCreation_Load(object sender, EventArgs e)
        {
            pnlStep.Controls.Add(UCCreationStep1.Instance);
            UCCreationStep1.Instance.Dock = DockStyle.Fill;
            UCCreationStep1.Instance.BringToFront();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!pnlStep.Controls.Contains(UCCreationStep2.Instance))
            {
                pnlStep.Controls.Add(UCCreationStep2.Instance);
                UCCreationStep2.Instance.Dock = DockStyle.Fill;
                UCCreationStep2.Instance.BringToFront();
            }
            else
            {
                UCCreationStep2.Instance.BringToFront();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!pnlStep.Controls.Contains(UCCreationStep1.Instance))
            {
                pnlStep.Controls.Add(UCCreationStep1.Instance);
                UCCreationStep1.Instance.Dock = DockStyle.Fill;
                UCCreationStep1.Instance.BringToFront();
            }
            else
            {
                UCCreationStep1.Instance.BringToFront();
            }
        }

        private void FrmCharCreation_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
