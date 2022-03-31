using System;

namespace Structs.Database
{
    public struct IChar
    {
        public readonly int CharID;
        public byte Deleted;
        public int RefObjID;
        public string CharName16;
        public string NickName16;
        public byte Scale;
        public byte CurLevel;
        public byte MaxLevel;
        public Int64 ExpOffset;
        public int SExpOffset;
        public Int16 Strength;
        public Int16 Intellect;
        public Int64 RemainGold;
        public int RemainSkillPoint;
        public Int16 RemainStatPoint;
        public byte RemainHwanCount;
        public int GatheredExpPoint;
        public int HP;
        public int MP;
        public Int16 LatestRegion;
        public float PosX;
        public float PosY;
        public float PosZ;
        public int AppointedTeleport;
        public byte AutoInvestExp;
        public int InventorySize;
        public byte DailyPK;
        public Int16 TotalPK;
        public int PKPenaltyPoint;
        public int TPP;
        public int PenaltyForfeit;
        public int JobPenaltyTime;
        public byte JobLvl_Trader;
        public int Trader_Exp;
        public byte JobLvl_Hunter;
        public int Hunter_Exp;
        public byte JobLvl_Robber;
        public int Robber_Exp;
        public int GuildID;
        public string LastLogout;
        public Int16 TelRegion;
        public string TelPosX;
        public string TelPosY;
        public string TelPosZ;
        public Int16 DiedRegion;
        public string DiedPosX;
        public string DiedPosY;
        public string DiedPosZ;
        public Int16 WorldID;
        public Int16 TelWorldID;
        public Int16 DiedWorldID;
        public byte HwanLevel;

        public IChar(object[] row)
        {
            CharID = int.Parse(row[0].ToString());
            Deleted = byte.Parse(row[1].ToString());
            RefObjID = int.Parse(row[2].ToString());
            CharName16 = row[3].ToString();
            NickName16 = row[4].ToString();
            Scale = byte.Parse(row[5].ToString());
            CurLevel = byte.Parse(row[6].ToString());
            MaxLevel = byte.Parse(row[7].ToString());
            ExpOffset = Int64.Parse(row[8].ToString());
            SExpOffset = int.Parse(row[9].ToString());
            Strength = Int16.Parse(row[10].ToString());
            Intellect = Int16.Parse(row[11].ToString());
            RemainGold = Int64.Parse(row[12].ToString());
            RemainSkillPoint = int.Parse(row[13].ToString());
            RemainStatPoint = Int16.Parse(row[14].ToString());
            RemainHwanCount = byte.Parse(row[15].ToString());
            GatheredExpPoint = int.Parse(row[16].ToString());
            HP = int.Parse(row[17].ToString());
            MP = int.Parse(row[18].ToString());
            LatestRegion = Int16.Parse(row[19].ToString());
            PosX = float.Parse(row[20].ToString());
            PosY = float.Parse(row[21].ToString());
            PosZ = float.Parse(row[22].ToString());
            AppointedTeleport = int.Parse(row[23].ToString());
            AutoInvestExp = byte.Parse(row[24].ToString());
            InventorySize = int.Parse(row[25].ToString());
            DailyPK = byte.Parse(row[26].ToString());
            TotalPK = Int16.Parse(row[27].ToString());
            PKPenaltyPoint = int.Parse(row[28].ToString());
            TPP = int.Parse(row[29].ToString());
            PenaltyForfeit = int.Parse(row[30].ToString());
            JobPenaltyTime = int.Parse(row[31].ToString());
            JobLvl_Trader = byte.Parse(row[32].ToString());
            Trader_Exp = int.Parse(row[33].ToString());
            JobLvl_Hunter = byte.Parse(row[34].ToString());
            Hunter_Exp = int.Parse(row[35].ToString());
            JobLvl_Robber = byte.Parse(row[36].ToString());
            Robber_Exp = int.Parse(row[37].ToString());
            GuildID = int.TryParse(row[38].ToString(), out int guildID) ? guildID : 0;
            LastLogout = row[39].ToString();
            TelRegion = Int16.Parse(row[40].ToString());
            TelPosX = row[41].ToString();
            TelPosY = row[42].ToString();
            TelPosZ = row[43].ToString();
            DiedRegion = Int16.Parse(row[44].ToString());
            DiedPosX = row[45].ToString();
            DiedPosY = row[46].ToString();
            DiedPosZ = row[47].ToString();
            WorldID = Int16.Parse(row[48].ToString());
            TelWorldID = Int16.Parse(row[49].ToString());
            DiedWorldID = Int16.Parse(row[50].ToString());
            HwanLevel = byte.Parse(row[51].ToString());
        }
    }

}
