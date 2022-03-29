using System.Drawing;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroSizableWindow : UserControl
    {
        #region Private Fields

        private bool onMove;

        #endregion Private Fields

        #region Public Constructors

        public vSroSizableWindow()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public Point LastMovePoint { get; private set; }

        public string Title
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        #endregion Public Properties

        #region Private Methods

        private void vSroSizableWindow_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void vSroSizableWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > 0 && e.X < Size.Width && e.Y < 27)
            {
                if (e.Button == MouseButtons.Left)
                {
                    onMove = true;
                    LastMovePoint = new Point(-e.X, -e.Y);
                }
            }
        }

        private void vSroSizableWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (onMove)
            {
                Point mousePoint = new Point(e.X, e.Y);
                Point mousePos = Control.MousePosition;
                mousePos.Offset(LastMovePoint.X, LastMovePoint.Y);

                if (ParentForm.Location != mousePos)
                {
                    ParentForm.Location = mousePos;
                }
            }
        }

        private void vSroSizableWindow_MouseUp(object sender, MouseEventArgs e)
        {
            onMove = false;
        }

        #endregion Private Methods
    }
}