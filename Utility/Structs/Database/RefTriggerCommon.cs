using System;

namespace Structs.Database
{
    public struct RefTriggerCommon
    {
        // Private fields
        private int _service;
        private readonly int _id;   // Read-only field
        private string _codeName128;
        private string _objName128;
        private short _tID1;
        private short _tID2;
        private short _tID3;
        private short _tID4;

        // Public properties to access the private fields
        public int Service
        {
            get { return _service; }
            set { _service = value; }
        }

        public int ID
        {
            get { return _id; }
        }

        public string CodeName128
        {
            get { return _codeName128; }
            set { _codeName128 = value; }
        }

        public string ObjName128
        {
            get { return _objName128; }
            set { _objName128 = value; }
        }

        public short TID1
        {
            get { return _tID1; }
            set { _tID1 = value; }
        }

        public short TID2
        {
            get { return _tID2; }
            set { _tID2 = value; }
        }

        public short TID3
        {
            get { return _tID3; }
            set { _tID3 = value; }
        }

        public short TID4
        {
            get { return _tID4; }
            set { _tID4 = value; }
        }

        public RefTriggerCommon(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _codeName128 = row[2].ToString();
            _objName128 = row[3].ToString();
            _tID1 = Convert.ToInt16(row[4]);
            _tID2 = Convert.ToInt16(row[5]);
            _tID3 = Convert.ToInt16(row[6]);
            _tID4 = Convert.ToInt16(row[7]);
        }
    }
}
