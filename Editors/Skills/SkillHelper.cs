using Structs.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editors.Skills
{
    public partial class SkillHelper : Form
    {
        public List<RefSkill> SelectedSkill = new List<RefSkill>();
        public SkillHelper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefSkill"].Rows.OfType<DataRow>().Any(row => row.Field<string>("Basic_Code").ToLower().Contains(textBox1.Text.ToLower())))
            {
                var monsterTable = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefSkill"].Rows.OfType<DataRow>().Where(row => row.Field<string>("Basic_Code").ToLower().Contains(textBox1.Text.ToLower())).CopyToDataTable();
                dataGridView1.DataSource = monsterTable;
            }
            else { dataGridView1.DataSource = null; }
        }

        private void selectSkillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    var id = (int)item.Cells["ID"].Value;
                    SelectedSkill.Add(ClientDataStorage.Database.SRO_VT_SHARD._RefSkill[id]);

                }
               
                this.Text = $"Add {SelectedSkill.Count} new skills to the monster.";
            }
        }
    }
}
