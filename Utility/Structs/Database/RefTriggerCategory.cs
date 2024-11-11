namespace Structs.Database
{
    public struct RefTriggerCategory
    {
        // Private fields
        private int _service;
        private int _id;
        private string _codeName128;
        private string _objName128;
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

        public string ObjName128
        {
            get => _objName128;
            set => _objName128 = value;
        }

        public int IndexNumber
        {
            get => _indexNumber;
            set => _indexNumber = value;
        }

        // Constructor to initialize the private fields
        public RefTriggerCategory(object[] row)
        {
            _service = int.Parse(row[0].ToString());
            _id = int.Parse(row[1].ToString());
            _codeName128 = row[2].ToString();
            _objName128 = row[3].ToString();
            _indexNumber = int.Parse(row[4].ToString());
        }
    }
}
