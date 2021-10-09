using System;
using Editors.Spawn;

namespace WorldMapSpawnEditor._2dMapViewer
{
    /// <summary>
    /// A single Npc spawn Control.
    /// </summary>
    class Npc : ISpawn
    {
        internal Npc(SingleSpawn spawn) : base(spawn, 8, "Media\\interface\\minimap\\mm_sign_npc.ddj")
        {
        }
    }
}
