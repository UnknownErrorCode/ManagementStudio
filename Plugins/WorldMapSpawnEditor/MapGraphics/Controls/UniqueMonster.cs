namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single UniqueMonster spawn Control.
    /// </summary>
    internal class UniqueMonster : Spawn
    {
        #region Constructors

        internal UniqueMonster(int nestID) : base(ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest[nestID])
        {
        }

        #endregion Constructors
    }
}