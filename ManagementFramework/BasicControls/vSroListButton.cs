using System;
using System.Drawing;
using System.Windows.Forms;

namespace ManagementFramework.BasicControls
{
    public partial class vSroListButton : UserControl
    {
        #region Constructors

        public vSroListButton(string buttonText)
        {
            InitializeComponent();
            ButtonName = buttonText.Length > 0 ? buttonText : "EmptyName";
            labelButtonName.Text = ButtonName;
        }

        public vSroListButton()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public string ButtonName { get; set; }

        #endregion Properties

        #region Methods

        public static void OnButtonClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("Clicked !");
        }

        public void RenameButton(string buttonText)
        {
            ButtonName = buttonText.Length > 0 ? buttonText : "EmptyName";
            labelButtonName.Text = ButtonName;
        }

        private void labelEnter(object sender, EventArgs e)
        {
            if (((Label)sender).ForeColor != Color.Red)
            {
                ((Label)sender).ForeColor = Color.Orange;
            }
        }

        private void labelleave(object sender, EventArgs e)
        {
            if (((Label)sender).ForeColor != Color.Red)
            {
                ((Label)sender).ForeColor = Color.White;
            }
        }

        private void vSroListButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = imageListSingleButton.Images[1];
        }

        private void vSroListButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundImage = imageListSingleButton.Images[0];
            labelButtonName.ForeColor = Color.Red;
        }

        #endregion Methods
    }
}