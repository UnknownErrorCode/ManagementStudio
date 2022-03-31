using System.Collections;
using System.Collections.Generic;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Dungeon : IEnumerable<RegionGraphic>
    {
        #region Fields

        private readonly short dungeonID;
        private readonly string dungeonName;
        private readonly List<RegionGraphic> Dungeons = new List<RegionGraphic>();

        #endregion Fields

        #region Constructors

        internal Dungeon(string name, IEnumerable<RegionGraphic> dungeonRegions)
        {
            dungeonName = name;
            Dungeons.AddRange(dungeonRegions);
        }

        internal Dungeon(string name, short regionID)
        {
            dungeonName = name;
            dungeonID = regionID;
        }

        #endregion Constructors

        #region Properties

        public short DungeonID => dungeonID;
        public string DungeonName => dungeonName;

        #endregion Properties

        #region Methods

        public IEnumerator<RegionGraphic> GetEnumerator()
            => Dungeons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
       => GetEnumerator();

        #endregion Methods
    }
}