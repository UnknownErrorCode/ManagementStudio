using System;

namespace Structs.Database
{
    public struct RefTriggerBindAction
    {
        // Private fields
        private int _service;
        private readonly int _id;   // Read-only field
        private int _triggerID;
        private int _triggerActionID;

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

        public int TriggerActionID
        {
            get { return _triggerActionID; }
            set { _triggerActionID = value; }
        }

        // Constructor to initialize the struct from an object array (e.g., from a database row)
        public RefTriggerBindAction(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _triggerID = Convert.ToInt32(row[2]);
            _triggerActionID = Convert.ToInt32(row[3]);
        }
    }
}
