using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroCheckBox : UserControl
    {
        public bool vSroChecked;
        public bool vSroCheck { get => vSroChecked; set => vSroChecked = value; }

        public string vSroCheckBoxName { get => labelCheckBox.Text; set => labelCheckBox.Text = value;  }

        public  event vSroCheckChanger vSroCheckChange;
        public delegate void vSroCheckChanger(object sender, EventArgs e);
        public vSroCheckBox()
        {
            InitializeComponent();
            ChangeStatus(vSroChecked);
        }
        
        /// <summary>
        /// Change the CheckStatus from vSroCheckBox to true or false
        /// </summary>
        /// <param name="check"></param>
        public void ChangeStatus(bool check)
        {
            vSroChecked = check;
            buttonCheckBox.Image = vSroChecked ? imageListCheckBox.Images[1] : imageListCheckBox.Images[0];
        }
  

        private void buttonCheckBox_Click(object sender, EventArgs e)
        {
            ChangeStatus(!vSroChecked);
            vSroCheckChange(sender, e);
        }
    }
}
