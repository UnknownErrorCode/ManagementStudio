using BinaryFiles.PackFile;
using ShopEditor.Interface.ShopInterface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class ShopGoodWindow : Panel
    {
        #region Constructors

        internal ShopGoodWindow(CIShopGood good)
        {
            Good = good;
            Size = new System.Drawing.Size(32, 32);
            Location = GetPositionBySlotIndex(good.SlotIndex);
            if (!PackFile.MediaPack.DDJFiles.ContainsKey(IconPath))
            {
                if (PackFile.MediaPack.Reader.GetByteArrayByDirectory(IconPath, out byte[] file))
                {
                    PackFile.MediaPack.DDJFiles.Add(IconPath, new JMXddjFile(file));
                }
            }

            if (PackFile.MediaPack.DDJFiles.ContainsKey(IconPath))
            {
                BackgroundImage = PackFile.MediaPack.DDJFiles[IconPath].BitmapImage;
            }

            TalkWindow.ShopToolTip.SetToolTip(this, Good.ScrapOfPackageItem.RefItemCodeName);
            Click += ShopGoodWindow_Click;
        }

        #endregion Constructors

        #region Properties

        internal CIShopGood Good { get; set; }
        private string IconPath => $"Media\\icon\\{Good.PackageItem.AssocFileIcon}";

        #endregion Properties

        #region Methods

        private Point GetPositionBySlotIndex(byte slotIndex)
        {
            if (slotIndex > 29)
            {
                slotIndex %= 30;
            }

            int ordinate = Convert.ToInt32(Math.Floor(slotIndex / 6d));
            int abszesse = slotIndex % 6;
            return new Point(abszesse * 36 + 4, ordinate * 36 + 4);
        }

        private void ShopGoodWindow_Click(object sender, EventArgs e)
        {
            ShopInterface.EditorInterface ed = new ShopInterface.EditorInterface(Good);
        }

        #endregion Methods
    }
}