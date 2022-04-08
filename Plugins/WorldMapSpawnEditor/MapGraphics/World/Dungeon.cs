using System.Collections;
using System.Collections.Generic;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Dungeon : IEnumerable<RegionGraphic>
    {
        private readonly short dungeonID;
        private readonly string dungeonName;
        private readonly List<RegionGraphic> DungeonGraphics = new List<RegionGraphic>();

        internal Dungeon(string name, IEnumerable<RegionGraphic> dungeonRegions)
        {
            dungeonName = name;
            DungeonGraphics.AddRange(dungeonRegions);
        }

        internal Dungeon(string name, short regionID)
        {
            dungeonName = name;
            dungeonID = regionID;
        }

        public short DungeonID => dungeonID;
        public string DungeonName => dungeonName;

        public IEnumerator<RegionGraphic> GetEnumerator()
            => DungeonGraphics.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
       => GetEnumerator();
    }
}