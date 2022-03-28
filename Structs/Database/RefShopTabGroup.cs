using System.Data;

namespace Structs.Database
{
    public struct RefShopTabGroup
    {
        public byte Service;
        public int Country;
        public int ID;
        public string CodeName128;
        public string StrID128_Group;

        public RefShopTabGroup(System.Data.DataRow row)
        {
            Service = row.Field<byte>("Service");//= byte.Parse(row[0].ToString());
            Country = row.Field<int>("Country");//= int.Parse(row[1].ToString());
            ID = row.Field<int>("ID");//= int.Parse(row[2].ToString());
            CodeName128 = row.Field<string>("CodeName128");//= row[3].ToString();
            StrID128_Group = row.Field<string>("StrID128_Group");//= row[4].ToString();
        }

    }
}
