using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor
{
    class WorldMap2dPanel : Panel
    {

        internal WorldMap2dPanel() : base() 
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
            this.AutoScroll = true; 
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        public void ScarleRegions(float delta)
        {
            var factor = new System.Drawing.SizeF(1 + (delta / 10f), 1 + (delta / 10f));
            //this.ScaleControl(factor, BoundsSpecified.All);

        }
    }
}
