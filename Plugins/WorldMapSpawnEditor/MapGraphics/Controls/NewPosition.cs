using Structs;

namespace WorldMapSpawnEditor.MapGraphics
{
    public struct NewPosition
    {
        #region Fields

        private SVector3 position;
        private WRegionID regionID;
        private string text;

        public SVector3 Position { get => position; set => position = value; }
        public WRegionID RegionID { get => regionID; set => regionID = value; }
        public string Text { get => text; set => text = value; }

        #endregion Fields
    }
}