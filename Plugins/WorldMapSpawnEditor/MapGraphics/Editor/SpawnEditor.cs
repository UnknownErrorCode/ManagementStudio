using PluginFramework.BasicControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Structs.Database;

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

        protected Dictionary<string, string> NestUpdateValues = new Dictionary<string, string>();
        protected Dictionary<string, string> HiveUpdateValues = new Dictionary<string, string>();
        protected Dictionary<string, string> TacticsUpdateValues = new Dictionary<string, string>();
        protected Dictionary<string, string> ObjCommonUpdateValues = new Dictionary<string, string>();
        protected Dictionary<string, string> ObjCharUpdateValues = new Dictionary<string, string>();

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
            propertyGrid1.SelectedObject = CurrentSpawn.Nest;
            propertyGrid2.SelectedObject = CurrentSpawn.Hive;
            propertyGrid3.SelectedObject = CurrentSpawn.Tactics;
            propertyGrid4.SelectedObject = CurrentSpawn.ObjCommon;
            propertyGrid5.SelectedObject = CurrentSpawn.ObjChar;
            propertyGrid1.Refresh();
            propertyGrid2.Refresh();
            propertyGrid3.Refresh();
            propertyGrid4.Refresh();
            propertyGrid5.Refresh();
        }

        /// <summary>
        /// Shows the Update Query prepared for MS SQL Server Management Studio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Show Query Click Voids

        private void ShowNestUpdate(object sender, EventArgs e)
        {
            if (GenerateQuery("Tab_RefNest", "dwNestID", ((TabRefNest)propertyGrid1.SelectedObject).DwNestID.ToString(), NestUpdateValues, out string query))
            {
                vSroMessageBox.Show(query);
            }
        }

        private void ShowUpdateHive(object sender, EventArgs e)
        {
            if (GenerateQuery("Tab_RefHive", "dwHiveID", ((Tab_RefHive)propertyGrid2.SelectedObject).dwHiveID.ToString(), HiveUpdateValues, out string query))
            {
                vSroMessageBox.Show(query);
            }
        }

        private void ShowUpdateTactics(object sender, EventArgs e)
        {
            if (GenerateQuery("Tab_RefTactics", "dwTacticsID", ((Tab_RefTactics)propertyGrid3.SelectedObject).DwTacticsID.ToString(), TacticsUpdateValues, out string query))
            {
                vSroMessageBox.Show(query);
            }
        }

        private void ShowUpdateCommon(object sender, EventArgs e)
        {
            if (GenerateQuery("_RefObjCommon", "ID", ((RefObjCommon)propertyGrid4.SelectedObject).ID.ToString(), ObjCommonUpdateValues, out string query))
            {
                vSroMessageBox.Show(query);
            }
        }

        private void ShowUpdateChar(object sender, EventArgs e)
        {
            if (GenerateQuery("_RefObjChar", "ID", ((RefObjChar)propertyGrid5.SelectedObject).ID.ToString(), ObjCharUpdateValues, out string query))
            {
                vSroMessageBox.Show(query);
            }
        }

        #endregion Show Query Click Voids

        /// <summary>
        /// Appends the changes from the different PropertyGrids into the Update List. This is required to update changed values only.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>

        #region Property Grid Change Void

        private void ChangeNestValue(object s, PropertyValueChangedEventArgs e)
        {
            UpdateObject(ref NestUpdateValues, e.ChangedItem.Label, e.ChangedItem.Value.ToString());
        }

        private void ChangeHive(object s, PropertyValueChangedEventArgs e)
        {
            UpdateObject(ref HiveUpdateValues, e.ChangedItem.Label, e.ChangedItem.Value.ToString());
        }

        private void ChangeTacticsValue(object s, PropertyValueChangedEventArgs e)
        {
            UpdateObject(ref TacticsUpdateValues, e.ChangedItem.Label, e.ChangedItem.Value.ToString());
        }

        private void ChangeObjCommonValue(object s, PropertyValueChangedEventArgs e)
        {
            UpdateObject(ref ObjCommonUpdateValues, e.ChangedItem.Label, e.ChangedItem.Value.ToString());
        }

        private void ChangeObjChar(object s, PropertyValueChangedEventArgs e)
        {
            UpdateObject(ref ObjCharUpdateValues, e.ChangedItem.Label, e.ChangedItem.Value.ToString());
        }

        #endregion Property Grid Change Void

        /// <summary>
        /// Stores the update values and columns inside a Dictionary to avoid updating non changed values.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        private void UpdateObject(ref Dictionary<string, string> dictionary, string column, string value)
        {
            if (!dictionary.ContainsKey(column))
            {
                dictionary.Add(column, value);
            }
            else
            {
                dictionary[column] = value;
            }
        }

        /// <summary>
        /// Generates the query from Dictionary.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="identifierColumn"></param>
        /// <param name="identifierValue"></param>
        /// <param name="dictionary"></param>
        /// <param name="query"></param>
        /// <returns> <see cref="bool"/>
        /// <br>Weather the Dictionary contains sequence to update the Table.</br></returns>
        private bool GenerateQuery(string tableName, string identifierColumn, string identifierValue, Dictionary<string, string> dictionary, out string query)
        {
            query = $"Update {tableName} SET";

            if (dictionary.Count == 0)
                return false;

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                query += $" [{item.Key}] = '{item.Value}',";
            }

            query = query.Remove(query.Length - 1, 1);
            query += $" where [{identifierColumn}] = '{identifierValue}';";

            return true;
        }

        private void buttonSelectNewPosition_Click(object sender, EventArgs e)
        {
            if (GenericSelectForm.SelectObjStruct(PositionStorage.Collection, out NewPosition pos))
            {
                CurrentSpawn.Nest.NRegionDBID = pos.RegionID.RegionID;
                CurrentSpawn.Nest.FLocalPosX = pos.Position.X;
                CurrentSpawn.Nest.FLocalPosZ = pos.Position.Z;
                CurrentSpawn.Nest.FLocalPosY = pos.Position.Y;
                propertyGrid1.SelectedObject = CurrentSpawn.Nest;

                if (NestUpdateValues.ContainsKey("nRegionDBID"))
                    NestUpdateValues["nRegionDBID"] = $"{pos.RegionID.RegionID}";
                else
                    NestUpdateValues.Add("nRegionDBID", $"{pos.RegionID.RegionID}");

                if (NestUpdateValues.ContainsKey("fLocalPosX"))
                    NestUpdateValues["fLocalPosX"] = $"{pos.Position.X}";
                else
                    NestUpdateValues.Add("fLocalPosX", $"{pos.Position.X}");

                if (NestUpdateValues.ContainsKey("fLocalPosZ"))
                    NestUpdateValues["fLocalPosZ"] = $"{pos.Position.Z}";
                else
                    NestUpdateValues.Add("fLocalPosZ", $"{pos.Position.Z}");

                if (NestUpdateValues.ContainsKey("fLocalPosY"))
                    NestUpdateValues["fLocalPosY"] = $"{pos.Position.Y}";
                else
                    NestUpdateValues.Add("fLocalPosY", $"{pos.Position.Y}");
            }
        }

        private void buttonSelectHive_Click(object sender, EventArgs e)
        {
            if (GenericSelectForm.SelectObjStruct(PluginFramework.Database.SRO_VT_SHARD.Tab_RefHive, out Structs.Database.Tab_RefHive hive))
            {
                CurrentSpawn.Hive = hive;
                CurrentSpawn.Nest.DwHiveID = hive.dwHiveID;
                propertyGrid1.SelectedObject = CurrentSpawn.Nest;
                propertyGrid2.SelectedObject = CurrentSpawn.Hive;
                if (NestUpdateValues.ContainsKey("dwHiveID"))
                    NestUpdateValues["dwHiveID"] = $"{hive.dwHiveID}";
                else
                    NestUpdateValues.Add("dwHiveID", $"{hive.dwHiveID}");
            }
        }

        private void SpawnEditor_Load(object sender, EventArgs e)
        {
        }

        private void buttonSelectTactics_Click(object sender, EventArgs e)
        {
            if (GenericSelectForm.SelectObjStruct(PluginFramework.Database.SRO_VT_SHARD.Tab_RefTactics, out Tab_RefTactics outer))
            {
                CurrentSpawn.Tactics = outer;
                CurrentSpawn.Nest.DwTacticsID = outer.DwTacticsID;
                propertyGrid1.SelectedObject = CurrentSpawn.Nest;
                propertyGrid3.SelectedObject = CurrentSpawn.Tactics;

                if (NestUpdateValues.ContainsKey("dwTacticsID"))
                    NestUpdateValues["dwTacticsID"] = $"{outer.DwTacticsID}";
                else
                    NestUpdateValues.Add("dwTacticsID", $"{outer.DwTacticsID}");
            }
        }

        private void buttonselectcommon_Click(object sender, EventArgs e)
        {
            if (GenericSelectForm.SelectObjStruct(PluginFramework.Database.SRO_VT_SHARD._RefObjCommon, out RefObjCommon outer))
            {
                CurrentSpawn.ObjCommon = outer;
                CurrentSpawn.Tactics.DwObjID = outer.ID;
                propertyGrid3.SelectedObject = CurrentSpawn.Tactics;
                propertyGrid4.SelectedObject = CurrentSpawn.ObjCommon;

                if (TacticsUpdateValues.ContainsKey("dwObjID"))
                    TacticsUpdateValues["dwObjID"] = $"{outer.ID}";
                else
                    TacticsUpdateValues.Add("dwObjID", $"{outer.ID}");
            }
        }
    }
}