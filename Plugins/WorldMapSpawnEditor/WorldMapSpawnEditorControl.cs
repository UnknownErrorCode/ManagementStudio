using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {

        internal static ServerData StaticServerData { get; set; }
        public Controls.xMap Minimap_pnlMap = new Controls.xMap();
        public Controls.xMapControl Minimap_xmcCharacterMark = new Controls.xMapControl();
        private protected static string ExtractedClientPath { get => ClientDataStorage.Config.StaticConfig.ClientExtracted; }

        private protected static string MinimapFileDirectory { get => Path.Combine(ExtractedClientPath, "media", "minimap"); }
        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();
            this.Minimap_pnlMap.BackColor = System.Drawing.Color.Transparent;
            this.Minimap_pnlMap.Controls.Add(this.Minimap_xmcCharacterMark);
            this.Minimap_pnlMap.Location = new System.Drawing.Point(-31, -174);
            this.Minimap_pnlMap.Name = "Minimap_pnlMap";
            this.Minimap_pnlMap.Size = new System.Drawing.Size(720, 720);
            this.Minimap_pnlMap.TabIndex = 1;
            this.Minimap_pnlMap.Tag = "Source Sans Pro";
            this.Minimap_pnlMap.Zoom = ((byte)(1));
            this.Minimap_pnlMap.Dock = DockStyle.Fill;


            this.Minimap_xmcCharacterMark.BackColor = System.Drawing.Color.Transparent;
            this.Minimap_xmcCharacterMark.Location = new System.Drawing.Point(352, 352);
            this.Minimap_xmcCharacterMark.Name = "Minimap_xmcCharacterMark";
            this.Minimap_xmcCharacterMark.Size = new System.Drawing.Size(16, 16);
            this.Minimap_xmcCharacterMark.TabIndex = 0;
            this.Minimap_xmcCharacterMark.TabStop = false;
            this.Minimap_xmcCharacterMark.Dock = DockStyle.Fill;


            this.splitContainerMain.Panel1.Controls.Add(Minimap_pnlMap);
            InitializePerformance(this);
            Minimap_pnlMap.UpdateTiles();
        }




        private void InitializePerformance(Control c)
        {
            if (typeof(Panel) == c.GetType())
            {
                typeof(Panel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, c, new object[] { true });
            }
        }
        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {


            Pk2Ressources ress = new Pk2Ressources(ClientDataStorage.Config.StaticConfig.ClientPath);
       
        }
    }
}
