using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Structs.Database
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RefTrigger
    {
        // Private fields
        private int _service;

        private int _id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string _codeName128;

        private byte _isActive;
        private byte _isRepeat;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        private string _comment512;

        private int _indexNumber;

        // Public properties with getters and setters
        public int Service
        {
            get => _service;
            set => _service = value;
        }

        public int ID
        {
            get => _id;
        }

        public string CodeName128
        {
            get => _codeName128;
            set => _codeName128 = value;
        }

        public byte IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public byte IsRepeat
        {
            get => _isRepeat;
            set => _isRepeat = value;
        }

        public string Comment512
        {
            get => _comment512;
            set => _comment512 = value;
        }

        public int IndexNumber
        {
            get => _indexNumber;
            set => _indexNumber = value;
        }

        // Constructor to initialize the private fields
        public RefTrigger(object[] row)
        {
            _service = int.Parse(row[0].ToString());
            _id = int.Parse(row[1].ToString());
            _codeName128 = row[2].ToString();
            _isActive = byte.Parse(row[3].ToString());
            _isRepeat = byte.Parse(row[4].ToString());
            _comment512 = row[5].ToString();
            _indexNumber = int.Parse(row[6].ToString());
        }

        public RefTrigger(bool defaultTrigger)
        {
            _service = 1;
            _id = 0;
            _codeName128 = "TRI_";
            _isActive = 1;
            _isRepeat = 0;
            _comment512 = "<any info>";
            _indexNumber = 0;
        }

        public SqlParameter[] ToSqlParameters()
        {
            return new SqlParameter[]
            {
        new SqlParameter("@Service", SqlDbType.Int) { Value = Service },
        new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
        new SqlParameter("@CodeName128", SqlDbType.VarChar, 128) { Value = CodeName128 },
        new SqlParameter("@IsActive", SqlDbType.TinyInt) { Value = IsActive },
        new SqlParameter("@IsRepeat", SqlDbType.TinyInt) { Value = IsRepeat },
        new SqlParameter("@Comment512", SqlDbType.VarChar, 512) { Value = Comment512 },
        new SqlParameter("@IndexNumber", SqlDbType.Int) { Value = IndexNumber }
            };
        }
    }
}