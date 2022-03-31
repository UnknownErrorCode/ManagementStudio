using Structs;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {
        #region Fields

        private readonly bool hasLayer;
        private readonly WRegionID regionID;
        private string areaName;

        #endregion Fields

        #region Constructors

        internal RegionGraphic(short ID, string name)
        {
            areaName = name;
            regionID = new WRegionID(ID);
            if (RegionID.IsDungeon || ID < 0)
            {
                hasLayer = false;
                return;
            }
            hasLayer = File.Exists(TexturePath);
        }

        #endregion Constructors

        #region Properties

        public bool HasLayer => hasLayer;

        public WRegionID RegionID => regionID;

        internal string AreaName { get => areaName; }

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        internal Bitmap RegionLayer => (Bitmap)Image.FromFile(TexturePath);

        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        protected string TexturePath => $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{regionID.X}x{regionID.Z}.JPG";

        #endregion Properties
    }
}