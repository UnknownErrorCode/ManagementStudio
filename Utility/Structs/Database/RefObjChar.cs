using System;

namespace Structs.Database
{
    public struct RefObjChar
    {
        private readonly int iD;
        private byte lvl;
        private byte charGender;
        private int maxHP;
        private int maxMP;
        private int resistFrozen;
        private int resistFrostbite;
        private int resistBurn;
        private int resistEShock;
        private int resistPoison;
        private int resistZombie;
        private int resistSleep;
        private int resistRoot;
        private int resistSlow;
        private int resistFear;
        private int resistMyopia;
        private int resistBlood;
        private int resistStone;
        private int resistDark;
        private int resistStun;
        private int resistDisea;
        private int resistChaos;
        private int resistCsePD;
        private int resistCseMD;
        private int resistCseSTR;
        private int resistCseINT;
        private int resistCseHP;
        private int resistCseMP;
        private int resist24;
        private int resistBomb;
        private int resist26;
        private int resist27;
        private int resist28;
        private int resist29;
        private int resist30;
        private int resist31;
        private int resist32;
        private byte inventorySize;
        private byte canStore_TID1;
        private byte canStore_TID2;
        private byte canStore_TID3;
        private byte canStore_TID4;
        private byte canBeVehicle;
        private byte canControl;
        private byte damagePortion;
        private Int16 maxPassenger;
        private int assocTactics;
        private int pD;
        private int mD;
        private int pAR;
        private int mAR;
        private int eR;
        private int bR;
        private int hR;
        private int cHR;
        private int expToGive;
        private int creepType;
        private byte knockdown;
        private int kO_RecoverTime;
        private int defaultSkill_1;
        private int defaultSkill_2;
        private int defaultSkill_3;
        private int defaultSkill_4;
        private int defaultSkill_5;
        private int defaultSkill_6;
        private int defaultSkill_7;
        private int defaultSkill_8;
        private int defaultSkill_9;
        private int defaultSkill_10;
        private byte textureType;
        private int except_1;
        private int except_2;
        private int except_3;
        private int except_4;
        private int except_5;
        private int except_6;
        private int except_7;
        private int except_8;
        private int except_9;
        private int except_10;
        private int link;

