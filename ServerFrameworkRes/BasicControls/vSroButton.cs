using System;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroButton : UserControl
    {
        #region Public Constructors

        public vSroButton()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Delegates

        //  public static event vSroClicker vSroClick;
        public delegate void vSroClicker(object sender, EventArgs e);

        #endregion Public Delegates

        #region Public Properties

        //  [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        //  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => RealButton.Text;
            set => RealButton.Text = value;
        }

        #endregion Public Properties

        #region Private Methods

        private void button1_Leave(object sender, EventArgs e)
        {
            ((Button)sender).Image = imageListButton.Images[0];
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Button)sender).Image = imageListButton.Images[2];
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Image = imageListButton.Images[1];
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).Image = imageListButton.Images[0];
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Button)sender).Image = imageListButton.Images[1];
            }
        }

        #endregion Private Methods
    }
}