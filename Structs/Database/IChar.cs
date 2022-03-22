using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Database
{
    public struct IChar
    {
        public int CharID { get; private set; }
        public byte Deleted { get; set; }
        public int RefObjID { get; set; }
        public string CharName16 { get; set; }
        public string NickName16 { get; set; }
        public byte Scale { get; set; }
        public byte CurLevel { get; set; }
        public byte MaxLevel { get; set; }
        public Int64 ExpOffset { get; set; }
        public int SExpOffset { get; set; }
        public Int16 Strength { get; set; }
        public Int16 Intellect { get; set; }
        public Int64 RemainGold { get; set; }
        public int RemainSkillPoint { get; set; }
        public Int16 RemainStatPoint { get; set; }
        public byte RemainHwanCount { get; set; }
        public int GatheredExpPoint { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public Int16 LatestRegion { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public int AppointedTeleport { get; set; }
        public byte AutoInvestExp { get; set; }
        public int InventorySize { get; set; }
        public byte DailyPK { get; set; }
        public Int16 TotalPK { get; set; }
        public int PKPenaltyPoint { get; set; }
        public int TPP { get; set; }
        public int PenaltyForfeit { get; set; }
        public int JobPenaltyTime { get; set; }
        public byte JobLvl_Trader { get; set; }
        public int Trader_Exp { get; set; }
        public byte JobLvl_Hunter { get; set; }
        public int Hunter_Exp { get; set; }
        public byte JobLvl_Robber { get; set; }
        public int Robber_Exp { get; set; }
        public int GuildID { get; set; }
        public string LastLogout { get; set; }
        public Int16 TelRegion { get; set; }
        public string TelPosX { get; set; }
        public string TelPosY { get; set; }
        public string TelPosZ { get; set; }
        public Int16 DiedRegion { get; set; }
        public string DiedPosX { get; set; }
        public string DiedPosY { get; set; }
        public string DiedPosZ { get; set; }
        public Int16 WorldID { get; set; }
        public Int16 TelWorldID { get; set; }
        public Int16 DiedWorldID { get; set; }
        public byte HwanLevel { get; set; }

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
