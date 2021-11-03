using Editors.Shop;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class SingleTabPageWindow : UserControl
    {
        /// <summary>
        /// Index of a single GoodsPage inside the Tab.
        /// </summary>
        internal byte PageIndex { get; set; }

        /// <summary>
        /// A Single TabPage window can contain max 30 ShopGood Windows.
        /// </summary>
        internal ShopGoodWindow[] ShopGoodsOnPage;

        public SingleTabPageWindow(byte page, RefShopGood[] goodsOnPage)
        {
            PageIndex = page;
            InitializeComponent();
            InitializeShopGoods(goodsOnPage);
            DrawGoodsOnPage();
        }

        /// <summary>
        /// Initialize all Goods on this Page.
        /// </summary>
        /// <param name="goodsOnPage">Raw goods without UI Elements.</param>
        private void InitializeShopGoods(RefShopGood[] goodsOnPage)
        {
            ShopGoodsOnPage = new ShopGoodWindow[goodsOnPage.Length];
            for (int i = 0; i < goodsOnPage.Length; i++)
                ShopGoodsOnPage[i] = new ShopGoodWindow(goodsOnPage[i]);
        }

        /// <summary>
        /// 
        /// </summary>
        private void DrawGoodsOnPage()
        {
            for (int i = 0; i < ShopGoodsOnPage.Length; i++)
                this.Controls.Add(ShopGoodsOnPage[i]);

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleTabPageWindow));
            this.SuspendLayout();
            // 
            // SingleTabPageWindow
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(223, 186);
            this.MinimumSize = new System.Drawing.Size(223, 186);
            this.Name = "SingleTabPageWindow";
            this.Size = new System.Drawing.Size(223, 186);
            this.ResumeLayout(false);
        }
    }
}