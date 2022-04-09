using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace WorldMapSpawnEditor
{
    public interface iin
    {
        string STRING_DLL { get; }
        PluginData PLUGINDATA { get; }
        Packet RequestData { get; }

        PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2);
    }

    public partial class WorldMapSpawnEditorControl : UserControl, iin
    {
        /// <summary>
        /// Loading form to let user know about loading.
        /// </summary>
        private static LoadingForm Loading = new LoadingForm();

        /// <summary>
        /// Map Panel to view the entired Open WorldMap without Dungeons.
        /// </summary>
        private MapGraphics.WorldMapPanel MapPanel;

        /// <summary>
        /// MapGuide panel to view the map guide.
        /// </summary>
        private MapGuide.MapGuideForm MapGuide;

        public WorldMapSpawnEditorControl()
        {
            InitializeComponent();
            InitializePerformance(this);
            STRING_DLL = "WorldMapSpawnEditor.dll";
            PLUGINDATA = PluginData.WorldMapSpawnEditor;
            PluginFramework.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            PluginFramework.ClientCore.Send(RequestData);
            Loading.Show();
        }

        public PluginData PLUGINDATA { get; }
        public string STRING_DLL { get; }
        public Packet RequestData => PluginFramework.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);

        /// <summary>
        /// Provides the client received required data.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            MapPanel = new MapGraphics.WorldMapPanel();

            Invoke(new Action(() =>
            {
                continentToolStripMenuItem.DropDownItems.Clear();

                foreach (var item in MapPanel.Continents)
                {
                    //Add continent to continent View
                    continentToolStripMenuItem.DropDownItems.Add(item);
                    continentToolStripMenuItem.DropDownItems[continentToolStripMenuItem.DropDownItems.Count - 1].Click += OnContinentClick;
                    // Add dungeons to dungeon view

                    // TODO: manage to view Dungeons and WorldMaps...
                }
                splitContainer2dViewer.Panel1.Controls.Clear();
                splitContainer2dViewer.Panel1.Controls.Add(MapPanel);
                toolStripDropDownButtonEditSpawn.Enabled = true;
                toolStripDropDownButtonView.Enabled = true;
                toolStripDropDownButtonReload.Enabled = true;
                Loading.Hide();
            }));
            return PacketHandlerResult.Block;
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

        private void OnContinentClick(object sender, EventArgs e)
        {
            var continent = ((ToolStripMenuItem)sender).Text;
            if (!MapPanel.TryViewContinent(continent))
                ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Failed to set view for continent: [{continent}]");
        }

        private void showAssignedRegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowRegionsDb = ((ToolStripMenuItem)sender).Checked;
            assignedToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide DB Regions" : "Show DB Regions";
        }

        private void showCommonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowMonster = ((ToolStripMenuItem)sender).Checked;
            commonToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide monster" : "Show monster";
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

        private void mapGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapGuide == null)
            {
                System.Threading.Tasks.Task.Run(() => PackFile.PackFileManager.ExtractRegionIcons(PluginFramework.Config.StaticConfig.ClientExtracted));
                MapGuide = new MapGuide.MapGuideForm();
            }

            MapGuide.Show();
        }

        private void meshBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPanel.ShowMeshBlocks = ((ToolStripMenuItem)sender).Checked;
            meshBlocksToolStripMenuItem.Text = ((ToolStripMenuItem)sender).Checked ? "Hide MeshBlocks" : "Show MeshBlocks";
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            splitContainer2dViewer.Panel1.Controls.Clear();

            toolStripDropDownButtonView.Enabled = false;
            toolStripDropDownButtonEditSpawn.Enabled = false;
            toolStripDropDownButtonReload.Enabled = false;
            PluginFramework.ClientCore.Send(RequestData);
        }

        private void dungeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}