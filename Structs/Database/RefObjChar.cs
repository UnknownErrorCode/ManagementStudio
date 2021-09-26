using System;

namespace Structs.Database
{
    public struct RefObjChar
    {
        public int ID { get; private set; }
        public byte Lvl{ get; set; }
        public byte CharGender{ get; set; }
        public int MaxHP{ get; set; }
        public int MaxMP{ get; set; }
        public int ResistFrozen{ get; set; }
        public int ResistFrostbite{ get; set; }
        public int ResistBurn{ get; set; }
        public int ResistEShock{ get; set; }
        public int ResistPoison{ get; set; }
        public int ResistZombie{ get; set; }
        public int ResistSleep{ get; set; }
        public int ResistRoot{ get; set; }
        public int ResistSlow{ get; set; }
        public int ResistFear{ get; set; }
        public int ResistMyopia{ get; set; }
        public int ResistBlood{ get; set; }
        public int ResistStone{ get; set; }
        public int ResistDark{ get; set; }
        public int ResistStun{ get; set; }
        public int ResistDisea{ get; set; }
        public int ResistChaos{ get; set; }
        public int ResistCsePD{ get; set; }
        public int ResistCseMD{ get; set; }
        public int ResistCseSTR{ get; set; }
        public int ResistCseINT{ get; set; }
        public int ResistCseHP{ get; set; }
        public int ResistCseMP{ get; set; }
        public int Resist24{ get; set; }
        public int ResistBomb{ get; set; }
        public int Resist26{ get; set; }
        public int Resist27{ get; set; }
        public int Resist28{ get; set; }
        public int Resist29{ get; set; }
        public int Resist30{ get; set; }
        public int Resist31{ get; set; }
        public int Resist32{ get; set; }
        public byte InventorySize{ get; set; }
        public byte CanStore_TID1{ get; set; }
        public byte CanStore_TID2{ get; set; }
        public byte CanStore_TID3{ get; set; }
        public byte CanStore_TID4{ get; set; }
        public byte CanBeVehicle{ get; set; }
        public byte CanControl{ get; set; }
        public byte DamagePortion{ get; set; }
        public Int16 MaxPassenger{ get; set; }
        public int AssocTactics{ get; set; }
        public int PD{ get; set; }
        public int MD{ get; set; }
        public int PAR{ get; set; }
        public int MAR{ get; set; }
        public int ER{ get; set; }
        public int BR{ get; set; }
        public int HR{ get; set; }
        public int CHR{ get; set; }
        public int ExpToGive{ get; set; }
        public int CreepType{ get; set; }
        public byte Knockdown{ get; set; }
        public int KO_RecoverTime{ get; set; }
        public int DefaultSkill_1{ get; set; }
        public int DefaultSkill_2{ get; set; }
        public int DefaultSkill_3{ get; set; }
        public int DefaultSkill_4{ get; set; }
        public int DefaultSkill_5{ get; set; }
        public int DefaultSkill_6{ get; set; }
        public int DefaultSkill_7{ get; set; }
        public int DefaultSkill_8{ get; set; }
        public int DefaultSkill_9{ get; set; }
        public int DefaultSkill_10{ get; set; }
        public byte TextureType{ get; set; }
        public int Except_1{ get; set; }
        public int Except_2{ get; set; }
        public int Except_3{ get; set; }
        public int Except_4{ get; set; }
        public int Except_5{ get; set; }
        public int Except_6{ get; set; }
        public int Except_7{ get; set; }
        public int Except_8{ get; set; }
        public int Except_9{ get; set; }
        public int Except_10{ get; set; }
        public int Link{ get; set; }

