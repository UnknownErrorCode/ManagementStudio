using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using Editors.Skills;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using Structs.Database;

namespace SkillEditor
{
    public partial class SkillEditorControl : UserControl
    {
        internal static ServerData StaticServerData;
        public SkillEditorControl(ServerData serverData)
        {
            StaticServerData = serverData;
            InitializeComponent();
        }

        /// <summary>
        /// After click on search button the datagridview will display the monsters containint the search text sequence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchMonster(object sender, EventArgs e)
        {
            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Any(row => row.Field<string>("CodeName128").ToLower().Contains(textBoxSearchMonster.Text.ToLower())))
            {
                var monsterTable = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Where(row => row.Field<string>("CodeName128").ToLower().Contains(textBoxSearchMonster.Text.ToLower())).CopyToDataTable();
                dataGridViewMonster.DataSource = monsterTable;
            }
            else { dataGridViewMonster.DataSource = null; }
        }

        /// <summary>
        /// Takes action after click on a Monster. Opens the monster skill editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMonsterClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMonster.SelectedRows.Count > 0)
                if (dataGridViewMonster.SelectedRows[0] != null)
                {
                    var commonID = (int)dataGridViewMonster.SelectedRows[0].Cells["ID"].Value;

                    if (ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(commonID))
                    {
                        Monster Monster = new Monster(commonID);
                        Editors.Skills.SkillEditor editor = new Editors.Skills.SkillEditor(Monster);
                        editor.Show();
                    }
                }
        }
    }
}
