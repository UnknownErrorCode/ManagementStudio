using System;

namespace Structs.Database
{
    public struct RefTriggerCondition
    {
        // Private fields
        private int _service;
        private readonly int _id;   // Read-only field
        private int _refTriggerCommonID;
        private string _onTrue;
        private string _onFalse;
        private short _sequence;
        private string _paramGroupCodeName128;

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

        public int RefTriggerCommonID
        {
            get { return _refTriggerCommonID; }
            set { _refTriggerCommonID = value; }
        }

        public string OnTrue
        {
            get { return _onTrue; }
            set { _onTrue = value; }
        }

        public string OnFalse
        {
            get { return _onFalse; }
            set { _onFalse = value; }
        }

        public short Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }

        public string ParamGroupCodeName128
        {
            get { return _paramGroupCodeName128; }
            set { _paramGroupCodeName128 = value; }
        }

        public RefTriggerCondition(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _refTriggerCommonID = Convert.ToInt32(row[2]);
            _onTrue = row[3].ToString();
            _onFalse = row[4].ToString();
            _sequence = Convert.ToInt16(row[5]);
            _paramGroupCodeName128 = row[6].ToString();
        }
    }
}
