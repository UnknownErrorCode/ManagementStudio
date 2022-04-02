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

        public Npc(int nestID) : base(ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID])
        {
            nGenerateRadius = ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nGenerateRadius;
            nRadius = ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nRadius;
            if (ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID))
            {
                var dwObjID = ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefTactics[ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID].dwObjID;
                if (ClientFrameworkRes.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(dwObjID))
                {
                    codeName128 = ClientFrameworkRes.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].CodeName128;
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
        public int NGenerateRadius => nGenerateRadius;
        public int NRadius => nRadius;

        #endregion Properties
    }
}