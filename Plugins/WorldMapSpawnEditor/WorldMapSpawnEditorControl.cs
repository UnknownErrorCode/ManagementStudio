using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.Reflection;
using System;
using System.Data;
using System.Collections.Generic;
using WorldMapSpawnEditor._2dMapViewer;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {
        int SpawnCount { get => toolStripProgressBarLoadSpawns.Maximum; set => toolStripProgressBarLoadSpawns.Maximum = value; }
        internal  int SpawnCounter { get => toolStripProgressBarLoadSpawns.Value; set => toolStripProgressBarLoadSpawns.Value = value; }

        MapGraphics.GraphicsPanel MapPanel = new MapGraphics.GraphicsPanel();

        /// <summary>
        /// ServerData from Client.
        /// </summary>
        internal static ServerData StaticServerData { get; set; }

        #region 2D Map Viewer



        /// <summary>
        /// Pools alrady load Continents inside the Dictionary to prevent load time.
        /// </summary>
        Dictionary<string, Continent> Continents = new Dictionary<string, Continent>();

        /// <summary>
        /// Displayed Continent that is shown to the user.
        /// </summary>
        _2dMapViewer.Continent DisplayedContinent;

        #endregion

        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            // Task.Run(() => InitializeContinentListView());
            InitializePerformance(this);
            splitContainer2dViewer.Panel1.Controls.Add(MapPanel);
            StatusThread();
        }

        
        private async Task StatusThread()
        {
            while (MapPanel.MaxSpawnCount == 0)
                await Task.Delay(100);

            SpawnCount = MapPanel.MaxSpawnCount;

            while (!MapPanel.Initialized)
            {
                SpawnCounter = MapPanel.AllMonsters.Count + MapPanel.AllUniqueMonsters.Count + MapPanel.AllNpcs.Count;
                toolStripStatusLabelSpawnsLoad.Text = $"{SpawnCounter}/{SpawnCount} Spawns";
                await Task.Delay(100);
            }
            SpawnCounter = SpawnCount;
            toolStripStatusLabelSpawnsLoad.Text = $"{SpawnCounter}/{SpawnCount} Spawns";
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


        #region 2D Continent Viewer

        
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

        #endregion

      

    }
}
