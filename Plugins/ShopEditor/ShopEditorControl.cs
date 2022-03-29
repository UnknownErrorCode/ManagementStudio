using ServerFrameworkRes.Network.Security;
using System;
using System.Windows.Forms;

namespace ShopEditor
{
    public partial class ShopEditorControl : UserControl
    {
        private const string STRING_DLL = "ShopEditor.dll";

        private new readonly TabPage Parent;

        /// <summary>
        /// The ShopEditor consists of all NPC Shops and the TalkWindow.
        /// </summary>
        /// <param name="data"></param>
        public ShopEditorControl(TabPage page)
        {
            Parent = page;
            InitializeComponent();
            ClientDataStorage.ClientCore.AddEntry(PacketID.Server.PluginDataSent, OnDataReceive);
            ClientDataStorage.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL);
            //ClientDataStorage.ClientMemory.UsedPlugins.Add("ShopEditor.dll");
        }

        private PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            if (arg2.ReadAscii() != STRING_DLL)
            {
                return PacketHandlerResult.Block;
            }
            // Initialize SRO_VT_SHARD for ShopEditor
            ClientDataStorage.Database.SRO_VT_SHARD.InitializeShopEditor();

            Parent.Invoke(new Action(() => Parent.Controls.Add(this)));
            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// initialize the ListView with all aviable NPC context from SRO_VT_SHARD.dbo.Tables["_RefShopGroup"]
        /// </summary>
        private void InitializeListView()
        {
            listViewAllNpcs.Items.Clear();
            foreach (Structs.Database.RefShopGroup item in ClientDataStorage.Database.SRO_VT_SHARD._RefShopGroup)
            {
                if (!listViewAllNpcs.Items.ContainsKey(item.RefNPCCodeName) && (!item.RefNPCCodeName.ToLower().Equals("xxx")))
                {
                    ListViewItem listItem = new ListViewItem(item.RefNPCCodeName);
                    listViewAllNpcs.Items.Add(listItem);
                }
            }
            ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load [{listViewAllNpcs.Items.Count}] Npc Shops.");
        }

        /// <summary>
        /// Action that takes place by click on an NPC element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewAllNpcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count > 0)
            {
                talkWindow1.OnNpcClick(((ListView)sender).SelectedItems[0].Text);
            }
        }

        private void onLoadShops(object sender, EventArgs e)
        {
            InitializeListView();
        }
    }
}