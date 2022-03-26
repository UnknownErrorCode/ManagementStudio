using System;
using System.Data;
using System.Windows.Forms;

namespace ShopEditor
{
    public partial class ShopEditorControl : UserControl
    {


        /// <summary>
        /// The ShopEditor consists of all NPC Shops and the TalkWindow.
        /// </summary>
        /// <param name="data"></param>
        public ShopEditorControl()
        {
            InitializeComponent();
            ClientDataStorage.Network.ClientCore.RequestPluginDataTable("ShopEditor.dll");
            //ClientDataStorage.ClientMemory.UsedPlugins.Add("ShopEditor.dll");
        }

        /// <summary>
        /// initialize the ListView with all aviable NPC context from SRO_VT_SHARD.dbo.Tables["_RefShopGroup"]
        /// </summary>
        private void InitializeListView()
        {
            listViewAllNpcs.Items.Clear();
            DataRowCollection test = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows;
            foreach (DataRow item in test)
            {
                if (!listViewAllNpcs.Items.ContainsKey(item.Field<string>("RefNPCCodeName")) && (!item.Field<string>("RefNPCCodeName").ToLower().Equals("xxx")))
                {
                    ListViewItem listItem = new ListViewItem(item.Field<string>("RefNPCCodeName")) { };
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
                talkWindow1.OnNpcClick(((ListView)sender).SelectedItems[0].Text);
        }

        private void onLoadShops(object sender, EventArgs e)
        {
            InitializeListView();
        }
    }
}
