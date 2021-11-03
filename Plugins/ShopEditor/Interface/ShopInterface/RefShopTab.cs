using Editors.Shop;
using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShopTab
    {
        internal protected string Name { get; set; }
        internal protected byte TabPageIndex { get; set; }
        internal protected string StrID128Name { get; set; }
        internal RefShopGood[] ShopGoods { get; set; }

        internal RefShopTab(string refShopTabCodeName, string StrID_CodeName128)
        {
            Name = refShopTabCodeName;

            if (byte.TryParse(Name.Substring(Name.Length - 1, 1), out byte tabIndex))
                TabPageIndex = tabIndex;
            else
                TabPageIndex = 1;

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