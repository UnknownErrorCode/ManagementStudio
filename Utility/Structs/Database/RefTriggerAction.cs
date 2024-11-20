using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Structs.Database
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RefTriggerAction : ISqlParameterConvertible
    {
        // Backing fields for marshaling compatibility
        private int _service;
        private readonly int _id;
        private int _refTriggerCommonID;
        private int _delay;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string _paramGroupCodeName128;

        // Public properties for field access
        public int Service
        {
            get => _service;
            set => _service = value;
        }

        public int ID
        {
            get => _id;
        }

        public int RefTriggerCommonID
        {
            get => _refTriggerCommonID;
            set => _refTriggerCommonID = value;
        }

        public int Delay
        {
            get => _delay;
            set => _delay = value;
        }

        public string ParamGroupCodeName128
        {
            get => _paramGroupCodeName128;
            set => _paramGroupCodeName128 = value;
        }

        // Constructor for initializing fields
        public RefTriggerAction(int service, int id, int refTriggerCommonID, int delay, string paramGroupCodeName128)
        {
            _service = service;
            _id = id;
            _refTriggerCommonID = refTriggerCommonID;
            _delay = delay;
            _paramGroupCodeName128 = paramGroupCodeName128;
        }

        // Alternate constructor for database row initialization
        public RefTriggerAction(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);
            _refTriggerCommonID = Convert.ToInt32(row[2]);
            _delay = Convert.ToInt32(row[3]);
            _paramGroupCodeName128 = Convert.ToString(row[4]);
        }

        public SqlParameter[] ToSqlParameters()
        {
            return new SqlParameter[]
            {
        new SqlParameter("@Service", System.Data.SqlDbType.Int) { Value = _service },
        new SqlParameter("@ID", System.Data.SqlDbType.Int) { Value = _id },
        new SqlParameter("@RefTriggerCommonID", System.Data.SqlDbType.Int) { Value = _refTriggerCommonID },
        new SqlParameter("@Delay", System.Data.SqlDbType.Int) { Value = _delay },
        new SqlParameter("@ParamGroupCodeName128", System.Data.SqlDbType.VarChar, 128)
        {
            Value = _paramGroupCodeName128 ?? (object)DBNull.Value
        }
            };
        }

    }
}
