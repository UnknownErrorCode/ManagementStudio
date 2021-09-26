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
            this.Click += Monster_Click;
            ToolTip tip = new ToolTip() { InitialDelay = 100, AutoPopDelay = 0, ReshowDelay = 100 };
            tip.SetToolTip(this, spawn.ObjCommon.CodeName128);
        }

        private void Monster_Click(object sender, EventArgs e)
        {
            using(WorldMapSpawnEditor._2dMapViewer.Forms.SpawnEditor editor = new Forms.SpawnEditor(Spawn))
            {
                editor.ShowDialog();
            }
        }
    }
}
