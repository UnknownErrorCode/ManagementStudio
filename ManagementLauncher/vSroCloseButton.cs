using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementLauncher
{
    public partial class vSroCloseButton : UserControl
    {
        public vSroCloseButton()
        {
            InitializeComponent();
        }

        private void vSroCloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = imageListCloseButton.Images[1];
        }

        private void vSroCloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = imageListCloseButton.Images[0];
        }

        private void vSroCloseButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = imageListCloseButton.Images[2];
        }

        private void vSroCloseButton_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
    }
}
