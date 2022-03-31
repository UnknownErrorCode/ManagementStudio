using ServerFrameworkRes.BasicControls;
using Structs.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Editors.Spawn
{
    public partial class SpawnEditor : Form
    {
        #region Property
        /// <summary>
        /// SingleSpawn to update. All displayed informations relates to the CuttentSpawn.
        /// </summary>
        public SingleSpawn CurrentSpawn { get; set; }

        #endregion

        #region Fields

        private protected Dictionary<string, string> NestUpdateValues = new Dictionary<string, string>();
        private protected Dictionary<string, string> HiveUpdateValues = new Dictionary<string, string>();
        private protected Dictionary<string, string> TacticsUpdateValues = new Dictionary<string, string>();
        private protected Dictionary<string, string> ObjCommonUpdateValues = new Dictionary<string, string>();
        private protected Dictionary<string, string> ObjCharUpdateValues = new Dictionary<string, string>();

        #endregion

        public SpawnEditor(SingleSpawn spawn)
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
            if (GenerateQuery("Tab_RefNest", "dwNestID", ((TabRefNest)propertyGrid1.SelectedObject).dwNestID.ToString(), NestUpdateValues, out string query))
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
            if (GenerateQuery("Tab_RefTactics", "dwTacticsID", ((Tab_RefTactics)propertyGrid3.SelectedObject).dwTacticsID.ToString(), TacticsUpdateValues, out string query))
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

        #endregion

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

        #endregion

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
        /// <returns>bool  Weather the Dictionary contains sequence to update the Table.</returns>
        private bool GenerateQuery(string tableName, string identifierColumn, string identifierValue, Dictionary<string, string> dictionary, out string query)
        {
            query = $"Update {tableName} SET";

            if (dictionary.Count == 0)
            {
                return false;
            }

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                query += $" {item.Key} = '{item.Value}',";
            }

            query = query.Remove(query.Length - 1, 1);
            query += $" where {identifierColumn} = '{identifierValue}';";

            return true;
        }
    }
}
