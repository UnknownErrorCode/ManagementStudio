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
        }


        private void treeViewTriggerViewer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (((TreeView)sender).SelectedNode == null)
                return;

            var index = ((TreeView)sender).SelectedNode.ImageIndex;

            propertyGrid1.SelectedObject = ((TreeView)sender).SelectedNode.Tag;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewTriggerViewer.SelectedNode != null)
            {
                var selectedStruct = treeViewTriggerViewer.SelectedNode.Tag;

                using (TriggerCategoryEditor editor = new TriggerCategoryEditor(selectedStruct, treeViewTriggerViewer.SelectedNode.ImageIndex))
                {
                    editor.ShowDialog();
                }
            }
        }
    }
}