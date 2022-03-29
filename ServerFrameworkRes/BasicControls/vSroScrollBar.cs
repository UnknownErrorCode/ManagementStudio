using System.Drawing;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroScrollBar : UserControl
    {
        #region Private Fields

        private Point LastScrollButtonPoint;
        private bool ScrollButtonIsHold;

        #endregion Private Fields

        #region Public Constructors

        public vSroScrollBar()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ScrollButtonIsHold = true;
                LastScrollButtonPoint = new Point(-e.X, -e.Y);
            }
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (ScrollButtonIsHold)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(LastScrollButtonPoint.X, LastScrollButtonPoint.Y);

                if (Location != mousePos)
                {
                    Location = mousePos;
                }
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ScrollButtonIsHold = false;
            }
        }

        #endregion Private Methods
    }
}