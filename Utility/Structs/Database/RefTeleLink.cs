namespace Structs.Database
{
    public struct RefTeleLink
    {
        // Private fields
        private int _service;
        private int _ownerTeleport;
        private int _targetTeleport;
        private int _fee;
        private byte _restrictBindMethod;
        private byte _runTimeTeleportMethod;
        private byte _checkResult;
        private int _restrict1;
        private int _data1_1;
        private int _data1_2;
        private int _restrict2;
        private int _data2_1;
        private int _data2_2;
        private int _restrict3;
        private int _data3_1;
        private int _data3_2;
        private int _restrict4;
        private int _data4_1;
        private int _data4_2;
        private int _restrict5;
        private int _data5_1;
        private int _data5_2;

        // Public properties
        public int Service
        {
            get => _service;
            set => _service = value;
        }

        public int OwnerTeleport
        {
            get => _ownerTeleport;
            set => _ownerTeleport = value;
        }

        public int TargetTeleport
        {
            get => _targetTeleport;
            set => _targetTeleport = value;
        }

        public int Fee
        {
            get => _fee;
            set => _fee = value;
        }

        public byte RestrictBindMethod
        {
            get => _restrictBindMethod;
            set => _restrictBindMethod = value;
        }

        public byte RunTimeTeleportMethod
        {
            get => _runTimeTeleportMethod;
            set => _runTimeTeleportMethod = value;
        }

        public byte CheckResult
        {
            get => _checkResult;
            set => _checkResult = value;
        }

        public int Restrict1
        {
            get => _restrict1;
            set => _restrict1 = value;
        }

        public int Data1_1
        {
            get => _data1_1;
            set => _data1_1 = value;
        }

        public int Data1_2
        {
            get => _data1_2;
            set => _data1_2 = value;
        }

        public int Restrict2
        {
            get => _restrict2;
            set => _restrict2 = value;
        }

        public int Data2_1
        {
            get => _data2_1;
            set => _data2_1 = value;
        }

        public int Data2_2
        {
            get => _data2_2;
            set => _data2_2 = value;
        }

        public int Restrict3
        {
            get => _restrict3;
            set => _restrict3 = value;
        }

        public int Data3_1
        {
            get => _data3_1;
            set => _data3_1 = value;
        }

        public int Data3_2
        {
            get => _data3_2;
            set => _data3_2 = value;
        }

        public int Restrict4
        {
            get => _restrict4;
            set => _restrict4 = value;
        }

        public int Data4_1
        {
            get => _data4_1;
            set => _data4_1 = value;
        }

        public int Data4_2
        {
            get => _data4_2;
            set => _data4_2 = value;
        }

        public int Restrict5
        {
            get => _restrict5;
            set => _restrict5 = value;
        }

        public int Data5_1
        {
            get => _data5_1;
            set => _data5_1 = value;
        }

        public int Data5_2
        {
            get => _data5_2;
            set => _data5_2 = value;
        }

        // Constructor to initialize the private fields
        public RefTeleLink(object[] row)
        {
            _service = int.Parse(row[0].ToString());
            _ownerTeleport = int.Parse(row[1].ToString());
            _targetTeleport = int.Parse(row[2].ToString());
            _fee = int.Parse(row[3].ToString());
            _restrictBindMethod = byte.Parse(row[4].ToString());
            _runTimeTeleportMethod = byte.Parse(row[5].ToString());
            _checkResult = byte.Parse(row[6].ToString());
            _restrict1 = int.Parse(row[7].ToString());
            _data1_1 = int.Parse(row[8].ToString());
            _data1_2 = int.Parse(row[9].ToString());
            _restrict2 = int.Parse(row[10].ToString());
            _data2_1 = int.Parse(row[11].ToString());
            _data2_2 = int.Parse(row[12].ToString());
            _restrict3 = int.Parse(row[13].ToString());
            _data3_1 = int.Parse(row[14].ToString());
            _data3_2 = int.Parse(row[15].ToString());
            _restrict4 = int.Parse(row[16].ToString());
            _data4_1 = int.Parse(row[17].ToString());
            _data4_2 = int.Parse(row[18].ToString());
            _restrict5 = int.Parse(row[19].ToString());
            _data5_1 = int.Parse(row[20].ToString());
            _data5_2 = int.TryParse(row[21].ToString(), out int parsedValue) ? parsedValue : 0;
        }
    }
}
