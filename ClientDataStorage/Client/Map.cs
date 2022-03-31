using BinaryFiles.PackFile;
using BinaryFiles.PackFile.Map.m;
using BinaryFiles.PackFile.Map.o2;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public class Map
    {
        #region Fields

        /// <summary>
        /// List of all .m files inside the Map.pk2.
        /// </summary>
        public static Dictionary<Point, MeshFile> AllmFiles = new Dictionary<Point, MeshFile>();

        /// <summary>
        /// List of all .o2 files inside the Map.pk2.
        /// </summary>
        public static List<o2File> Allo2Files = new List<o2File>();

        /// <summary>
        /// The Main abstract Pk2 reader.
        /// </summary>
        public static Pk2.Pk2Reader Reader;

        /// <summary>
        /// Each texture infos for 2d tiles.
        /// </summary>
        public static Tile2dIFOFile Tile2d_ifo;

        /// <summary>
        /// All Textures for tiles as dds format. Key = TextureID. Value = .dds file to display bitmap.
        /// </summary>
        public static Dictionary<int, DDJImage> TileTextureDictionary = new Dictionary<int, DDJImage>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Initialize the Map.pk2 syncronous.
        /// </summary>
        public static bool Initialize()
        {
            Reader = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Map.pk2");

            if (!Reader.Initialized)
                return false;

            if (!Reader.GetByteArrayByDirectory("Map\\tile2d.ifo", out byte[] tile2d_ifo))
                return false;

            Tile2d_ifo = new Tile2dIFOFile(tile2d_ifo);

            Log.Logger.MessageStack.Push(Reader.Initialized ? "Successfully load Map.pk2..." : "Cannot find Map.pk2...");

            return Reader.Initialized;
        }

        /// <summary>
        /// Initialize the Map.pk2 file async.
        /// </summary>
        public static async Task<bool> InitializeMapAsync()
        {
            return Task.Run(() => Initialize()).Result;
        }

        #endregion Methods
    }
}