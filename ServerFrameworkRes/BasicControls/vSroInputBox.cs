using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroInputBox : UserControl
    {
        #region Public Constructors

        public vSroInputBox()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public string TitleText { get => label1.Text; set => label1.Text = value; }
        public string ValueText { get => textBox1.Text; set => textBox1.Text = value; }
        public bool vSroUseSystemPasswordChar { get => textBox1.UseSystemPasswordChar; set => textBox1.UseSystemPasswordChar = value; }

        #endregion Public Properties

        #region Public Methods

        public void ShowPWCharakter(bool hide)
        {
            textBox1.UseSystemPasswordChar = hide;
        }

        #endregion Public Methods
    }
}