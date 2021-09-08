using ServerFrameworkRes.BasicControls;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ShopEditor.Interface
{
    abstract internal class NpcShopData
    {
        #region Properties
        string NpcCodeName128 { get; set; } // singular
        string RefShopGroupCodeName { get; set; } // singular
        string RefShopCodeName { get; set; } // singular

        Dictionary<string, string> SN_RefTabGroupCodeNames { get; set; } // probably obsolete
        Dictionary<string, string> RefShopTabGroups { get; set; } // probably obsolete

        #endregion


        #region Methods


        /// <summary>
        /// Searches all Store Informations by a simpe NPC Name like NPC_TT_TEST  
        /// _RefShopGroup > _RefMappingShopGroup >_RefMappingShopWithTab > _RefShopItemGroup +_RefShopTabGroup > _RefShopTab  > _RefShopGoods   >Edits can start
        /// </summary>
        /// <param name="npcCodeName128"></param>
        internal void InitializeNpcShopGroups(string npcCodeName128)
        {
            NpcCodeName128 = npcCodeName128;

            //Colelcting RefShopGroupCodeName by NPC CodeName128
            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefNPCCodeName") == npcCodeName128))
            {
                vSroMessageBox.Show($"No Group CodeName128 found for NPC: {npcCodeName128}", "Error loading RefShopGroup");
                return;
            }
            this.RefShopGroupCodeName = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows.OfType<DataRow>().Single(Row => Row.Field<string>("RefNPCCodeName") == npcCodeName128).Field<string>("CodeName128");


            //Collecting RefShopCodeName by RefShopGroupCodeName
            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefShopGroupCodeName") == this.RefShopGroupCodeName))
            {
                vSroMessageBox.Show($"No RefShopCodeName found for \nNPC: {npcCodeName128}\nGroupName:{this.RefShopGroupCodeName}", "Error loading RefMappingShopGroup");
                return;
            }
            this.RefShopCodeName = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Single(row => row.Field<string>("RefShopGroupCodeName") == this.RefShopGroupCodeName).Field<string>("RefShopCodeName");


            //Collecting RefTabGroupCodeNames from _RefMappingShopWithTab by RefShopCodeName
            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopWithTab"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefShopCodeName") == this.RefShopCodeName))
            {
                vSroMessageBox.Show($"No RefTabGroupCodeNames found for \nNPC: {npcCodeName128}\nGroupName:{this.RefShopGroupCodeName}\nShopCodeName:{this.RefShopCodeName}", "Error loading RefMappingShopWithTab");
                return;
            }
            foreach (DataRow item in ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopWithTab"].Rows.OfType<DataRow>().Where(row => row.Field<string>("RefShopCodeName") == this.RefShopCodeName))
            {
                //Collect StrID128_Group from _RefShopItemGroup by RefTabGroupCodeName
                if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopItemGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("CodeName128") == item.Field<string>("RefTabGroupCodeName")))
                {
                    vSroMessageBox.Show($"No CodeName128 found for \nNPC: {npcCodeName128}\nTabGroupName:{item.Field<string>("RefTabGroupCodeName")}\nShopCodeName:{this.RefShopCodeName}", "Error loading _RefShopItemGroup");
                    return;
                }

                //Collect StrID128_Group from _RefShopTabGroup by RefTabGroupCodeName
                if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopTabGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("CodeName128") == item.Field<string>("RefTabGroupCodeName")))
                {
                    vSroMessageBox.Show($"No CodeName128 found for \nNPC: {npcCodeName128}\nTabGroupName:{item.Field<string>("RefTabGroupCodeName")}\nShopCodeName:{this.RefShopCodeName}", "Error loading _RefShopTabGroup");
                    return;
                }

                RefShopTabGroups.Add(item.Field<string>("RefTabGroupCodeName"), ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopTabGroup"].Rows.OfType<DataRow>().Single(row => row.Field<string>("CodeName128") == item.Field<string>("RefTabGroupCodeName")).Field<string>("StrID128_Group"));
                SN_RefTabGroupCodeNames.Add(item.Field<string>("RefTabGroupCodeName"), ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopItemGroup"].Rows.OfType<DataRow>().Single(row => row.Field<string>("CodeName128") == item.Field<string>("RefTabGroupCodeName")).Field<string>("StrID128_Group"));
            }
        }
        #endregion



    }
}
