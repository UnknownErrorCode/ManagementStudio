using PackFile.Media.Textdata;
using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System;
using System.Windows.Forms;

namespace ShopEditor
{
    public partial class ShopEditorControl : UserControl
    {
        #region Fields

        private const PluginData PLUGINDATA = PluginData.ShopEditor;
        private const string STRING_DLL = "ShopEditor.dll";

        internal static TextUISystem StaticTextUISystem;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// The ShopEditor consists of all NPC Shops and the TalkWindow.
        /// </summary>
        /// <param name="data"></param>
        public ShopEditorControl()
        {
            InitializeComponent();
            if (!PackFile.MediaPack.GetTextUISystem(out StaticTextUISystem))
            {
                ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.fatal, "Failed to get textuisystem for ShopEditor.");
            }

            ClientFrameworkRes.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            ClientFrameworkRes.ClientCore.Send(RequestDataPacket);
        }

        #endregion Constructors

        #region Properties

        private Packet RequestDataPacket => ClientFrameworkRes.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);

        #endregion Properties

        #region Methods

        /// <summary>
        /// initialize the ListView with all aviable NPC context from SRO_VT_SHARD.dbo.Tables["_RefShopGroup"]
        /// </summary>
        private void InitializeListView()
        {
            listViewAllNpcs.Items.Clear();
            foreach (Structs.Database.RefShopGroup item in ClientFrameworkRes.Database.SRO_VT_SHARD._RefShopGroup)
            {
                if (!listViewAllNpcs.Items.ContainsKey(item.RefNPCCodeName) && (!item.RefNPCCodeName.ToLower().Equals("xxx")))
                {
                    ListViewItem listItem = new ListViewItem(item.RefNPCCodeName);
                    listViewAllNpcs.Items.Add(listItem);
                }
            }
            ServerFrameworkRes.Log.Logger.WriteLogLine($"Successfully load [{listViewAllNpcs.Items.Count}] Npc Shops.");
        }

        /// <summary>
        /// Action that takes place by click on an NPC element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewAllNpcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count > 0)
                talkWindow1.OnNpcClick(((ListView)sender).SelectedItems[0].Text);
        }

        private PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            if (arg2.ReadAscii() != PLUGINDATA.ToString())
                return PacketHandlerResult.Block;

            Invoke(new Action(() => InitializeListView()));
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}