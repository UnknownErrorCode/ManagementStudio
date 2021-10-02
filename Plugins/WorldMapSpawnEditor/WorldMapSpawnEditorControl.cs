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
            tabPage2.Controls.Add(new MapGraphics.GraphicsPanel());
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
        /// Gets a ListView of all existing ContinentNames in _RefRegion.
        /// </summary>
        private void InitializeContinentListView()
        {
            var allRegions = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefRegion"].Rows;

            List<string> list = new List<string>();
            foreach (DataRow item in allRegions)
            {
                if (!list.Contains(item.Field<string>("ContinentName")))
                    list.Add(item.Field<string>("ContinentName"));
            }

            foreach (var contin in list)
                if (!Continents.ContainsKey(contin))
                    Task.Run(() => GenerateContinent(contin));
        }


        private void GenerateContinent(string Continentname)
        {
            Continents.Add(Continentname, new Continent(Continentname));
            listView1.Invoke((MethodInvoker)delegate { listView1.Items.Add(Continentname); });

        }

        /// <summary>
        /// Gets called when the Continent View changes.
        /// </summary>
        /// <param name="continentName"></param>
        /// <param name="continent"></param>
        private void ChangeContinent(string continentName)
        {
            DisplayedContinent = Continents[listView1.SelectedItems[0].Text];
        }

        /// <summary>
        /// Runs when a new Continent gets clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIndexChanged(object sender, EventArgs e)
        {
            this.splitContainer2dViewer.Panel1.Controls.Clear();

            if (listView1.SelectedItems.Count > 0)
            {
                this.splitContainer2dViewer.Panel1.Controls.Add(Continents[listView1.SelectedItems[0].Text]);

                trackBarZoom.Value = Continents[listView1.SelectedItems[0].Text].LastZoomFactor;
            }
            GC.Collect();
        }

        /// <summary>
        /// Calculates the zoom factor for the Continent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomChange(object sender, EventArgs e)
        {
            this.SuspendLayout();
            Continents[listView1.SelectedItems[0].Text].AutoScrollPosition = new System.Drawing.Point(0, 0);
            Continents[listView1.SelectedItems[0].Text].OnZoom(trackBarZoom.Value);
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

        #endregion

      

    }
}
