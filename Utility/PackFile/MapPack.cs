using BinaryFiles.PackFile;
using BinaryFiles.PackFile.Map.m;
using BinaryFiles.PackFile.Map.o2;
using PackFile.Map;
using PackFile.Utility;
using System;
using System.Collections.Generic;

namespace PackFile
{
    public class MapPack
    {
        #region Fields

        /// <summary>
        /// List of all .m files inside the Map.pk2.
        /// </summary>
        public static Dictionary<short, JMXmFile> AllmFiles = new Dictionary<short, JMXmFile>();

        /// <summary>
        /// List of all .o2 files inside the Map.pk2.
        /// </summary>
        public static List<JMXo2File> Allo2Files = new List<JMXo2File>();

        /// <summary>
        /// The Main abstract Pk2 reader.
        /// </summary>
        public static Pk2Reader Reader;

        /// <summary>
        /// All Textures for tiles as dds format. Key = TextureID. Value = .dds file to display bitmap.
        /// </summary>
        public static Dictionary<int, JMXddjFile> TileTextureDictionary = new Dictionary<int, JMXddjFile>();

        internal static bool Initialized => Reader.Initialized;

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

        public static bool TryGetMeshZ(byte X, byte Y, short regionID, float regX, float regY, out float zZ)
        {
            zZ = 0.0f;
            if (!PackFile.MapPack.AllmFiles.ContainsKey(regionID))
            {
                if (PackFile.MapPack.Reader.GetByteArrayByDirectory($"Map\\{Y}\\{X}.m", out byte[] mFile))
                {
                    BinaryFiles.PackFile.Map.m.JMXmFile mfi = new BinaryFiles.PackFile.Map.m.JMXmFile(mFile, (byte)X, (byte)Y);
                    PackFile.MapPack.AllmFiles.Add((short)regionID, mfi);
                }
            }
            if (!PackFile.MapPack.AllmFiles.ContainsKey(regionID))
            {
                return false;
            }
            zZ = PackFile.MapPack.AllmFiles[regionID].GetHightByfPoint(regX, regY);
            return true;
        }

        #endregion Methods
    }
}