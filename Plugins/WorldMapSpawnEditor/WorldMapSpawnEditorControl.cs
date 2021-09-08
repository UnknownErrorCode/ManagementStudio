using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.IO;
using System.Drawing;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {

        internal static ServerData StaticServerData { get; set; }

        private protected static string ExtractedClientPath { get => ClientDataStorage.Config.StaticConfig.ClientExtracted; }

        private protected static string MinimapFileDirectory { get => Path.Combine(ExtractedClientPath, "media", "minimap"); }
        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {


            Pk2Ressources ress = new Pk2Ressources(ClientDataStorage.Config.StaticConfig.ClientPath);
        }
    }
}
