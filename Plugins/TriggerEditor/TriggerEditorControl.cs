using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System.Windows.Forms;

namespace TriggerEditor
{
    public partial class TriggerEditorControl : UserControl
    {
        #region Fields

        private const PluginData PLUGINDATA = PluginData.TriggerEditor;
        private const string STRING_DLL = "TriggerEditor.dll";

        #endregion Fields

        #region Constructors

        public TriggerEditorControl()
        {
            InitializeComponent();
            ClientFrameworkRes.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            ClientFrameworkRes.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);
        }

        #endregion Constructors

        #region Methods

        private PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}