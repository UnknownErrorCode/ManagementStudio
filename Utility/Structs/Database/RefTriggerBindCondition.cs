using System;

namespace Structs.Database
{
    public struct RefTriggerBindCondition
    {
        // Private fields
        private int _service;
        private readonly int _id;   // Read-only field
        private int _triggerID;
        private int _triggerConditionID;

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

        public int TriggerID
        {
            get { return _triggerID; }
            set { _triggerID = value; }
        }

        public int TriggerConditionID
        {
            get { return _triggerConditionID; }
            set { _triggerConditionID = value; }
        }

        // Constructor to initialize the struct from an object array (e.g., from a database row)
        public RefTriggerBindCondition(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _triggerID = Convert.ToInt32(row[2]);
            _triggerConditionID = Convert.ToInt32(row[3]);
        }
    }
}