        public RefObjChar(object[] row)
        {
            iD = int.Parse(row[0].ToString());
            lvl = byte.Parse(row[1].ToString());
            charGender = byte.Parse(row[2].ToString());
            maxHP = int.Parse(row[3].ToString());
            maxMP = int.Parse(row[4].ToString());
            resistFrozen = int.Parse(row[5].ToString());
            resistFrostbite = int.Parse(row[6].ToString());
            resistBurn = int.Parse(row[7].ToString());
            resistEShock = int.Parse(row[8].ToString());
            resistPoison = int.Parse(row[9].ToString());
            resistZombie = int.Parse(row[10].ToString());
            resistSleep = int.Parse(row[11].ToString());
            resistRoot = int.Parse(row[12].ToString());
            resistSlow = int.Parse(row[13].ToString());
            resistFear = int.Parse(row[14].ToString());
            resistMyopia = int.Parse(row[15].ToString());
            resistBlood = int.Parse(row[16].ToString());
            resistStone = int.Parse(row[17].ToString());
            resistDark = int.Parse(row[18].ToString());
            resistStun = int.Parse(row[19].ToString());
            resistDisea = int.Parse(row[20].ToString());
            resistChaos = int.Parse(row[21].ToString());
            resistCsePD = int.Parse(row[22].ToString());
            resistCseMD = int.Parse(row[23].ToString());
            resistCseSTR = int.Parse(row[24].ToString());
            resistCseINT = int.Parse(row[25].ToString());
            resistCseHP = int.Parse(row[26].ToString());
            resistCseMP = int.Parse(row[27].ToString());
            resist24 = int.Parse(row[28].ToString());
            resistBomb = int.Parse(row[29].ToString());
            resist26 = int.Parse(row[30].ToString());
            resist27 = int.Parse(row[31].ToString());
            resist28 = int.Parse(row[32].ToString());
            resist29 = int.Parse(row[33].ToString());
            resist30 = int.Parse(row[34].ToString());
            resist31 = int.Parse(row[35].ToString());
            resist32 = int.Parse(row[36].ToString());
            inventorySize = byte.Parse(row[37].ToString());
            canStore_TID1 = byte.Parse(row[38].ToString());
            canStore_TID2 = byte.Parse(row[39].ToString());
            canStore_TID3 = byte.Parse(row[40].ToString());
            canStore_TID4 = byte.Parse(row[41].ToString());
            canBeVehicle = byte.Parse(row[42].ToString());
            canControl = byte.Parse(row[43].ToString());
            damagePortion = byte.Parse(row[44].ToString());
            maxPassenger = Int16.Parse(row[45].ToString());
            assocTactics = int.Parse(row[46].ToString());
            pD = int.Parse(row[47].ToString());
            mD = int.Parse(row[48].ToString());
            pAR = int.Parse(row[49].ToString());
            mAR = int.Parse(row[50].ToString());
            eR = int.Parse(row[51].ToString());
            bR = int.Parse(row[52].ToString());
            hR = int.Parse(row[53].ToString());
            cHR = int.Parse(row[54].ToString());
            expToGive = int.Parse(row[55].ToString());
            creepType = int.Parse(row[56].ToString());
            knockdown = byte.Parse(row[57].ToString());
            kO_RecoverTime = int.Parse(row[58].ToString());
            defaultSkill_1 = int.Parse(row[59].ToString());
            defaultSkill_2 = int.Parse(row[60].ToString());
            defaultSkill_3 = int.Parse(row[61].ToString());
            defaultSkill_4 = int.Parse(row[62].ToString());
            defaultSkill_5 = int.Parse(row[63].ToString());
            defaultSkill_6 = int.Parse(row[64].ToString());
            defaultSkill_7 = int.Parse(row[65].ToString());
            defaultSkill_8 = int.Parse(row[66].ToString());
            defaultSkill_9 = int.Parse(row[67].ToString());
            defaultSkill_10 = int.Parse(row[68].ToString());
            textureType = byte.Parse(row[69].ToString());
            except_1 = int.TryParse(row[70].ToString(), out int _Except_1) ? _Except_1 : 0;
            except_2 = int.TryParse(row[71].ToString(), out int _Except_2) ? _Except_2 : 0;
            except_3 = int.TryParse(row[71].ToString(), out int _Except_3) ? _Except_3 : 0;
            except_4 = int.TryParse(row[71].ToString(), out int _Except_4) ? _Except_4 : 0;
            except_5 = int.TryParse(row[71].ToString(), out int _Except_5) ? _Except_5 : 0;
            except_6 = int.TryParse(row[71].ToString(), out int _Except_6) ? _Except_6 : 0;
            except_7 = int.TryParse(row[71].ToString(), out int _Except_7) ? _Except_7 : 0;
            except_8 = int.TryParse(row[71].ToString(), out int _Except_8) ? _Except_8 : 0;
            except_9 = int.TryParse(row[78].ToString(), out int _Except_9) ? _Except_9 : 0;
            except_10 = int.TryParse(row[79].ToString(), out int _Except_10) ? _Except_10 : 0;
            link = int.TryParse(row[80].ToString(), out int _link) ? _link : 0;
        }

        public int ID => iD;

