using Structs;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Spawn
    {
        public readonly int ID;
        public readonly GraphicsPanel.SpawnType spawnType;
        public WRegionID RegionID;
        public float xLocation;
        public float yLocation;
        internal int nGenerateRadius;
        internal int nRadius;
        internal float zLocation;

        internal Spawn(int id, short wRegionID, float x, float y, float z, GraphicsPanel.SpawnType type, int radius, int genRaius)
        {
            ID = id;
            RegionID = new WRegionID(wRegionID);
            xLocation = x;
            yLocation = y;
            zLocation = z;
            spawnType = type;
            nRadius = radius;
            nGenerateRadius = genRaius;
        }
    }
}