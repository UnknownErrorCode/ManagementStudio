using Structs;
using Structs.Database;
using Structs.Tool;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Spawn
    {
        #region Public Fields

        public readonly int ID;
        public readonly SpawnType spawnType;
        public WRegionID RegionID;
        public float xLocation;
        public float yLocation;

        #endregion Public Fields

        #region Internal Fields

        internal int nGenerateRadius;
        internal int nRadius;
        internal float zLocation;

        #endregion Internal Fields

        #region Internal Constructors

        internal Spawn(int id, short wRegionID, float x, float y, float z, int radius, int genRaius)
        {
            ID = id;
            RegionID = new WRegionID(wRegionID);
            xLocation = x;
            yLocation = y;
            zLocation = z;
            GetSpawnType(id, ref spawnType);
            nRadius = radius;
            nGenerateRadius = genRaius;
        }

        #endregion Internal Constructors

        #region Private Methods

        private bool GetSpawnType(int nestID, ref SpawnType type)
        {
            type = SpawnType.None;

            var tacticsID = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID;
            if (!ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(tacticsID))
                return false;
            var objCommonID = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics[tacticsID].dwObjID;
            var objCommon = ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon[objCommonID];
            if (objCommon.TypeID1 == 1 && objCommon.TypeID2 == 2 && objCommon.TypeID3 == 1 && objCommon.TypeID4 == 1 && objCommon.Rarity != Rarity.MonsterUnique && objCommon.Rarity != Rarity.MonsterUniqueNoMsg)
            { type = SpawnType.Monster; return true; }
            else if (objCommon.TypeID1 == 1 && objCommon.TypeID2 == 2 && objCommon.TypeID3 == 1 && objCommon.TypeID4 == 1 && (objCommon.Rarity == Rarity.MonsterUnique || objCommon.Rarity == Rarity.MonsterUniqueNoMsg))
            { type = SpawnType.Unique; return true; }
            else if (objCommon.TypeID1 == 1 && objCommon.TypeID2 == 2 && objCommon.TypeID3 == 2 && objCommon.TypeID4 == 0)
            { type = SpawnType.Npc; return true; }

            return false;
        }

        #endregion Private Methods
    }
}