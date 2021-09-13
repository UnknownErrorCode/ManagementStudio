using System;
using System.Data;

namespace ShopEditor.Interface.ShopInterface
{
    internal struct RefScrapOfPackageItem
    {
        byte    Service;
        string  RefPackageItemCodeName;
        string  RefItemCodeName;
        byte    OptLevel;
        long    Variance;
        int     Data;
        byte    MagParamNum;
        long    MagParam1 ;
        long    MagParam2 ;
        long    MagParam3 ;
        long    MagParam4 ;
        long    MagParam5 ;
        long    MagParam6 ;
        long    MagParam7 ;
        long    MagParam8 ;
        long    MagParam9 ;
        long    MagParam10;
        long    MagParam11;
        long    MagParam12;
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