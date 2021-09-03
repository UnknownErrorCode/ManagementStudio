using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditor: UserControl
    {

        internal static ServerData StaticServerData { get; set; }

        public WorldMapSpawnEditor(ServerData data)
        {
            InitializeComponent();
        }

     
    }
}
