using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShopTabGroup
    {
        #region Constructors

        internal RefShopTabGroup(string refTabGroupCodeName128)
        {
            Name = refTabGroupCodeName128;

            if (!ClientDataStorage.Database.SRO_VT_SHARD._RefShopTab.Values.Any(row => row.RefTabGroupCodeName.Equals(Name) && row.Service == 1))
            {
                return;
            }

            Structs.Database.RefShopTab[] tempShopTabs = ClientDataStorage.Database.SRO_VT_SHARD._RefShopTab.Values.Where(row => row.RefTabGroupCodeName.Equals(Name) && row.Service == 1).ToArray();

            ShopTabs = new RefShopTab[tempShopTabs.Length];
            for (int i = 0; i < tempShopTabs.Length; i++)
            {
                ShopTabs[i] = new RefShopTab(tempShopTabs[i].CodeName128, tempShopTabs[i].StrID128_Tab);
            }

            //Due to different tables, the StrID128_Name needs to be set manually.
            StrID128Name = ClientDataStorage.Database.SRO_VT_SHARD._RefShopTabGroup[Name].StrID128_Group;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// All RefShopTabs inside this TabGroup.
        /// </summary>
        internal RefShopTab[] ShopTabs { get; set; }

        /// <summary>
        /// StrID128_CodeName128 from _RefShopTabGroup
        /// </summary>
        protected internal string StrID128Name { get; set; }

        /// <summary>
        /// RefShopTabGroupCodeName from RefShopTabGroup
        /// </summary>
        protected string Name { get; set; }

        #endregion Properties
    }
}