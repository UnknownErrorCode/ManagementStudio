using System.Windows.Forms;

namespace ManagementLauncher
{
    public partial class vSroInputBox : UserControl
    {
        public string ValueText { get => textBox1.Text; set => textBox1.Text = value; }
        public string TitleText { get => label1.Text; set => label1.Text = value; }
        public bool vSroUseSystemPasswordChar { get => textBox1.UseSystemPasswordChar; set => textBox1.UseSystemPasswordChar = value; }
        public vSroInputBox()
        {
            InitializeComponent();
        }

        public void ShowPWCharakter(bool hide)
        {
            textBox1.UseSystemPasswordChar = hide;
        }
        public void ResetText()
        {
            ValueText = ("");
        }
        public void AppendText(string textBoxText)
        {
            ValueText = textBoxText;
        }

        public void AppendNameNAppendText(string Name, string Text)
        {
            ValueText = Text; TitleText = Name;
        }
    }
}
