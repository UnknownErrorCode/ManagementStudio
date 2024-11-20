using System.Data.SqlClient;

namespace Structs.Database
{
    public interface ISqlParameterConvertible
    {
        SqlParameter[] ToSqlParameters();
    }
}
