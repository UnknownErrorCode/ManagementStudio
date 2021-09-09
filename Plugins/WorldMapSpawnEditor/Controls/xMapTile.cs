using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.Controls
{
	public class xMapTile : PictureBox
	{
		public int SectorX { get; }
		public int SectorY { get; }
		public xMapTile(int SectorX, int SectorY)
		{
			this.SectorX = SectorX;
			this.SectorY = SectorY;
		}
		public async void LoadAsyncTile(string path, Size size)
		{
			if (File.Exists(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, "media",path)))
			{
				this.Image = await Task.Run(() => GetTile(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, "media", path), size));
			}
		}
		private Bitmap GetTile(string path, Size size)
		{
			return new Bitmap(Image.FromFile(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, "media", path)), size);
		}
	}
}