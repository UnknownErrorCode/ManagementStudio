using ManagementFramework.Network.Security;
using Structs.Database;
using Structs.Tool;
using System;
using System.Linq;
using System.Windows.Forms;
using TriggerEditor.PacketFormat;

namespace TriggerEditor
{
    public partial class TriggerEditorControl : UserControl, PluginFramework.BasicControls.IPluginControl
    {
        #region Constructors

        public TriggerEditorControl()
        {
            InitializeComponent();
            InitializePlugin();
        }

        #endregion Constructors

        #region Properties

        public PluginData PLUGINDATA { get; set; }
        public Packet RequestDataPacket => PluginFramework.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);

        public string STRING_DLL { get; set; }

        #endregion Properties

        private Packet RequestUpdateTable()
            => RequestDataPacket;

        #region Methods

        public void InitializePlugin()
        {
            PLUGINDATA = PluginData.TriggerEditor;
            STRING_DLL = "TriggerEditor.dll";
            PluginFramework.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            // Register packet handlers for receiving server responses
            PluginFramework.ClientCore.AddEntry((ushort)PacketID.Client.TriggerEditor_Add_RefTrigger, OnAddRefTriggerResponse);
            PluginFramework.ClientCore.AddEntry((ushort)PacketID.Client.TriggerEditor_Update_RefTrigger, OnUpdateRefTriggerResponse);

            PluginFramework.ClientCore.Send(RequestDataPacket);
            //PluginFramework.ClientCore.Send(RequestDataUpdatePacket);
        }

