using System;
using Editors.Spawn;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single Npc spawn Control.
    /// </summary>
    class Npc : ISpawn
    {
        internal Npc(SingleSpawn spawn) : base(spawn)
        {
        }
    }
}
