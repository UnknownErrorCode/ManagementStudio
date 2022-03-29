using Editors.Spawn;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single Npc spawn Control.
    /// </summary>
    internal class Npc : ISpawn
    {
        internal Npc(SingleSpawn spawn) : base(spawn)
        {
        }

        public string CodeName128 { get => base.Spawn.ObjCommon.CodeName128; set => Spawn.ObjCommon.CodeName128 = value; }
    }
}