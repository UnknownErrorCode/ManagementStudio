using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.Reflection;
using System;
using System.Data;
using System.Collections.Generic;
using WorldMapSpawnEditor._2dMapViewer;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {

        /// <summary>
        /// Get or set the latest zoom value. 
        /// </summary>
        int LastZoomFactor { get; set; }

        /// <summary>
        /// ServerData from Client.
        /// </summary>
        internal static ServerData StaticServerData { get; set; }

        /// <summary>
        /// Pools alrady load Continents inside the Dictionary to prevent load time.
        /// </summary>
        Dictionary<string, _2dMapViewer.Continent> Continents = new Dictionary<string, _2dMapViewer.Continent>();

        /// <summary>
        /// Displayed Continent that is shown to the user.
        /// </summary>
        _2dMapViewer.Continent DisplayedContinent;


        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            InitializeContinentListView();
            InitializePerformance(this);
        }

        /// <summary>
        /// Gets a ListView of all existing ContinentNames in _RefRegion.
        /// </summary>
        private void InitializeContinentListView()
        {
            var Continents = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefRegion"].Rows;

            foreach (DataRow item in Continents)
            {
                if (!listView1.Items.ContainsKey(item.Field<string>("ContinentName")))
                    listView1.Items.Add(new ListViewItem(item.Field<string>("ContinentName")) { Name = item.Field<string>("ContinentName") });
            }
        }

        /// <summary>
        /// Gets called when the Continent View changes.
        /// </summary>
        /// <param name="continentName"></param>
        /// <param name="continent"></param>
        private void ChangeContinent(string continentName, out Continent continent)
        {
            if (!Continents.ContainsKey(continentName))
            {
                continent = new Continent(continentName);
                Continents.Add(continentName, continent);
            }
            else
                continent = Continents[listView1.SelectedItems[0].Text];
        }

        /// <summary>
        /// Sets the panel to Doublebuffered = true; 
        /// </summary>
        /// <param name="c"></param>
        private void InitializePerformance(Control c)
        {
            if (typeof(Panel) == c.GetType())
                typeof(Panel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, c, new object[] { true });
        }

        /// <summary>
        /// Runs when a new Continent gets clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIndexChanged(object sender, EventArgs e)
        {
            this.splitContainer2dViewer.Panel1.Controls.Clear();
            LastZoomFactor = 0;

            if (listView1.SelectedItems.Count > 0)
            {
                ChangeContinent(listView1.SelectedItems[0].Text, out DisplayedContinent);
                this.splitContainer2dViewer.Panel1.Controls.Add(DisplayedContinent);
            }
        }

        /// <summary>
        /// Calculates the zoom factor for the Continent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomChange(object sender, EventArgs e)
        {
            DisplayedContinent.Visible = false;
            this.SuspendLayout();
            DisplayedContinent.AutoScrollPosition = new System.Drawing.Point(0, 0);
            DisplayedContinent.OnZoom(trackBarZoom.Value - LastZoomFactor);
            LastZoomFactor = trackBarZoom.Value;
            DisplayedContinent.Visible = true;
            this.ResumeLayout();
        }

        /// <summary>
        /// Returns the minimum of x Coortinate and Maximum of Y Coordinate to know how to trim empty space and reset the view to 0,0 .
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxY"></param>
        private void GetMinXMaxY(out int minX, out int maxY)
        {
            minX = 256; maxY = 0;
            for (int i = 0; i < DisplayedContinent.Regions.Length; i++)
            {
                if (DisplayedContinent.Regions[i].X < minX && DisplayedContinent.Regions[i].X > 0)
                    minX = DisplayedContinent.Regions[i].X;

                if (DisplayedContinent.Regions[i].Y > maxY)
                    maxY = DisplayedContinent.Regions[i].Y;
            }
        }
    }
}
