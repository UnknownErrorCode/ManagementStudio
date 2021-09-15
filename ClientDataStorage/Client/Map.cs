using ClientDataStorage.Client.Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public class Map
    {
        public static Pk2.Pk2Reader MapPk2 { get; set; }

        public static Dictionary<int, DDSImage> TileTextureDictionary = new Dictionary<int, DDSImage>();
        public static List<o2File> Allo2Files = new List<o2File>();
        public static Dictionary<Point, mFile> AllmFiles = new Dictionary<Point, mFile>();

        public static Tile2dIFOFile Tile2d_ifo;

        public static void Initialize()
        {
            MapPk2 = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Map.pk2");

            Tile2d_ifo = new Tile2dIFOFile();
            
        }
    }
}
