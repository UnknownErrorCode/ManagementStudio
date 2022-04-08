using System;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroButton : UserControl
    {
        #region Constructors

        public vSroButton()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Delegates

        //  public static event vSroClicker vSroClick;
        public delegate void vSroClicker(object sender, EventArgs e);

        #endregion Delegates

        #region Properties

        //  [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        //  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Text
        {
            get => RealButton.Text;
            set => RealButton.Text = value;
        }

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}