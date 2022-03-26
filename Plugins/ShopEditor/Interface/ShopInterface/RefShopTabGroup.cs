using System.Data;
using System.Linq;

namespace ShopEditor.Interface.ShopInterface
{
    internal class RefShopTabGroup
    {
        /// <summary>
        /// RefShopTabGroupCodeName from RefShopTabGroup
        /// </summary>
        private protected string Name { get; set; }

        /// <summary>
        /// StrID128_CodeName128 from _RefShopTabGroup
        /// </summary>
        protected internal string StrID128Name { get; set; }

        /// <summary>
        /// All RefShopTabs inside this TabGroup.
        /// </summary>
        internal RefShopTab[] ShopTabs { get; set; }


        internal RefShopTabGroup(string refTabGroupCodeName128)
        {
            Name = refTabGroupCodeName128;

            if (!ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopTab"].Rows.OfType<DataRow>().Any(row => row.Field<string>("RefTabGroupCodeName") == Name && row.Field<byte>("Service") == 1))
                return;

            DataRow[] tempShopTabs = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopTab"].Rows.OfType<DataRow>().Where(row => row.Field<string>("RefTabGroupCodeName") == Name && row.Field<byte>("Service") == 1).ToArray();

            ShopTabs = new RefShopTab[tempShopTabs.Length];
            for (int i = 0; i < tempShopTabs.Length; i++)
                ShopTabs[i] = new RefShopTab(tempShopTabs[i].Field<string>("CodeName128"), tempShopTabs[i].Field<string>("StrID128_Tab"));

            //Due to different tables, the StrID128_Name needs to be set manually.
            StrID128Name = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefShopTabGroup"].Rows.OfType<DataRow>().First(row => row.Field<string>("CodeName128") == Name).Field<string>("StrID128_Group");

        }

    }
}