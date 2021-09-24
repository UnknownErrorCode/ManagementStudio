using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class ShopTabWindow : Panel
    {
        internal bool Active { get; set; }
        private ShopInterface.RefShopTab TabPage { get; set; }

        internal SingleTabPageWindow[] Pages;


        internal ShopTabWindow(ShopInterface.RefShopTab page)
        {
            TabPage = page;
            this.Size = new Size(72, 24);
            this.Location = new Point(15 + ((page.TabPageIndex - 1) * 72), 34);
            ForeColor = Color.Transparent;
            Image img = ClientDataStorage.Client.Media.DDJFiles["Media\\interface\\ifcommon\\ifcommon\\com_long_tab_off.ddj"].BitmapImage;
           
            this.BackgroundImage = img;
            if (TabPage.ShopGoods == null)
                return;

            if (Enumerable.Range(0, 29).Contains(TabPage.ShopGoods.Length))
            {
                Pages = new SingleTabPageWindow[1] { new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()) };
            }
            else if (Enumerable.Range(30, 29).Contains(TabPage.ShopGoods.Length))
            {
                Pages = new SingleTabPageWindow[2]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray())
                };
            }
            else if (Enumerable.Range(60, 29).Contains(TabPage.ShopGoods.Length))
            {
                Pages = new SingleTabPageWindow[3]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray()),
                    new SingleTabPageWindow(3, TabPage.ShopGoods.Where(val => val.SlotIndex < 90 && val.SlotIndex >= 60).ToArray())
                };
            }
            else if (Enumerable.Range(90, 29).Contains(TabPage.ShopGoods.Length))
            {
                Pages = new SingleTabPageWindow[4]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray()),
                    new SingleTabPageWindow(3, TabPage.ShopGoods.Where(val => val.SlotIndex < 90 && val.SlotIndex >= 60).ToArray()),
                    new SingleTabPageWindow(4, TabPage.ShopGoods.Where(val => val.SlotIndex < 120 && val.SlotIndex >= 90).ToArray())
                };
            }
            else if (Enumerable.Range(120, 29).Contains(TabPage.ShopGoods.Length))
            {
                Pages = new SingleTabPageWindow[5]
                {
                    new SingleTabPageWindow(1, TabPage.ShopGoods.Where(val => val.SlotIndex < 30).ToArray()),
                    new SingleTabPageWindow(2, TabPage.ShopGoods.Where(val => val.SlotIndex < 60 && val.SlotIndex >= 30).ToArray()),
                    new SingleTabPageWindow(3, TabPage.ShopGoods.Where(val => val.SlotIndex < 90 && val.SlotIndex >= 60).ToArray()),
                    new SingleTabPageWindow(4, TabPage.ShopGoods.Where(val => val.SlotIndex < 120 && val.SlotIndex >= 90).ToArray()),
                    new SingleTabPageWindow(5, TabPage.ShopGoods.Where(val => val.SlotIndex < 150 && val.SlotIndex >= 120).ToArray())
                };
            }
            else if (Enumerable.Range(150, 29).Contains(TabPage.ShopGoods.Length))
            {
                Pages = new SingleTabPageWindow[6]
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
}