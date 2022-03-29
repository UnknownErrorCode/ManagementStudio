using System;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroSmallButton : UserControl
    {
        #region Public Constructors

        public vSroSmallButton()
        {
            InitializeComponent();
            buttonvSroSmall.Click += onClickvSroButton;
        }

        #endregion Public Constructors

        #region Public Delegates

        public delegate void vSroClick();

        #endregion Public Delegates

        #region Public Events

        public event vSroClick vSroClickEvent;

        #endregion Public Events

        #region Public Properties

        public string vSroSmallButtonName { get => buttonvSroSmall.Text; set => buttonvSroSmall.Text = value; }

        #endregion Public Properties

        #region Public Methods

        public void RenameButton(string Name)
        {
            buttonvSroSmall.Text = Name;
        }

        #endregion Public Methods

        #region Private Methods

        private void onClickvSroButton(object sender, EventArgs e)
        {
            if (vSroClickEvent != null)
            {
                vSroClickEvent();
            }
        }

        private void OpenSettings_Leave(object sender, EventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[0];
        }

        private void OpenSettings_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[2];
        }

        private void OpenSettings_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[1];
        }

        private void OpenSettings_MouseLeave(object sender, EventArgs e)
        {
            OpenSettings_Leave(sender, new EventArgs());
        }

        private void OpenSettings_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = ButtonImageList.Images[1];
        }

        #endregion Private Methods
    }
}