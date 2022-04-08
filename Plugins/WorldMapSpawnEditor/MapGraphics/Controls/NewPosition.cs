using System.Numerics;

namespace WorldMapSpawnEditor.MapGraphics
{
    public struct NewPosition
    {
        #region Fields

        private Vector3 position;
        private short regionID;
        private string text;

        public Vector3 Position { get => position; set => position = value; }
        public short RegionID { get => regionID; set => regionID = value; }
        public string Text { get => text; set => text = value; }

        #endregion Fields
    }
}