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
    public partial class vSroButton : UserControl
    {
      //  public static event vSroClicker vSroClick;
        public delegate void vSroClicker(object sender, EventArgs e);

      //  [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
      //  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return RealButton.Text; }
            set { RealButton.Text = value; }
        }
        public vSroButton()
        {
            InitializeComponent();
        }
      
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Image = imageListButton.Images[1];
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).Image = imageListButton.Images[0];
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ((Button)sender).Image = imageListButton.Images[2];
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ((Button)sender).Image = imageListButton.Images[1];
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            ((Button)sender).Image = imageListButton.Images[0];
        }
    }
}
