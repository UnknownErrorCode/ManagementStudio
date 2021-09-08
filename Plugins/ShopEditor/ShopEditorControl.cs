using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.IO;

namespace ShopEditor
{
    public partial class ShopEditorControl : UserControl
    {
        // private protected readonly string TextUISystemPath = Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, "media", "server_dep", "silkroad", "textuisystem.txt"); 

        internal static ServerData StaticData;

        public ShopEditorControl(ServerData data)
        {
            InitializeComponent();
            StaticData = data;
            InitializeListView();
        }

        private void InitializeListView()
        {
            DataRowCollection test = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows;
            foreach (DataRow item in test)
            {
                if (!listViewAllNpcs.Items.ContainsKey(item.Field<string>("RefNPCCodeName")) && (!item.Field<string>("RefNPCCodeName").ToLower().Equals("xxx")))
                {
                    ListViewItem listItem = new ListViewItem(item.Field<string>("RefNPCCodeName")) { };
                    listViewAllNpcs.Items.Add(listItem);
                }
            }
        }

        private void listViewAllNpcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count>0)
                talkWindow1.OnNpcClick(((ListView)sender).SelectedItems[0].Text);

        }
    }
}