        public RefObjChar(object[] row)
        {
            ID = int.Parse(row[0].ToString());
            Lvl = byte.Parse(row[1].ToString());
            CharGender = byte.Parse(row[2].ToString());
            MaxHP = int.Parse(row[3].ToString());
            MaxMP = int.Parse(row[4].ToString());
            ResistFrozen = int.Parse(row[5].ToString());
            ResistFrostbite = int.Parse(row[6].ToString());
            ResistBurn = int.Parse(row[7].ToString());
            ResistEShock = int.Parse(row[8].ToString());
            ResistPoison = int.Parse(row[9].ToString());
            ResistZombie = int.Parse(row[10].ToString());
            ResistSleep = int.Parse(row[11].ToString());
            ResistRoot = int.Parse(row[12].ToString());
            ResistSlow = int.Parse(row[13].ToString());
            ResistFear = int.Parse(row[14].ToString());
            ResistMyopia = int.Parse(row[15].ToString());
            ResistBlood = int.Parse(row[16].ToString());
            ResistStone = int.Parse(row[17].ToString());
            ResistDark = int.Parse(row[18].ToString());
            ResistStun = int.Parse(row[19].ToString());
            ResistDisea = int.Parse(row[20].ToString());
            ResistChaos = int.Parse(row[21].ToString());
            ResistCsePD = int.Parse(row[22].ToString());
            ResistCseMD = int.Parse(row[23].ToString());
            ResistCseSTR = int.Parse(row[24].ToString());
            ResistCseINT = int.Parse(row[25].ToString());
            ResistCseHP = int.Parse(row[26].ToString());
            ResistCseMP = int.Parse(row[27].ToString());
            Resist24 = int.Parse(row[28].ToString());
            ResistBomb = int.Parse(row[29].ToString());
            Resist26 = int.Parse(row[30].ToString());
            Resist27 = int.Parse(row[31].ToString());
            Resist28 = int.Parse(row[32].ToString());
            Resist29 = int.Parse(row[33].ToString());
            Resist30 = int.Parse(row[34].ToString());
            Resist31 = int.Parse(row[35].ToString());
            Resist32 = int.Parse(row[36].ToString());
            InventorySize = byte.Parse(row[37].ToString());
            CanStore_TID1 = byte.Parse(row[38].ToString());
            CanStore_TID2 = byte.Parse(row[39].ToString());
            CanStore_TID3 = byte.Parse(row[40].ToString());
            CanStore_TID4 = byte.Parse(row[41].ToString());
            CanBeVehicle = byte.Parse(row[42].ToString());
            CanControl = byte.Parse(row[43].ToString());
            DamagePortion = byte.Parse(row[44].ToString());
            MaxPassenger = Int16.Parse(row[45].ToString());
            AssocTactics = int.Parse(row[46].ToString());
            PD = int.Parse(row[47].ToString());
            MD = int.Parse(row[48].ToString());
            PAR = int.Parse(row[49].ToString());
            MAR = int.Parse(row[50].ToString());
            ER = int.Parse(row[51].ToString());
            BR = int.Parse(row[52].ToString());
            HR = int.Parse(row[53].ToString());
            CHR = int.Parse(row[54].ToString());
            ExpToGive = int.Parse(row[55].ToString());
            CreepType = int.Parse(row[56].ToString());
            Knockdown = byte.Parse(row[57].ToString());
            KO_RecoverTime = int.Parse(row[58].ToString());
            DefaultSkill_1 = int.Parse(row[59].ToString());
            DefaultSkill_2 = int.Parse(row[60].ToString());
            DefaultSkill_3 = int.Parse(row[61].ToString());
            DefaultSkill_4 = int.Parse(row[62].ToString());
            DefaultSkill_5 = int.Parse(row[63].ToString());
            DefaultSkill_6 = int.Parse(row[64].ToString());
            DefaultSkill_7 = int.Parse(row[65].ToString());
            DefaultSkill_8 = int.Parse(row[66].ToString());
            DefaultSkill_9 = int.Parse(row[67].ToString());
            DefaultSkill_10 = int.Parse(row[68].ToString());
            TextureType = byte.Parse(row[69].ToString());
            if (int.TryParse(row[70].ToString(), out int _Except_1))
                Except_1 = _Except_1;
            else
                Except_1 = 0;
           if(int.TryParse(row[71].ToString(), out int _Except_2))
                Except_2 = _Except_2;
            else
                Except_2 = 0;
            if (int.TryParse(row[72].ToString(), out int _Except_3))
                Except_3 = _Except_3;
            else
                Except_3 = 0;
            if (int.TryParse(row[73].ToString(), out int _Except_4))
                Except_4 = _Except_4;
            else
                Except_4 = 0;
            if (int.TryParse(row[74].ToString(), out int _Except_5))
                Except_5 = _Except_5;
            else
                Except_5 = 0;
            if (int.TryParse(row[75].ToString(), out int _Except_6))   
                Except_6 = _Except_6;
            else
                Except_6 = 0;
           if(int.TryParse(row[76].ToString(), out int _Except_7))
                Except_7 = _Except_7;
            else
                Except_7 = 0;
           if(int.TryParse(row[77].ToString(), out int _Except_8))  
                Except_8 = _Except_8;
            else
                Except_8 = 0;
           if(int.TryParse(row[78].ToString(), out int _Except_9))  
                Except_9 = _Except_9;
            else
                Except_9 = 0;
           if(int.TryParse(row[79].ToString(), out int _Except_10))  
                Except_10 = _Except_10;
            else
                Except_10 = 0;
            Link = int.Parse(row[80].ToString());
        }
    }
}
