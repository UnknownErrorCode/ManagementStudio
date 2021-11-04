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
    public partial class SkillEditor : Form
    {
        bool ChangeAviable = false;
        public SkillEditor(Monster monster)
        {
            InitializeComponent();

            var UsedSkillIDs = new List<int>();
            foreach (var skill in monster.Skills.Where(ski => ski.ID > 0))
            {
                checkedListBoxSkills.Items.Add(skill.Basic_Code);
                UsedSkillIDs.Add(skill.ID);
            }

            propertyGrid1.SelectedObject = monster;
            propertyGrid1.Refresh();
            dataGridView1.DataSource = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefSkill"].Rows.OfType<DataRow>().Where(row => UsedSkillIDs.Contains(row.Field<int>("ID"))).CopyToDataTable();


        }

        private void OnSkillChanged(object s, PropertyValueChangedEventArgs e)
        {
            ChangeAviable = true;
            var column = e.ChangedItem.PropertyDescriptor.Name;
            var changedValue = e.ChangedItem.Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var skill1 = ((Monster)propertyGrid1.SelectedObject).ObjChar.DefaultSkill_1;

            string updatestring = $"UPDATE _RefObjChar SET DefaultSkil_1 = 0, DefaultSkil_2 = 0,DefaultSkil_1 = 3, DefaultSkil_1 = 4, DefaultSkil_5 = 0, DefaultSkil_6 = 0, DefaultSkil_7 = 0, DefaultSkil_8 = 0, DefaultSkil_9 = 0, DefaultSkil_10 = 0 where ID = {((Monster)propertyGrid1.SelectedObject).ObjChar.ID};\nUPDATE _RefObjChar SET";

            for (int i = 0; i < ((Monster)propertyGrid1.SelectedObject).Skills.Count; i++)
            {
                updatestring = $"{updatestring} DefaultSkill_{i + 1} = {((Monster)propertyGrid1.SelectedObject).Skills[i].ID}, ";
            }
            updatestring = $"{updatestring.Substring(0, updatestring.Length - 2)} WHERE ID = {((Monster)propertyGrid1.SelectedObject).ObjChar.ID} ";
            richTextBoxUpdateQuery.Text = updatestring;


            foreach (var item in ((Monster)propertyGrid1.SelectedObject).Skills)
            {

            }
        }
    }
}
