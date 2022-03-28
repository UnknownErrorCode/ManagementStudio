using System;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {

        internal WRegionID RegionID { get; set; }

        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        private protected string TexturePath { get => $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{RegionID.X}x{RegionID.Z}.JPG"; }

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        internal Bitmap RegionLayer;//{ get => GetRegionLayer(); }

        internal RegionGraphic(short regionID)
        {
            RegionID = new WRegionID(regionID);
            if (RegionID.IsDungeon || regionID < 0)
                return;

            RegionLayer = File.Exists(TexturePath) ? (Bitmap)Image.FromFile(TexturePath) : null;
        }
    }
}