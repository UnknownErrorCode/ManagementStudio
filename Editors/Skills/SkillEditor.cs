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
        public bool ChangeAviable = false;
        public SkillEditor(Monster monster)
        {
            InitializeComponent();

            var UsedSkillIDs = new List<int>();
            foreach (var skill in monster.Skills.Where(ski => ski.ID > 0))
            {
                UsedSkillIDs.Add(skill.ID);
            }

            propertyGrid1.SelectedObject = monster;
            propertyGrid1.Refresh();
            dataGridViewMobSkills.DataSource = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefSkill"].Rows.OfType<DataRow>().Where(row => UsedSkillIDs.Contains(row.Field<int>("ID"))).CopyToDataTable();


            if (ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllCharakterInfos.Exists(charinfo => (string)charinfo.CodeName128 == monster.ObjCommon.CodeName128))
            {
                var CharInfoOfMob = ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllCharakterInfos.Where(charinfo => (string)charinfo.CodeName128 == monster.ObjCommon.CodeName128);

                //If charInfoOfMob exists, assign it to the Grid after create
                if (CharInfoOfMob.Count() > 0)
                {
                    if (CharInfoOfMob.Count() > 1)
                    {
                        ServerFrameworkRes.BasicControls.vSroMessageBox.Show("This monster has 2 or more charInfos in SkillEffect.txt!\nYou should use 1 charInfo per mob only!");
                    }

                    foreach (var charinfo in CharInfoOfMob)
                    {
                        //Check if columncount matches the result
                        if (charinfo.ObjectArray.Length > this.dataGridViewSkillEffectCharakterInfo.Columns.Count)
                        {
                            while (charinfo.ObjectArray.Length > this.dataGridViewSkillEffectCharakterInfo.Columns.Count)
                            {
                                this.dataGridViewSkillEffectCharakterInfo.Columns.Add("ComingSoon", "ComingSoon");
                            }
                        }
                        //Finally assign the charInfo
                        this.dataGridViewSkillEffectCharakterInfo.Rows.Add(charinfo.ObjectArray);
                    }
                }
            }

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

            string updatestring = $"UPDATE _RefObjChar SET DefaultSkill_1 = 0, DefaultSkill_2 = 0,DefaultSkill_3 = 0, DefaultSkill_4 = 0, DefaultSkill_5 = 0, DefaultSkill_6 = 0, DefaultSkill_7 = 0, DefaultSkill_8 = 0, DefaultSkill_9 = 0, DefaultSkill_10 = 0 where ID = {((Monster)propertyGrid1.SelectedObject).ObjChar.ID};\nUPDATE _RefObjChar SET";

            for (int i = 0; i < ((Monster)propertyGrid1.SelectedObject).Skills.Count; i++)
            {
                updatestring = $"{updatestring} DefaultSkill_{i + 1} = {((Monster)propertyGrid1.SelectedObject).Skills[i].ID}, ";
            }
            updatestring = $"{updatestring.Substring(0, updatestring.Length - 2)} WHERE ID = {((Monster)propertyGrid1.SelectedObject).ObjChar.ID} ";
            richTextBoxUpdateQuery.Text = updatestring;

        }

        private void OnAddExistingSkill()
        {
            using (SkillHelper helper = new SkillHelper())
            {
                helper.ShowDialog();

                if (helper.SelectedSkill.Count > 0)
                    ((Monster)propertyGrid1.SelectedObject).Skills.AddRange(helper.SelectedSkill);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                dataGridViewSkillEffectAniSet2.Rows.Clear();
                dataGridViewSkillEffectset.Rows.Clear();

                for (int i = 0; i < dataGridViewMobSkills.SelectedRows.Count; i++)
                {
                    var CurrentlySelectedBasicCode = $"{dataGridViewMobSkills.SelectedRows[i].Cells["Basic_Code"].Value}";
                    if (CurrentlySelectedBasicCode.Length > 0)
                    {
                        if (ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllAniSet2s.Exists(singleAniSet2 => (string)singleAniSet2.Basic_Code == CurrentlySelectedBasicCode))
                        {
                            var anienum = ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllAniSet2s.Where(singleAniSet2 => (string)singleAniSet2.Basic_Code == CurrentlySelectedBasicCode);
                            foreach (var item in anienum)
                            {
                                while (item.ObjectArray.Length > this.dataGridViewSkillEffectAniSet2.Columns.Count)
                                {
                                    this.dataGridViewSkillEffectAniSet2.Columns.Add("comingSoon", "comingSoon");
                                }
                                this.dataGridViewSkillEffectAniSet2.Rows.Add(item.ObjectArray);
                            }
                        }

                        if (ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllEffectSets.Exists(singleEffect => (string)singleEffect.SkillEffectID == CurrentlySelectedBasicCode))
                        {
                            var effectSetEnum = ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllEffectSets.Where(singleEffect => (string)singleEffect.SkillEffectID == CurrentlySelectedBasicCode);
                            foreach (var effectset in effectSetEnum)
                            {
                                if ((string)effectset.SkillEffectID == CurrentlySelectedBasicCode)
                                {
                                    while (effectset.ObjectArray.Length > this.dataGridViewSkillEffectset.Columns.Count)
                                    {
                                        this.dataGridViewSkillEffectset.Columns.Add("comingSoon", "comingSoon");
                                    }
                                    this.dataGridViewSkillEffectset.Rows.Add(effectset.ObjectArray);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
