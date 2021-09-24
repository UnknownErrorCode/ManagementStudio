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
        private ShopTabWindow[] ShopTabs { get; set; }



        internal ShopTabGroupWindow(ShopInterface.RefShopTabGroup shopTabGroup)
        {
            InitializeComponent();

            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey("Media\\interface\\ifcommon\\com_tab_on.ddj"))
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory("Media\\interface\\ifcommon\\com_tab_on.ddj", out byte[] ddjbytearray))
                    ClientDataStorage.Client.Media.DDJFiles.Add("Media\\interface\\ifcommon\\com_tab_on.ddj", new DDJImage(ddjbytearray));

            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey("Media\\interface\\ifcommon\\com_tab_off.ddj"))
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory("Media\\interface\\ifcommon\\com_tab_off.ddj", out byte[] ddjbytearray2))
                    ClientDataStorage.Client.Media.DDJFiles.Add("Media\\interface\\ifcommon\\com_tab_off.ddj", new DDJImage(ddjbytearray2));

            ShopTabs = new ShopTabWindow[shopTabGroup.ShopTabs.Length];
      
            for (int i = 0; i < shopTabGroup.ShopTabs.Length; i++)
                ShopTabs[i] = new ShopTabWindow(shopTabGroup.ShopTabs[i], (byte)i);

            foreach (var tabWindow in ShopTabs)
            {
                if (tabWindow == null)
                    return;

                tabWindow.MouseClick += TabWindow_MouseClick;
                this.Controls.Add(tabWindow);
            }
        }

        private void TabWindow_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ShopTabs.Length; i++)
                ShopTabs[i].Active = false;
            
            ((ShopTabWindow)sender).Active = true;

            

            this.panelCurrentPage.Controls.Clear();
            if (((ShopTabWindow)sender).Pages.Length>0)
            {
                this.panelCurrentPage.Controls.Add(((ShopTabWindow)sender).Pages[0]);
                this.label1.Text = ((ShopTabWindow)sender).Pages[0].PageIndex.ToString();
                return;
            }
            this.label1.Text = "0";
        }
    }
}
