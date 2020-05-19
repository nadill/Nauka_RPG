using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgGenerator
{
    public partial class UCCreationStep2 : UserControl
    {
        private static UCCreationStep2 instance;
        public static UCCreationStep2 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UCCreationStep2();
                }
                return instance;
            }
        }
        //bool mouseDrag = false;
        //Panel draggedPanel = null;
        //Point startLoc;
        //int mouseX = 0;
        //int mouseY = 0;

        

        public UCCreationStep2()
        {
            InitializeComponent();
        }

        private void Roll_MouseDown(object sender, MouseEventArgs e)
        {
            //Point startLoc = new Point(Cursor.Position.X, Cursor.Position.Y);
            //mouseX = Cursor.Position.X;
            //mouseY = Cursor.Position.Y;
        }
        private void Roll_DragEnter(object sender, DragEventArgs e)
        {
        }
        private void Roll_MouseUp(object sender, MouseEventArgs e) 
        {

        }

        public void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Panel panel = (Panel)sender;
                panel.Location = new Point(e.X, e.Y);
            }
            lblStrength.Text = string.Format("X:{0}, y:{1}", Cursor.Position.X, Cursor.Position.Y);
            lblConstitution.Text = string.Format("X:{0}, y:{1}", e.X, e.Y);
        }
        public void mouse_Form_Location(object sender, MouseEventArgs e) {
        
        }
    }
}
