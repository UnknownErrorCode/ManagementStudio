using ClientDataStorage.Client;
using Structs.Pk2.Media;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class BlueShopTabWindow : Panel
    {
        private bool onFocus = false;
        internal bool Active { get => onFocus; set { onFocus = value; this.BackgroundImage = value ? ClientDataStorage.Client.Media.DDJFiles["Media\\interface\\ifcommon\\com_tab_on.ddj"].BitmapImage : ClientDataStorage.Client.Media.DDJFiles["Media\\interface\\ifcommon\\com_tab_off.ddj"].BitmapImage; } }
        private ShopInterface.RefShopTab TabPage { get; set; }
        internal Label StrIDLabel { get; set; }

        internal SingleTabPageWindow[] SingleTabPages;


        internal BlueShopTabWindow(ShopInterface.RefShopTab page, byte index)
            => InitializeComponents(page, index);

        private void InitializeComponents(ShopInterface.RefShopTab page, byte index)
        {
            TabPage = page;
            this.DoubleBuffered = true;
            this.Size = new Size(60, 24);
            this.Location = new Point(6 + ((index) * 60 +1), 34);
            
            if (TabPage.ShopGoods != null)
                GenerateSingleTabPages();

            StrIDLabel = new Label() { Text = page.StrID128Name , Tag = this, Location = new Point(4,4), BackColor = Color.Transparent};
            if (Media.StaticTextuiSystem.UIIT_Strings.TryGetValue(page.StrID128Name, out TextUISystemStruct str))
                StrIDLabel.Text = str.Viethnam;

            this.Controls.Add(StrIDLabel);
        }

        private void GenerateSingleTabPages()
        {

            if (Enumerable.Range(0, 30).Contains(TabPage.ShopGoods.Length-1))
                SingleTabPages = new SingleTabPageWindow[1] { new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()) };
            else if (Enumerable.Range(30, 29).Contains(TabPage.ShopGoods.Length-1))
                SingleTabPages = new SingleTabPageWindow[2]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray())
                };
            else if (Enumerable.Range(60, 29).Contains(TabPage.ShopGoods.Length-1))
                SingleTabPages = new SingleTabPageWindow[3]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray()),
                    new SingleTabPageWindow(3, TabPage.ShopGoods.Where(val => val.SlotIndex < 90 && val.SlotIndex >= 60).ToArray())
                };
            else if (Enumerable.Range(90, 29).Contains(TabPage.ShopGoods.Length-1))
                SingleTabPages = new SingleTabPageWindow[4]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray()),
                    new SingleTabPageWindow(3, TabPage.ShopGoods.Where(val => val.SlotIndex < 90 && val.SlotIndex >= 60).ToArray()),
                    new SingleTabPageWindow(4, TabPage.ShopGoods.Where(val => val.SlotIndex < 120 && val.SlotIndex >= 90).ToArray())
                };
            else if (Enumerable.Range(120, 29).Contains(TabPage.ShopGoods.Length-1))
                SingleTabPages = new SingleTabPageWindow[5]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray()),
                    new SingleTabPageWindow(3, TabPage.ShopGoods.Where(val => val.SlotIndex < 90 && val.SlotIndex >= 60).ToArray()),
                    new SingleTabPageWindow(4, TabPage.ShopGoods.Where(val => val.SlotIndex < 120 && val.SlotIndex >= 90).ToArray()),
                    new SingleTabPageWindow(5, TabPage.ShopGoods.Where(val => val.SlotIndex < 150 && val.SlotIndex >= 120).ToArray())
                };
            else if (Enumerable.Range(150, 29).Contains(TabPage.ShopGoods.Length-1))
                SingleTabPages = new SingleTabPageWindow[6]
                {
                     new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                     new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray()),
                     new SingleTabPageWindow(3, TabPage.ShopGoods.Where(val => val.SlotIndex < 90 && val.SlotIndex >= 60).ToArray()),
                     new SingleTabPageWindow(4, TabPage.ShopGoods.Where(val => val.SlotIndex < 120 && val.SlotIndex >= 90).ToArray()),
                     new SingleTabPageWindow(5, TabPage.ShopGoods.Where(val => val.SlotIndex < 150 && val.SlotIndex >= 120).ToArray()),
                     new SingleTabPageWindow(6, TabPage.ShopGoods.Where(val => val.SlotIndex < 180 && val.SlotIndex >= 150).ToArray())
                };
        }
    }
}