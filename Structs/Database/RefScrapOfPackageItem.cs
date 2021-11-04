using System.Data;

namespace Structs.Database
{
    public struct RefScrapOfPackageItem
    {
        public byte Service{ get; set; }
        public string RefPackageItemCodeName{ get; set; }
        public string RefItemCodeName{ get; set; }
        public byte OptLevel{ get; set; }
        public long Variance{ get; set; }
        public int Data{ get; set; }
        public byte MagParamNum{ get; set; }
        public long MagParam1{ get; set; }
        public long MagParam2{ get; set; }
        public long MagParam3{ get; set; }
        public long MagParam4{ get; set; }
        public long MagParam5{ get; set; }
        public long MagParam6{ get; set; }
        public long MagParam7{ get; set; }
        public long MagParam8{ get; set; }
        public long MagParam9{ get; set; }
        public long MagParam10{ get; set; }
        public long MagParam11{ get; set; }
        public long MagParam12{ get; set; }
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
