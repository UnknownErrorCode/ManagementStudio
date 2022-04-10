namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single Npc spawn Control.
    /// </summary>
    internal class Npc : Spawn
    {
        #region Fields

        private readonly int nGenerateRadius;
        private readonly int nRadius;
        private string codeName128;

        #endregion Fields

        #region Constructors

        public Npc(int nestID) : base(PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID])
        {
            nGenerateRadius = PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].NGenerateRadius;
            nRadius = PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].NRadius;
            if (PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].DwTacticsID))
            {
                var dwObjID = PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics[PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].DwTacticsID].DwObjID;
                if (PluginFramework.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(dwObjID))
                {
                    codeName128 = PluginFramework.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].CodeName128;
                }
                else
                {
                    codeName128 = $"No ObjCommon ID:{dwObjID}";
                }
            }
            else
            {
                codeName128 = $"No TacticsID:{PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[nestID].DwTacticsID}";
            }
        }

        #endregion Constructors

        #region Properties

        public string CodeName128 => codeName128;
        public int NGenerateRadius => nGenerateRadius;
        public int NRadius => nRadius;

        #endregion Properties
    }
}