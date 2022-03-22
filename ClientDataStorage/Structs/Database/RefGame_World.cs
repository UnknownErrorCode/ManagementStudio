using System;

namespace Structs.Database
{
    public struct RefGame_World
    {
        public int ID { get; set; }
        public string WorldCodeName128 { get; set; }
        public byte Type { get; set; }
        public short WorldMaxCount { get; set; }
        public short WorldMaxUserCount { get; set; }
        public byte WorldEntryType { get; set; }
        public byte WorldEntranceType { get; set; }
        public byte WorldLeaveType { get; set; }
        public int WorldDurationTime { get; set; }
        public int WorldEmptyRemainTime { get; set; }
        public string ConfigGroupCodeName128 { get; set; }


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