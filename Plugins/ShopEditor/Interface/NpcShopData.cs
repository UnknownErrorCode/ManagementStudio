using ServerFrameworkRes.BasicControls;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ShopEditor.Interface
{
    internal class NpcShopData
    {
        #region Properties
        internal string NpcCodeName128 { get; set; } // singular
        internal string[] RefShopGroupCodeName { get; set; } // singular
        internal string RefShopCodeName { get; set; } // singular
        Dictionary<string, string> RefShopGroupCodeNameToRefShopCodeName { get; set; }
        internal Dictionary<string, string> SN_RefTabGroupCodeNames { get; set; } // probably obsolete
        internal Dictionary<string, string> RefShopTabGroups { get; set; } // probably obsolete

        #endregion


        #region Methods


        /// <summary>
        /// Searches all Store Informations by a simpe NPC Name like NPC_TT_TEST  
        /// _RefShopGroup > _RefMappingShopGroup >_RefMappingShopWithTab > _RefShopItemGroup +_RefShopTabGroup > _RefShopTab  > _RefShopGoods   >Edits can start
        /// </summary>
        /// <param name="npcCodeName128"></param>
        internal NpcShopData(string npcCodeName128)
        {
            NpcCodeName128 = npcCodeName128;

            //Colelcting RefShopGroupCodeName by NPC CodeName128
            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefNPCCodeName") == npcCodeName128))
            {
                vSroMessageBox.Show($"No Group CodeName128 found for NPC: {npcCodeName128}", "Error loading RefShopGroup");
                return;
            }
            var ShopGroupCodeNames = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopGroup"].Rows.OfType<DataRow>().Where(Row => Row.Field<string>("RefNPCCodeName") == npcCodeName128).ToArray();//.Field<string>("CodeName128");

            this.RefShopGroupCodeName = new string[ShopGroupCodeNames.Length];
            RefShopGroupCodeNameToRefShopCodeName = new Dictionary<string, string>();
            RefShopTabGroups = new Dictionary<string, string>();
            SN_RefTabGroupCodeNames = new Dictionary<string, string>();
            for (int i = 0; i < ShopGroupCodeNames.Length; i++)
            {
                this.RefShopGroupCodeName[i] = ShopGroupCodeNames[i].Field<string>("CodeName128");

                //Collecting RefShopCodeName by RefShopGroupCodeName
                if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefShopGroupCodeName") == this.RefShopGroupCodeName[i]))
                {
                    vSroMessageBox.Show($"No RefShopCodeName found for \nNPC: {npcCodeName128}\nGroupName:{this.RefShopGroupCodeName}", "Error loading RefMappingShopGroup");
                    return;
                }
                var ShopCodeName = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Single(row => row.Field<string>("RefShopGroupCodeName") == this.RefShopGroupCodeName[i]).Field<string>("RefShopCodeName");

                RefShopGroupCodeNameToRefShopCodeName.Add(ShopGroupCodeNames[i].Field<string>("CodeName128"),ShopCodeName);

                //Collecting RefShopCodeName by RefShopGroupCodeName
                if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefShopGroupCodeName") == ShopGroupCodeNames[i].Field<string>("CodeName128")))
                {
                    vSroMessageBox.Show($"No RefShopCodeName found for \nNPC: {npcCodeName128}\nGroupName:{ShopGroupCodeNames[i].Field<string>("CodeName128")}", "Error loading RefMappingShopGroup");
                    return;
                }
                this.RefShopCodeName = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopGroup"].Rows.OfType<DataRow>().Single(row => row.Field<string>("RefShopGroupCodeName") == ShopGroupCodeNames[i].Field<string>("CodeName128")).Field<string>("RefShopCodeName");


                //Collecting RefTabGroupCodeNames from _RefMappingShopWithTab by RefShopCodeName
                if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopWithTab"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefShopCodeName") == ShopCodeName))
                {
                    vSroMessageBox.Show($"No RefTabGroupCodeNames found for \nNPC: {npcCodeName128}\nGroupName:{ShopGroupCodeNames[i].Field<string>("CodeName128")}\nShopCodeName:{ShopCodeName}", "Error loading RefMappingShopWithTab");
                    return;
                }

                foreach (DataRow item in ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefMappingShopWithTab"].Rows.OfType<DataRow>().Where(row => row.Field<string>("RefShopCodeName") == ShopCodeName))
                {
                    //Collect StrID128_Group from _RefShopItemGroup by RefTabGroupCodeName
                    if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopItemGroup"].Rows.OfType<DataRow>().Any(row => row.Field<string>("CodeName128") == item.Field<string>("RefTabGroupCodeName")))
                    {
                        vSroMessageBox.Show($"No CodeName128 found for \nNPC: {npcCodeName128}\nTabGroupName:{item.Field<string>("RefTabGroupCodeName")}\nShopCodeName:{ShopCodeName}", "Error loading _RefShopItemGroup");
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

        

            
          
        }
        #endregion



    }
}
