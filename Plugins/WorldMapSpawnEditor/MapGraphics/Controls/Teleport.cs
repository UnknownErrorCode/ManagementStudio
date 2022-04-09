using Structs.Database;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Teleport : Spawn
    {
        #region Constructors

        internal Teleport(RefTeleport teleport) : base(teleport)
        {
            AssocRefObjCodeName128 = teleport.AssocRefObjCodeName128;
        }

        #endregion Constructors

        public string AssocRefObjCodeName128 { get; set; }
    }
}