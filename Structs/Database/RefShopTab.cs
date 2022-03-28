using System.Data;

namespace Structs.Database
{
    public struct RefShopTab
    {
        public byte Service;
        public int Country;
        public int ID;
        public string CodeName128;
        public string RefTabGroupCodeName;
        public string StrID128_Tab;

        public RefShopTab(DataRow row)
        {
            Service = row.Field<byte>("Service");   //    = byte.Parse(row[0].ToString());
            Country = row.Field<int>("Country");   //     = int.Parse(row[1].ToString());
            ID = row.Field<int>("ID");   //     = int.Parse(row[2].ToString());
            CodeName128 = row.Field<string>("CodeName128");   //        = row[3].ToString();
            RefTabGroupCodeName = row.Field<string>("RefTabGroupCodeName");   //= row[4].ToString();
            StrID128_Tab = row.Field<string>("StrID128_Tab");   //= row[5].ToString();
        }
    }
}
