using Structs;
using Structs.Database;
using Structs.Tool;
using System;
using WorldMapSpawnEditor.MapGraphics.Interface;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Spawn : InterfaceSpawn
    {
        #region Fields

        private readonly int gameWorldID;
        private readonly int id;
        private readonly WRegionID regionID;
        private readonly SpawnType spawnType;
        private readonly float xLocation;
        private readonly float yLocation;
        private readonly float zLocation;

        #endregion Fields

        #region Constructors

        internal Spawn(IChar _char)
        {
            id = _char.CharID;
            regionID = new WRegionID(_char.LatestRegion);
            xLocation = _char.PosX;
            yLocation = _char.PosY;
            zLocation = _char.PosZ;
            spawnType = SpawnType.Player;
            gameWorldID = _char.WorldID;
        }

        internal Spawn(TabRefNest nest)
        {
            id = nest.dwNestID;
            regionID = new WRegionID(nest.nRegionDBID);
            xLocation = nest.fLocalPosX;
            yLocation = nest.fLocalPosY;
            zLocation = nest.fLocalPosZ;
            GetSpawnInformation(nest, ref spawnType, ref gameWorldID);
        }

        internal Spawn(RefTeleport teleport)
        {
            id = teleport.ID;
            var objCommon = ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon[teleport.AssocRefObjID];
            regionID = new WRegionID(objCommon.RegionID);
            xLocation = objCommon.OffsetX;
            yLocation = objCommon.OffsetY;
            zLocation = objCommon.OffsetZ;
            spawnType = SpawnType.Teleport;
            gameWorldID = 1; // TODO: Check if all teleports who does not belong to a NPC as associated ObjID are GameWorldID = 1;
        }

        #endregion Constructors

        #region Properties

        public int GameWorldID => gameWorldID;
        public int ID { get => id; }
        public WRegionID RegionID { get => regionID; }
        public SpawnType SpawnType { get => spawnType; }
        public float XLocation { get => xLocation; }
        public float YLocation { get => yLocation; }
        public float ZLocation { get => zLocation; }

        #endregion Properties

        #region Methods

        internal static InterfaceSpawn FromSpawn<T>(Spawn spawn) where T : class
        {
            return (InterfaceSpawn)Activator.CreateInstance(typeof(T), spawn.ID);
        }

        private bool GetSpawnInformation(TabRefNest nest, ref SpawnType type, ref int gameWorldID)
        {
            type = SpawnType.None;
            int nestID = nest.dwNestID;

            if (ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefHive.TryGetValue(nest.dwHiveID, out Tab_RefHive hive))
                gameWorldID = hive.GameWorldID;
            else
                gameWorldID = -1;

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

        #endregion Methods
    }
}