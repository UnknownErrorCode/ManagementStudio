using ServerFrameworkRes.BasicControls;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShop
    {
        #region Constructors

        internal RefShop(string _RefShopCodeName)
        {
            Name = _RefShopCodeName;

            if (!PluginFramework.Database.SRO_VT_SHARD._RefMappingShopWithTab.ContainsKey(Name))
            {
                vSroMessageBox.Show($"No RefTabGroupCodeNames found for \nRefShopCodeName:{Name}", "Error loading RefMappingShopWithTab");
                return;
            }
            Structs.Database.RefMappingShopWithTab[] tabGroups = PluginFramework.Database.SRO_VT_SHARD._RefMappingShopWithTab[Name];
            TabGroups = new RefShopTabGroup[tabGroups.Length];

            for (int i = 0; i < tabGroups.Length; i++)
            {
                TabGroups[i] = new RefShopTabGroup(tabGroups[i].RefTabGroupCodeName);
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Array of TabGroups from _RefShopTabGroup where StoreCodeName128 is equal to this.Name.
        /// </summary>
        protected internal RefShopTabGroup[] TabGroups { get; set; }

        /// <summary>
        /// CodeName128 from _RefShop.
        /// </summary>
        protected string Name { get; set; }

        #endregion Properties
    }
}