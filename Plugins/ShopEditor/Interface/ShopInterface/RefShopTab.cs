using Editors.Shop;
using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShopTab
    {
        protected internal string Name { get; set; }
        protected internal byte TabPageIndex { get; set; }
        protected internal string StrID128Name { get; set; }
        internal CIShopGood[] ShopGoods { get; set; }

        internal RefShopTab(string refShopTabCodeName, string StrID_CodeName128)
        {
            Name = refShopTabCodeName;

            if (byte.TryParse(Name.Substring(Name.Length - 1, 1), out byte tabIndex))
            {
                TabPageIndex = tabIndex;
            }
            else
            {
                TabPageIndex = 1;
            }

            StrID128Name = StrID_CodeName128;

            if (!ClientDataStorage.Database.SRO_VT_SHARD._RefShopGoods.Any(row => row.RefTabCodeName.Equals(Name) && row.Service == 1))
            {
                return;
            }

            Structs.Database.RefShopGood[] allGoodsOnTab = ClientDataStorage.Database.SRO_VT_SHARD._RefShopGoods.Where(row => row.RefTabCodeName.Equals(Name) && row.Service == 1).ToArray();
            ShopGoods = new CIShopGood[allGoodsOnTab.Length];

            for (int i = 0; i < allGoodsOnTab.Length; i++)
            {
                ShopGoods[i] = new CIShopGood(allGoodsOnTab[i]);
            }
        }
    }
}