using System;

namespace WorldMapSpawnEditor._2dMapViewer
{
    /// <summary>
    /// A single Npc spawn Control.
    /// </summary>
    class Npc : ISpawn
    {

        internal Npc(SingleSpawn spawn) : base(spawn, 8, "Media\\interface\\minimap\\mm_sign_npc.ddj")
        {
            this.Click += Npc_Click; ;
        }

        private void Npc_Click(object sender, EventArgs e)
        {
            using (_2dMapViewer.Forms. SpawnEditor edit = new Forms.SpawnEditor(Spawn) )
            {
                edit.ShowDialog();
            }
        }


    }
}
