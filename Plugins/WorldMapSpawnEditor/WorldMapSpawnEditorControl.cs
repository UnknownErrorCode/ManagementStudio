using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.Reflection;
using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {
        /// <summary>
        /// Map Panel to view the entired Open WorldMap without Dungeons.
        /// </summary>
        MapGraphics.GraphicsPanel MapPanel = new MapGraphics.GraphicsPanel();

        /// <summary>
        /// ServerData from Client.
        /// </summary>
        internal static ServerData StaticServerData { get; set; }


        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            InitializePerformance(this);
            splitContainer2dViewer.Panel1.Controls.Add(MapPanel);
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

        private void vSroCheckBox1_vSroCheckChange(object sender, EventArgs e)
        {
            MapPanel.HasToolTip = vSroCheckBox1.vSroCheck;
        }

        private void vSroCheckBox2_vSroCheckChange(object sender, EventArgs e)
        {
            MapPanel.OpenEditorOnClick = vSroCheckBox2.vSroCheck;
        }
    }
}
