using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShopTab
    {
        private protected string Name { get; set; }
        private protected string StrID128Name { get; set; }
        private RefShopGood[] ShopGoods { get; set; }

        internal RefShopTab(string refShopTabCodeName, string StrID_CodeName128)
        {
            Name = refShopTabCodeName;
            StrID128Name = StrID_CodeName128;

            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGoods"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefTabCodeName") == this.Name && row.Field<byte>("Service") == 1))
                return;

            var allGoodsOnTab = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGoods"].Rows.OfType<DataRow>().Where(row => row.Field<string>("RefTabCodeName") == this.Name && row.Field<byte>("Service") == 1).ToArray();
            ShopGoods = new RefShopGood[allGoodsOnTab.Length];

            for (int i = 0; i < allGoodsOnTab.Length; i++)
                ShopGoods[i] = new RefShopGood(allGoodsOnTab[i].Field<string>("RefPackageItemCodeName"), allGoodsOnTab[i].Field<byte>("SlotIndex"));
        }
    }
}