using Structs.Database;
using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShopGood
    {
        internal string PackageItemCodeName { get; set; }
        internal byte SlotIndex { get; set; }
        internal RefPackageItem PackageItem { get; set; }
        internal RefScrapOfPackageItem ScrapOfPackageItem { get; set; }
        internal RefPricePolicyOfItem[] PricePolicyOfItem { get; set; }

        internal RefShopGood(string refPackageItemCodeName, byte slotIndex)
        {
            PackageItemCodeName = refPackageItemCodeName;
            SlotIndex = slotIndex;

            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPackageItem"].Rows.OfType<DataRow>().Any(packItem => packItem.Field<string>("CodeName128") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1))
                PackageItem = new RefPackageItem(ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPackageItem"].Rows.OfType<DataRow>().First(packItem => packItem.Field<string>("CodeName128") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1));

            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefScrapOfPackageItem"].Rows.OfType<DataRow>().Any(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1))
                ScrapOfPackageItem = new RefScrapOfPackageItem(ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefScrapOfPackageItem"].Rows.OfType<DataRow>().First(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1));

            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPricePolicyOfItem"].Rows.OfType<DataRow>().Any(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1))
            {
                var allPolicy = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefPricePolicyOfItem"].Rows.OfType<DataRow>().Where(packItem => packItem.Field<string>("RefPackageItemCodeName") == PackageItemCodeName && packItem.Field<byte>("Service") >= 1).ToArray();
                PricePolicyOfItem = new RefPricePolicyOfItem[allPolicy.Length];
                for (int i = 0; i < allPolicy.Length; i++)
                {
                    PricePolicyOfItem[i] = new RefPricePolicyOfItem(allPolicy[i]);
                }
            }
        }
    }
}