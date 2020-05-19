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
        Point startLoc;
        Point preDragLoc;
        //int mouseX = 0;
        //int mouseY = 0;

        

        public UCCreationStep2()
        {
            InitializeComponent();
        }

        private void Roll_MouseDown(object sender, MouseEventArgs e)
        {

            Point startLoc = e.Location;
            Panel panel = (Panel)sender;

            preDragLoc = panel.Location;

            //mouseX = Cursor.Position.X;
            //mouseY = Cursor.Position.Y;
        }
        private void Roll_DragEnter(object sender, DragEventArgs e)
        {
        }
        private void Roll_MouseUp(object sender, MouseEventArgs e) 
        {
            Panel panel = (Panel)sender;

            panel.Location = preDragLoc;
        }

        public void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Panel panel = (Panel)sender;
                panel.BringToFront();
                panel.Location = new Point(panel.Location.X - (startLoc.X - e.X), panel.Location.Y - (startLoc.Y - e.Y));
            }
        }
        public void mouse_Form_Location(object sender, MouseEventArgs e) {
        
        }
    }
}
