using ServerFrameworkRes.BasicControls;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShop
    {
        /// <summary>
        /// CodeName128 from _RefShop.
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// Array of TabGroups from _RefShopTabGroup where StoreCodeName128 is equal to this.Name.
        /// </summary>
        protected internal RefShopTabGroup[] TabGroups { get; set; }

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
    }
}