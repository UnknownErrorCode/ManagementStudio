using Structs;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {
        #region Fields

        private readonly bool hasLayer;
        private readonly bool hasDataBase;
        private readonly WRegionID regionID;
        private string areaName;
        private string continentName;

        #endregion Fields

        #region Constructors

        internal RegionGraphic(short ID,string continent, string name, bool hasDB = false)
        {
            areaName = name;
            continentName = continent;
            hasDataBase = hasDB;
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

        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        public string TexturePath => $"{PluginFramework.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{regionID.X}x{regionID.Z}.PNG";

        internal string AreaName { get => areaName; }
        internal string ContinentName { get => continentName; }

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        //internal Bitmap RegionLayer => (Bitmap)Image.FromFile(TexturePath);

        #endregion Properties
    }
}