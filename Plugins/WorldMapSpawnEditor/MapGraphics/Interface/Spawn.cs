using Structs;
using Structs.BinaryFiles;
using Structs.Database;
using Structs.Tool;
using System;
using WorldMapSpawnEditor.MapGraphics.Interface;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// Contains all shared informations of a spawn
    /// </summary>
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
            id = nest.DwNestID;
            regionID = new WRegionID(nest.NRegionDBID);
            xLocation = nest.FLocalPosX;
            yLocation = nest.FLocalPosY;
            zLocation = nest.FLocalPosZ;
            GetSpawnInformation(nest, ref spawnType, ref gameWorldID);
        }

        internal Spawn(ObjectStringIFOStruct struc)
        {
            id = struc.ID1;

            regionID = WRegionID.GetWRegionID(struc.X, struc.Y);
            xLocation = struc.PosX;
            yLocation = struc.PosY;
            zLocation = struc.PosZ;
            spawnType = SpawnType.Structure;
            gameWorldID = 1; 
        }


        internal Spawn(RefTeleport teleport)
        {
            id = teleport.ID;
            var objCommon = PluginFramework.Database.SRO_VT_SHARD._RefObjCommon[teleport.AssocRefObjID];
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

        /// <summary>
        ///<see cref="Npc"/>, <see cref="Monster"/> = Nest dwNestID
        ///<br><see cref="Player"/> = CharID</br>
        ///<br><see cref="Teleport"/> = _RefTeleport.ID</br>
        /// </summary>
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
            int nestID = nest.DwNestID;

            gameWorldID = PluginFramework.Database.SRO_VT_SHARD.Tab_RefHive.TryGetValue(nest.DwHiveID, out Tab_RefHive hive) ? hive.GameWorldID : 0;

            var tacticsID = PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].DwTacticsID;

            if (!PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(tacticsID))
                return false;
            var objCommonID = PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics[tacticsID].DwObjID;
            var objCommon = PluginFramework.Database.SRO_VT_SHARD._RefObjCommon[objCommonID];
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