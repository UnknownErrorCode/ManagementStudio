using Structs;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {
        #region Fields

        internal bool HasLayer;
        internal WRegionID RegionID;

        #endregion Fields

        #region Constructors

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

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        internal Bitmap RegionLayer => (Bitmap)Image.FromFile(TexturePath);

        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        protected string TexturePath => $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{RegionID.X}x{RegionID.Z}.JPG";

        #endregion Properties
    }
}