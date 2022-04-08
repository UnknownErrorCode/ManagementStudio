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

        public Monster(int nestID) : base(PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID])
        {
            nGenerateRadius = PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nGenerateRadius;
            nRadius = PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nRadius;

            if (PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID))
            {
                int dwObjID = PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics[PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID].dwObjID;
                if (PluginFramework.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(dwObjID))
                {
                    codeName128 = PluginFramework.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].CodeName128;
                    rarity = PluginFramework.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].Rarity;
                }
                else
                {
                    codeName128 = $"No ObjCommon ID:{dwObjID}";
                }
            }
            else
            {
                codeName128 = $"No TacticsID:{PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID}";
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