using ShopEditor.Interface.ShopInterface;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class SingleTabPageWindow : UserControl
    {
        #region Fields

        /// <summary>
        /// A Single TabPage window can contain max 30 ShopGood Windows.
        /// </summary>
        internal ShopGoodWindow[] ShopGoodsOnPage;

        #endregion Fields

        #region Constructors

        public SingleTabPageWindow(byte page, CIShopGood[] goodsOnPage)
        {
            PageIndex = page;
            InitializeComponent();
            InitializeShopGoods(goodsOnPage);
            DrawGoodsOnPage();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Index of a single GoodsPage inside the Tab.
        /// </summary>
        internal byte PageIndex { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        ///
        /// </summary>
        private void DrawGoodsOnPage()
        {
            for (int i = 0; i < ShopGoodsOnPage.Length; i++)
            {
                Controls.Add(ShopGoodsOnPage[i]);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleTabPageWindow));
            SuspendLayout();
            //
            // SingleTabPageWindow
            //
            BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            DoubleBuffered = true;
            MaximumSize = new System.Drawing.Size(223, 186);
            MinimumSize = new System.Drawing.Size(223, 186);
            Name = "SingleTabPageWindow";
            Size = new System.Drawing.Size(223, 186);
            ResumeLayout(false);
        }

        /// <summary>
        /// Initialize all Goods on this Page.
        /// </summary>
        /// <param name="goodsOnPage">Raw goods without UI Elements.</param>
        private void InitializeShopGoods(CIShopGood[] goodsOnPage)
        {
            ShopGoodsOnPage = new ShopGoodWindow[goodsOnPage.Length];
            for (int i = 0; i < goodsOnPage.Length; i++)
            {
                ShopGoodsOnPage[i] = new ShopGoodWindow(goodsOnPage[i]);
            }
        }

        #endregion Methods
    }
}