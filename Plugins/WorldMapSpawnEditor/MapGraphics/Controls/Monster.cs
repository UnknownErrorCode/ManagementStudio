using Structs.Database;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Monster : Spawn
    {
        #region Fields

        private readonly string codeName128;
        private readonly int nGenerateRadius;
        private readonly int nRadius;
        private readonly Rarity rarity;

        #endregion Fields

        #region Constructors

        public Monster(int nestID) : base(ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID])
        {
            nGenerateRadius = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nGenerateRadius;
            nRadius = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nRadius;

            if (ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID))
            {
                int dwObjID = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics[ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID].dwObjID;
                if (ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(dwObjID))
                {
                    codeName128 = ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].CodeName128;
                    rarity = ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].Rarity;
                }
                else
                {
                    codeName128 = $"No ObjCommon ID:{dwObjID}";
                }
            }
            else
            {
                codeName128 = $"No TacticsID:{ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID}";
            }
        }

        #endregion Constructors

        #region Properties

        public string CodeName128 => codeName128;

        internal int NGenerateRadius => nGenerateRadius;
        internal int NRadius => nRadius;
        internal Rarity Rarity => rarity;

        #endregion Properties
    }
}