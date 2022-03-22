using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroInputBox : UserControl
    {
        public string ValueText { get => textBox1.Text; set => textBox1.Text = value; }
        public string TitleText { get => label1.Text; set => label1.Text = value; }
        public bool vSroUseSystemPasswordChar { get => textBox1.UseSystemPasswordChar; set => textBox1.UseSystemPasswordChar = value; }
        public vSroInputBox()
            =>InitializeComponent();

        public void ShowPWCharakter(bool hide)
            => textBox1.UseSystemPasswordChar = hide;
        
    }
}
