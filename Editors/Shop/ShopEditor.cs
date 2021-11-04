
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Editors.Shop
{
    public partial class ShopEditor : Form
    {
        private Dictionary<string, string> AddPolicyOfItem = new Dictionary<string, string>();
        private Dictionary<string, string> DelPolicyOfItem = new Dictionary<string, string>();
        public readonly  CIShopGood Good;
        public readonly  CIShopGood OldGood;

        public event Action OnUpdatePricePolicy;

        public ShopEditor(CIShopGood good)
        {
            Good = good;
            var cgood = new CIShopGood(good.Good);
            OldGood = cgood;
            InitializeComponent();
            propertyGrid1.SelectedObject = Good;
            propertyGrid2.SelectedObject = good.Good;
            propertyGrid3.SelectedObject = good.PackageItem;
            propertyGrid4.SelectedObject = good.ScrapOfPackageItem;
            propertyGrid1.ExpandAllGridItems();
        }


      
        private void DisplayPrice()
        {
            
            OnUpdatePricePolicy();
        }


    }
}
