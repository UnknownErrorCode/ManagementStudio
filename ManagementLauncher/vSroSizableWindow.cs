using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementLauncher
{
    public partial class vSroSizableWindow : UserControl
    {
        private bool onMove;

        public Point LastMovePoint { get; private set; }

        public string Title
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public vSroSizableWindow()
        {
            InitializeComponent();
        }

        private void vSroSizableWindow_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vSroSizableWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > 0 && e.X < this.Size.Width  && e.Y < 27)
            {
                if (e.Button == MouseButtons.Left)
                {
                    onMove = true;
                    LastMovePoint = new Point(-e.X, -e.Y);
                }
            }
        }

        private void vSroSizableWindow_MouseUp(object sender, MouseEventArgs e)
        {
            onMove = false;
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
    }
}
