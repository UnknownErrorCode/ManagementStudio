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
    public partial class vSroScrollBar : UserControl
    {
        bool ScrollButtonIsHold;
        Point LastScrollButtonPoint;
        public vSroScrollBar()
        {
            InitializeComponent();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ScrollButtonIsHold = true;
                LastScrollButtonPoint = new Point(-e.X, -e.Y);
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ScrollButtonIsHold = false;
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
    }
}
