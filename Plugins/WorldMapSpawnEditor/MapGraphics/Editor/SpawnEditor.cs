using PluginFramework.BasicControls;
using Structs.Database;
using System;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGraphics
{
    public partial class SpawnEditor : Form
    {
        #region Property

        /// <summary>
        /// SingleSpawn to update. All displayed informations relates to the CuttentSpawn.
        /// </summary>
        public NestSpawnProperty CurrentSpawn { get; set; }

        #endregion Property

        #region Fields

        protected PluginFramework.Database.DbQueryGenerator CharUpdater;
        protected PluginFramework.Database.DbQueryGenerator CommonUpdater;
        protected PluginFramework.Database.DbQueryGenerator HiveUpdater;
        protected PluginFramework.Database.DbQueryGenerator NestUpdater;
        protected PluginFramework.Database.DbQueryGenerator TacticsUpdater;

        #endregion Fields

        public SpawnEditor(NestSpawnProperty spawn)
        {
            InitializeComponent();
            CurrentSpawn = spawn;
            InitializeSpawn();
            Text = CurrentSpawn.ObjCommon.CodeName128;
        }

        /// <summary>
        /// Initialize the spawn informations to the property grids.
        /// </summary>
        private void InitializeSpawn()
        {
            propertyGridNest.SelectedObject = CurrentSpawn.Nest;
            propertyGridHive.SelectedObject = CurrentSpawn.Hive;
            propertyGridTactics.SelectedObject = CurrentSpawn.Tactics;
            propertyGridCommon.SelectedObject = CurrentSpawn.ObjCommon;
            propertyGridChar.SelectedObject = CurrentSpawn.ObjChar;
            propertyGridNest.Refresh();
            propertyGridHive.Refresh();
            propertyGridTactics.Refresh();
            propertyGridCommon.Refresh();
            propertyGridChar.Refresh();

            NestUpdater = new PluginFramework.Database.DbQueryGenerator("Tab_RefNest", "dwNestID", CurrentSpawn.Nest.DwNestID.ToString());
            HiveUpdater = new PluginFramework.Database.DbQueryGenerator("Tab_RefHive", "dwHiveID", CurrentSpawn.Hive.dwHiveID.ToString());
            TacticsUpdater = new PluginFramework.Database.DbQueryGenerator("Tab_RefTactics", "dwTacticsID", CurrentSpawn.Tactics.DwTacticsID.ToString());
            CommonUpdater = new PluginFramework.Database.DbQueryGenerator("_RefObjCommon", "ID", CurrentSpawn.ObjCommon.ID.ToString());
            CharUpdater = new PluginFramework.Database.DbQueryGenerator("_RefObjChar", "ID", CurrentSpawn.ObjChar.ID.ToString());
        }

        /// <summary>
        /// Shows the Update Query prepared for MS SQL Server Management Studio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Show Query Click Voids

        private void ShowNestUpdate(object sender, EventArgs e)
        {
            if (NestUpdater.GenerateQuery(out string query))
                vSroMessageBox.Show(query);
        }

        private void ShowUpdateChar(object sender, EventArgs e)
        {
            if (CharUpdater.GenerateQuery(out string query))
                vSroMessageBox.Show(query);
        }

        private void ShowUpdateCommon(object sender, EventArgs e)
        {
            if (CommonUpdater.GenerateQuery(out string query))
                vSroMessageBox.Show(query);
        }

        private void ShowUpdateHive(object sender, EventArgs e)
        {
            if (HiveUpdater.GenerateQuery(out string query))
                vSroMessageBox.Show(query);
        }

        private void ShowUpdateTactics(object sender, EventArgs e)
        {
            if (TacticsUpdater.GenerateQuery(out string query))
                vSroMessageBox.Show(query);
        }

        #endregion Show Query Click Voids

        /// <summary>
        /// Appends the changes from the different PropertyGrids into the Update List. This is required to update changed values only.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>

        #region Property Grid Change Void

        private void ChangeHive(object s, PropertyValueChangedEventArgs e)
        {
            HiveUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
            Queries();
        }

        private void ChangeNestValue(object s, PropertyValueChangedEventArgs e)
        {
            NestUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
            Queries();
        }

        private void ChangeObjChar(object s, PropertyValueChangedEventArgs e)
        {
            CharUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
            Queries();
        }

        private void ChangeObjCommonValue(object s, PropertyValueChangedEventArgs e)
        {
            object val = e.ChangedItem.Value;
            if (e.ChangedItem.Label == "CanBorrow")
            {
                BorrowFlag str = (Structs.Database.BorrowFlag)e.ChangedItem.Value;
                val = (byte)str;
            }
            CommonUpdater.UpdateObject(e.ChangedItem.Label, val.ToString());
            Queries();
        }

        private void ChangeTacticsValue(object s, PropertyValueChangedEventArgs e)
        {
            TacticsUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
            Queries();
        }

        #endregion Property Grid Change Void

        #region Select New xxx

        private void buttonselectcommon_Click(object sender, EventArgs e)
        {
            if (propertyGridViewCommon.SelectedObject == null)
                return;

            RefObjCommon outer = (RefObjCommon)propertyGridViewCommon.SelectedObject;

            CurrentSpawn.Tactics.DwObjID = outer.ID;
            propertyGridTactics.SelectedObject = CurrentSpawn.Tactics;

            CurrentSpawn.ObjCommon = outer;
            propertyGridCommon.SelectedObject = outer;
            textBoxSearchCommon.ResetText();
            TacticsUpdater.UpdateObject("dwObjID", $"{outer.ID}");
            CommonUpdater.ReassignIdentifier(outer.ID.ToString());
            Queries();
        }

        private void buttonSelectHive_Click(object sender, EventArgs e)
        {
            if (propertyGridViewHive.SelectedObject == null)
                return;

            Tab_RefHive hive = (Tab_RefHive)propertyGridViewHive.SelectedObject;

            CurrentSpawn.Hive = hive;
            CurrentSpawn.Nest.DwHiveID = hive.dwHiveID;
            propertyGridNest.SelectedObject = CurrentSpawn.Nest;
            propertyGridHive.SelectedObject = hive;
            textBoxSearchHive.Text = "";
            NestUpdater.UpdateObject("dwHiveID", $"{hive.dwHiveID}");
            HiveUpdater.ReassignIdentifier(hive.dwHiveID.ToString());
            Queries();
        }

        private void buttonSelectNewPosition_Click(object sender, EventArgs e)
        {
            if (GenericSelectForm.SelectObjStruct(PositionStorage.Collection, out NewPosition pos))
            {
                CurrentSpawn.Nest.NRegionDBID = pos.RegionID.RegionID;
                CurrentSpawn.Nest.FLocalPosX = pos.Position.X;
                CurrentSpawn.Nest.FLocalPosZ = pos.Position.Z;
                CurrentSpawn.Nest.FLocalPosY = pos.Position.Y;
                propertyGridNest.SelectedObject = CurrentSpawn.Nest;

                NestUpdater.UpdateObject("nRegionDBID", $"{pos.RegionID.RegionID}");
                NestUpdater.UpdateObject("fLocalPosX", $"{pos.Position.X}");
                NestUpdater.UpdateObject("fLocalPosY", $"{pos.Position.Y}");
                NestUpdater.UpdateObject("fLocalPosZ", $"{pos.Position.Z}");
                Queries();
            }
        }

        private void buttonSelectTactics_Click(object sender, EventArgs e)
        {
            if (propertyGridviewTactics.SelectedObject == null)
                return;

            Tab_RefTactics outer = (Tab_RefTactics)propertyGridviewTactics.SelectedObject;

            CurrentSpawn.Nest.DwTacticsID = outer.DwTacticsID;
            propertyGridNest.SelectedObject = CurrentSpawn.Nest;
            CurrentSpawn.Tactics = outer;
            propertyGridTactics.SelectedObject = outer;
            textBoxsearchTactics.Text = "";
            NestUpdater.UpdateObject("dwTacticsID", $"{outer.DwTacticsID}");
            TacticsUpdater.ReassignIdentifier(outer.DwTacticsID.ToString());
            Queries();
        }

        #endregion Select New xxx

        #region TextBox TextChanged

        private bool AssignView<T>(T obj, ref PropertyGrid grid, ref Button btn) where T : struct
        {
            errorProvider1.Clear();
            grid.SelectedObject = obj;
            btn.Enabled = true;
            return true;
        }

        private bool CheckTextBox(ref TextBox box, ref PropertyGrid grid, ref Button btn, out int value)
        {
            if (!int.TryParse(box.Text, out value))
            {
                if (box.Text != "")
                {
                    errorProvider1.SetError(textBoxSearchCommon, "No valid dattype int!");
                }
                btn.Enabled = false;
                grid.SelectedObject = null;
                return false;
            }
            return true;
        }

        private void textBoxSearchCommon_TextChanged(object sender, EventArgs e)
        {
            if (!CheckTextBox(ref textBoxSearchCommon, ref propertyGridViewCommon, ref buttonselectcommon, out int commonID))
                return;

            if (PluginFramework.Database.SRO_VT_SHARD._RefObjCommon.TryGetValue(commonID, out RefObjCommon obj))
            {
                AssignView(obj, ref propertyGridViewCommon, ref buttonselectcommon);
                return;
            }
            errorProvider1.SetError(textBoxSearchCommon, $"No ObjCommon with ID {commonID}!");
        }

        private void textBoxsearchHive_TextChanged(object sender, EventArgs e)
        {
            if (!CheckTextBox(ref textBoxSearchHive, ref propertyGridViewHive, ref buttonSelectHive, out int id))
                return;
            else
            {
                if (PluginFramework.Database.SRO_VT_SHARD.Tab_RefHive.TryGetValue(id, out Tab_RefHive obj))
                {
                    AssignView(obj, ref propertyGridViewHive, ref buttonSelectHive);
                    return;
                }
                errorProvider1.SetError(textBoxSearchHive, $"No Hive with dwHiveID {id}!");
            }
        }

        private void textBoxsearchTactics_TextChanged(object sender, EventArgs e)
        {
            if (!CheckTextBox(ref textBoxsearchTactics, ref propertyGridviewTactics, ref buttonSelectTactics, out int id))
                return;
            else
            {
                if (PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics.TryGetValue(id, out Tab_RefTactics obj))
                {
                    AssignView(obj, ref propertyGridviewTactics, ref buttonSelectTactics);
                    return;
                }
                errorProvider1.SetError(textBoxsearchTactics, $"No Tactics with dwTacticsID {id}!");
            }
        }

        #endregion TextBox TextChanged

        private void Queries()
        {
            richTextBox1.Clear();

            if (NestUpdater.GenerateQuery(out string str1))
                richTextBox1.Text += $"--Tab_RefNest:\n{str1}\n\n";
            if (HiveUpdater.GenerateQuery(out string str2))
                richTextBox1.Text += $"--Tab_RefHive:\n{str2}\n\n";
            if (TacticsUpdater.GenerateQuery(out string str3))
                richTextBox1.Text += $"--Tab_RefTactics:\n{str3}\n\n";
            if (CommonUpdater.GenerateQuery(out string str4))
                richTextBox1.Text += $"--_RefObjCommon:\n{str4}\n\n";
            if (CharUpdater.GenerateQuery(out string str5))
                richTextBox1.Text += $"--_RefObjChar:\n{str5}\n\n";
        }

        private void SpawnEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NestUpdater.HasUpdates)
            {
                PluginFramework.ClientCore.Send(SpawnEditorPacket.UpdateTabRefNest(CurrentSpawn.Nest));
            }
        }
    }
}