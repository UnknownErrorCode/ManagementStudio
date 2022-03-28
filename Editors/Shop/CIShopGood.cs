using Structs.Database;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Editors.Shop
{
    public class CIShopGood 
    {
        public string PackageItemCodeName { get => Good.RefPackageItemCodeName; }
        public byte SlotIndex { get => Good.SlotIndex; }

        public RefShopGood Good { get; set; }
        public RefPackageItem PackageItem { get; set; }
        public RefScrapOfPackageItem ScrapOfPackageItem { get; set; }
        public List<DataModelRefPricePolicyOfItem> PricePolicyOfItem { get; set; }

        public CIShopGood(RefShopGood good)
        {
            Good = good;

            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPackageItem"].Rows.OfType<DataRow>().Any(packItem => packItem.Field<string>("CodeName128") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1))
                PackageItem = new RefPackageItem(ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPackageItem"].Rows.OfType<DataRow>().First(packItem => packItem.Field<string>("CodeName128") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1));

            if (ClientDataStorage.Database.SRO_VT_SHARD._RefPackageItem.TryGetValue(Good.RefPackageItemCodeName, out RefPackageItem packItm ))
            {
                PackageItem = packItm;
            }
            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefScrapOfPackageItem"].Rows.OfType<DataRow>().Any(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1))
                ScrapOfPackageItem = new RefScrapOfPackageItem(ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefScrapOfPackageItem"].Rows.OfType<DataRow>().First(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1));

            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPricePolicyOfItem"].Rows.OfType<DataRow>().Any(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1))
            {
                var allPolicy = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPricePolicyOfItem"].Rows.OfType<DataRow>().Where(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1).ToArray();
                PricePolicyOfItem = new List<DataModelRefPricePolicyOfItem>(allPolicy.Length); ;
                for (int i = 0; i < allPolicy.Length; i++)
                {
                    PricePolicyOfItem.Add( new DataModelRefPricePolicyOfItem(allPolicy[i].ItemArray));
                }
            }
        }
    }
}