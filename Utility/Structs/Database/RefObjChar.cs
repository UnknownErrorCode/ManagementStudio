﻿using System;

namespace Structs.Database
{
    public struct RefObjChar
    {
        public readonly int ID;
        public byte Lvl;
        public byte CharGender;
        public int MaxHP;
        public int MaxMP;
        public int ResistFrozen;
        public int ResistFrostbite;
        public int ResistBurn;
        public int ResistEShock;
        public int ResistPoison;
        public int ResistZombie;
        public int ResistSleep;
        public int ResistRoot;
        public int ResistSlow;
        public int ResistFear;
        public int ResistMyopia;
        public int ResistBlood;
        public int ResistStone;
        public int ResistDark;
        public int ResistStun;
        public int ResistDisea;
        public int ResistChaos;
        public int ResistCsePD;
        public int ResistCseMD;
        public int ResistCseSTR;
        public int ResistCseINT;
        public int ResistCseHP;
        public int ResistCseMP;
        public int Resist24;
        public int ResistBomb;
        public int Resist26;
        public int Resist27;
        public int Resist28;
        public int Resist29;
        public int Resist30;
        public int Resist31;
        public int Resist32;
        public byte InventorySize;
        public byte CanStore_TID1;
        public byte CanStore_TID2;
        public byte CanStore_TID3;
        public byte CanStore_TID4;
        public byte CanBeVehicle;
        public byte CanControl;
        public byte DamagePortion;
        public Int16 MaxPassenger;
        public int AssocTactics;
        public int PD;
        public int MD;
        public int PAR;
        public int MAR;
        public int ER;
        public int BR;
        public int HR;
        public int CHR;
        public int ExpToGive;
        public int CreepType;
        public byte Knockdown;
        public int KO_RecoverTime;
        public int DefaultSkill_1;
        public int DefaultSkill_2;
        public int DefaultSkill_3;
        public int DefaultSkill_4;
        public int DefaultSkill_5;
        public int DefaultSkill_6;
        public int DefaultSkill_7;
        public int DefaultSkill_8;
        public int DefaultSkill_9;
        public int DefaultSkill_10;
        public byte TextureType;
        public int Except_1;
        public int Except_2;
        public int Except_3;
        public int Except_4;
        public int Except_5;
        public int Except_6;
        public int Except_7;
        public int Except_8;
        public int Except_9;
        public int Except_10;
        public int Link;

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
            {
                Except_1 = _Except_1;
            }
            else
            {
                Except_1 = 0;
            }

            if (int.TryParse(row[71].ToString(), out int _Except_2))
            {
                Except_2 = _Except_2;
            }
            else
            {
                Except_2 = 0;
            }

            if (int.TryParse(row[72].ToString(), out int _Except_3))
            {
                Except_3 = _Except_3;
            }
            else
            {
                Except_3 = 0;
            }

            if (int.TryParse(row[73].ToString(), out int _Except_4))
            {
                Except_4 = _Except_4;
            }
            else
            {
                Except_4 = 0;
            }

            if (int.TryParse(row[74].ToString(), out int _Except_5))
            {
                Except_5 = _Except_5;
            }
            else
            {
                Except_5 = 0;
            }

            if (int.TryParse(row[75].ToString(), out int _Except_6))
            {
                Except_6 = _Except_6;
            }
            else
            {
                Except_6 = 0;
            }

            if (int.TryParse(row[76].ToString(), out int _Except_7))
            {
                Except_7 = _Except_7;
            }
            else
            {
                Except_7 = 0;
            }

            if (int.TryParse(row[77].ToString(), out int _Except_8))
            {
                Except_8 = _Except_8;
            }
            else
            {
                Except_8 = 0;
            }

            if (int.TryParse(row[78].ToString(), out int _Except_9))
            {
                Except_9 = _Except_9;
            }
            else
            {
                Except_9 = 0;
            }

            if (int.TryParse(row[79].ToString(), out int _Except_10))
            {
                Except_10 = _Except_10;
            }
            else
            {
                Except_10 = 0;
            }

            Link = int.Parse(row[80].ToString());
        }
    }
}