using ManagementFramework.Network.Security;
using Structs.Tool;
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
            foreach (var item in PluginFramework.Database.SRO_VT_SHARD._RefGame_World.Values)
            {
                vSroButtonList1.AddSingleButtonToList(item.WorldCodeName128, item);
            }
            return PacketHandlerResult.Block;
        }

      
        private void vSroButtonList1_OnIndCh(object sender, System.EventArgs e)
        {
            Structs.Database.RefGame_World world = (Structs.Database.RefGame_World)((PluginFramework.BasicControls.vSroListButton)sender).Tag;
            _curGameWorld = new GameWorldProperty();
             foreach (Structs.Database.RefGameWorldBindTriggerCategory item in PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Values)
            {
                if (item.GameWorldID == world.ID)
                {
                    TreeNode node = new TreeNode($"CategoryID:{item.TriggerCategoryID}") { Tag = item };
                    treeViewCategory.Nodes.Add(node);
                    _curGameWorld.bcat.Add(item);

                    foreach (Structs.Database.RefTriggerCategory item2 in PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values)
                    {
                        if (item2.ID == item.TriggerCategoryID)
                            _curGameWorld.cat.Add(item2.ID, item2);
                    }

                }
            }
        }

      

        private void treeViewCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          
        }

        private void treeViewCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            propertyGridTCategory.SelectedObject = _curGameWorld.cat[((Structs.Database.RefGameWorldBindTriggerCategory)treeViewCategory.SelectedNode.Tag).TriggerCategoryID];

            propertyGridTCategory.Refresh();
        }
    }
}