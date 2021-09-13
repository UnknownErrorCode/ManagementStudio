using ServerFrameworkRes.BasicControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEditor.Interface.ShopInterface
{
    class RefShopGroup
    {

        /// <summary>
        /// CodeName128 from _RefShopGroup
        /// </summary>
        private protected string Name { get; set; }

        /// <summary>
        /// All Stores caged by "Select RefShopCodeName from _RefMappingShopGroup where RefShopGroupCodeName = 'this.Name' " . 
        /// This way we jump over RefMappingShopGroup to save memory internal.
        /// </summary>
        internal RefShop[] ShopGroup { get; set; }

        /// <summary>
        /// Requires the ShopGroupCodeName128 to get all StoreCodeNames.
        /// </summary>
        /// <param name="shopGroupCodeName128">CodeName128 from _RefMappingShopGroup</param>
        internal RefShopGroup(string shopGroupCodeName128)
        {
            Name = shopGroupCodeName128;

            //Collecting RefShopCodeName by RefShopGroupCodeName
            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefShopGroupCodeName") == this.Name))
            {
                vSroMessageBox.Show($"No RefShopCodeName found for\nGroupName:{this.Name}", "Error loading RefMappingShopGroup");
                return;
            }

            var ShopCodeNames = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Where(row => row.Field<string>("RefShopGroupCodeName") == this.Name).ToArray();

            ShopGroup = new RefShop[ShopCodeNames.Length];

            for (int i = 0; i < ShopCodeNames.Length; i++)
                ShopGroup[i] = new RefShop(ShopCodeNames[i].Field<string>("RefShopCodeName"));
        }
    }
}
