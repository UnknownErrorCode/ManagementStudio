using System;
using System.Windows.Forms;

namespace ManagementFramework.BasicControls
{
    public partial class vSroCheckBox : UserControl
    {
        #region Fields

        public bool vSroChecked;

        #endregion Fields

        #region Constructors

        public vSroCheckBox()
        {
            InitializeComponent();
            ChangeStatus(vSroChecked);
        }

        #endregion Constructors

        #region Delegates

        public delegate void vSroCheckChanger(object sender, EventArgs e);

        #endregion Delegates

        #region Events

        public event vSroCheckChanger vSroCheckChange;

        #endregion Events

        #region Properties

        public bool vSroCheck { get => vSroChecked; set => vSroChecked = value; }

        public string vSroCheckBoxName { get => labelCheckBox.Text; set => labelCheckBox.Text = value; }

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}