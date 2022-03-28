
using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Editors.Shop
{
    public partial class ShopEditor : Form
    {
        public readonly CIShopGood Good;

        public event Action OnUpdatePricePolicy;
        public ShopEditor(CIShopGood good)
        {
            Good = good;

            InitializeComponent();
            this.vSroSizableWindow1.Title = $"Edit: {Good.PackageItemCodeName}";
            vSroButtonList1.OnIndCh += VSroButtonList1_OnIndCh;
            foreach (var item in good.PricePolicyOfItem)
            {
                vSroButtonList1.AddSingleButtonToList(item.PaymentDevice.ToString(), item);
            }
        }

        private void VSroButtonList1_OnIndCh(object sender, EventArgs e)
        {
            DataModelRefPricePolicyOfItem obj = (DataModelRefPricePolicyOfItem)((vSroListButton)sender).Tag;
            MessageBox.Show(obj.PaymentDevice.ToString());
        }

        private void OnChangeSelection()
        {
            //  var currPricePolicy = (DataModelRefPricePolicyOfItem)vSroButtonList1.LatestSelectedButton.Tag;
            //  vSroMessageBox.Show($"{currPricePolicy.PackageItemCodeName}\n{currPricePolicy.PaymentDevice}\n{currPricePolicy.Cost}");
            vSroSmallButton4.Enabled = true;
        }

        private void DisplayPrice()
        {
            OnUpdatePricePolicy();
        }

        /// <summary>
        /// Delete PaymentDevice
        /// </summary>
        private void vSroSmallButton2_vSroClickEvent()
        {
            vSroButtonList1.RemoveSingleButtonFromList(vSroButtonList1.LatestSelectedButton.ButtonName);
        }

        /// <summary>
        /// Add Payment Device with Price
        /// </summary>
        private void vSroSmallButton3_vSroClickEvent()
        {
            var strarr = vSroMessageBox.GetInput($"Enter a PaymentDevice for the package item:{Good.PackageItemCodeName}\n1 = Gold  2 = silk  4 = Silk Gift\n8 = GuildPoint  16 = Silk Point  32 = Honor\n64 = Copper  128 = IronCoin  256 = SilverCoin\n512 = GoldCoin  1024 = ArenaCoin", "Add new PaymentDevice", "Device", "Price");

            if (int.TryParse(strarr[0], out int device))
            {
                PaymentDevice dev = (PaymentDevice)device;
                if (int.TryParse(strarr[1], out int price))
                {
                    if (vSroMessageBox.YesOrNo($"Do you want to add a new [{dev}] price for \n[{price}] {dev}? ", $"Add [{dev}] price"))
                    {
                        var rppoi = new DataModelRefPricePolicyOfItem(1, Good.PackageItemCodeName, price, dev);

                        vSroButtonList1.AddSingleButtonToList(rppoi.PaymentDevice.ToString(), rppoi);
                    }
                }
            }
        }
    }
}
