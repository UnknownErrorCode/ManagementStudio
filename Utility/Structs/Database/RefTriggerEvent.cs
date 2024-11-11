using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Database
{
    public struct RefTriggerEvent
    {
        // Private fields
        private int _service;
        private readonly int _id;   // Read-only field
        private int _refTriggerCommonID;

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

        // Constructor to initialize the struct from an object array (e.g., from a database row)
        public RefTriggerEvent(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _refTriggerCommonID = Convert.ToInt32(row[2]);
        }
    }
}
