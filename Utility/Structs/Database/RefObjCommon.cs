using System;
using System.Runtime.InteropServices;

namespace Structs.Database
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 1413)]
    public struct RefObjCommon
    {
        private int service;
        private readonly int iD;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string codeName128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string objName128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string orgObjCodeName128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string nameStrID128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string descStrID128;

        private byte cashItem;
        private byte bionic;
        private byte typeID1;
        private byte typeID2;
        private byte typeID3;
        private byte typeID4;
        private int decayTime;
        private byte country;
        private Rarity rarity;
        private byte canTrade;
        private byte canSell;
        private byte canBuy;
        private BorrowFlag canBorrow;
        private DropFlag canDrop;
        private byte canPick;
        private byte canRepair;
        private byte canRevive;
        private byte canUse;
        private byte canThrow;
        private int price;
        private int costRepair;
        private int costRevive;
        private int costBorrow;
        private int keepingFee;
        private int sellPrice;
        private int reqLevelType1;
        private byte reqLevel1;
        private int reqLevelType2;
        private byte reqLevel2;
        private int reqLevelType3;
        private byte reqLevel3;
        private int reqLevelType4;
        private byte reqLevel4;
        private int maxContain;
        private Int16 regionID;
        private Int16 dir;
        private Int16 offsetX;
        private Int16 offsetY;
        private Int16 offsetZ;
        private Int16 speed1;
        private Int16 speed2;
        private int scale;
        private Int16 bCHeight;
        private Int16 bCRadius;
        private int eventID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string assocFileObj128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string assocFileDrop128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string assocFileIcon128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string assocFile1_128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string assocFile2_128;

        private int link; public RefObjCommon(object[] row)
        {
            service = int.Parse(row[0].ToString());
            iD = int.Parse(row[1].ToString());
            codeName128 = row[2].ToString();
            objName128 = row[3].ToString();
            orgObjCodeName128 = row[4].ToString();
            nameStrID128 = row[5].ToString();
            descStrID128 = row[6].ToString();
            cashItem = byte.Parse(row[7].ToString());
            bionic = byte.Parse(row[8].ToString());
            typeID1 = byte.Parse(row[9].ToString());
            typeID2 = byte.Parse(row[10].ToString());
            typeID3 = byte.Parse(row[11].ToString());
            typeID4 = byte.Parse(row[12].ToString());
            decayTime = int.Parse(row[13].ToString());
            country = byte.Parse(row[14].ToString());
            rarity = (Rarity)byte.Parse(row[15].ToString());
            canTrade = byte.Parse(row[16].ToString());
            canSell = byte.Parse(row[17].ToString());
            canBuy = byte.Parse(row[18].ToString());
            canBorrow = (BorrowFlag)byte.Parse(row[19].ToString());
            canDrop = (DropFlag)byte.Parse(row[20].ToString());
            canPick = byte.Parse(row[21].ToString());
            canRepair = byte.Parse(row[22].ToString());
            canRevive = byte.Parse(row[23].ToString());
            canUse = byte.Parse(row[24].ToString());
            canThrow = byte.Parse(row[25].ToString());
            price = int.Parse(row[26].ToString());
            costRepair = int.Parse(row[27].ToString());
            costRevive = int.Parse(row[28].ToString());
            costBorrow = int.Parse(row[29].ToString());
            keepingFee = int.Parse(row[30].ToString());
            sellPrice = int.Parse(row[31].ToString());
            reqLevelType1 = int.Parse(row[32].ToString());
            reqLevel1 = byte.Parse(row[33].ToString());
            reqLevelType2 = int.Parse(row[34].ToString());
            reqLevel2 = byte.Parse(row[35].ToString());
            reqLevelType3 = int.Parse(row[36].ToString());
            reqLevel3 = byte.Parse(row[37].ToString());
            reqLevelType4 = int.Parse(row[38].ToString());
            reqLevel4 = byte.Parse(row[39].ToString());
            maxContain = int.Parse(row[40].ToString());
            regionID = Int16.Parse(row[41].ToString());
            dir = Int16.Parse(row[42].ToString());
            offsetX = Int16.Parse(row[43].ToString());
            offsetY = Int16.Parse(row[44].ToString());
            offsetZ = Int16.Parse(row[45].ToString());
            speed1 = Int16.Parse(row[46].ToString());
            speed2 = Int16.Parse(row[47].ToString());
            scale = int.Parse(row[48].ToString());
            bCHeight = Int16.Parse(row[49].ToString());
            bCRadius = Int16.Parse(row[50].ToString());
            eventID = int.Parse(row[51].ToString());
            assocFileObj128 = row[52].ToString();
            assocFileDrop128 = row[53].ToString();
            assocFileIcon128 = row[54].ToString();
            assocFile1_128 = row[55].ToString();
            assocFile2_128 = row[56].ToString();
            link = int.Parse(row[57].ToString());
        }

        public int Service { get => service; set => service = value; }

        public int ID => iD;

        public string CodeName128 { get => codeName128; set => codeName128 = value; }
        public string ObjName128 { get => objName128; set => objName128 = value; }
        public string OrgObjCodeName128 { get => orgObjCodeName128; set => orgObjCodeName128 = value; }
        public string NameStrID128 { get => nameStrID128; set => nameStrID128 = value; }
        public string DescStrID128 { get => descStrID128; set => descStrID128 = value; }
        public byte CashItem { get => cashItem; set => cashItem = value; }
        public byte Bionic { get => bionic; set => bionic = value; }
        public byte TypeID1 { get => typeID1; set => typeID1 = value; }
        public byte TypeID2 { get => typeID2; set => typeID2 = value; }
        public byte TypeID3 { get => typeID3; set => typeID3 = value; }
        public byte TypeID4 { get => typeID4; set => typeID4 = value; }
        public int DecayTime { get => decayTime; set => decayTime = value; }
        public byte Country { get => country; set => country = value; }
        public Rarity Rarity { get => rarity; set => rarity = value; }
        public byte CanTrade { get => canTrade; set => canTrade = value; }
        public byte CanSell { get => canSell; set => canSell = value; }
        public byte CanBuy { get => canBuy; set => canBuy = value; }
        public BorrowFlag CanBorrow { get => canBorrow; set => canBorrow = value; }
        public DropFlag CanDrop { get => canDrop; set => canDrop = value; }
        public byte CanPick { get => canPick; set => canPick = value; }
        public byte CanRepair { get => canRepair; set => canRepair = value; }
        public byte CanRevive { get => canRevive; set => canRevive = value; }
        public byte CanUse { get => canUse; set => canUse = value; }
        public byte CanThrow { get => canThrow; set => canThrow = value; }
        public int Price { get => price; set => price = value; }
        public int CostRepair { get => costRepair; set => costRepair = value; }
        public int CostRevive { get => costRevive; set => costRevive = value; }
        public int CostBorrow { get => costBorrow; set => costBorrow = value; }
        public int KeepingFee { get => keepingFee; set => keepingFee = value; }
        public int SellPrice { get => sellPrice; set => sellPrice = value; }
        public int ReqLevelType1 { get => reqLevelType1; set => reqLevelType1 = value; }
        public byte ReqLevel1 { get => reqLevel1; set => reqLevel1 = value; }
        public int ReqLevelType2 { get => reqLevelType2; set => reqLevelType2 = value; }
        public byte ReqLevel2 { get => reqLevel2; set => reqLevel2 = value; }
        public int ReqLevelType3 { get => reqLevelType3; set => reqLevelType3 = value; }
        public byte ReqLevel3 { get => reqLevel3; set => reqLevel3 = value; }
        public int ReqLevelType4 { get => reqLevelType4; set => reqLevelType4 = value; }
        public byte ReqLevel4 { get => reqLevel4; set => reqLevel4 = value; }
        public int MaxContain { get => maxContain; set => maxContain = value; }
        public short RegionID { get => regionID; set => regionID = value; }
        public short Dir { get => dir; set => dir = value; }
        public short OffsetX { get => offsetX; set => offsetX = value; }
        public short OffsetY { get => offsetY; set => offsetY = value; }
        public short OffsetZ { get => offsetZ; set => offsetZ = value; }
        public short Speed1 { get => speed1; set => speed1 = value; }
        public short Speed2 { get => speed2; set => speed2 = value; }
        public int Scale { get => scale; set => scale = value; }
        public short BCHeight { get => bCHeight; set => bCHeight = value; }
        public short BCRadius { get => bCRadius; set => bCRadius = value; }
        public int EventID { get => eventID; set => eventID = value; }
        public string AssocFileObj128 { get => assocFileObj128; set => assocFileObj128 = value; }
        public string AssocFileDrop128 { get => assocFileDrop128; set => assocFileDrop128 = value; }
        public string AssocFileIcon128 { get => assocFileIcon128; set => assocFileIcon128 = value; }
        public string AssocFile1_128 { get => assocFile1_128; set => assocFile1_128 = value; }
        public string AssocFile2_128 { get => assocFile2_128; set => assocFile2_128 = value; }
        public int Link { get => link; set => link = value; }
    }
}