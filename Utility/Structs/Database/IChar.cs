using System;
using System.Runtime.InteropServices;

namespace Structs.Database
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 312)]//298)]
    public struct IChar
    {
        private readonly int charID;
        private byte deleted;
        private int refObjID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        private string charName16;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        private string nickName16;

        private byte scale;
        private byte curLevel;
        private byte maxLevel;
        private Int64 expOffset;
        private int sExpOffset;
        private Int16 strength;
        private Int16 intellect;
        private Int64 remainGold;
        private int remainSkillPoint;
        private Int16 remainStatPoint;
        private byte remainHwanCount;
        private int gatheredExpPoint;
        private int hP;
        private int mP;
        private Int16 latestRegion;
        private float posX;
        private float posY;
        private float posZ;
        private int appointedTeleport;
        private byte autoInvestExp;
        private int inventorySize;
        private byte dailyPK;
        private Int16 totalPK;
        private int pKPenaltyPoint;
        private int tPP;
        private int penaltyForfeit;
        private int jobPenaltyTime;//111
        private byte jobLvl_Trader;
        private int trader_Exp;
        private byte jobLvl_Hunter;
        private int hunter_Exp;
        private byte jobLvl_Robber;
        private int robber_Exp;
        private int guildID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
        private DateTime lastLogout;

        private Int16 telRegion; // 132
        private float telPosX;
        private float telPosY;
        private float telPosZ;
        private Int16 diedRegion;
        private float diedPosX;
        private float diedPosY;
        private float diedPosZ;
        private Int16 worldID;
        private Int16 telWorldID;
        private Int16 diedWorldID;
        private byte hwanLevel; // 165

        public IChar(object[] row)
        {
            charID = int.Parse(row[0].ToString());
            deleted = byte.Parse(row[1].ToString());
            refObjID = int.Parse(row[2].ToString());
            charName16 = row[3].ToString();
            nickName16 = row[4].ToString();
            scale = byte.Parse(row[5].ToString());
            curLevel = byte.Parse(row[6].ToString());
            maxLevel = byte.Parse(row[7].ToString());
            expOffset = Int64.Parse(row[8].ToString());
            sExpOffset = int.Parse(row[9].ToString());
            strength = Int16.Parse(row[10].ToString());
            intellect = Int16.Parse(row[11].ToString());
            remainGold = Int64.Parse(row[12].ToString());
            remainSkillPoint = int.Parse(row[13].ToString());
            remainStatPoint = Int16.Parse(row[14].ToString());
            remainHwanCount = byte.Parse(row[15].ToString());
            gatheredExpPoint = int.Parse(row[16].ToString());
            hP = int.Parse(row[17].ToString());
            mP = int.Parse(row[18].ToString());
            latestRegion = Int16.Parse(row[19].ToString());
            posX = float.Parse(row[20].ToString());
            posY = float.Parse(row[21].ToString());
            posZ = float.Parse(row[22].ToString());
            appointedTeleport = int.Parse(row[23].ToString());
            autoInvestExp = byte.Parse(row[24].ToString());
            inventorySize = int.Parse(row[25].ToString());
            dailyPK = byte.Parse(row[26].ToString());
            totalPK = Int16.Parse(row[27].ToString());
            pKPenaltyPoint = int.Parse(row[28].ToString());
            tPP = int.Parse(row[29].ToString());
            penaltyForfeit = int.Parse(row[30].ToString());
            jobPenaltyTime = int.Parse(row[31].ToString());
            jobLvl_Trader = byte.Parse(row[32].ToString());
            trader_Exp = int.Parse(row[33].ToString());
            jobLvl_Hunter = byte.Parse(row[34].ToString());
            hunter_Exp = int.Parse(row[35].ToString());
            jobLvl_Robber = byte.Parse(row[36].ToString());
            robber_Exp = int.Parse(row[37].ToString());
            guildID = int.TryParse(row[38].ToString(), out int _guildID) ? _guildID : 0;
            lastLogout = DateTime.Parse(row[39].ToString());
            telRegion = Int16.Parse(row[40].ToString());
            telPosX = float.Parse(row[41].ToString());
            telPosY = float.Parse(row[42].ToString());
            telPosZ = float.Parse(row[43].ToString());
            diedRegion = Int16.Parse(row[44].ToString());
            diedPosX = float.Parse(row[45].ToString());
            diedPosY = float.Parse(row[46].ToString());
            diedPosZ = float.Parse(row[47].ToString());
            worldID = Int16.Parse(row[48].ToString());
            telWorldID = Int16.Parse(row[49].ToString());
            diedWorldID = Int16.Parse(row[50].ToString());
            hwanLevel = byte.Parse(row[51].ToString());
        }

        public int CharID => charID;

        public byte Deleted { get => deleted; set => deleted = value; }
        public int RefObjID { get => refObjID; set => refObjID = value; }
        public string CharName16 { get => charName16; set => charName16 = value; }
        public string NickName16 { get => nickName16; set => nickName16 = value; }
        public byte Scale { get => scale; set => scale = value; }
        public byte CurLevel { get => curLevel; set => curLevel = value; }
        public byte MaxLevel { get => maxLevel; set => maxLevel = value; }
        public long ExpOffset { get => expOffset; set => expOffset = value; }
        public int SExpOffset { get => sExpOffset; set => sExpOffset = value; }
        public short Strength { get => strength; set => strength = value; }
        public short Intellect { get => intellect; set => intellect = value; }
        public long RemainGold { get => remainGold; set => remainGold = value; }
        public int RemainSkillPoint { get => remainSkillPoint; set => remainSkillPoint = value; }
        public short RemainStatPoint { get => remainStatPoint; set => remainStatPoint = value; }
        public byte RemainHwanCount { get => remainHwanCount; set => remainHwanCount = value; }
        public int GatheredExpPoint { get => gatheredExpPoint; set => gatheredExpPoint = value; }
        public int HP { get => hP; set => hP = value; }
        public int MP { get => mP; set => mP = value; }
        public short LatestRegion { get => latestRegion; set => latestRegion = value; }
        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }
        public float PosZ { get => posZ; set => posZ = value; }
        public int AppointedTeleport { get => appointedTeleport; set => appointedTeleport = value; }
        public byte AutoInvestExp { get => autoInvestExp; set => autoInvestExp = value; }
        public int InventorySize { get => inventorySize; set => inventorySize = value; }
        public byte DailyPK { get => dailyPK; set => dailyPK = value; }
        public short TotalPK { get => totalPK; set => totalPK = value; }
        public int PKPenaltyPoint { get => pKPenaltyPoint; set => pKPenaltyPoint = value; }
        public int TPP { get => tPP; set => tPP = value; }
        public int PenaltyForfeit { get => penaltyForfeit; set => penaltyForfeit = value; }
        public int JobPenaltyTime { get => jobPenaltyTime; set => jobPenaltyTime = value; }
        public byte JobLvl_Trader { get => jobLvl_Trader; set => jobLvl_Trader = value; }
        public int Trader_Exp { get => trader_Exp; set => trader_Exp = value; }
        public byte JobLvl_Hunter { get => jobLvl_Hunter; set => jobLvl_Hunter = value; }
        public int Hunter_Exp { get => hunter_Exp; set => hunter_Exp = value; }
        public byte JobLvl_Robber { get => jobLvl_Robber; set => jobLvl_Robber = value; }
        public int Robber_Exp { get => robber_Exp; set => robber_Exp = value; }
        public int GuildID { get => guildID; set => guildID = value; }
        public DateTime LastLogout { get => lastLogout; set => lastLogout = value; }
        public short TelRegion { get => telRegion; set => telRegion = value; }
        public float TelPosX { get => telPosX; set => telPosX = value; }
        public float TelPosY { get => telPosY; set => telPosY = value; }
        public float TelPosZ { get => telPosZ; set => telPosZ = value; }
        public short DiedRegion { get => diedRegion; set => diedRegion = value; }
        public float DiedPosX { get => diedPosX; set => diedPosX = value; }
        public float DiedPosY { get => diedPosY; set => diedPosY = value; }
        public float DiedPosZ { get => diedPosZ; set => diedPosZ = value; }
        public short WorldID { get => worldID; set => worldID = value; }
        public short TelWorldID { get => telWorldID; set => telWorldID = value; }
        public short DiedWorldID { get => diedWorldID; set => diedWorldID = value; }
        public byte HwanLevel { get => hwanLevel; set => hwanLevel = value; }
    }
}