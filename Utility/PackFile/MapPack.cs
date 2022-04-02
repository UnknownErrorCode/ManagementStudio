using BinaryFiles.PackFile;
using BinaryFiles.PackFile.Map.m;
using BinaryFiles.PackFile.Map.o2;
using PackFile.Map;
using PackFile.Utility;
using System.Collections.Generic;

namespace PackFile
{
    public class MapPack
    {
        #region Fields

        /// <summary>
        /// List of all .m files inside the Map.pk2.
        /// </summary>
        public static Dictionary<short, MeshFile> AllmFiles = new Dictionary<short, MeshFile>();

        /// <summary>
        /// List of all .o2 files inside the Map.pk2.
        /// </summary>
        public static List<o2File> Allo2Files = new List<o2File>();

        /// <summary>
        /// The Main abstract Pk2 reader.
        /// </summary>
        public static Pk2Reader Reader;
        internal static bool Initialized => Reader.Initialized;


        /// <summary>
        /// All Textures for tiles as dds format. Key = TextureID. Value = .dds file to display bitmap.
        /// </summary>
        public static Dictionary<int, DDJImage> TileTextureDictionary = new Dictionary<int, DDJImage>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Initialize the Map.pk2 syncronous.
        /// </summary>
        public static bool Initialize(string clientPath)
        {
            Reader = new Pk2Reader($"{clientPath}\\Map.pk2");
            return Reader.Initialized;
        }

        public static bool GetTile2dIFOFile(out Tile2dIFOFile tile2DIFOFile)
        {
            tile2DIFOFile = null;

            if (!Reader.GetByteArrayByDirectory("Map\\tile2d.ifo", out byte[] tile2d_ifo))
                return false;

            tile2DIFOFile = new Tile2dIFOFile(tile2d_ifo);
            return tile2DIFOFile.Initialized;
        }

        #endregion Methods
    }
}