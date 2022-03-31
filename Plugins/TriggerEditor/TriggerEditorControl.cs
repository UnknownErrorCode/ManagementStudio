using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System.Windows.Forms;

namespace TriggerEditor
{
    public partial class TriggerEditorControl : UserControl
    {
        private const string STRING_DLL = "TriggerEditor.dll";
        private const PluginData PLUGINDATA = PluginData.TriggerEditor;

        public TriggerEditorControl()
        {
            InitializeComponent();
            ClientDataStorage.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            ClientDataStorage.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);

        }

        private PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            return PacketHandlerResult.Block;
        }
    }
}
