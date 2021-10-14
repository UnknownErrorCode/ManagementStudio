using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    class MapGuidePanel : Panel
    {

        private Point DrawStartPoint;

        private Point LastMousePosition;

        internal MapGuidePanel()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(652, 424);

            this.Paint += MapGuidePanel_Paint;
            this.MouseUp += MapGuidePanel_MouseUp;
            this.MouseDown += MapGuidePanel_MouseDown;
        }

        private void MapGuidePanel_MouseUp(object sender, MouseEventArgs e) 
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                DrawStartPoint.X = DrawStartPoint.X + (e.X - LastMousePosition.X);
                DrawStartPoint.Y = DrawStartPoint.Y + (e.Y - LastMousePosition.Y);
                this.Invalidate();
            }
        }

        private void MapGuidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
                this.LastMousePosition = e.Location;
        }

        private void MapGuidePanel_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
