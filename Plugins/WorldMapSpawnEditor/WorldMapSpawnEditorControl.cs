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
        MapGraphics.GraphicsPanel MapPanel ;

        /// <summary>
        /// ServerData from Client.
        /// </summary>
        internal static ServerData StaticServerData { get; set; }


        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            InitializePerformance(this);

            Packet tableRequestPacket = new Packet(0x0999, false, true);
            tableRequestPacket.WriteByte(6);
            tableRequestPacket.WriteAscii("_RefRegion");
            tableRequestPacket.WriteAscii("_RefObjChar");
            tableRequestPacket.WriteAscii("_RefObjCommon");
            tableRequestPacket.WriteAscii("Tab_RefTactics");
            tableRequestPacket.WriteAscii("Tab_RefHive");
            tableRequestPacket.WriteAscii("Tab_RefNest");


            StaticServerData = data;
            StaticServerData.m_security.Send(tableRequestPacket);


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
            MapPanel.HasToolTip = vSroCheckBoxShowToolTip.vSroCheck;
        }

        private void vSroCheckBox2_vSroCheckChange(object sender, EventArgs e)
        {
            MapPanel.OpenEditorOnClick = vSroCheckBoxOpenSpawnEditor.vSroCheck;
        }

        private void vSroCheckBoxShowMob_vSroCheckChange(object sender, EventArgs e)
            => MapPanel.ShowMonster = vSroCheckBoxShowMob.vSroCheck;

        private void vSroCheckBoxShowuMob_vSroCheckChange(object sender, EventArgs e)
            => MapPanel.ShowUniqueMonster = vSroCheckBoxShowuMob.vSroCheck;

        private void vSroCheckBoxShowNpc_vSroCheckChange(object sender, EventArgs e)
            => MapPanel.ShowNpc = vSroCheckBoxShowNpc.vSroCheck;

        private void vSroCheckBoxReg_vSroCheckChange(object sender, EventArgs e)
        {
            MapPanel.ShowDbRegions = vSroCheckBoxReg.vSroCheck;
            MapPanel.Invalidate();
        }

        private void vSroCheckBoxUnAsReg_vSroCheckChange(object sender, EventArgs e)
        {
            MapPanel.ShowUnassignedRegions = vSroCheckBoxUnAsReg.vSroCheck;
            MapPanel.Invalidate();
        }

        private void vSroSmallButtonLoad_vSroClickEvent()
        {
            ClientDataStorage.Database.SRO_VT_SHARD.InitializeWorldMapRess();

            MapPanel = new MapGraphics.GraphicsPanel();
            splitContainer2dViewer.Panel1.Controls.Add(MapPanel);
        }
    }
}
