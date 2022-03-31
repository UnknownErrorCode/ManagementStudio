using System;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroCloseButton : UserControl
    {
        #region Constructors

        public vSroCloseButton()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void vSroCloseButton_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void vSroCloseButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = imageListCloseButton.Images[2];
        }

        private void vSroCloseButton_MouseEnter(object sender, EventArgs e)
        {
            BackgroundImage = imageListCloseButton.Images[1];
        }

        private void vSroCloseButton_MouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = imageListCloseButton.Images[0];
        }

        #endregion Methods
    }
}