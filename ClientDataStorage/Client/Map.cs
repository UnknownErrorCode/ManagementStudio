using ClientDataStorage.Client.Files;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public class Map
    {
        #region Public Fields

        /// <summary>
        /// List of all .m files inside the Map.pk2.
        /// </summary>
        public static Dictionary<Point, mFile> AllmFiles = new Dictionary<Point, mFile>();

        /// <summary>
        /// List of all .o2 files inside the Map.pk2.
        /// </summary>
        public static List<o2File> Allo2Files = new List<o2File>();

        /// <summary>
        /// The Main abstract Pk2 reader.
        /// </summary>
        public static Pk2.Pk2Reader MapPk2;

        /// <summary>
        /// Each texture infos for 2d tiles.
        /// </summary>
        public static Tile2dIFOFile Tile2d_ifo;

        /// <summary>
        /// All Textures for tiles as dds format. Key = TextureID. Value = .dds file to display bitmap.
        /// </summary>
        public static Dictionary<int, DDJImage> TileTextureDictionary = new Dictionary<int, DDJImage>();

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Initialize the Map.pk2 syncronous.
        /// </summary>
        public static bool Initialize()
        {
            MapPk2 = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Map.pk2");

            Tile2d_ifo = new Tile2dIFOFile();

            Log.Logger.MessageStack.Push(MapPk2.Initialized ? "Successfully load Map.pk2..." : "Cannot find Map.pk2...");

            return MapPk2.Initialized;
        }

        /// <summary>
        /// Initialize the Map.pk2 file async.
        /// </summary>
        public static async Task<bool> InitializeMapAsync()
        {
            return Task.Run(() => Initialize()).Result;
        }

        #endregion Public Methods
    }
}