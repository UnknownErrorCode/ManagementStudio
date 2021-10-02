using System;

namespace WorldMapSpawnEditor._2dMapViewer
{
    /// <summary>
    /// A single UniqueMonster spawn Control.
    /// </summary>
    class UniqueMonster : ISpawn
    {
        internal UniqueMonster(SingleSpawn spawn) : base(spawn, 12, "Media\\interface\\minimap\\mm_sign_unique.ddj")
        {
        }
    }
}
