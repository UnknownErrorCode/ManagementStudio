using ShopEditor.Interface.ShopInterface;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class SingleTabPageWindow : UserControl
    {
        internal byte PageIndex { get; set; }

        internal ShopGoodWindow[] ShopGoodsOnPage;

        public SingleTabPageWindow(byte page, RefShopGood[] goodsOnPage)
        {
            PageIndex = page;
            ShopGoodsOnPage = new ShopGoodWindow[goodsOnPage.Length] ;
            InitializeComponent();
            InitializeShopGoods(goodsOnPage);
            DrawGoodsOnPage();

        }

        private void InitializeShopGoods(RefShopGood[] goodsOnPage)
        {
            foreach (var item in goodsOnPage)
                ShopGoodsOnPage[item.SlotIndex] = new ShopGoodWindow(item) ;
        }

        private void DrawGoodsOnPage()
        {
            for (int i = 0; i < ShopGoodsOnPage.Length; i++)
            {
                this.Controls.Add(ShopGoodsOnPage[i]);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleTabPageWindow));
            this.SuspendLayout();
            // 
            // SingleTabPageWindow
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.MaximumSize = new System.Drawing.Size(223, 186);
            this.MinimumSize = new System.Drawing.Size(223, 186);
            this.Name = "SingleTabPageWindow";
            this.Size = new System.Drawing.Size(223, 186);
            this.ResumeLayout(false);

        }
    }
}