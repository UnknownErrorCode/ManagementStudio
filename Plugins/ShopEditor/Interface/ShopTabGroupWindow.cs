using BinaryFiles.PackFile;
using ShopEditor.Interface.ShopInterface;
using System.Linq;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    public partial class ShopTabGroupWindow : Form
    {
        #region Fields

        protected const string TabOffUIPath = "Media\\interface\\ifcommon\\com_tab_off.ddj";
        protected const string TabOnUIPath = "Media\\interface\\ifcommon\\com_tab_on.ddj";
        private readonly BlueShopTabWindow[] ShopBlueTabWindows;

        #endregion Fields

        #region Constructors

        internal ShopTabGroupWindow(RefShopTabGroup shopTabGroup)
        {
            InitializeComponent();
            InitializeUIElements(shopTabGroup.StrID128Name);
            if (GenerateShopTabWindows(shopTabGroup, out ShopBlueTabWindows))
            {
                Controls.AddRange(ShopBlueTabWindows);
            }

            DisplaySingleTabPage(ShopBlueTabWindows[0], CurrentPageIndex);
        }

        #endregion Constructors

        #region Properties

        public byte CurrentPageIndex { get => byte.Parse(labelPageIndex.Text); set => labelPageIndex.Text = $"{value}"; }
        public string ShopTitle { get => labelShopTabGroup.Text; set => labelShopTabGroup.Text = value; }
        private BlueShopTabWindow DisplayedBlueTab { get; set; }

        #endregion Properties

        #region Methods

        private void DisabeTabFocus()
        {
            ShopBlueTabWindows.ToList().ForEach(tw => tw.Active = false);
        }

        private void DisplaySingleTabPage(BlueShopTabWindow window, byte page)
        {
            DisabeTabFocus();
            window.Active = true;
            panelCurrentPage.Controls.Clear();
            DisplayedBlueTab = window;
            if (DisplayedBlueTab.SingleTabPages != null)
            {
                if (DisplayedBlueTab.SingleTabPages.Length > 0)
                {
                    panelCurrentPage.Controls.Add(DisplayedBlueTab.SingleTabPages[page]);
                }
            }

            CurrentPageIndex = DisplayedBlueTab.SingleTabPages != null ? DisplayedBlueTab.SingleTabPages.Length > 0 ? DisplayedBlueTab.SingleTabPages[page].PageIndex : page : (byte)0;
        }

        private bool GenerateShopTabWindows(RefShopTabGroup shopTabGroup, out BlueShopTabWindow[] shopTabWindows)
        {
            shopTabWindows = new BlueShopTabWindow[shopTabGroup.ShopTabs.Length];

            for (int i = 0; i < shopTabGroup.ShopTabs.Length; i++)
            {
                shopTabWindows[i] = new BlueShopTabWindow(shopTabGroup.ShopTabs[i], (byte)i);
            }

            foreach (BlueShopTabWindow tabWindow in ShopBlueTabWindows)
            {
                if (tabWindow != null)
                {
                    tabWindow.MouseClick += TabWindow_MouseClick;
                    tabWindow.StrIDLabel.MouseClick += TabWindow_onLabelClick;
                }
            }

            return shopTabWindows[0].SingleTabPages != null;
        }

        private void InitializeUIElements(string title)
        {
            //ShopTitle = Media.StaticTextuiSystem.UIIT_Strings.TryGetValue(title, out TextUISystemStruct str) ? str.Viethnam : title;

            CurrentPageIndex = 0;
            if (!PackFile.MediaPack.DDJFiles.ContainsKey(TabOnUIPath))
            {
                if (PackFile.MediaPack.Reader.GetByteArrayByDirectory(TabOnUIPath, out byte[] ddjbytearray))
                {
                    PackFile.MediaPack.DDJFiles.Add(TabOnUIPath, new JMXddjFile(ddjbytearray));
                }
            }

            if (!PackFile.MediaPack.DDJFiles.ContainsKey(TabOffUIPath))
            {
                if (PackFile.MediaPack.Reader.GetByteArrayByDirectory(TabOffUIPath, out byte[] ddjbytearray2))
                {
                    PackFile.MediaPack.DDJFiles.Add(TabOffUIPath, new JMXddjFile(ddjbytearray2));
                }
            }
        }

        private void ShowNextPage(object sender, MouseEventArgs e)
        {
            if (DisplayedBlueTab.SingleTabPages.Length > CurrentPageIndex)
            {
                DisplaySingleTabPage(DisplayedBlueTab, CurrentPageIndex);
            }
        }

        private void ShowPreviousPage(object sender, MouseEventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                DisplaySingleTabPage(DisplayedBlueTab, (byte)(CurrentPageIndex - 2));
            }
        }

        private void TabWindow_MouseClick(object sender, MouseEventArgs e)
        {
            DisplaySingleTabPage((BlueShopTabWindow)sender, 0);
        }

        private void TabWindow_onLabelClick(object sender, MouseEventArgs e)
        {
            DisplaySingleTabPage((BlueShopTabWindow)((Label)sender).Tag, 0);
        }

        #endregion Methods
    }
}