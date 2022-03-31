using ServerFrameworkRes.BasicControls;
using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShopGroup
    {
        #region Constructors

        /// <summary>
        /// Requires the ShopGroupCodeName128 to get all StoreCodeNames.
        /// </summary>
        /// <param name="shopGroupCodeName128">CodeName128 from _RefMappingShopGroup</param>
        internal RefShopGroup(string shopGroupCodeName128)
        {
            Name = shopGroupCodeName128;

            if (!ClientDataStorage.Database.SRO_VT_SHARD._RefMappingShopGroup.Any(obj => obj.RefShopGroupCodeName.Equals(Name)))
            {
                vSroMessageBox.Show($"No RefShopCodeName found for\nGroupName:{Name}", "Error loading RefMappingShopGroup");
                return;
            }

            Structs.Database.RefMappingShopGroup[] ShopCodeNames = ClientDataStorage.Database.SRO_VT_SHARD._RefMappingShopGroup.Where(row => row.RefShopGroupCodeName.Equals(Name)).ToArray();

            ShopGroup = new RefShop[ShopCodeNames.Length];

            for (int i = 0; i < ShopCodeNames.Length; i++)
            {
                ShopGroup[i] = new RefShop(ShopCodeNames[i].RefShopCodeName);
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// All Stores caged by "Select RefShopCodeName from _RefMappingShopGroup where RefShopGroupCodeName = 'this.Name' " .
        /// This way we jump over RefMappingShopGroup to save memory internal.
        /// </summary>
        internal RefShop[] ShopGroup { get; set; }

        /// <summary>
        /// CodeName128 from _RefShopGroup
        /// </summary>
        protected string Name { get; set; }

        #endregion Properties
    }
}