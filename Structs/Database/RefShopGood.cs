using System.Data;

namespace Structs.Database
{
    public struct RefShopGood
    {
        public byte Service;
        public int Country;
        public string RefTabCodeName;
        public string RefPackageItemCodeName;
        public byte SlotIndex;
        public int Param1;
        public string Param1_Desc128;
        public int Param2;
        public string Param2_Desc128;
        public int Param3;
        public string Param3_Desc128;
        public int Param4;
        public string Param4_Desc128;
        public readonly int Index;


        public RefShopGood(object[] row)
        {
            Service = byte.Parse(row[0].ToString());
            Country = int.Parse(row[1].ToString());
            RefTabCodeName = row[2].ToString();
            RefPackageItemCodeName = row[3].ToString();
            SlotIndex = byte.Parse(row[4].ToString());
            Param1 = int.Parse(row[5].ToString());
            Param1_Desc128 = row[6].ToString();
            Param2 = int.Parse(row[7].ToString());
            Param2_Desc128 = row[8].ToString();
            Param3 = int.Parse(row[9].ToString());
            Param3_Desc128 = row[10].ToString();
            Param4 = int.Parse(row[11].ToString());
            Param4_Desc128 = row[12].ToString();
            Index = 0;//  int.Parse(row[13].ToString());
        }

        public RefShopGood(DataRow row)
        {
            Service = row.Field<byte>("Service");
            Country = row.Field<int>("Country");
            RefTabCodeName = row.Field<string>("RefTabCodeName");
            RefPackageItemCodeName = row.Field<string>("RefPackageItemCodeName");
            SlotIndex = row.Field<byte>("SlotIndex");
            Param1 = row.Field<int>("Param1");
            Param1_Desc128 = row.Field<string>("Param1_Desc128");
            Param2 = row.Field<int>("Param2");
            Param2_Desc128 = row.Field<string>("Param2_Desc128");
            Param3 = row.Field<int>("Param3");
            Param3_Desc128 = row.Field<string>("Param3_Desc128");
            Param4 = row.Field<int>("Param4");
            Param4_Desc128 = row.Field<string>("Param4_Desc128");
            Index = 0;
        }
    }
}
