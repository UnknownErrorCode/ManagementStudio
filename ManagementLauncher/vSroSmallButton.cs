using System;
using System.Windows.Forms;

namespace ManagementLauncher
{
    public partial class vSroSmallButton : UserControl
    {
        public delegate void vSroClick();
        public event vSroClick vSroClickEvent;
        public vSroSmallButton()
        {
            InitializeComponent();
            this.buttonvSroSmall.Click += onClickvSroButton;
        }

        private void onClickvSroButton(object sender, EventArgs e)
        {
            if (vSroClickEvent!= null)
            {
                vSroClickEvent();
            }
        }

        public string vSroSmallButtonName { get => buttonvSroSmall.Text; set => buttonvSroSmall.Text = value; }
        public void RenameButton(string Name)
        {
            buttonvSroSmall.Text = Name;
        }

        private void OpenSettings_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[2];
        }

        private void OpenSettings_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[1];
        }

        private void OpenSettings_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[1];
        }

        private void OpenSettings_MouseLeave(object sender, EventArgs e)
        {
            OpenSettings_Leave(sender, new EventArgs());
        }

        private void OpenSettings_Leave(object sender, EventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[0];
        }
    }
}
