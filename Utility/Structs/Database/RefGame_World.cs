using System;

namespace Structs.Database
{
    public struct RefGame_World
    {
        // Private fields
        private readonly int _id;
        private string _worldCodeName128;
        private byte _type;
        private short _worldMaxCount;
        private short _worldMaxUserCount;
        private byte _worldEntryType;
        private byte _worldEntranceType;
        private byte _worldLeaveType;
        private int _worldDurationTime;
        private int _worldEmptyRemainTime;
        private string _configGroupCodeName128;

        // Public properties
        public int ID => _id; // Readonly property, accessible but not settable

        public string WorldCodeName128
        {
            get => _worldCodeName128;
            set => _worldCodeName128 = value;
        }

        public byte Type
        {
            get => _type;
            set => _type = value;
        }

        public short WorldMaxCount
        {
            get => _worldMaxCount;
            set => _worldMaxCount = value;
        }

        public short WorldMaxUserCount
        {
            get => _worldMaxUserCount;
            set => _worldMaxUserCount = value;
        }

        public byte WorldEntryType
        {
            get => _worldEntryType;
            set => _worldEntryType = value;
        }

        public byte WorldEntranceType
        {
            get => _worldEntranceType;
            set => _worldEntranceType = value;
        }

        public byte WorldLeaveType
        {
            get => _worldLeaveType;
            set => _worldLeaveType = value;
        }

        public int WorldDurationTime
        {
            get => _worldDurationTime;
            set => _worldDurationTime = value;
        }

        public int WorldEmptyRemainTime
        {
            get => _worldEmptyRemainTime;
            set => _worldEmptyRemainTime = value;
        }

        public string ConfigGroupCodeName128
        {
            get => _configGroupCodeName128;
            set => _configGroupCodeName128 = value;
        }

        // Constructor to initialize readonly ID and other private fields
        public RefGame_World(object[] row)
        {
            _id = int.Parse(row[0].ToString());
            _worldCodeName128 = row[1].ToString();
            _type = byte.Parse(row[2].ToString());
            _worldMaxCount = short.Parse(row[3].ToString());
            _worldMaxUserCount = short.Parse(row[4].ToString());
            _worldEntryType = byte.Parse(row[5].ToString());
            _worldEntranceType = byte.Parse(row[6].ToString());
            _worldLeaveType = byte.Parse(row[7].ToString());
            _worldDurationTime = int.Parse(row[8].ToString());
            _worldEmptyRemainTime = int.Parse(row[9].ToString());
            _configGroupCodeName128 = row[10].ToString();
        }
    }
}
