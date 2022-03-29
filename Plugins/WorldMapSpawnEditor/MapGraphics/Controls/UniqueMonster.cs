using Editors.Spawn;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single UniqueMonster spawn Control.
    /// </summary>
    internal class UniqueMonster : ISpawn
    {
        internal UniqueMonster(SingleSpawn spawn) : base(spawn)
        {
        }
    }
}