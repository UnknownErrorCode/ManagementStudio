using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.IO;
using System.Drawing;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditor : UserControl
    {

        internal static ServerData StaticServerData { get; set; }

        private protected static string ExtractedClientPath { get => ClientDataStorage.Config.StaticConfig.ClientExtracted; }

        private protected static string MinimapFileDirectory { get => Path.Combine(ExtractedClientPath, "media", "minimap"); }
        public WorldMapSpawnEditor(ServerData data)
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            for (int x = 0; x < 255; x++)
            {
                for (int y = 0; y < 255; y++)
                {
                    var regionImagePath = Path.Combine(MinimapFileDirectory, $"{x}x{y}.jpg");
                    if (File.Exists(regionImagePath))
                    {
                        PictureBox regionBox = new PictureBox()
                        {
                            Name = $"{x}x{y}",
                            BackgroundImage = Image.FromFile(regionImagePath),
                            Location = new Point(x * 256, y * 256),
                            Size = new Size(BackgroundImage.Width, BackgroundImage.Height)
                        };
                        this.tableLayoutPanel1.Controls.Add(regionBox);
                        this.tableLayoutPanel1.SetColumn(regionBox, x);
                        this.tableLayoutPanel1.SetRow(regionBox, y);

                    }
                }
            }
        }
    }
}
