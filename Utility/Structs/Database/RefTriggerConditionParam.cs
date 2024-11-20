using System;
using System.Data.SqlClient;

namespace Structs.Database
{
    public struct RefTriggerConditionParam : ISqlParameterConvertible
    {
        // Private fields
        private int _service;
        private readonly int _id;   // Read-only field
        private string _groupCodeName128;
        private string _valueCodeName128;
        private string _value;
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

        public RefTriggerConditionParam(object[] row)
        {
            _service = Convert.ToInt32(row[0]);
            _id = Convert.ToInt32(row[1]);  // Read-only field, initialized once in the constructor
            _groupCodeName128 = row[2].ToString();
            _valueCodeName128 = row[3].ToString();
            _value = row[4].ToString();
            _type = row[5].ToString();
        }

        // ToSqlParameters Function
        public SqlParameter[] ToSqlParameters()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Service", System.Data.SqlDbType.Int) { Value = _service },
                new SqlParameter("@ID", System.Data.SqlDbType.Int) { Value = _id },
                new SqlParameter("@GroupCodeName128", System.Data.SqlDbType.VarChar, 129)
                {
                    Value = _groupCodeName128 ?? (object)DBNull.Value
                },
                new SqlParameter("@ValueCodeName128", System.Data.SqlDbType.VarChar, 129)
                {
                    Value = _valueCodeName128 ?? (object)DBNull.Value
                },
                new SqlParameter("@Value", System.Data.SqlDbType.VarChar, 129)
                {
                    Value = _value ?? (object)DBNull.Value
                },
                new SqlParameter("@Type", System.Data.SqlDbType.VarChar, 20)
                {
                    Value = _type ?? (object)DBNull.Value
                }
            };
        }
    }
}
