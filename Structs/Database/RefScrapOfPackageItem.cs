using System.Data;

namespace Structs.Database
{
    public struct RefScrapOfPackageItem
    {
        public byte Service;
        public string RefPackageItemCodeName;
        public string RefItemCodeName;
        public byte OptLevel;
        public long Variance;
        public int Data;
        public byte MagParamNum;
        public long MagParam1;
        public long MagParam2;
        public long MagParam3;
        public long MagParam4;
        public long MagParam5;
        public long MagParam6;
        public long MagParam7;
        public long MagParam8;
        public long MagParam9;
        public long MagParam10;
        public long MagParam11;
        public long MagParam12;
        public RefScrapOfPackageItem(DataRow row)
        {
            Service = row.Field<byte>("Service");
            RefPackageItemCodeName = row.Field<string>("RefPackageItemCodeName");
            RefItemCodeName = row.Field<string>("RefItemCodeName");
            OptLevel = row.Field<byte>("OptLevel");
            Variance = row.Field<long>("Variance");
            Data = row.Field<int>("Data");
            MagParamNum = row.Field<byte>("MagParamNum");
            MagParam1 = row.Field<long>("MagParam1");
            MagParam2 = row.Field<long>("MagParam2");
            MagParam3 = row.Field<long>("MagParam3");
            MagParam4 = row.Field<long>("MagParam4");
            MagParam5 = row.Field<long>("MagParam5");
            MagParam6 = row.Field<long>("MagParam6");
            MagParam7 = row.Field<long>("MagParam7");
            MagParam8 = row.Field<long>("MagParam8");
            MagParam9 = row.Field<long>("MagParam9");
            MagParam10 = row.Field<long>("MagParam10");
            MagParam11 = row.Field<long>("MagParam11");
            MagParam12 = row.Field<long>("MagParam12");
        }
    }
}
