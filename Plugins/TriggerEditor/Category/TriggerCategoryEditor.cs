using PluginFramework.Database;
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

namespace TriggerEditor.Category
{
    public partial class TriggerCategoryEditor : Form
    {


        protected DbQueryGenerator TriggerUpdater;
        protected DbQueryGenerator TriggerActionUpdater;
        protected DbQueryGenerator TriggerConditionUpdater;
        protected DbQueryGenerator TriggerEventUpdater;
        protected DbQueryGenerator TriggerCategoryUpdater;
        protected DbQueryGenerator TriggerCategoryBindTriggerUpdater;
        protected DbQueryGenerator TriggerActionParamUpdater;
        protected DbQueryGenerator TriggerConditionParamUpdater;
        protected DbQueryGenerator GameWorldUpdater;
        protected DbQueryGenerator GameWorldBindTriggerCategoryUpdater;


        public TriggerCategoryEditor()
        {
            InitializeComponent();
        }

        public TriggerCategoryEditor(object sender, int index)
        {
            InitializeComponent();
            //Task.Run(InitializeEditor);
            propertyGridEditor.SelectedObject = sender;
            InitializeUpdater(sender);
        }

        void InitializeUpdater(object selectedObject)
        {
            if (selectedObject is RefTrigger trigger)
            {
                TriggerUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTrigger", "ID", trigger.ID.ToString());
            }
            else if (selectedObject is RefTriggerAction action)
            {
                TriggerActionUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTriggerAction", "ID", action.ID.ToString());
            }
            else if (selectedObject is RefTriggerCondition condition)
            {
                TriggerConditionUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTriggerCondition", "ID", condition.ID.ToString());
            }
            else if (selectedObject is RefTriggerEvent triggerEvent)
            {
                TriggerEventUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTriggerEvent", "ID", triggerEvent.ID.ToString());
            }
            else if (selectedObject is RefTriggerCategory category)
            {
                TriggerCategoryUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTriggerCategory", "ID", category.ID.ToString());
            }
            else if (selectedObject is RefTriggerCategoryBindTrigger categoryBindTrigger)
            {
                TriggerCategoryBindTriggerUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTriggerCategoryBindTrigger", "ID", categoryBindTrigger.ID.ToString());
            }
            else if (selectedObject is RefTriggerActionParam actionParam)
            {
                TriggerActionParamUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTriggerActionParam", "ID", actionParam.ID.ToString());
            }
            else if (selectedObject is RefTriggerConditionParam conditionParam)
            {
                TriggerConditionParamUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefTriggerConditionParam", "ID", conditionParam.ID.ToString());
            }
            else if (selectedObject is RefGame_World gameWorld)
            {
                GameWorldUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefGame_World", "ID", gameWorld.ID.ToString());
            }
            else if (selectedObject is RefGameWorldBindTriggerCategory gameWorldBind)
            {
                GameWorldBindTriggerCategoryUpdater = new PluginFramework.Database.DbQueryGenerator(
                    "_RefGameWorldBindTriggerCategory", "ID", gameWorldBind.ID.ToString());
            }
        }

