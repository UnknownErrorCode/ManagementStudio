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
    public partial class ShopEditorControl: UserControl
    {
       // private protected readonly string TextUISystemPath = Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, "media", "server_dep", "silkroad", "textuisystem.txt"); 
        
        internal static ServerData StaticData;

        internal ClientDataStorage.Pk2.Pk2Reader MediaPK2;


        public ShopEditorControl(ServerData data)
        {
            InitializeComponent();
            StaticData = data;
        }

        private void InitializeListView()
        {
           // if (File.Exists(TextUISystemPath))
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MediaPK2 = new ClientDataStorage.Pk2.Pk2Reader(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientPath, "Media.pk2"));
            MediaPK2.Read();

            foreach (var item in MediaPK2.GetFolder().subfolders)
            {

            }
            this.listViewAllNpcs.Items.Add("");
        }
    }
}