        private PacketHandlerResult OnUpdateRefTriggerResponse(ServerData serverData, Packet packet)
        {
            MessageBox.Show($"Trigger updated successfully!\nRefreshing", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh the UI if needed
            PluginFramework.ClientCore.Send(RequestDataPacket);

            return PacketHandlerResult.Block; // Block further processing of the packet
        }

        private PacketHandlerResult OnAddRefTriggerResponse(ServerData serverData, Packet packet)
        {
            MessageBox.Show($"Trigger added successfully!\nRefreshing:", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh the UI if needed (example: reload triggers)
            PluginFramework.ClientCore.Send(RequestDataPacket);

            return PacketHandlerResult.Block; // Block further processing of the packet
        }

        public PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            TreeNode treeNew = BuildGameWorldNode();

            TreeNode unlinkedNode = BuildUnlinkedNodes();

            TreeNode unlinkedNode2 = BuildUnlinkedNodes2();

            Invoke(new Action(() =>
            {
                treeViewTriggerViewer.Nodes.Clear();

                foreach (TreeNode item in treeNew.Nodes)
                {
                    treeViewTriggerViewer.Nodes.Add(item);
                    // treeViewGameWorlds.Nodes.Add(item);
                }
                treeViewTriggerViewer.Nodes.Add(unlinkedNode);
                treeViewGameWorlds.Nodes.Clear();

                treeViewGameWorlds.Nodes.Add(unlinkedNode2);
            }));

            return PacketHandlerResult.Block;
        }

        private void AddActionParamToAction(RefTriggerAction triggerAction)
        {
            MessageBox.Show($"Adding an ActionParam to Action: {triggerAction.ParamGroupCodeName128}");
            // Implement event logic here
        }

        private void AddActionToTrigger(RefTrigger trigger)
        {
            MessageBox.Show($"Adding an Action to Trigger: {trigger.CodeName128}");
            // Implement action logic here
        }

        private void AddConditionParamToCondition(RefTriggerCondition triggerCondition)
        {
            MessageBox.Show($"Adding a ConditionParam to Condition: {triggerCondition.ParamGroupCodeName128}");
            // Implement the logic for adding a ConditionParam here
        }

        private void AddConditionToTrigger(RefTrigger trigger)
        {
            MessageBox.Show($"Adding a Condition to Trigger: {trigger.CodeName128}");
            // Implement condition logic here
        }

        private void AddEventToTrigger(RefTrigger trigger)
        {
            MessageBox.Show($"Adding an Event to Trigger: {trigger.CodeName128}");
            // Implement event logic here
        }

        private TreeNode BuildGameWorldNode()
        {
            TreeNode serverNode = new TreeNode("ManagementStudioClient");
            foreach (var gWorld in PluginFramework.Database.SRO_VT_SHARD._RefGame_World.Values)
            {
                TreeNode worldNode = new TreeNode($"ID: {gWorld.ID} Name: {gWorld.WorldCodeName128}")
                {
                    Tag = gWorld,
                    ImageIndex = 0
                };

                // Pre-group data for fast access
                var gameWorldCategories = PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Values
                    .GroupBy(gbc => gbc.GameWorldID)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var triggerCategories = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values
                    .ToDictionary(cat => cat.ID, cat => cat);

                var categoryTriggers = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values
                    .GroupBy(cbt => cbt.TriggerCategoryID)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var triggers = PluginFramework.Database.SRO_VT_SHARD._RefTrigger.Values
                    .ToDictionary(t => t.ID, t => t);

                var triggerEvents = PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindEvent.Values
                    .GroupBy(be => be.TriggerID)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var triggerConditions = PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindCondition.Values
                    .GroupBy(bc => bc.TriggerID)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var triggerActions = PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindAction.Values
                    .GroupBy(ba => ba.TriggerID)
                    .ToDictionary(g => g.Key, g => g.ToList());

                // Get Categories for this GameWorld
                if (gameWorldCategories.TryGetValue(gWorld.ID, out var categoryBinds))
                {
                    foreach (var categoryBind in categoryBinds)
                    {
                        if (triggerCategories.TryGetValue(categoryBind.TriggerCategoryID, out var category))
                        {
                            TreeNode categoryNode = new TreeNode($"{category.CodeName128}")
                            {
                                Tag = category,
                                ImageIndex = 1,
                                SelectedImageIndex = 1
                            };

                            // Triggers for this Category
                            if (categoryTriggers.TryGetValue(category.ID, out var triggersForCategory))
                            {
                                foreach (var triggerBind in triggersForCategory)
                                {
                                    if (triggers.TryGetValue(triggerBind.TriggerID, out var trigger))
                                    {
                                        TreeNode triggerNode = new TreeNode(trigger.CodeName128)
                                        {
                                            Tag = trigger,
                                            ImageIndex = 2,
                                            SelectedImageIndex = 2
                                        };

                                        // Events for this Trigger
                                        if (triggerEvents.TryGetValue(trigger.ID, out var eventsForTrigger))
                                        {
                                            foreach (var triggerEventBind in eventsForTrigger)
                                            {
                                                var triggerEvent = PluginFramework.Database.SRO_VT_SHARD._RefTriggerEvent[triggerEventBind.TriggerEventID];
                                                var eventCommon = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCommon[triggerEvent.RefTriggerCommonID];

                                                TreeNode eventNode = new TreeNode($"EventID: {triggerEvent.ID} - {eventCommon.CodeName128}")
                                                {
                                                    Tag = triggerEvent,
                                                    ImageIndex = 3,
                                                    SelectedImageIndex = 3
                                                };

                                                triggerNode.Nodes.Add(eventNode);
                                            }
                                        }

                                        // Conditions for this Trigger
                                        if (triggerConditions.TryGetValue(trigger.ID, out var conditionsForTrigger))
                                        {
                                            foreach (var conditionBind in conditionsForTrigger)
                                            {
                                                var condition = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCondition[conditionBind.TriggerConditionID];
                                                var conditionCommon = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCommon[condition.RefTriggerCommonID];

                                                TreeNode conditionNode = new TreeNode($"Condition: {condition.ID} --> {conditionCommon.CodeName128}")
                                                {
                                                    Tag = condition,
                                                    ImageIndex = 4,
                                                    SelectedImageIndex = 4
                                                };

                                                // Add Condition Parameters
                                                if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerConditionParam.Values.Any(param => param.GroupCodeName128 == condition.ParamGroupCodeName128))
                                                {
                                                    foreach (var conditionParam in PluginFramework.Database.SRO_VT_SHARD._RefTriggerConditionParam.Values.Where(param => param.GroupCodeName128 == condition.ParamGroupCodeName128))
                                                    {
                                                        TreeNode conditionParamNode = new TreeNode($"ParamID: {conditionParam.ID}")
                                                        {
                                                            Tag = conditionParam,
                                                            ImageIndex = 6,
                                                            SelectedImageIndex = 6
                                                        };

                                                        conditionNode.Nodes.Add(conditionParamNode);
                                                    }
                                                }

                                                triggerNode.Nodes.Add(conditionNode);
                                            }
                                        }

                                        // Actions for this Trigger
                                        if (triggerActions.TryGetValue(trigger.ID, out var actionsForTrigger))
                                        {
                                            foreach (var actionBind in actionsForTrigger)
                                            {
                                                var action = PluginFramework.Database.SRO_VT_SHARD._RefTriggerAction[actionBind.TriggerActionID];

                                                TreeNode actionNode = new TreeNode($"ActionID: {action.ID}  --> {action.ParamGroupCodeName128}")
                                                {
                                                    Tag = action,
                                                    ImageIndex = 5,
                                                    SelectedImageIndex = 5
                                                };

                                                // Add Action Parameters
                                                if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerActionParam.Values.Any(param => param.GroupCodeName128 == action.ParamGroupCodeName128))
                                                {
                                                    foreach (var actionParam in PluginFramework.Database.SRO_VT_SHARD._RefTriggerActionParam.Values.Where(param => param.GroupCodeName128 == action.ParamGroupCodeName128))
                                                    {
                                                        TreeNode actionParamNode = new TreeNode($"ActionParamID: {actionParam.ID}")
                                                        {
                                                            Tag = actionParam,
                                                            ImageIndex = 6,
                                                            SelectedImageIndex = 6
                                                        };

                                                        actionNode.Nodes.Add(actionParamNode);
                                                    }
                                                }

                                                triggerNode.Nodes.Add(actionNode);
                                            }
                                        }

                                        categoryNode.Nodes.Add(triggerNode);
                                    }
                                }
                            }

                            worldNode.Nodes.Add(categoryNode);
                        }
                    }
                }
                serverNode.Nodes.Add(worldNode);
            }