        private bool InitializeEditor()
        {

            TreeNode tree = new TreeNode("World");
            foreach (RefGame_World gWorld in PluginFramework.Database.SRO_VT_SHARD._RefGame_World.Values)
            {
                TreeNode node1 = new TreeNode($"ID: {gWorld.ID} Name: {gWorld.WorldCodeName128}") { Tag = gWorld, ImageIndex = 0 };

                if (PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Values.Any(gbc => gbc.GameWorldID == gWorld.ID))
                {
                    var categorieBinds = (PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Values.Where(gbc => gbc.GameWorldID == gWorld.ID));

                    foreach (var categoryBind in categorieBinds)
                    {
                        if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values.Any(gbc => gbc.ID == categoryBind.TriggerCategoryID))
                        {
                            var categories = (PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values.Where(gbc => gbc.ID == categoryBind.TriggerCategoryID));

                            foreach (var category in categories)
                            {
                                TreeNode categoryNode = new TreeNode($"{category.CodeName128}") { Tag = category, ImageIndex = 1, SelectedImageIndex = 1 };
                                if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Any(cbt => cbt.TriggerCategoryID == category.ID))
                                {
                                    var catBindTr = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Where(cbt => cbt.TriggerCategoryID == category.ID);

                                    foreach (var catBind in catBindTr)
                                    {
                                        if (PluginFramework.Database.SRO_VT_SHARD._RefTrigger.Values.Any(t => t.ID == catBind.TriggerID))
                                        {
                                            var tri = PluginFramework.Database.SRO_VT_SHARD._RefTrigger.Values.Single(t => t.ID == catBind.TriggerID);
                                            var triNode = new TreeNode(tri.CodeName128) { Tag = tri, ImageIndex = 2, SelectedImageIndex = 2 };


                                            if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindEvent.Values.Any(bindEvent => bindEvent.TriggerID == tri.ID))
                                            {
                                                foreach (var triBindEvent in PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindEvent.Values.Where(bindEvent => bindEvent.TriggerID == tri.ID))
                                                {
                                                    var triEvent = PluginFramework.Database.SRO_VT_SHARD._RefTriggerEvent.Values.Single(t => t.ID == triBindEvent.TriggerEventID);
                                                    var triEventCommon = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCommon[triEvent.RefTriggerCommonID];
                                                    var triEventNode = new TreeNode($"EventID: {triEvent.ID} - {triEventCommon.CodeName128}") { Tag = triEvent, ImageIndex = 3, SelectedImageIndex = 3 };
                                                    triNode.Nodes.Add(triEventNode);
                                                }
                                            }


                                            if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindCondition.Values.Any(bindCondition => bindCondition.TriggerID == tri.ID))
                                            {
                                                foreach (var triBindCond in PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindCondition.Values.Where(bindEvent => bindEvent.TriggerID == tri.ID))
                                                {
                                                    var triCondition = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCondition[triBindCond.TriggerConditionID];//.Values.Single(t => t.ID == triBindCond.TriggerConditionID);

                                                    var triConditionNode = new TreeNode($"Condition: {triCondition.ID} --> {PluginFramework.Database.SRO_VT_SHARD._RefTriggerCommon[triCondition.RefTriggerCommonID].CodeName128}")
                                                    {
                                                        Tag = triCondition,
                                                        ImageIndex = 4,
                                                        SelectedImageIndex = 4
                                                    };

                                                    // Add Condition Parameters (Filtered by GroupCodeName128)
                                                    if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerConditionParam.Values.Any(param => param.GroupCodeName128 == triCondition.ParamGroupCodeName128))
                                                    {
                                                        foreach (var conditionParam in PluginFramework.Database.SRO_VT_SHARD._RefTriggerConditionParam.Values.Where(param => param.GroupCodeName128 == triCondition.ParamGroupCodeName128))
                                                        {
                                                            var conditionParamNode = new TreeNode($"ParamID: {conditionParam.ID}")
                                                            {
                                                                Tag = conditionParam,
                                                                ImageIndex = 6,
                                                                SelectedImageIndex = 6
                                                            };


                                                            triConditionNode.Nodes.Add(conditionParamNode);
                                                        }
                                                    }

                                                    triNode.Nodes.Add(triConditionNode);
                                                }
                                            }

                                            // Handle BindTriggerAction
                                            if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindAction.Values.Any(bindAction => bindAction.TriggerID == tri.ID))
                                            {
                                                foreach (var triBindAction in PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindAction.Values.Where(bindAction => bindAction.TriggerID == tri.ID))
                                                {
                                                    var triAction = PluginFramework.Database.SRO_VT_SHARD._RefTriggerAction.Values.Single(action => action.ID == triBindAction.TriggerActionID);

                                                    var triActionNode = new TreeNode($"ActionID: {triAction.ID}  --> {triAction.ParamGroupCodeName128} --> {triAction.RefTriggerCommonID}")
                                                    {
                                                        Tag = triAction,
                                                        ImageIndex = 5,
                                                        SelectedImageIndex = 5
                                                    };
                                                    // Add Action Parameters
                                                    if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerActionParam.Values.Any(param => param.GroupCodeName128 == triAction.ParamGroupCodeName128))
                                                    {
                                                        foreach (var actionParam in PluginFramework.Database.SRO_VT_SHARD._RefTriggerActionParam.Values.Where(param => param.GroupCodeName128 == triAction.ParamGroupCodeName128))
                                                        {
                                                            var actionParamNode = new TreeNode($"ActionParamID: {actionParam.ID}")
                                                            {
                                                                Tag = actionParam,
                                                                ImageIndex = 6,
                                                                SelectedImageIndex = 6
                                                            };
                                                            triActionNode.Nodes.Add(actionParamNode);
                                                        }
                                                    }
                                                    triNode.Nodes.Add(triActionNode);
                                                }
                                            }

                                            //TODO: Actions, Conditions 
                                            categoryNode.Nodes.Add(triNode);
                                        }
                                    }
                                }
                                node1.Nodes.Add(categoryNode);
                            }
                        }
                        else
                        {
                            ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.loading, $"Loading _RefTriggerCategory for catID{categoryBind.TriggerCategoryID} failed");
                        }
                    }
                }
                tree.Nodes.Add(node1);
            }


            Invoke(new Action(() =>
            {

                foreach (TreeNode item in tree.Nodes)
                {
                    treeViewHierarchy.Nodes.Add(item);
                }

            }));

            return true;
        }



        private void onPropertyChanged(object s, PropertyValueChangedEventArgs e)
        {
            var selectedObject = propertyGridEditor.SelectedObject;

            if (selectedObject is RefTrigger trigger)
            {

                TriggerUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                TriggerUpdater.GenerateQuery(out string query);
                ManagementFramework.Log.Logger.WriteLogLine(
                   ManagementFramework.Ressources.LogLevel.sql,
                   $"Generated Query: {query}");
            }
            else if (selectedObject is RefTriggerAction action)
            {
                // Initialize and update TriggerActionUpdater
                TriggerActionUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                TriggerActionUpdater.GenerateQuery(out string query);
                ManagementFramework.Log.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.sql,
                    $"Generated Query: {query}");
            }
            else if (selectedObject is RefTriggerCondition condition)
            {
                TriggerConditionUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());

                // Optionally generate and log query
                TriggerConditionUpdater.GenerateQuery(out string query);
                ManagementFramework.Log.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.sql,
                    $"Generated Query: {query}");
            }
            else if (selectedObject is RefTriggerEvent triggerEvent)
            {
                TriggerEventUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());

                // Optionally generate and log query
                TriggerEventUpdater.GenerateQuery(out string query);
                ManagementFramework.Log.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.sql,
                    $"Generated Query: {query}");
            }
            else if (selectedObject is RefTriggerCategory category)
            {
                TriggerCategoryUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                TriggerCategoryUpdater.GenerateQuery(out string query);
                ManagementFramework.Log.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.sql,
                    $"Generated Query: {query}");
            }
            else if (selectedObject is RefTriggerCategoryBindTrigger categoryBindTrigger)
            {
                TriggerCategoryBindTriggerUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                TriggerCategoryBindTriggerUpdater.GenerateQuery(out string query);
            }
            else if (selectedObject is RefTriggerActionParam actionParam)
            {
                TriggerActionParamUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                TriggerActionParamUpdater.GenerateQuery(out string query);
            }
            else if (selectedObject is RefTriggerConditionParam conditionParam)
            {
                TriggerConditionParamUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                TriggerConditionParamUpdater.GenerateQuery(out string query);
            }
            else if (selectedObject is RefGame_World gameWorld)
            {
                GameWorldUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                GameWorldUpdater.GenerateQuery(out string query);
            }
            else if (selectedObject is RefGameWorldBindTriggerCategory gameWorldBind)
            {
                GameWorldBindTriggerCategoryUpdater.UpdateObject(e.ChangedItem.Label, e.ChangedItem.Value.ToString());
                GameWorldBindTriggerCategoryUpdater.GenerateQuery(out string query);
            }
            toolStripStatusLabel.Text = "Change tracked. Don't forget to save!";
        }

        private void treeViewHierarchy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            propertyGridEditor.SelectedObject = treeViewHierarchy.SelectedNode.Tag;
            var selectedObject = propertyGridEditor.SelectedObject;
            

        }

    }
}
