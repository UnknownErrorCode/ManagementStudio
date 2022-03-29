using System;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroCheckBox : UserControl
    {
        #region Public Fields

        public bool vSroChecked;

        #endregion Public Fields

        #region Public Constructors

        public vSroCheckBox()
        {
            InitializeComponent();
            ChangeStatus(vSroChecked);
        }

        #endregion Public Constructors

        #region Public Delegates

        public delegate void vSroCheckChanger(object sender, EventArgs e);

        #endregion Public Delegates

        #region Public Events

        public event vSroCheckChanger vSroCheckChange;

        #endregion Public Events

        #region Public Properties

        public bool vSroCheck { get => vSroChecked; set => vSroChecked = value; }

        public string vSroCheckBoxName { get => labelCheckBox.Text; set => labelCheckBox.Text = value; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Change the CheckStatus from vSroCheckBox to true or false
        /// </summary>
        /// <param name="check"></param>
        public void ChangeStatus(bool check)
        {
            vSroChecked = check;
            buttonCheckBox.Image = vSroChecked ? imageListCheckBox.Images[1] : imageListCheckBox.Images[0];
        }

        #endregion Public Methods

        #region Private Methods

        private void buttonCheckBox_Click(object sender, EventArgs e)
        {
            ChangeStatus(!vSroChecked);
            vSroCheckChange(sender, e);
        }

        #endregion Private Methods
    }
}