using PackFile.Media.Textdata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Editors.Skills
{
    public partial class SkillEditor : Form
    {
        #region Fields

        public bool ChangeAviable = false;
        private readonly Dictionary<int, Dictionary<string, string>> AviableChanges = new Dictionary<int, Dictionary<string, string>>();
        private readonly SkillEffect skillEffect;
        #endregion Fields

        #region Constructors

        public SkillEditor(Monster monster)
        {
            InitializeComponent();
            if (!PackFile.MediaPack.GetSkillEffect(out skillEffect))
            {
                MessageBox.Show("Failed to read skilleffect.txt from client!!");
            }
            List<int> UsedSkillIDs = new List<int>();
            foreach (Structs.Database.RefSkill skill in monster.Skills.Where(ski => ski.ID > 0))
            {
                UsedSkillIDs.Add(skill.ID);
            }

            propertyGrid1.SelectedObject = monster;
            propertyGrid1.Refresh();
            dataGridViewMobSkills.DataSource = ClientFrameworkRes.Database.SRO_VT_SHARD.dbo.Tables["_RefSkill"].Rows.OfType<DataRow>().Where(row => UsedSkillIDs.Contains(row.Field<int>("ID"))).CopyToDataTable();

            if (skillEffect.ExistsCharInfoCodename128(monster.ObjCommon.CodeName128))
            {
                IEnumerable<CharakterInfo> CharInfoOfMob = skillEffect.GetCharakterInfos(monster.ObjCommon.CodeName128);

                //If charInfoOfMob exists, assign it to the Grid after create
                if (CharInfoOfMob.Count() > 0)
                {
                    if (CharInfoOfMob.Count() > 1)
                    {
                        ServerFrameworkRes.BasicControls.vSroMessageBox.Show("This monster has 2 or more charInfos in SkillEffect.txt!\nYou should use 1 charInfo per mob only!");
                    }

                    foreach (CharakterInfo charinfo in CharInfoOfMob)
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

        #endregion Constructors

        #region Methods

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
                        if (skillEffect.ExistsAniSet2s(CurrentlySelectedBasicCode))
                        {
                            IEnumerable<AniSet2> anienum = skillEffect.GetAniSet2s(CurrentlySelectedBasicCode);
                            foreach (AniSet2 item in anienum)
                            {
                                while (item.ObjectArray.Length > dataGridViewSkillEffectAniSet2.Columns.Count)
                                {
                                    dataGridViewSkillEffectAniSet2.Columns.Add("comingSoon", "comingSoon");
                                }
                                dataGridViewSkillEffectAniSet2.Rows.Add(item.ObjectArray);
                            }
                        }

                        if (skillEffect.ExistsEffectSets(CurrentlySelectedBasicCode))
                        {
                            IEnumerable<EffectSet> effectSetEnum = skillEffect.Skilleffects.AllEffectSets.Where(singleEffect => (string)singleEffect.SkillEffectID == CurrentlySelectedBasicCode);
                            foreach (EffectSet effectset in effectSetEnum)
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        #endregion Methods
    }
}