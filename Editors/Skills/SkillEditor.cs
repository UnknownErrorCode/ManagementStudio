using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Editors.Skills
{
    public partial class SkillEditor : Form
    {
        public bool ChangeAviable = false;
        readonly Dictionary<int, Dictionary<string, string>> AviableChanges = new Dictionary<int, Dictionary<string, string>>();

        public SkillEditor(Monster monster)
        {
            InitializeComponent();

            List<int> UsedSkillIDs = new List<int>();
            foreach (Structs.Database.RefSkill skill in monster.Skills.Where(ski => ski.ID > 0))
            {
                UsedSkillIDs.Add(skill.ID);
            }

            propertyGrid1.SelectedObject = monster;
            propertyGrid1.Refresh();
            dataGridViewMobSkills.DataSource = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefSkill"].Rows.OfType<DataRow>().Where(row => UsedSkillIDs.Contains(row.Field<int>("ID"))).CopyToDataTable();


            if (ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllCharakterInfos.Exists(charinfo => (string)charinfo.CodeName128 == monster.ObjCommon.CodeName128))
            {
                IEnumerable<Structs.Pk2.Media.CharakterInfo> CharInfoOfMob = ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllCharakterInfos.Where(charinfo => (string)charinfo.CodeName128 == monster.ObjCommon.CodeName128);

                //If charInfoOfMob exists, assign it to the Grid after create
                if (CharInfoOfMob.Count() > 0)
                {
                    if (CharInfoOfMob.Count() > 1)
                    {
                        ServerFrameworkRes.BasicControls.vSroMessageBox.Show("This monster has 2 or more charInfos in SkillEffect.txt!\nYou should use 1 charInfo per mob only!");
                    }

                    foreach (Structs.Pk2.Media.CharakterInfo charinfo in CharInfoOfMob)
                    {
                        //Check if columncount matches the result
                        if (charinfo.ObjectArray.Length > dataGridViewSkillEffectCharakterInfo.Columns.Count)
                        {
                            while (charinfo.ObjectArray.Length > dataGridViewSkillEffectCharakterInfo.Columns.Count)
                            {
                                dataGridViewSkillEffectCharakterInfo.Columns.Add("ComingSoon", "ComingSoon");
                            }
                        }
                        //Finally assign the charInfo
                        dataGridViewSkillEffectCharakterInfo.Rows.Add(charinfo.ObjectArray);
                    }
                }
            }

        }

        private void OnSkillChanged(object s, PropertyValueChangedEventArgs e)
        {
            ChangeAviable = true;
            string column = e.ChangedItem.PropertyDescriptor.Name;
            string changedValue = e.ChangedItem.Value.ToString();
            object identifier = e.ChangedItem.GridItems["ID"].Value;

            if (!AviableChanges.ContainsKey(int.Parse(e.ChangedItem.GridItems["ID"].Value.ToString())))
            {
                AviableChanges.Add(int.Parse(e.ChangedItem.GridItems["ID"].Value.ToString()), new Dictionary<string, string>());
            }
            else
            {
                if (AviableChanges[int.Parse(e.ChangedItem.GridItems["ID"].Value.ToString())].ContainsKey(column))
                {
                    AviableChanges[int.Parse(e.ChangedItem.GridItems["ID"].Value.ToString())][column] = changedValue;
                }
            }
            AviableChanges[int.Parse(e.ChangedItem.GridItems["ID"].Value.ToString())].Add(column, changedValue);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int skill1 = ((Monster)propertyGrid1.SelectedObject).ObjChar.DefaultSkill_1;

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
                {
                    ((Monster)propertyGrid1.SelectedObject).Skills.AddRange(helper.SelectedSkill);
                }
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
                    string CurrentlySelectedBasicCode = $"{dataGridViewMobSkills.SelectedRows[i].Cells["Basic_Code"].Value}";
                    if (CurrentlySelectedBasicCode.Length > 0)
                    {
                        if (ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllAniSet2s.Exists(singleAniSet2 => (string)singleAniSet2.Basic_Code == CurrentlySelectedBasicCode))
                        {
                            IEnumerable<Structs.Pk2.Media.AniSet2> anienum = ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllAniSet2s.Where(singleAniSet2 => (string)singleAniSet2.Basic_Code == CurrentlySelectedBasicCode);
                            foreach (Structs.Pk2.Media.AniSet2 item in anienum)
                            {
                                while (item.ObjectArray.Length > dataGridViewSkillEffectAniSet2.Columns.Count)
                                {
                                    dataGridViewSkillEffectAniSet2.Columns.Add("comingSoon", "comingSoon");
                                }
                                dataGridViewSkillEffectAniSet2.Rows.Add(item.ObjectArray);
                            }
                        }

                        if (ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllEffectSets.Exists(singleEffect => (string)singleEffect.SkillEffectID == CurrentlySelectedBasicCode))
                        {
                            IEnumerable<Structs.Pk2.Media.EffectSet> effectSetEnum = ClientDataStorage.Client.Media.SkillEffect.Skilleffects.AllEffectSets.Where(singleEffect => (string)singleEffect.SkillEffectID == CurrentlySelectedBasicCode);
                            foreach (Structs.Pk2.Media.EffectSet effectset in effectSetEnum)
                            {
                                if ((string)effectset.SkillEffectID == CurrentlySelectedBasicCode)
                                {
                                    while (effectset.ObjectArray.Length > dataGridViewSkillEffectset.Columns.Count)
                                    {
                                        dataGridViewSkillEffectset.Columns.Add("comingSoon", "comingSoon");
                                    }
                                    dataGridViewSkillEffectset.Rows.Add(effectset.ObjectArray);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
