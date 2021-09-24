using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class ShopTabWindow : Panel
    {
        private bool active;
        internal bool Active { get => active; set { active = value;  this.BackgroundImage = value ? ClientDataStorage.Client.Media.DDJFiles["Media\\interface\\ifcommon\\com_tab_on.ddj"].BitmapImage : ClientDataStorage.Client.Media.DDJFiles["Media\\interface\\ifcommon\\com_tab_off.ddj"].BitmapImage; } }
        private ShopInterface.RefShopTab TabPage { get; set; }

        internal SingleTabPageWindow[] Pages;
        internal ShopTabWindow()
        {
        }

            internal ShopTabWindow(ShopInterface.RefShopTab page, byte index)
        {
            TabPage = page;
            this.Size = new Size(60, 24);
            this.Location = new Point(6 + ((index) * 60), 34);
            ForeColor = Color.Transparent;
            Active = false;
            if (TabPage.ShopGoods == null)
            { 
                Pages= new SingleTabPageWindow[0]; return;
            }

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