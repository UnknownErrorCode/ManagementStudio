using Editors.Spawn;
using System;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single Monster spawn Control.
    /// </summary>
    class Monster : ISpawn
    {
        internal Monster(SingleSpawn spawn) : base(spawn)
        {
        }
    }
}
