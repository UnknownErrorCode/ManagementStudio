using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.IO;
using System.Reflection;
using ClientDataStorage.Client.Files;
using System;
using ClientDataStorage.Client;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {
        internal static ServerData StaticServerData { get; set; }
        private protected static string ExtractedClientPath { get => ClientDataStorage.Config.StaticConfig.ClientExtracted; }
        private protected static string MinimapFileDirectory { get => Path.Combine(ExtractedClientPath, "media", "minimap"); }

        private MapRessources.MapControl mapViewWindow;

        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            mapViewWindow = new MapRessources.MapControl(this.splitContainerMain.Panel1);
            InitializePerformance(this);
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


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
            => mapViewWindow.Draw(new mFile(Map.MapPk2.GetFileByDirectory("Map\\98\\94.m")), false);

        private void loadNewViewerToolStripMenuItem_Click(object sender, EventArgs e)
            => mapViewWindow.Draw(new mFile(Map.MapPk2.GetFileByDirectory("Map\\98\\94.m")), true);

    }
}
