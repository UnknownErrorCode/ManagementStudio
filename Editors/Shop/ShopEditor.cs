
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
            vSroButtonList1.OnAddButton += VSroButtonList1_OnAddButton;
            vSroButtonList1.OnRemoveButton += VSroButtonList1_OnRemoveButton;
            foreach (var item in good.PricePolicyOfItem)
            {
                vSroButtonList1.AddSingleButtonToList(item.PaymentDevice.ToString(), item);
            }
            vSroButtonList1.OnSelectChanged += OnChangeSelection;
        }

        private void VSroButtonList1_OnRemoveButton()
        {
            //Network stuff to delete payment Device
        }

        private void OnChangeSelection()
        {
          //  var currPricePolicy = (DataModelRefPricePolicyOfItem)vSroButtonList1.LatestSelectedButton.Tag;
          //  vSroMessageBox.Show($"{currPricePolicy.PackageItemCodeName}\n{currPricePolicy.PaymentDevice}\n{currPricePolicy.Cost}");
            vSroSmallButton4.Enabled = true;
        }

        private void VSroButtonList1_OnAddButton()
        {
            //Network stuff to add payment Device
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
            var strarr = vSroMessageBox.GetInput($"Enter a PaymentDevice for the package item:{Good.PackageItemCodeName}\n1 = Gold\n2 = silk\n4 = Silk Gift\n8 = GuildPoint\n16 = Silk Point\n32 = Honor\n64 = Copper\n128 = IronCoin\n256 = SilverCoin\n512 = GoldCoin\n1024 = ArenaCoin", "Add new PaymentDevice", "Device", "Price");

            if (int.TryParse(strarr[0], out int device))
            {
                PaymentDevice dev = (PaymentDevice)device;
                if (int.TryParse(strarr[1], out int price))
                {
                    if (vSroMessageBox.YesOrNo($"Do you want to add a new [{dev}] price for \n[{price}] {dev}? ", $"Add [{dev}] price"))
                    {
                        var rppoi = new DataModelRefPricePolicyOfItem()
                        {
                            PaymentDevice = dev,
                            Cost = price,
                            PackageItemCodeName = Good.PackageItemCodeName,
                        };
                       

                        vSroButtonList1.AddSingleButtonToList(rppoi.PaymentDevice.ToString(), rppoi);
                    }
                }
            }
        }
    }
}
