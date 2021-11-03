using ClientDataStorage.Client;
using Editors.Shop;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    internal class ShopGoodWindow : Panel
    {
        private string IconPath { get => $"Media\\icon\\{Good.PackageItem.AssocFileIcon}"; }
        internal RefShopGood Good { get; set; }

        
        internal ShopGoodWindow(RefShopGood good)
        {
            Good = good;
            this.Size = new System.Drawing.Size(32, 32);
            this.Location = GetPositionBySlotIndex(good.SlotIndex);
            if (!Media.DDJFiles.ContainsKey(IconPath))
                if (Media.MediaPk2.GetByteArrayByDirectory(IconPath, out byte[] file))
                    Media.DDJFiles.Add(IconPath, new ClientDataStorage.Client.Files.DDJImage(file));

            if (Media.DDJFiles.ContainsKey(IconPath))
                this.BackgroundImage = Media.DDJFiles[IconPath].BitmapImage;
            Media.DDJFiles[IconPath].BitmapImage.Save($".\\{Good.PackageItemCodeName}.png");
            TalkWindow.ShopToolTip.SetToolTip(this, this.Good.ScrapOfPackageItem.RefItemCodeName);
            this.Click += ShopGoodWindow_Click;
        }

        private void ShopGoodWindow_Click(object sender, EventArgs e)
        {
            var ed = new Editors.Shop.ShopEditor(Good);
            ed.Show();
        }

        private Point GetPositionBySlotIndex(byte slotIndex)
        {
            if (slotIndex > 29)
                slotIndex %= 30;
            int page = slotIndex % 30;
            int ordinate = Convert.ToInt32(Math.Floor(slotIndex / 6d));
            int abszesse = slotIndex % 6;
            return new Point(abszesse*36+4, ordinate * 36+4);
        }
    }
}