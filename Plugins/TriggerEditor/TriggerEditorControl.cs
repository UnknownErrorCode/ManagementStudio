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
            foreach (var item in ClientFrameworkRes.Database.SRO_VT_SHARD._RefGame_World.Values)
            {
                vSroButtonList1.AddSingleButtonToList(item.WorldCodeName128, item);
            }
            return PacketHandlerResult.Block;
        }

        #endregion Methods

        private void vSroButtonList1_OnIndCh(object sender, System.EventArgs e)
        {
            Structs.Database.RefGame_World world = (Structs.Database.RefGame_World)((ServerFrameworkRes.BasicControls.vSroListButton)sender).Tag;

        }
    }
}