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

        public Monster(int nestID) : base(ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID])
        {
            nGenerateRadius = ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nGenerateRadius;
            nRadius = ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nRadius;

            if (ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID))
            {
                int dwObjID = ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefTactics[ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID].dwObjID;
                if (ClientFrameworkRes.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(dwObjID))
                {
                    codeName128 = ClientFrameworkRes.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].CodeName128;
                    rarity = ClientFrameworkRes.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].Rarity;
                }
                else
                {
                    codeName128 = $"No ObjCommon ID:{dwObjID}";
                }
            }
            else
            {
                codeName128 = $"No TacticsID:{ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID}";
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