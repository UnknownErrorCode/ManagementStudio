using ServerFrameworkRes.BasicControls;
using ShopEditor.Interface.ShopInterface;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ShopEditor.Interface
{
    internal class NpcShopData
    {
        #region Properties

        /// <summary>
        /// Name of NPC from _RefObjCommon
        /// </summary>
        internal protected string NpcCodeName { get; set; }

        /// <summary>
        /// Contains all RefShopGroups assigned to this NPC.
        /// </summary>
        internal RefShopGroup[] ShopGroups { get; set; }

        #endregion


        #region Methods

        /// <summary>
        /// Searches all Store Informations by a simpe NPC Name like NPC_TT_TEST  
        /// _RefShopGroup > _RefMappingShopGroup >_RefMappingShopWithTab > _RefShopItemGroup +_RefShopTabGroup > _RefShopTab  > _RefShopGoods   >Edits can start
        /// </summary>
        /// <param name="npcCodeName128"></param>
        internal NpcShopData(string npcCodeName128)
        {
            NpcCodeName = npcCodeName128;

            //Collecting RefShopGroupCodeName by NPC CodeName128
            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefNPCCodeName") == npcCodeName128))
            {
                vSroMessageBox.Show($"No Group CodeName128 found for NPC: {npcCodeName128}", "Error loading RefShopGroup");
                return;
            }
            var ShopGroupCodeNames = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows.OfType<DataRow>().Where(Row => Row.Field<string>("RefNPCCodeName") == npcCodeName128).ToArray();
            ShopGroups = new RefShopGroup[ShopGroupCodeNames.Length];

            for (int i = 0; i < ShopGroupCodeNames.Length; i++)
                ShopGroups[i] = new RefShopGroup(ShopGroupCodeNames[i].Field<string>("CodeName128"));
        }

        #endregion
    }
}
