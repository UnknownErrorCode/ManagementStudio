using ServerFrameworkRes.BasicControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopEditor.Interface
{
    public partial class TalkWindow : UserControl
    {
        string NpcCodeName128 { get; set; } // singular
        string RefShopGroupCodeName { get; set; } // singular
        string RefShopCodeName { get; set; } // singular
        string[] RefTabGroupCodeName { get; set; } // plural


        public TalkWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// NPC_CodeName128 => _RefShopGroup == CodeName128 from GROUP_...
        /// 
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
                RefTabGroupCodeName[RefTabGroupCodeName.Length] = item.Field<string>("RefTabGroupCodeName");


        }
    }
}
