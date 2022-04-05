using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGuide
{
    internal class CGuideRegion
    {
        internal readonly string Name;
        internal readonly byte X;
        internal readonly byte Z;
        internal readonly bool HasLayer;

        public CGuideRegion(string name, byte x, byte z, string path)
        {
            Name = name;
            X = x;
            Z = z;
            HasLayer = File.Exists(TexturePath);
            TexturePath = path;
        }

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        internal Bitmap RegionLayer => (Bitmap)Image.FromFile(TexturePath);

        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        protected string TexturePath; //=> $"{ClientFrameworkRes.Config.StaticConfig.ClientExtracted}\\Media\\interface\\worldmap\\map\\{X}x{Z}.JPG";



    }
}