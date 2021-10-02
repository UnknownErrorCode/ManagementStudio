using System;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {
        internal byte X;
        internal byte Z;
        internal short wRegionID;

        #region Constants
        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        private protected string TexturePath { get => $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{X}x{Z}.jpg"; }
        #endregion

        internal Image RegionLayer;
        internal RegionGraphic(short regionID)
        {
            wRegionID = regionID;

            if (wRegionID > 0)
            {
                string convertedRegionID = wRegionID.ToString("X");
                Z = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(0, 2), 16));
                X = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(2, 2), 16));
                if (File.Exists(TexturePath))
                    RegionLayer = Image.FromFile(TexturePath);
            }
        }
    }
}