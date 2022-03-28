using System;
using Editors.Spawn;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single Npc spawn Control.
    /// </summary>
    class Npc : ISpawn
    {
        public string CodeName128 { get => base.Spawn.ObjCommon.CodeName128; set => Spawn.ObjCommon.CodeName128 = value; }
        internal Npc(SingleSpawn spawn) : base(spawn)
        {
        }
    }
}
