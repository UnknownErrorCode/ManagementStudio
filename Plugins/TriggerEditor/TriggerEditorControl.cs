using ManagementFramework.Network.Security;
using Structs.Tool;
using System.Windows.Forms;

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

        public void InitializePlugin()
        {
            PLUGINDATA = PluginData.TriggerEditor;
            STRING_DLL = "TriggerEditor.dll";
            PluginFramework.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            PluginFramework.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);
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
        }
    }
}