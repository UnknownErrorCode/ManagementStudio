using ClientDataStorage.Database;
using System;
using System.Data;
using System.Linq;

namespace WorldMapSpawnEditor._2dMapViewer
{
    internal class Continent : WorldMap2dPanel
    {
        /// <summary>
        /// ContinentName from _RefRegion
        /// </summary>
        string ContinentName { get; set; }

        /// <summary>
        /// Array of Region that exists on the Continent.
        /// </summary>
        internal Region[] Regions { get; set; }

        /// <summary>
        /// Continent consists out of several Regions.
        /// </summary>
        /// <param name="name">Continent Name</param>
        internal Continent(string name)
        {
            ContinentName = name;
            InitializeComponents();
        }

        /// <summary>
        /// Initialize all Regions on the Continent
        /// </summary>
        private void InitializeComponents()
        {
            this.DoubleBuffered = true;

            var allRegions = SRO_VT_SHARD.dbo.Tables["_RefRegion"].Rows.OfType<DataRow>().Where(row => row.Field<string>("ContinentName") == this.ContinentName).ToArray();
            
            Regions = new Region[allRegions.Length];


            for (int i = 0; i < Regions.Length; i++)
                Regions[i] = new Region(allRegions[i].Field<short>("wRegionID")) { };

            GetMinXMaxY(out int minX, out int maxY);

            for (int i = 0; i < Regions.Length; i++)
            {
                Regions[i].MouseClick += Region_MouseClick;
                Regions[i].Location = new System.Drawing.Point((Regions[i].X * 256) - (256 * minX), (((Regions[i].Y * 256) - 65536) * -1) - (((256 * maxY) - 65536) * -1));
                foreach(var mob in Regions[i].Spawns.MonsterOnRegion )
                {
                    mob.MouseClick += Mob_Click;
                    SpawnToolTip.SetToolTip(mob, (mob.Spawn.ObjCommon.CodeName128));
                }
            }
            this.SuspendLayout();
            this.Controls.AddRange(Regions);
            this.ResumeLayout();
        }

        private void Mob_Click(object sender, EventArgs e)
        {
            using (WorldMapSpawnEditor._2dMapViewer.Forms.SpawnEditor editor = new Forms.SpawnEditor(((Monster)sender).Spawn))
            {
                editor.ShowDialog();
            }
        }

        /// <summary>
        /// Gets execute when the Region is clicked.
        /// </summary>
        /// <param name="sender">Region</param>
        /// <param name="e">MouseEventArgs</param>
        private void Region_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var CurrentPositionX = (1920f / ((Region)sender).Width) * e.X;
                var CurrentPositionY = ((1920f / ((Region)sender).Width) * e.Y  - 1920f) * -1;
                RegionContextMenu.Show((System.Windows.Forms.Control)sender, e.Location, System.Windows.Forms.ToolStripDropDownDirection.BelowRight);
            }
        }

        /// <summary>
        /// Saves coordinates into the Application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void SaveCoordinateClickContext(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Opens a Spawn Adder Form to create new spawns on the Region.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void CreateSpawnClickContext(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Resizes and locates the Regions on the Continent.
        /// </summary>
        /// <param name="delta"></param>
        internal void OnZoom(int delta)
        {
            GetMinXMaxY(out int minX, out int maxY);
            this.SuspendLayout();
            foreach (Region item in GetControlsOfType<Region>(this))
            {
                item.Size = new System.Drawing.Size(item.Size.Width - delta * 8, item.Size.Height - delta * 8);
                item.Location = new System.Drawing.Point((((_2dMapViewer.Region)item).X * item.Size.Width) - (item.Size.Width * minX), (((((_2dMapViewer.Region)item).Y * item.Size.Width) - item.Size.Width ^ 2) * -1) - (((item.Size.Width * maxY) - item.Size.Width ^ 2) * -1));
            }
            this.ResumeLayout();
        }

        /// <summary>
        /// Returns the Minimin X value and Maximum Y of the Continent to trim empty space of the Panel.
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxY"></param>
        private void GetMinXMaxY(out int minX, out int maxY)
        {
            minX = 256; maxY = 0;
            for (int i = 0; i < Regions.Length; i++)
            {
                if (Regions[i].X < minX && Regions[i].X > 0)
                    minX = Regions[i].X;

                if (Regions[i].Y > maxY)
                    maxY = Regions[i].Y;
            }
        }
    }
}
