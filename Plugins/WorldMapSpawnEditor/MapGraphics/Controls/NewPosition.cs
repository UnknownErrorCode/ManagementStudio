using Structs;
using System;

namespace WorldMapSpawnEditor.MapGraphics
{
    public struct NewPosition
    {
        private SroPosition sroPosition;

        private string text;

        public NewPosition(SroPosition sroPosition, string text)
        {
            this.sroPosition = sroPosition;
            this.text = text;
        }

        public SVector3 Position { get => sroPosition.fPosition; set => sroPosition.fPosition = value; }
        public WRegionID RegionID { get => sroPosition.wRegionID; set => sroPosition.wRegionID = value; }

        public short wRegionID => sroPosition.wRegionID.RegionID;
        public float X => sroPosition.fPosition.X;
        public float Y => sroPosition.fPosition.Y;
        public float Z => sroPosition.fPosition.Z;
        public string Text { get => text; set => text = value; }
    }
}