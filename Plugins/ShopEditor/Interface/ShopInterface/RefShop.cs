using ServerFrameworkRes.BasicControls;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShop
    {
        #region Internal Constructors

        internal RefShop(string _RefShopCodeName)
        {
            Name = _RefShopCodeName;

            if (!ClientDataStorage.Database.SRO_VT_SHARD._RefMappingShopWithTab.ContainsKey(Name))
            {
                vSroMessageBox.Show($"No RefTabGroupCodeNames found for \nRefShopCodeName:{Name}", "Error loading RefMappingShopWithTab");
                return;
            }
            Structs.Database.RefMappingShopWithTab[] tabGroups = ClientDataStorage.Database.SRO_VT_SHARD._RefMappingShopWithTab[Name];
            TabGroups = new RefShopTabGroup[tabGroups.Length];

            for (int i = 0; i < tabGroups.Length; i++)
            {
                TabGroups[i] = new RefShopTabGroup(tabGroups[i].RefTabGroupCodeName);
            }
        }

        #endregion Internal Constructors

        #region Protected Internal Properties

        /// <summary>
        /// Array of TabGroups from _RefShopTabGroup where StoreCodeName128 is equal to this.Name.
        /// </summary>
        protected internal RefShopTabGroup[] TabGroups { get; set; }

        #endregion Protected Internal Properties

        #region Protected Properties

        /// <summary>
        /// CodeName128 from _RefShop.
        /// </summary>
        protected string Name { get; set; }

        #endregion Protected Properties
    }
}