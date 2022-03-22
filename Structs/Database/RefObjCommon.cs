using System;

namespace Structs.Database
{
    public struct RefObjCommon
    {
        public int Service { get; set; }
        public int ID { get; private set; }
        public string CodeName128 { get; set; }
        public string ObjName128 { get; set; }
        public string OrgObjCodeName128 { get; set; }
        public string NameStrID128 { get; set; }
        public string DescStrID128 { get; set; }
        public byte CashItem { get; set; }
        public byte Bionic { get; set; }
        public byte TypeID1 { get; set; }
        public byte TypeID2 { get; set; }
        public byte TypeID3 { get; set; }
        public byte TypeID4 { get; set; }
        public int DecayTime { get; set; }
        public byte Country { get; set; }
        public Rarity Rarity { get; set; }
        public byte CanTrade { get; set; }
        public byte CanSell { get; set; }
        public byte CanBuy { get; set; }
        public BorrowFlag CanBorrow { get; set; }
        public DropFlag CanDrop { get; set; }
        public byte CanPick { get; set; }
        public byte CanRepair { get; set; }
        public byte CanRevive { get; set; }
        public byte CanUse { get; set; }
        public byte CanThrow { get; set; }
        public int Price { get; set; }
        public int CostRepair { get; set; }
        public int CostRevive { get; set; }
        public int CostBorrow { get; set; }
        public int KeepingFee { get; set; }
        public int SellPrice { get; set; }
        public int ReqLevelType1 { get; set; }
        public byte ReqLevel1 { get; set; }
        public int ReqLevelType2 { get; set; }
        public byte ReqLevel2 { get; set; }
        public int ReqLevelType3 { get; set; }
        public byte ReqLevel3 { get; set; }
        public int ReqLevelType4 { get; set; }
        public byte ReqLevel4 { get; set; }
        public int MaxContain { get; set; }
        public Int16 RegionID { get; set; }
        public Int16 Dir { get; set; }
        public Int16 OffsetX { get; set; }
        public Int16 OffsetY { get; set; }
        public Int16 OffsetZ { get; set; }
        public Int16 Speed1 { get; set; }
        public Int16 Speed2 { get; set; }
        public int Scale { get; set; }
        public Int16 BCHeight { get; set; }
        public Int16 BCRadius { get; set; }
        public int EventID { get; set; }
        public string AssocFileObj128 { get; set; }
        public string AssocFileDrop128 { get; set; }
        public string AssocFileIcon128 { get; set; }
        public string AssocFile1_128 { get; set; }
        public string AssocFile2_128 { get; set; }
        public int Link { get; set; }

        public RefObjCommon(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            CodeName128 = row[2].ToString();
            ObjName128 = row[3].ToString();
            OrgObjCodeName128 = row[4].ToString();
            NameStrID128 = row[5].ToString();
            DescStrID128 = row[6].ToString();
            CashItem = byte.Parse(row[7].ToString());
            Bionic = byte.Parse(row[8].ToString());
            TypeID1 = byte.Parse(row[9].ToString());
            TypeID2 = byte.Parse(row[10].ToString());
            TypeID3 = byte.Parse(row[11].ToString());
            TypeID4 = byte.Parse(row[12].ToString());
            DecayTime = int.Parse(row[13].ToString());
            Country = byte.Parse(row[14].ToString());
            Rarity = (Rarity)byte.Parse(row[15].ToString());
            CanTrade = byte.Parse(row[16].ToString());
            CanSell = byte.Parse(row[17].ToString());
            CanBuy = byte.Parse(row[18].ToString());
            CanBorrow = (BorrowFlag)byte.Parse(row[19].ToString());
            CanDrop = (DropFlag)byte.Parse(row[20].ToString());
            CanPick = byte.Parse(row[21].ToString());
            CanRepair = byte.Parse(row[22].ToString());
            CanRevive = byte.Parse(row[23].ToString());
            CanUse = byte.Parse(row[24].ToString());
            CanThrow = byte.Parse(row[25].ToString());
            Price = int.Parse(row[26].ToString());
            CostRepair = int.Parse(row[27].ToString());
            CostRevive = int.Parse(row[28].ToString());
            CostBorrow = int.Parse(row[29].ToString());
            KeepingFee = int.Parse(row[30].ToString());
            SellPrice = int.Parse(row[31].ToString());
            ReqLevelType1 = int.Parse(row[32].ToString());
            ReqLevel1 = byte.Parse(row[33].ToString());
            ReqLevelType2 = int.Parse(row[34].ToString());
            ReqLevel2 = byte.Parse(row[35].ToString());
            ReqLevelType3 = int.Parse(row[36].ToString());
            ReqLevel3 = byte.Parse(row[37].ToString());
            ReqLevelType4 = int.Parse(row[38].ToString());
            ReqLevel4 = byte.Parse(row[39].ToString());
            MaxContain = int.Parse(row[40].ToString());
            RegionID = Int16.Parse(row[41].ToString());
            Dir = Int16.Parse(row[42].ToString());
            OffsetX = Int16.Parse(row[43].ToString());
            OffsetY = Int16.Parse(row[44].ToString());
            OffsetZ = Int16.Parse(row[45].ToString());
            Speed1 = Int16.Parse(row[46].ToString());
            Speed2 = Int16.Parse(row[47].ToString());
            Scale = int.Parse(row[48].ToString());
            BCHeight = Int16.Parse(row[49].ToString());
            BCRadius = Int16.Parse(row[50].ToString());
            EventID = int.Parse(row[51].ToString());
            AssocFileObj128 = row[52].ToString();
            AssocFileDrop128 = row[53].ToString();
            AssocFileIcon128 = row[54].ToString();
            AssocFile1_128 = row[55].ToString();
            AssocFile2_128 = row[56].ToString();
            Link = int.Parse(row[57].ToString());
        }
    }
}
