using System;

namespace Structs.Database
{
    public struct RefTriggerAction
    {
        // Private fields for new parameters
        private int _service;
        private readonly int _id;   // Read-only field
        private int _refTriggerCommonID;
        private int _delay;
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

        public int Delay
        {
            get { return _delay; }
            set { _delay = value; }
        }

        public string ParamGroupCodeName128
        {
            get { return _paramGroupCodeName128; }
            set { _paramGroupCodeName128 = value; }
        }

        // Constructor for new parameters
        public RefTriggerAction(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _refTriggerCommonID = Convert.ToInt32(row[2]);
            _delay = Convert.ToInt32(row[3]);
            _paramGroupCodeName128 = Convert.ToString(row[4]);
        }
    }
}
