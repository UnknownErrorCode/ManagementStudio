using Structs.Database;
using System.Collections.Generic;

namespace Editors.Shop
{
    public class CIShopGood
    {
        #region Public Fields

        public RefShopGood Good;

        public RefPackageItem PackageItem;

        public RefScrapOfPackageItem ScrapOfPackageItem;

        #endregion Public Fields

        #region Public Constructors

        public CIShopGood(RefShopGood good)
        {
            Good = good;

            if (ClientFrameworkRes.Database.SRO_VT_SHARD._RefPackageItem.ContainsKey(PackageItemCodeName))
            {
                PackageItem = ClientFrameworkRes.Database.SRO_VT_SHARD._RefPackageItem[PackageItemCodeName];
            }

            if (ClientFrameworkRes.Database.SRO_VT_SHARD._RefPackageItem.TryGetValue(Good.RefPackageItemCodeName, out RefPackageItem packItm))
            {
                PackageItem = packItm;
            }
            if (ClientFrameworkRes.Database.SRO_VT_SHARD._RefScrapOfPackageItem.ContainsKey(PackageItemCodeName))
            {
                ScrapOfPackageItem = ClientFrameworkRes.Database.SRO_VT_SHARD._RefScrapOfPackageItem[PackageItemCodeName];
            }

            if (ClientFrameworkRes.Database.SRO_VT_SHARD._RefPricePolicyOfItem.ContainsKey(PackageItemCodeName))
            {
                var allPolicy = ClientFrameworkRes.Database.SRO_VT_SHARD._RefPricePolicyOfItem[PackageItemCodeName];
                PricePolicyOfItem = new List<DataModelRefPricePolicyOfItem>(allPolicy.Length); ;
                for (int i = 0; i < allPolicy.Length; i++)
                    PricePolicyOfItem.Add(new DataModelRefPricePolicyOfItem(allPolicy[i]));
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public string PackageItemCodeName => Good.RefPackageItemCodeName;
        public List<DataModelRefPricePolicyOfItem> PricePolicyOfItem { get; set; }
        public byte SlotIndex => Good.SlotIndex;

        #endregion Public Properties
    }
}