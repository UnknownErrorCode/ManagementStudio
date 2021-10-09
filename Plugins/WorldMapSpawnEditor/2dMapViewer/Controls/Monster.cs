using Editors.Spawn;
using System;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer
{
    /// <summary>
    /// A single Monster spawn Control.
    /// </summary>
    class Monster : ISpawn
    {
        internal Monster(SingleSpawn spawn) : base(spawn, 8, "Media\\interface\\minimap\\mm_sign_monster.ddj")
        {
        }
    }
}
