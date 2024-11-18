using System;
using System.Runtime.InteropServices;

namespace Structs.Database
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RefTriggerActionParam
    {
        // Backing fields
        private int _service;
        private int _id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        private string _groupCodeName128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        private string _valueCodeName128;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        private string _value;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        private string _type;


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

        public string GroupCodeName128
        {
            get { return _groupCodeName128; }
            set { _groupCodeName128 = value; }
        }

        public string ValueCodeName128
        {
            get { return _valueCodeName128; }
            set { _valueCodeName128 = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Constructor to initialize the struct from an object array (e.g., from a database row)
        public RefTriggerActionParam(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _groupCodeName128 = row[2].ToString();
            _valueCodeName128 = row[3].ToString();
            _value = row[4].ToString();
            _type = row[5].ToString();
        }
    }
}
