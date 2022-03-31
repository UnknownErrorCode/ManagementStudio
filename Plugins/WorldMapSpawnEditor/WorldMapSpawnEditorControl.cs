using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {
        #region Fields

        private const PluginData PLUGINDATA = PluginData.WorldMapSpawnEditor;
        private const string STRING_DLL = "WorldMapSpawnEditor.dll";

        /// <summary>
        /// Map Panel to view the entired Open WorldMap without Dungeons.
        /// </summary>
        private MapGraphics.GraphicsPanel MapPanel;

        #endregion Fields

        #region Constructors

        public WorldMapSpawnEditorControl()
        {
            InitializeComponent();
            InitializePerformance(this);
            ClientDataStorage.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            var pack = ClientDataStorage.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);
            ClientDataStorage.ClientCore.Send(pack);
        }

        #endregion Constructors

        #region Methods

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

        private void OnContinentClick(object sender, EventArgs e)
        {
            var continent = ((ToolStripMenuItem)sender).Text;
            if (!MapPanel.TryViewContinent(continent))
                ClientDataStorage.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Failed to set view for continent: [{continent}]");
        }

        private PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            MapPanel = new MapGraphics.GraphicsPanel();

            Invoke(new Action(() =>
            {
                continentToolStripMenuItem.DropDownItems.Clear();

                foreach (var item in MapPanel.Continents)
                {
                    continentToolStripMenuItem.DropDownItems.Add(item);
                    continentToolStripMenuItem.DropDownItems[continentToolStripMenuItem.DropDownItems.Count - 1].Click += OnContinentClick;
                }
                vSroSmallButtonLoad.Enabled = true;
            }));

            return PacketHandlerResult.Block;
        }

        private void showAssignedRegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowRegionsDb = ((ToolStripMenuItem)sender).Checked;
            assignedToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide DB Regions" : "Show DB Regions";
        }

        private void showCommonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowMonster = ((ToolStripMenuItem)sender).Checked;
            commonToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide general monster" : "Show general monster";
        }

        private void showDBRegionsWithoutDdjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowRegionDBnoDDJ = ((ToolStripMenuItem)sender).Checked;
            dBRegionsWithoutDdjToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide DB regions without ddj" : "Show DB regions without ddj";
        }

        private void showNestNGenRadiusToolStripMenuItem_Click(object sender, EventArgs e) => MapPanel.ShowNestGenRadius = ((ToolStripMenuItem)sender).Checked;

        private void showNestNRadiusToolStripMenuItem_Click(object sender, EventArgs e) => MapPanel.ShowNestRadius = ((ToolStripMenuItem)sender).Checked;

        private void showNPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowNpc = ((ToolStripMenuItem)sender).Checked;
            nPCToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide NPCs" : "Show NPCs";
        }

        private void showPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowPlayer = ((ToolStripMenuItem)sender).Checked;
            playerToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide players" : "Show players";
        }

        private void showSpawnEditorOnClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowEditorOnClick = ((ToolStripMenuItem)sender).Checked;
        }

        private void showSpawnInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowToolTip = ((ToolStripMenuItem)sender).Checked;
        }

        private void showTeleportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowTeleport = ((ToolStripMenuItem)sender).Checked;
            teleportToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide teleports" : "Show teleports";
        }

        private void showUnassignedRegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowRegionsUnassigned = ((ToolStripMenuItem)sender).Checked;
            unassignedToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide Regions with ddj but no DB" : "Show Regions with ddj but no DB";
        }

        private void showUniqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowUniqueMonster = ((ToolStripMenuItem)sender).Checked;
            uniqueToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide uniques" : "Show uniques";
        }

        private void vSroSmallButtonLoad_vSroClickEvent()
        {
            splitContainer2dViewer.Panel1.Controls.Clear();
            if (MapPanel == null)
            {
                return;
            }
            splitContainer2dViewer.Panel1.Controls.Add(MapPanel);
            vSroSmallButtonLoad.Enabled = false;
            toolStripDropDownButton1.Enabled = true;
        }

        #endregion Methods
    }
}