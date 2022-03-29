using ClientDataStorage.Client;
using Editors.Shop;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class ShopGoodWindow : Panel
    {
        private string IconPath => $"Media\\icon\\{Good.PackageItem.AssocFileIcon}";
        internal CIShopGood Good { get; set; }

        internal ShopGoodWindow(CIShopGood good)
        {
            Good = good;
            Size = new System.Drawing.Size(32, 32);
            Location = GetPositionBySlotIndex(good.SlotIndex);
            if (!Media.DDJFiles.ContainsKey(IconPath))
                if (Media.MediaPk2.GetByteArrayByDirectory(IconPath, out byte[] file))
                    Media.DDJFiles.Add(IconPath, new ClientDataStorage.Client.Files.DDJImage(file));

            if (Media.DDJFiles.ContainsKey(IconPath))
                BackgroundImage = Media.DDJFiles[IconPath].BitmapImage;

            TalkWindow.ShopToolTip.SetToolTip(this, Good.ScrapOfPackageItem.RefItemCodeName);
            Click += ShopGoodWindow_Click;
        }

        private void ShopGoodWindow_Click(object sender, EventArgs e)
        {
            ShopInterface.EditorInterface ed = new ShopInterface.EditorInterface(Good);
        }

        private Point GetPositionBySlotIndex(byte slotIndex)
        {
            if (slotIndex > 29)
                slotIndex %= 30;
            int ordinate = Convert.ToInt32(Math.Floor(slotIndex / 6d));
            int abszesse = slotIndex % 6;
            return new Point(abszesse * 36 + 4, ordinate * 36 + 4);
        }
    }
}