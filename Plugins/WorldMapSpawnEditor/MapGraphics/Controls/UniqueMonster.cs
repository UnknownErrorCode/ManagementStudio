using System;
using Editors.Spawn;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single UniqueMonster spawn Control.
    /// </summary>
    class UniqueMonster : ISpawn
    {
        internal UniqueMonster(SingleSpawn spawn) : base(spawn)
        {
        }
    }
}
