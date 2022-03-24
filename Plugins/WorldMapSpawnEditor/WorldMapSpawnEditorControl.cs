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
        MapGraphics.GraphicsPanel MapPanel;

        /// <summary>
        /// ServerData from Client.
        /// </summary>
        internal static ServerData StaticServerData { get; set; }


        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            InitializePerformance(this);

            StaticServerData = data;
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
        #region Checkbox region
        private void vSroCheckBox1_vSroCheckChange(object sender, EventArgs e)
            => MapPanel.HasToolTip = vSroCheckBoxShowToolTip.vSroCheck;

        private void vSroCheckBox2_vSroCheckChange(object sender, EventArgs e)
            => MapPanel.OpenEditorOnClick = vSroCheckBoxOpenSpawnEditor.vSroCheck;

        private void vSroCheckBoxShowMob_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowMonster = vSroCheckBoxShowMob.vSroCheck; MapPanel.Invalidate(); }

        private void vSroCheckBoxShowuMob_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowUniqueMonster = vSroCheckBoxShowuMob.vSroCheck; MapPanel.Invalidate(); }

        private void vSroCheckBoxShowNpc_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowNpc = vSroCheckBoxShowNpc.vSroCheck; MapPanel.Invalidate(); }

        private void vSroCheckBoxReg_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowDbRegions = vSroCheckBoxReg.vSroCheck; MapPanel.Invalidate();
        }

        private void vSroCheckBoxUnAsReg_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowUnassignedRegions = vSroCheckBoxUnAsReg.vSroCheck; MapPanel.Invalidate(); }

        private void vSroCheckBoxShowTeleports_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowTeleport = vSroCheckBoxShowTeleports.vSroCheck; MapPanel.Invalidate(); }
        private void vSroCheckBoxShowPlayer_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowPlayer = vSroCheckBoxShowPlayer.vSroCheck; MapPanel.Invalidate(); }


        private void vSroCheckBoxShowNestGenRadius_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowNestGenRadius = vSroCheckBoxShowNestGenRadius.vSroCheck; MapPanel.Invalidate(); }

        private void vSroCheckBoxShowNestRadius_vSroCheckChange(object sender, EventArgs e)
        { MapPanel.ShowNestRadius = vSroCheckBoxShowNestRadius.vSroCheck; MapPanel.Invalidate(); }



        #endregion

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
        private async void EnableControl(Control control, int InSeconds)
        {
            await Task.Delay(InSeconds * 1000);
            control.Enabled = true;
        }
    }
}
