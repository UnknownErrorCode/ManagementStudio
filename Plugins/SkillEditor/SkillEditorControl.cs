using Editors.Skills;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SkillEditor
{
    public partial class SkillEditorControl : UserControl
    {
        #region Public Constructors

        public SkillEditorControl()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Takes action after click on a Monster. Opens the monster skill editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMonsterClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMonster.SelectedRows.Count > 0)
            {
                if (dataGridViewMonster.SelectedRows[0] != null)
                {
                    int commonID = (int)dataGridViewMonster.SelectedRows[0].Cells["ID"].Value;

                    if (ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(commonID))
                    {
                        Monster Monster = new Monster(commonID);
                        Editors.Skills.SkillEditor editor = new Editors.Skills.SkillEditor(Monster);
                        editor.Show();
                        if (editor.ChangeAviable)
                        {
                            //Send msg here
                        }
                    }
                }
            }
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
                dataGridViewMonster.DataSource = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Where(row => row.Field<string>("CodeName128").ToLower().Contains(textBoxSearchMonster.Text.ToLower())).CopyToDataTable();
            }
            else { dataGridViewMonster.DataSource = null; }
        }

        private void vSroSmallButton1_vSroClickEvent()
        {
            //ClientDataStorage.Database.SRO_VT_SHARD.InitializeSkillEditor();
            buttonSearch.Enabled = true;
        }

        #endregion Private Methods
    }
}