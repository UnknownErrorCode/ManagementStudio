using Structs;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {
        internal WRegionID RegionID;

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        internal Bitmap RegionLayer => (Bitmap)Image.FromFile(TexturePath);

        internal bool HasLayer;

        internal RegionGraphic(short regionID)
        {
            RegionID = new WRegionID(regionID);
            if (RegionID.IsDungeon || regionID < 0)
            {
                HasLayer = false;
                return;
            }
            HasLayer = File.Exists(TexturePath);
        }

        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        protected string TexturePath => $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{RegionID.X}x{RegionID.Z}.JPG";
    }
}