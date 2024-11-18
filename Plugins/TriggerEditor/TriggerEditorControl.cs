using ManagementFramework;
using ManagementFramework.Network.Security;
using Structs.Database;
using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TriggerEditor.Category;
using TriggerEditor.PacketFormat;
using static System.Net.Mime.MediaTypeNames;

namespace TriggerEditor
{
    public partial class TriggerEditorControl : UserControl, PluginFramework.BasicControls.IPluginControl
    {
        public TriggerEditorControl()
        {
            InitializeComponent();
            InitializePlugin();
        }

        public PluginData PLUGINDATA { get; set; }
        public Packet RequestDataPacket => PluginFramework.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);
        
        
        
        public string STRING_DLL { get; set; }

        GameWorldProperty _curGameWorld;


        public void InitializePlugin()
        {
            PLUGINDATA = PluginData.TriggerEditor;
            STRING_DLL = "TriggerEditor.dll";
            PluginFramework.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            PluginFramework.ClientCore.Send(RequestDataPacket);
        }

        public PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            treeViewTriggerViewer.Nodes.Clear();
            TreeNode tree = new TreeNode(STRING_DLL);
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
                    treeViewTriggerViewer.Nodes.Add(item);
                    // treeViewGameWorlds.Nodes.Add(item);
                }

                foreach (var item in PluginFramework.Database.SRO_VT_SHARD._RefGame_World.Values)
                {
                    treeViewGameWorlds.Nodes.Add(new TreeNode($"{item.WorldCodeName128}") { Tag = item });
                }
            }));

            return PacketHandlerResult.Block;
        }



        private void treeViewGameWorlds_AfterSelect(object sender, TreeViewEventArgs e)
        {


        }

        private void treeViewTriggerViewer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((TreeView)sender).SelectedNode == null)
                return;

            var index = ((TreeView)sender).SelectedNode.ImageIndex;

            propertyGrid1.SelectedObject = ((TreeView)sender).SelectedNode.Tag;
            editToolStripMenuItem.Enabled = false;
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewTriggerViewer.SelectedNode != null)
            {
                var selectedStruct = treeViewTriggerViewer.SelectedNode.Tag;

                if (selectedStruct is RefTrigger trigger)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefTrigger(trigger));
                }
                else if (selectedStruct is RefTriggerAction action)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefTriggerAction(action));
                }
                else if (selectedStruct is RefTriggerCondition condition)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefTriggerCondition(condition));
                }
                else if (selectedStruct is RefTriggerEvent triggerEvent)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefTriggerEvent(triggerEvent));
                }
                else if (selectedStruct is RefTriggerCategory category)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefTriggerCategory(category));
                }
                else if (selectedStruct is RefTriggerActionParam actionParam)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefTriggerActionParam(actionParam));
                }
                else if (selectedStruct is RefTriggerConditionParam conditionParam)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefTriggerConditionParam(conditionParam));
                }
                else if (selectedStruct is RefGame_World gameWorld)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefGameWorld(gameWorld));
                }
                else if (selectedStruct is RefGameWorldBindTriggerCategory bindCategory)
                {
                    PluginFramework.ClientCore.Send(TriggerEditorPacket.UpdateRefGameWorldBindTriggerCategory(bindCategory));
                }
                else
                {
                    MessageBox.Show("Unsupported node type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No node selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void contextMenuStripTriggerEditor_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Get the selected node's associated object
            var selectedStruct = treeViewTriggerViewer.SelectedNode?.Tag;
            addToolStripMenuItem.DropDownItems.Clear();

            if (selectedStruct == null)
            {
                e.Cancel = true; // No object selected; cancel the menu
                return;
            }

            // Handle menu creation based on the selected object type
            switch (selectedStruct)
            {
                case RefGame_World gameWorld:
                    SetupGameWorldMenu(gameWorld);
                    break;
                case RefTrigger trigger:
                    SetupTriggerMenu(trigger);
                    break;

                case RefTriggerCategory triggerCategory:
                    SetupTriggerCategoryMenu(triggerCategory);
                    break;

                case RefTriggerAction triggerAction:
                    SetupActionMenu(triggerAction);
                    break;

                case RefTriggerCondition triggerCondition:
                    SetupConditionMenu(triggerCondition);
                    break;

                case RefTriggerEvent triggerEvent:
                    SetupEventMenu(triggerEvent);
                    break;

                default:
                    SetupDefaultMenu();
                    break;
            }
        }

        private void SetupGameWorldMenu(RefGame_World gameWorld)
        {
            // Add menu option: Category
            var categoryMenuItem = new ToolStripMenuItem("Category");
            categoryMenuItem.Click += (s, e) => LinkCategoryToGameWorld(gameWorld);

            // Add the single item to the context menu
            addToolStripMenuItem.DropDownItems.Add(categoryMenuItem);
        }

        private void SetupConditionMenu(RefTriggerCondition triggerCondition)
        {
            // Add menu option: ConditionParam
            var conditionParamMenuItem = new ToolStripMenuItem("ConditionParam");
            conditionParamMenuItem.Click += (s, e) => AddConditionParamToCondition(triggerCondition);

            // Add the single item to the context menu
            addToolStripMenuItem.DropDownItems.Add(conditionParamMenuItem);
        }

        private void SetupEventMenu(RefTriggerEvent triggerEvent)
        {
          
        }

        private void SetupTriggerMenu(RefTrigger trigger)
        {
            // Add "Condition," "Action," and "Event" options
            var conditionMenuItem = new ToolStripMenuItem("Condition");
            conditionMenuItem.Click += (s, e) => AddConditionToTrigger(trigger);

            var actionMenuItem = new ToolStripMenuItem("Action");
            actionMenuItem.Click += (s, e) => AddActionToTrigger(trigger);

            var eventMenuItem = new ToolStripMenuItem("Event");
            eventMenuItem.Click += (s, e) => AddEventToTrigger(trigger);

            // Add items to the context menu
            addToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            addToolStripMenuItem.DropDownItems.Add(conditionMenuItem);
            addToolStripMenuItem.DropDownItems.Add(actionMenuItem);
            addToolStripMenuItem.DropDownItems.Add(eventMenuItem);
        }

        private void SetupActionMenu(RefTriggerAction triggerAction)
        {
            var editActionItem = new ToolStripMenuItem("ActionParam");
            editActionItem.Click += (s, e) => AddActionParamToAction(triggerAction);

            addToolStripMenuItem.DropDownItems.Add(editActionItem);
        }


        // Menu for Trigger Category
        private void SetupTriggerCategoryMenu(RefTriggerCategory triggerCategory)
        {
            var categoryToGameWorldItem = new ToolStripMenuItem("Category to GameWorld");
            categoryToGameWorldItem.Click += (s, e) => LinkCategoryToGameWorld(triggerCategory);

            var triggerToCategoryItem = new ToolStripMenuItem("Trigger to Category");
            triggerToCategoryItem.Click += (s, e) => LinkTriggerToCategory(triggerCategory);

            addToolStripMenuItem.DropDownItems.Add(categoryToGameWorldItem);
            addToolStripMenuItem.DropDownItems.Add(triggerToCategoryItem);
        }




        // Default menu setup
        private void SetupDefaultMenu()
        {
            var defaultItem = new ToolStripMenuItem("Default Action");
            defaultItem.Click += (s, e) => MessageBox.Show("No specific object selected.");
            addToolStripMenuItem.DropDownItems.Add(defaultItem);
        }

        // Link actions
        private void LinkCategoryToGameWorld(RefTriggerCategory triggerCategory)
        {
            MessageBox.Show($"Linking Category '{triggerCategory.CodeName128}' to GameWorld.");
        }

        private void LinkTriggerToCategory(RefTriggerCategory triggerCategory)
        {
            MessageBox.Show($"Linking a Trigger to Category '{triggerCategory.CodeName128}'.");
        }

        private void LinkCategoryToGameWorld(RefGame_World gameWorld)
        {
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(new EditorLayouts.UserControlAddCategoryToWorld(gameWorld) { Dock = DockStyle.Fill});
            MessageBox.Show($"Linking a Category to GameWorld: {gameWorld.WorldCodeName128}");
            // Implement the logic for linking a category to this game world
        }


        private void AddConditionToTrigger(RefTrigger trigger)
        {
            MessageBox.Show($"Adding a Condition to Trigger: {trigger.CodeName128}");
            // Implement condition logic here
        }

        private void AddActionToTrigger(RefTrigger trigger)
        {
            MessageBox.Show($"Adding an Action to Trigger: {trigger.CodeName128}");
            // Implement action logic here
        }

        private void AddEventToTrigger(RefTrigger trigger)
        {
            MessageBox.Show($"Adding an Event to Trigger: {trigger.CodeName128}");
            // Implement event logic here
        }

        private void AddActionParamToAction(RefTriggerAction triggerAction)
        {
            MessageBox.Show($"Adding an ActionParam to Action: {triggerAction.ParamGroupCodeName128}");
            // Implement event logic here
        }
        private void AddConditionParamToCondition(RefTriggerCondition triggerCondition)
        {
            MessageBox.Show($"Adding a ConditionParam to Condition: {triggerCondition.ParamGroupCodeName128}");
            // Implement the logic for adding a ConditionParam here
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            editToolStripMenuItem.Enabled = true;
           
        }
    }
}