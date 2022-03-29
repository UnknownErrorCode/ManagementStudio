using ServerFrameworkRes.Network.Security;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {
        private const string STRING_DLL = "WorldMapSpawnEditor.dll";

        /// <summary>
        /// Map Panel to view the entired Open WorldMap without Dungeons.
        /// </summary>
        private MapGraphics.GraphicsPanel MapPanel;

        private readonly TabPage Parent;

        public WorldMapSpawnEditorControl(TabPage parentPage)
        {
            Parent = parentPage;
            InitializeComponent();
            InitializePerformance(this);
            ClientDataStorage.ClientCore.AddEntry(PacketID.Server.PluginDataSent, OnDataReceive);
            ClientDataStorage.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL);
        }

        private async void EnableControl(Control control, int InSeconds)
        {
            await Task.Delay(InSeconds * 1000);
            control.Enabled = true;
        }

        /// <summary>
        /// Sets the panel to Doublebuffered = true;
        /// </summary>
        /// <param name="c"></param>
        private void InitializePerformance(Control c)
        {
            if (typeof(Panel) == c.GetType())
            {
                typeof(Panel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, c, new object[] { true });
            }
        }

        private PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            if (arg2.ReadAscii() != STRING_DLL)
            {
                return PacketHandlerResult.Block;
            }
            // Initialize SRO_VT_SHARD for ShopEditor
            ClientDataStorage.Database.SRO_VT_SHARD.InitializeWorldMapEditor();

            Parent.Invoke(new Action(() => Parent.Controls.Add(this)));
            return PacketHandlerResult.Block;
        }

        #region ToolStripMenuItem region

        private void assignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowDbRegions = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void commonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowMonster = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void nestNGenRadiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowNestGenRadius = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void nestNRadiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowNestRadius = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void nPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowNpc = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowPlayer = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void spawnEditorOnClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.OpenEditorOnClick = ((ToolStripMenuItem)sender).Checked;
        }

        private void spawnInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.HasToolTip = ((ToolStripMenuItem)sender).Checked;
        }

        private void teleportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowTeleport = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void unassignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowUnassignedRegions = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        private void uniqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowUniqueMonster = ((ToolStripMenuItem)sender).Checked;
            MapPanel.Invalidate();
        }

        #endregion ToolStripMenuItem region

        private void vSroSmallButtonLoad_vSroClickEvent()
        {
            splitContainer2dViewer.Panel1.Controls.Clear();

            MapPanel = new MapGraphics.GraphicsPanel();
            splitContainer2dViewer.Panel1.Controls.Add(MapPanel);

            vSroSmallButtonLoad.Enabled = false;
            EnableControl(vSroSmallButtonLoad, 5);

            // using (WorldMapSpawnEditor.MapGuide.MapGuideForm guide = new MapGuide.MapGuideForm())
            // {
            //     guide.ShowDialog();
            // }
        }
    }
}