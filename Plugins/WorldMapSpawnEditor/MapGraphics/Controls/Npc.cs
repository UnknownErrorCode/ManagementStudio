namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single Npc spawn Control.
    /// </summary>
    internal class Npc : Spawn
    {

        #region Private Fields

        private readonly int nGenerateRadius;
        private readonly int nRadius;
        private string codeName128;

        #endregion Private Fields

        #region Internal Constructors

        public Npc(int nestID) : base(ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID])
        {
            nGenerateRadius = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nGenerateRadius;
            nRadius = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].nRadius;
            if (ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics.ContainsKey(ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID))
            {
                var dwObjID = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics[ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID].dwTacticsID].dwObjID;
                if (ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(dwObjID))
                {
                    codeName128 = ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon[dwObjID].CodeName128;
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

        #endregion Internal Constructors

        #region Public Properties

        public string CodeName128 => codeName128;
        public int NGenerateRadius => nGenerateRadius;
        public int NRadius => nRadius;

        #endregion Public Properties

    }
}