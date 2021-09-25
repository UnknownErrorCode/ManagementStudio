using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.IO;
using System.Reflection;
using ClientDataStorage.Client.Files;
using System;
using ClientDataStorage.Client;
using WorldMapSpawnEditor.MapGame;
using System.Data;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {
        int LastZoomFactor = 0;

        _2dMapViewer.Continent Cont;
        internal static ServerData StaticServerData { get; set; }

        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            InitializeContinentListView();
        }


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



        private void OnIndexChanged(object sender, EventArgs e)
        {
            this.splitContainer2dViewer.Panel1.Controls.Clear();
            if (listView1.SelectedItems.Count > 0)
            {
                Cont = new _2dMapViewer.Continent(listView1.SelectedItems[0].Text);
                Cont.DrawRegions();
                this.splitContainer2dViewer.Panel1.Controls.Add(Cont);
            }
        }


        private void ZoomChange(object sender, EventArgs e)
        {
            var delta = trackBarZoom.Value - LastZoomFactor;
            LastZoomFactor = trackBarZoom.Value;
            Cont.OnZoom(delta);
        }

        private void GetMinXMaxY(out int minX, out int maxY)
        {
            minX = 256; maxY = 0;
            for (int i = 0; i < Cont.Regions.Length; i++)
            {
                if (Cont.Regions[i].X < minX && Cont.Regions[i].X > 0)
                    minX = Cont.Regions[i].X;

                if (Cont.Regions[i].Y > maxY)
                    maxY = Cont.Regions[i].Y;
            }
        }

        
    }
}
