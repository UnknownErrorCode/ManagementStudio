using ClientDataStorage.Client.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    public partial class ShopTabGroupWindow : Form
    {
        private ShopTabWindow[] ShopTabs = new ShopTabWindow[6];


        internal ShopTabGroupWindow(ShopInterface.RefShopTabGroup shopTabGroup)
        {
            InitializeComponent();

            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey("Media\\interface\\ifcommon\\ifcommon\\com_long_tab_on.ddj"))
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory("Media\\interface\\ifcommon\\ifcommon\\com_long_tab_on.ddj", out byte[] ddjbytearray))
                    ClientDataStorage.Client.Media.DDJFiles.Add("Media\\interface\\ifcommon\\ifcommon\\com_long_tab_on.ddj", new DDJImage(ddjbytearray));

            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey("Media\\interface\\ifcommon\\ifcommon\\com_long_tab_off.ddj"))
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory("Media\\interface\\ifcommon\\ifcommon\\com_long_tab_off.ddj", out byte[] ddjbytearray2))
                    ClientDataStorage.Client.Media.DDJFiles.Add("Media\\interface\\ifcommon\\ifcommon\\com_long_tab_off.ddj", new DDJImage(ddjbytearray2));

            foreach (var tab in shopTabGroup.ShopTabs)
                ShopTabs[tab.TabPageIndex-1] = new ShopTabWindow(tab);

            foreach (var tabWindow in ShopTabs)
            {
                this.Controls.Add(tabWindow);
            }
        }
    }
}
