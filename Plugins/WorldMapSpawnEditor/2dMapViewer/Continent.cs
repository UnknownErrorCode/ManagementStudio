using ClientDataStorage.Database;
using System;
using System.Data;
using System.Linq;

namespace WorldMapSpawnEditor._2dMapViewer
{
    internal class Continent : WorldMap2dPanel
    {
        string ContinentName { get; set; }

        internal Region[] Regions { get; set; }

        

        internal Continent(string name)
        {
            this.DoubleBuffered = true;

            ContinentName = name;
            var allRegions = SRO_VT_SHARD.dbo.Tables["_RefRegion"].Rows.OfType<DataRow>().Where(row => row.Field<string>("ContinentName") == this.ContinentName).ToArray();
            Regions = new Region[allRegions.Length];

            RegionContextMenu.Items[0].Click += CreateSpawnClickContext;
            RegionContextMenu.Items[1].Click += SaveCoordinateClickContext;


            for (int i = 0; i < Regions.Length; i++)
                Regions[i] = new Region(allRegions[i].Field<short>("wRegionID")) {  };

            GetMinXMaxY(out int minX, out int maxY);
           
            for (int i = 0; i < Regions.Length; i++)
            {
                Regions[i].MouseClick += Region_MouseClick;
                Regions[i].Location = new System.Drawing.Point((Regions[i].X * 256) - (256 * minX), (((Regions[i].Y * 256) - 65536) * -1) - (((256 * maxY) - 65536) * -1));
            }
        }

        private void Region_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var CurrentPositionX = (1920f / ((Region)sender).Width) * e.X;
                var CurrentPositionY = ((1920f / ((Region)sender).Width) * e.Y  - 1920f) * -1;
                RegionContextMenu.Show((System.Windows.Forms.Control)sender, e.Location, System.Windows.Forms.ToolStripDropDownDirection.BelowRight);
            }
           
        }

        private void SaveCoordinateClickContext(object sender, EventArgs e)
        {
        }

        private void CreateSpawnClickContext(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void DrawRegions()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new System.Action(() => Controls.AddRange(Regions)));
                return;
            }
            this.Controls.AddRange(Regions);
        }

        internal void OnZoom(int delta)
        {
            GetMinXMaxY(out int minX, out int maxY);

            foreach (Region item in GetControlsOfType<Region>(this))
            {
                item.Size = new System.Drawing.Size(item.Size.Width - delta * 8, item.Size.Height - delta * 8);
                item.Location = new System.Drawing.Point((((_2dMapViewer.Region)item).X * item.Size.Width) - (item.Size.Width * minX), (((((_2dMapViewer.Region)item).Y * item.Size.Width) - item.Size.Width ^ 2) * -1) - (((item.Size.Width * maxY) - item.Size.Width ^ 2) * -1));
            }
        }
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
