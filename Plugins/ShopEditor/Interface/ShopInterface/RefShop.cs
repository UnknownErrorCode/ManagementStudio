using ServerFrameworkRes.BasicControls;
using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShop
    {
        /// <summary>
        /// CodeName128 from _RefShop.
        /// </summary>
        private protected string Name { get; set; }

        /// <summary>
        /// Array of TabGroups from _RefShopTabGroup where StoreCodeName128 is equal to this.Name.
        /// </summary>
        protected internal RefShopTabGroup[] TabGroups { get; set; }

        internal RefShop(string storeCodeName)
        {
            Name = storeCodeName;

            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopWithTab"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefShopCodeName") == Name))
            {
                vSroMessageBox.Show($"No RefTabGroupCodeNames found for \nRefShopCodeName:{Name}", "Error loading RefMappingShopWithTab");
                return;
            }
            DataRow[] tabGroups = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopWithTab"].Rows.OfType<DataRow>().Where(row => row.Field<string>("RefShopCodeName") == Name).ToArray();
            TabGroups = new RefShopTabGroup[tabGroups.Length];

            for (int i = 0; i < tabGroups.Length; i++)
            {
                TabGroups[i] = new RefShopTabGroup(tabGroups[i].Field<string>("RefTabGroupCodeName"));
            }
        }
    }
}