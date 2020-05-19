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
    public partial class UCCreationStep1 : UserControl
    {
        private static UCCreationStep1 instance;
        public static UCCreationStep1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UCCreationStep1();
                }
                return instance;
            }
        }

        public UCCreationStep1()
        {
            InitializeComponent();
        }
    }
}
