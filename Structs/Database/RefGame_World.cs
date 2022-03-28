using System;

namespace Structs.Database
{
    public struct RefGame_World
    {
        public readonly int ID ;
        public string WorldCodeName128 ;
        public byte Type ;
        public short WorldMaxCount ;
        public short WorldMaxUserCount ;
        public byte WorldEntryType ;
        public byte WorldEntranceType ;
        public byte WorldLeaveType ;
        public int WorldDurationTime ;
        public int WorldEmptyRemainTime ;
        public string ConfigGroupCodeName128 ;


        public RefGame_World(object[] row)
        {
            ID = int.Parse(row[0].ToString());
            WorldCodeName128 = row[1].ToString();
            Type = byte.Parse(row[2].ToString());
            WorldMaxCount = Int16.Parse(row[3].ToString());
            WorldMaxUserCount = Int16.Parse(row[4].ToString());
            WorldEntryType = byte.Parse(row[5].ToString());
            WorldEntranceType = byte.Parse(row[6].ToString());
            WorldLeaveType = byte.Parse(row[7].ToString());
            WorldDurationTime = int.Parse(row[8].ToString());
            WorldEmptyRemainTime = int.Parse(row[9].ToString());
            ConfigGroupCodeName128 = row[10].ToString();
        }
    }
}