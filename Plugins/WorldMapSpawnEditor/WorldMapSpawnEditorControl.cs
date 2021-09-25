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
        WorldMap2dPanel map2DPanel = new WorldMap2dPanel();
        int LastZoomFactor = 0;

        _2dMapViewer.Continent Cont;
        internal static ServerData StaticServerData { get; set; }
       
        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            InitializeContinentListView();
            this.splitContainer2dViewer.Panel1.Controls.Add(map2DPanel);
            //InitializePerformance(this);

            
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
            map2DPanel.AutoSize = true;
            map2DPanel.AutoScroll = true;
            map2DPanel.Controls.Clear();
            if (listView1.SelectedItems.Count > 0)
            {
                 Cont = new _2dMapViewer.Continent(listView1.SelectedItems[0].Text);
                


                int minX = 256, maxY = 0;


                for (int i = 0; i < Cont.Regions.Length; i++)
                {
                    
                    if (Cont.Regions[i].X < minX && Cont.Regions[i].X >0)
                        minX = Cont.Regions[i].X;

                    if (Cont.Regions[i].Y > maxY)
                        maxY = Cont.Regions[i].Y;
                }

                for (int i2 = 0; i2 < Cont.Regions.Length; i2++)
                    Cont.Regions[i2].Location = new System.Drawing.Point((Cont.Regions[i2].X * 256) - (256 * minX), (((Cont.Regions[i2].Y * 256) - 65536 ) * -1 ) -(((256 * maxY) - 65536) * -1));

                map2DPanel.Controls.AddRange(Cont.Regions);
            }
        }

        private void ZoomChange(object sender, EventArgs e)
        {
            var delta =trackBarZoom.Value- LastZoomFactor;
            LastZoomFactor = trackBarZoom.Value;
            var factor = new System.Drawing.SizeF(1 + (delta / 10f), 1 + (delta / 10f));

            for (int i = 0; i < map2DPanel.Controls.Count; i++)
            {
                if (i == 3)
                {
                    var size = new System.Drawing.Size(map2DPanel.Controls[i].Size.Width + delta * 100, map2DPanel.Controls[i].Size.Height + delta * 100);
                    var location = new System.Drawing.Point(map2DPanel.Controls[i].Location.X == 0 ? map2DPanel.Controls[i].Location.X : map2DPanel.Controls[i].Location.X + delta * 100, map2DPanel.Controls[i].Location.Y == 0 ? map2DPanel.Controls[i].Location.Y : map2DPanel.Controls[i].Location.Y + delta * 100);

                
                }
                //map2DPanel.Controls[i].Size = new System.Drawing.Size(map2DPanel.Controls[i].Size.Width + delta*100, map2DPanel.Controls[i].Size.Height + delta * 100);

              //  map2DPanel.Controls[i].Location =new System.Drawing.Point(map2DPanel.Controls[i].Location.X <= 100 ? map2DPanel.Controls[i].Location.X : map2DPanel.Controls[i].Location.X - delta * 100, map2DPanel.Controls[i].Location.Y <= 100 ? map2DPanel.Controls[i].Location.Y : map2DPanel.Controls[i].Location.Y - delta * 100);
            }
            int minX = 256, maxY = 0;


            for (int i = 0; i < Cont.Regions.Length; i++)
            {

                if (Cont.Regions[i].X < minX && Cont.Regions[i].X > 0)
                    minX = Cont.Regions[i].X;

                if (Cont.Regions[i].Y > maxY)
                    maxY = Cont.Regions[i].Y;
            }
            foreach (Control item in map2DPanel.Controls)
            {
                
                
                item.Location = new System.Drawing.Point(item.Location.X ==0 ? item.Location.X : item.Location.X - delta * 100, item.Location.Y ==0 ? item.Location.Y : item.Location.Y - delta * 100);

                item.Size = new System.Drawing.Size(item.Size.Width + delta * 100, item.Size.Height + delta * 100);





                item.Location = new System.Drawing.Point((((_2dMapViewer.Region)item).X * item.Size.Width) - (item.Size.Width * minX), (((((_2dMapViewer.Region)item).Y * item.Size.Width) - item.Size.Width^2) * -1) - (((item.Size.Width * maxY) - item.Size.Width^2) * -1));

               // var size = new System.Drawing.Size(item.Size.Width + (delta * 100), item.Size.Height +( delta * 100));
                
                var location = new System.Drawing.Point(item.Location.X == 0 ? item.Location.X : item.Location.X - (delta * 100), item.Location.Y == 0 ? item.Location.Y : item.Location.Y - delta * 100);

            }
        }
    }
}
