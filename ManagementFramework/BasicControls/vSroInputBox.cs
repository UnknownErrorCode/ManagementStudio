using System.Windows.Forms;

namespace ManagementFramework.BasicControls
{
    public partial class vSroInputBox : UserControl
    {
        #region Constructors

        public vSroInputBox()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public string TitleText { get => label1.Text; set => label1.Text = value; }
        public string ValueText { get => textBox1.Text; set => textBox1.Text = value; }
        public bool vSroUseSystemPasswordChar { get => textBox1.UseSystemPasswordChar; set => textBox1.UseSystemPasswordChar = value; }

        #endregion Properties

        #region Methods

        public void ShowPWCharakter(bool hide)
        {
            textBox1.UseSystemPasswordChar = hide;
        }

        #endregion Methods
    }
}