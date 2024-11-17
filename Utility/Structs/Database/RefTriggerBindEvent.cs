using System;
using System.ComponentModel;

namespace Structs.Database
{

    [Category("RefTriggerBindEvent")]
    public struct RefTriggerBindEvent
    {
        // Private fields
        private int _service;
        private readonly int _id;   // Read-only field
        private int _triggerID;
        private int _triggerEventID;

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

        public int TriggerEventID
        {
            get { return _triggerEventID; }
            set { _triggerEventID = value; }
        }

        public RefTriggerBindEvent(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _triggerID = Convert.ToInt32(row[2]);
            _triggerEventID = Convert.ToInt32(row[3]);
        }
    }
}