        public byte Lvl { get => lvl; set => lvl = value; }
        public byte CharGender { get => charGender; set => charGender = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int MaxMP { get => maxMP; set => maxMP = value; }
        public int ResistFrozen { get => resistFrozen; set => resistFrozen = value; }
        public int ResistFrostbite { get => resistFrostbite; set => resistFrostbite = value; }
        public int ResistBurn { get => resistBurn; set => resistBurn = value; }
        public int ResistEShock { get => resistEShock; set => resistEShock = value; }
        public int ResistPoison { get => resistPoison; set => resistPoison = value; }
        public int ResistZombie { get => resistZombie; set => resistZombie = value; }
        public int ResistSleep { get => resistSleep; set => resistSleep = value; }
        public int ResistRoot { get => resistRoot; set => resistRoot = value; }
        public int ResistSlow { get => resistSlow; set => resistSlow = value; }
        public int ResistFear { get => resistFear; set => resistFear = value; }
        public int ResistMyopia { get => resistMyopia; set => resistMyopia = value; }
        public int ResistBlood { get => resistBlood; set => resistBlood = value; }
        public int ResistStone { get => resistStone; set => resistStone = value; }
        public int ResistDark { get => resistDark; set => resistDark = value; }
        public int ResistStun { get => resistStun; set => resistStun = value; }
        public int ResistDisea { get => resistDisea; set => resistDisea = value; }
        public int ResistChaos { get => resistChaos; set => resistChaos = value; }
        public int ResistCsePD { get => resistCsePD; set => resistCsePD = value; }
        public int ResistCseMD { get => resistCseMD; set => resistCseMD = value; }
        public int ResistCseSTR { get => resistCseSTR; set => resistCseSTR = value; }
        public int ResistCseINT { get => resistCseINT; set => resistCseINT = value; }
        public int ResistCseHP { get => resistCseHP; set => resistCseHP = value; }
        public int ResistCseMP { get => resistCseMP; set => resistCseMP = value; }
        public int Resist24 { get => resist24; set => resist24 = value; }
        public int ResistBomb { get => resistBomb; set => resistBomb = value; }
        public int Resist26 { get => resist26; set => resist26 = value; }
        public int Resist27 { get => resist27; set => resist27 = value; }
        public int Resist28 { get => resist28; set => resist28 = value; }
        public int Resist29 { get => resist29; set => resist29 = value; }
        public int Resist30 { get => resist30; set => resist30 = value; }
        public int Resist31 { get => resist31; set => resist31 = value; }
        public int Resist32 { get => resist32; set => resist32 = value; }
        public byte InventorySize { get => inventorySize; set => inventorySize = value; }
        public byte CanStore_TID1 { get => canStore_TID1; set => canStore_TID1 = value; }
        public byte CanStore_TID2 { get => canStore_TID2; set => canStore_TID2 = value; }
        public byte CanStore_TID3 { get => canStore_TID3; set => canStore_TID3 = value; }
        public byte CanStore_TID4 { get => canStore_TID4; set => canStore_TID4 = value; }
        public byte CanBeVehicle { get => canBeVehicle; set => canBeVehicle = value; }
        public byte CanControl { get => canControl; set => canControl = value; }
        public byte DamagePortion { get => damagePortion; set => damagePortion = value; }
        public short MaxPassenger { get => maxPassenger; set => maxPassenger = value; }
        public int AssocTactics { get => assocTactics; set => assocTactics = value; }
        public int PD { get => pD; set => pD = value; }
        public int MD { get => mD; set => mD = value; }
        public int PAR { get => pAR; set => pAR = value; }
        public int MAR { get => mAR; set => mAR = value; }
        public int ER { get => eR; set => eR = value; }
        public int BR { get => bR; set => bR = value; }
        public int HR { get => hR; set => hR = value; }
        public int CHR { get => cHR; set => cHR = value; }
        public int ExpToGive { get => expToGive; set => expToGive = value; }
        public int CreepType { get => creepType; set => creepType = value; }
        public byte Knockdown { get => knockdown; set => knockdown = value; }
        public int KO_RecoverTime { get => kO_RecoverTime; set => kO_RecoverTime = value; }
        public int DefaultSkill_1 { get => defaultSkill_1; set => defaultSkill_1 = value; }
        public int DefaultSkill_2 { get => defaultSkill_2; set => defaultSkill_2 = value; }
        public int DefaultSkill_3 { get => defaultSkill_3; set => defaultSkill_3 = value; }
        public int DefaultSkill_4 { get => defaultSkill_4; set => defaultSkill_4 = value; }
        public int DefaultSkill_5 { get => defaultSkill_5; set => defaultSkill_5 = value; }
        public int DefaultSkill_6 { get => defaultSkill_6; set => defaultSkill_6 = value; }
        public int DefaultSkill_7 { get => defaultSkill_7; set => defaultSkill_7 = value; }
        public int DefaultSkill_8 { get => defaultSkill_8; set => defaultSkill_8 = value; }
        public int DefaultSkill_9 { get => defaultSkill_9; set => defaultSkill_9 = value; }
        public int DefaultSkill_10 { get => defaultSkill_10; set => defaultSkill_10 = value; }
        public byte TextureType { get => textureType; set => textureType = value; }
        public int Except_1 { get => except_1; set => except_1 = value; }
        public int Except_2 { get => except_2; set => except_2 = value; }
        public int Except_3 { get => except_3; set => except_3 = value; }
        public int Except_4 { get => except_4; set => except_4 = value; }
        public int Except_5 { get => except_5; set => except_5 = value; }
        public int Except_6 { get => except_6; set => except_6 = value; }
        public int Except_7 { get => except_7; set => except_7 = value; }
        public int Except_8 { get => except_8; set => except_8 = value; }
        public int Except_9 { get => except_9; set => except_9 = value; }
        public int Except_10 { get => except_10; set => except_10 = value; }
        public int Link { get => link; set => link = value; }
    }
}