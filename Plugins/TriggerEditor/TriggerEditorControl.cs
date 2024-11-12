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

        GameWorldProperty _curGameWorld = new GameWorldProperty();


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
                TreeNode node1 = new TreeNode($"ID: {gWorld.ID} Name: {gWorld.WorldCodeName128}") {Tag = gWorld };

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
                                TreeNode categoryNode = new TreeNode($"{category.CodeName128}") { Tag = category };

                                if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Any(cbt => cbt.TriggerCategoryID == category.ID))
                                {
                                    var catBindTr = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Where(cbt => cbt.TriggerCategoryID == category.ID);
                                   
                                    foreach (var catBind in catBindTr)
                                    {
                                        if (PluginFramework.Database.SRO_VT_SHARD._RefTrigger.Values.Any(t => t.ID == catBind.TriggerID))
                                        {
                                            var tri = PluginFramework.Database.SRO_VT_SHARD._RefTrigger.Values.Single(t => t.ID == catBind.TriggerID);
                                            categoryNode.Nodes.Add(new TreeNode(tri.CodeName128) { Tag = tri });
                                        }
                                    }
                                
                                }
                                node1.Nodes.Add(categoryNode);


                            }

                        }
                    }
                }

                tree.Nodes.Add(node1);


            }



            Invoke(new Action(() =>
            {
                treeViewTriggerViewer.Nodes.Add(tree);
                foreach (var item in PluginFramework.Database.SRO_VT_SHARD._RefGame_World.Values)
                {
                    treeViewGameWorlds.Nodes.Add(new TreeNode($"{item.WorldCodeName128}") { Tag = item });
                   // treeViewTriggerViewer.Nodes.Add(new TreeNode($"{item.WorldCodeName128}") { Tag = item });
                }
            }));
              
            return PacketHandlerResult.Block;
        }

      
        private void vSroButtonList1_OnIndCh(object sender, System.EventArgs e)
        {
           
        }

      

        private void treeViewCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          
        }

        private void treeViewCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            propertyGridTCategory.SelectedObject = ((Structs.Database.RefTriggerCategory)treeViewCategory.SelectedNode.Tag);
            propertyGridTrigger.SelectedObject = null;

            propertyGridTriggerEvent.SelectedObject = null;
            treeViewTrigger.Nodes.Clear();
            foreach (var item in _curGameWorld.cat[((Structs.Database.RefTriggerCategory)treeViewCategory.SelectedNode.Tag)])
            {
                treeViewTrigger.Nodes.Add(new TreeNode($"TriggerID: {item.ID}") {Tag= item });
            }
            
            propertyGridTCategory.Refresh();
            propertyGridTrigger.Refresh();
            propertyGridTriggerEvent.Refresh();

        }

        private void treeViewGameWorlds_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeViewCategory.Nodes.Clear();
            treeViewTrigger.Nodes.Clear();
            propertyGridTCategory.SelectedObject = null;
            propertyGridTCategory.Refresh();
            propertyGridTriggerEvent.SelectedObject = null;
            propertyGridTriggerEvent.Refresh();
            propertyGridTrigger.SelectedObject = null;
            propertyGridTrigger.Refresh();
            Structs.Database.RefGame_World world = (Structs.Database.RefGame_World)((TreeView)sender).SelectedNode.Tag;
            _curGameWorld = new GameWorldProperty(world);

            foreach (Structs.Database.RefTriggerCategory ite in _curGameWorld.cat.Keys)
            {
                TreeNode node = new TreeNode($"CategoryID:{ite.ID}") { Tag = ite };
                treeViewCategory.Nodes.Add(node);
            }
        }

        private void treeViewTriggerViewer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var test = treeViewTriggerViewer.SelectedNode.Level;
           //Structs.Database.RefGame_World world = (Structs.Database.RefGame_World)((TreeView)sender).SelectedNode.Tag;
           //
           //_curGameWorld = new GameWorldProperty(world);
        }

        private void treeViewTrigger_AfterSelect(object sender, TreeViewEventArgs e)
        {
            propertyGridTrigger.SelectedObject = (RefTrigger)treeViewTrigger.SelectedNode.Tag;
            propertyGridTrigger.Refresh();

            var tID = ((RefTrigger)treeViewTrigger.SelectedNode.Tag).ID;
            if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindEvent.Values.Any(tbe => tbe.TriggerID == tID))
            {
                var boundEvent = PluginFramework.Database.SRO_VT_SHARD._RefTriggerBindEvent.Values.Single(tbe => tbe.TriggerID == tID);


                propertyGridTriggerEvent.SelectedObject = (RefTriggerBindEvent)boundEvent;
                propertyGridTriggerEvent.Refresh();
            }

        }
    }
}