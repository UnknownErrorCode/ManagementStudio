using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor
{
    abstract class WorldMap2dPanel : Panel
    {
        internal ContextMenuStrip RegionContextMenu = new ContextMenuStrip();

        internal ToolTip SpawnToolTip = new ToolTip() { InitialDelay = 100, AutoPopDelay = 0, ReshowDelay = 100 };
        internal WorldMap2dPanel()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
            this.AutoScroll = true;
            RegionContextMenu.Items.Add("Create Spawn");
            RegionContextMenu.Items.Add("Save Coordinate");

            RegionContextMenu.Items[0].Click += CreateSpawnClickContext;
            RegionContextMenu.Items[1].Click += SaveCoordinateClickContext;

            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        public abstract void SaveCoordinateClickContext(object sender, EventArgs e);

        public abstract void CreateSpawnClickContext(object sender, EventArgs e);

        public static IEnumerable<T> GetControlsOfType<T>(Control root)
            where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            foreach (Control c in root.Controls)
                foreach (var i in GetControlsOfType<T>(c))
                    yield return i;
        }
    }
}
