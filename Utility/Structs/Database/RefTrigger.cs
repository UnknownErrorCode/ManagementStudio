namespace Structs.Database
{
    public struct RefTrigger
    {
        // Private fields
        private int _service;
        private int _id;
        private string _codeName128;
        private byte _isActive;
        private byte _isRepeat;
        private string _comment512;
        private int _indexNumber;

        // Public properties with getters and setters
        public int Service
        {
            get => _service;
            set => _service = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string CodeName128
        {
            get => _codeName128;
            set => _codeName128 = value;
        }

        public byte IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public byte IsRepeat
        {
            get => _isRepeat;
            set => _isRepeat = value;
        }

        public string Comment512
        {
            get => _comment512;
            set => _comment512 = value;
        }

        public int IndexNumber
        {
            get => _indexNumber;
            set => _indexNumber = value;
        }

        // Constructor to initialize the private fields
        public RefTrigger(object[] row)
        {
            _service = int.Parse(row[0].ToString());
            _id = int.Parse(row[1].ToString());
            _codeName128 = row[2].ToString();
            _isActive = byte.Parse(row[3].ToString());
            _isRepeat = byte.Parse(row[4].ToString());
            _comment512 = row[5].ToString();
            _indexNumber = int.Parse(row[6].ToString());
        }
    }
}