            return serverNode;
        }

        private TreeNode BuildUnlinkedNodes()
        {
            TreeNode unlinkedRootNode = new TreeNode("Not Used Nodes");

            // Not Used Categories
            TreeNode unlinkedCategoriesNode = new TreeNode("Not Used Categories") { ImageIndex = 0 };
            var unlinkedCategories = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values
                .Where(category => !PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values
                    .Any(bind => bind.TriggerCategoryID == category.ID && bind.Service == 1))
                .ToList();

            foreach (var category in unlinkedCategories)
            {
                unlinkedCategoriesNode.Nodes.Add(new TreeNode($"{category.CodeName128}")
                {
                    Tag = category,
                    ImageIndex = 1,
                    SelectedImageIndex = 1
                });
            }
            unlinkedRootNode.Nodes.Add(unlinkedCategoriesNode);

            // Not Used Actions
            TreeNode unlinkedActionsNode = new TreeNode("Not Used Actions") { ImageIndex = 0 };
            var unlinkedActions = PluginFramework.Database.SRO_VT_SHARD._RefTriggerAction.Values
                .Where(action => !PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindAction.Values
                    .Any(bind => bind.TriggerActionID == action.ID && bind.Service == 1))
                .ToList();

            foreach (var action in unlinkedActions)
            {
                TreeNode actionNode = new TreeNode($"ActionID: {action.ID}  --> {action.ParamGroupCodeName128}")
                {
                    Tag = action,
                    ImageIndex = 2,
                    SelectedImageIndex = 2
                };

                // Add Unlinked Action Parameters
                var actionParams = PluginFramework.Database.SRO_VT_SHARD._RefTriggerActionParam.Values
                    .Where(param => param.GroupCodeName128 == action.ParamGroupCodeName128)
                    .ToList();

                foreach (var param in actionParams)
                {
                    actionNode.Nodes.Add(new TreeNode($"ActionParamID: {param.ID} --> {param.ValueCodeName128}")
                    {
                        Tag = param,
                        ImageIndex = 3,
                        SelectedImageIndex = 3
                    });
                }

                unlinkedActionsNode.Nodes.Add(actionNode);
            }
            unlinkedRootNode.Nodes.Add(unlinkedActionsNode);

            // Not Used Conditions
            TreeNode unlinkedConditionsNode = new TreeNode("Not Used Conditions") { ImageIndex = 0 };
            var unlinkedConditions = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCondition.Values
                .Where(condition => !PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindCondition.Values
                    .Any(bind => bind.TriggerConditionID == condition.ID && bind.Service == 1))
                .ToList();

            foreach (var condition in unlinkedConditions)
            {
                TreeNode conditionNode = new TreeNode($"Condition: {condition.ID} --> {condition.ParamGroupCodeName128}")
                {
                    Tag = condition,
                    ImageIndex = 3,
                    SelectedImageIndex = 3
                };

                // Add Unlinked Condition Parameters
                var conditionParams = PluginFramework.Database.SRO_VT_SHARD._RefTriggerConditionParam.Values
                    .Where(param => param.GroupCodeName128 == condition.ParamGroupCodeName128)
                    .ToList();

                foreach (var param in conditionParams)
                {
                    conditionNode.Nodes.Add(new TreeNode($"ConditionParamID: {param.ID} --> {param.ValueCodeName128}")
                    {
                        Tag = param,
                        ImageIndex = 4,
                        SelectedImageIndex = 4
                    });
                }

                unlinkedConditionsNode.Nodes.Add(conditionNode);
            }
            unlinkedRootNode.Nodes.Add(unlinkedConditionsNode);

            // Not Used Events
            TreeNode unlinkedEventsNode = new TreeNode("Not Used Events") { ImageIndex = 0 };
            var unlinkedEvents = PluginFramework.Database.SRO_VT_SHARD._RefTriggerEvent.Values
                .Where(triggerEvent => !PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindEvent.Values
                    .Any(bind => bind.TriggerEventID == triggerEvent.ID && bind.Service == 1))
                .ToList();

            foreach (var triggerEvent in unlinkedEvents)
            {
                var eventCommon = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCommon[triggerEvent.RefTriggerCommonID];
                unlinkedEventsNode.Nodes.Add(new TreeNode($"EventID: {triggerEvent.ID} --> {eventCommon.CodeName128}")
                {
                    Tag = triggerEvent,
                    ImageIndex = 5,
                    SelectedImageIndex = 5
                });
            }
            unlinkedRootNode.Nodes.Add(unlinkedEventsNode);

            // Not Used Triggers
            TreeNode unlinkedTriggersNode = new TreeNode("Not Used Triggers") { ImageIndex = 0 };
            var unlinkedTriggers = PluginFramework.Database.SRO_VT_SHARD._RefTrigger.Values
                .Where(trigger =>
                    !PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Any(bind => bind.TriggerID == trigger.ID && bind.Service == 1)
                     )
                .ToList();

            foreach (var trigger in unlinkedTriggers)
            {
                unlinkedTriggersNode.Nodes.Add(new TreeNode($"TriggerID: {trigger.ID} - {trigger.CodeName128}")
                {
                    Tag = trigger,
                    ImageIndex = 6,
                    SelectedImageIndex = 6
                });
            }
            unlinkedRootNode.Nodes.Add(unlinkedTriggersNode);

            return unlinkedRootNode;
        }

        private TreeNode BuildUnlinkedNodes2()
        {
            TreeNode unlinkedRootNode = new TreeNode("Not Used Nodes");

            // Not Used Categories
            TreeNode unlinkedCategoriesNode = new TreeNode("Not Used Categories") { ImageIndex = 0 };
            foreach (var category in PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values)
            {
                if (!PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Any(bind => bind.TriggerCategoryID == category.ID))
                {
                    unlinkedCategoriesNode.Nodes.Add(new TreeNode($"{category.CodeName128}")
                    {
                        Tag = category,
                        ImageIndex = 1,
                        SelectedImageIndex = 1
                    });
                }
            }
            unlinkedRootNode.Nodes.Add(unlinkedCategoriesNode);

            // Not Used Actions
            TreeNode unlinkedActionsNode = new TreeNode("Not Used Actions") { ImageIndex = 0 };
            foreach (var action in PluginFramework.Database.SRO_VT_SHARD._RefTriggerAction.Values)
            {
                if (!PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindAction.Values.Any(bind => bind.TriggerActionID == action.ID && bind.Service == 1))
                {
                    unlinkedActionsNode.Nodes.Add(new TreeNode($"ActionID: {action.ID}  --> {action.ParamGroupCodeName128}")
                    {
                        Tag = action,
                        ImageIndex = 2,
                        SelectedImageIndex = 2
                    });
                }
            }
            unlinkedRootNode.Nodes.Add(unlinkedActionsNode);

            // Not Used Conditions
            TreeNode unlinkedConditionsNode = new TreeNode("Not Used Conditions") { ImageIndex = 0 };
            foreach (var condition in PluginFramework.Database.SRO_VT_SHARD._RefTriggerCondition.Values)
            {
                if (!PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindCondition.Values.Any(bind => bind.TriggerConditionID == condition.ID))
                {
                    TreeNode conditionNode = new TreeNode($"Condition: {condition.ID} --> {condition.ParamGroupCodeName128}")
                    {
                        Tag = condition,
                        ImageIndex = 3,
                        SelectedImageIndex = 3
                    };

                    // Add Unlinked Condition Parameters
                    foreach (var conditionParam in PluginFramework.Database.SRO_VT_SHARD._RefTriggerConditionParam.Values.Where(param => param.GroupCodeName128 == condition.ParamGroupCodeName128))
                    {
                        conditionNode.Nodes.Add(new TreeNode($"ConditionParamID: {conditionParam.ID}")
                        {
                            Tag = conditionParam,
                            ImageIndex = 4,
                            SelectedImageIndex = 4
                        });
                    }

                    unlinkedConditionsNode.Nodes.Add(conditionNode);
                }
            }
            unlinkedRootNode.Nodes.Add(unlinkedConditionsNode);

            // Not Used Events
            TreeNode unlinkedEventsNode = new TreeNode("Not Used Events") { ImageIndex = 0 };
            foreach (var triggerEvent in PluginFramework.Database.SRO_VT_SHARD._RefTriggerEvent.Values)
            {
                if (!PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindEvent.Values.Any(bind => bind.TriggerEventID == triggerEvent.ID))
                {
                    var eventCommon = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCommon[triggerEvent.RefTriggerCommonID];
                    unlinkedEventsNode.Nodes.Add(new TreeNode($"EventID: {triggerEvent.ID} --> {eventCommon.CodeName128}")
                    {
                        Tag = triggerEvent,
                        ImageIndex = 5,
                        SelectedImageIndex = 5
                    });
                }
            }
            unlinkedRootNode.Nodes.Add(unlinkedEventsNode);

            return unlinkedRootNode;
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

        private TreeNode GetTriggerViewOld()
        {
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

            return tree;
        }

        // Link actions
        private void LinkCategoryToGameWorld(RefGame_World gameWorld)
        {
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(new EditorLayouts.UCAddCategoryToWorld(gameWorld) { Dock = DockStyle.Fill });
            MessageBox.Show($"Linking a Category to GameWorld: {gameWorld.WorldCodeName128}");
            // Implement the logic for linking a category to this game world
        }

        private void LinkTriggerToCategory(RefTriggerCategory triggerCategory)
        {
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(new EditorLayouts.AddTriggerToCategory(triggerCategory) { Dock = DockStyle.Fill });

            MessageBox.Show($"Linking a Trigger to Category '{triggerCategory.CodeName128}'.");
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            editToolStripMenuItem.Enabled = true;
        }

        private void propertyGridStructEditor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            saveToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void SetupActionMenu(RefTriggerAction triggerAction)
        {
            var editActionItem = new ToolStripMenuItem("ActionParam");
            editActionItem.Click += (s, e) => AddActionParamToAction(triggerAction);

            addToolStripMenuItem.DropDownItems.Add(editActionItem);
        }

        private void SetupConditionMenu(RefTriggerCondition triggerCondition)
        {
            // Add menu option: ConditionParam
            var conditionParamMenuItem = new ToolStripMenuItem("ConditionParam");
            conditionParamMenuItem.Click += (s, e) => AddConditionParamToCondition(triggerCondition);

            // Add the single item to the context menu
            addToolStripMenuItem.DropDownItems.Add(conditionParamMenuItem);
        }

        // Default menu setup
        private void SetupDefaultMenu()
        {
            var defaultItem = new ToolStripMenuItem("Default Action");
            defaultItem.Click += (s, e) => MessageBox.Show("No specific object selected.");
            addToolStripMenuItem.DropDownItems.Add(defaultItem);
        }

        private void SetupEventMenu(RefTriggerEvent triggerEvent)
        {
        }

        private void SetupGameWorldMenu(RefGame_World gameWorld)
        {
            // Add menu option: Category
            var categoryMenuItem = new ToolStripMenuItem("Category");
            categoryMenuItem.Click += (s, e) => LinkCategoryToGameWorld(gameWorld);

            // Add the single item to the context menu
            addToolStripMenuItem.DropDownItems.Add(categoryMenuItem);
        }

        // Menu for Trigger Category
        private void SetupTriggerCategoryMenu(RefTriggerCategory triggerCategory)
        {
            var triggerToCategoryItem = new ToolStripMenuItem("Trigger to Category");
            triggerToCategoryItem.Click += (s, e) => LinkTriggerToCategory(triggerCategory);

            addToolStripMenuItem.DropDownItems.Add(triggerToCategoryItem);
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

        private void treeViewGameWorlds_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((TreeView)sender).SelectedNode == null)
                return;

            var index = ((TreeView)sender).SelectedNode.ImageIndex;

            propertyGridStructEditor.SelectedObject = ((TreeView)sender).SelectedNode.Tag;
            saveToolStripMenuItem.Enabled = false;
        }

        private void treeViewTriggerViewer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((TreeView)sender).SelectedNode == null)
                return;

            var index = ((TreeView)sender).SelectedNode.ImageIndex;

            propertyGrid1.SelectedObject = ((TreeView)sender).SelectedNode.Tag;
            editToolStripMenuItem.Enabled = false;
        }

        #endregion Methods
    }
}