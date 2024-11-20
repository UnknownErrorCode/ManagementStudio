using Structs.Tool;
using System.Data;
using System.Data.SqlClient;

namespace ManagementServer.Utility
{
    internal partial class SQL
    {

        /// <summary>
        /// EXEC <see cref="_LoginClientUser"/> UserName, Pasword, IP, OnOff
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="IP"></param>
        /// <returns><see cref="LoginStatus"/></returns>
        internal static LoginStatus CheckLogin(string userName, string password, string IP)
        {
            SqlParameter[] regparams = new SqlParameter[4]
             {
                    new SqlParameter("@UserName",SqlDbType.VarChar,64) {Value = userName.ToLower() },
                    new SqlParameter("@Password",SqlDbType.VarChar,128) { Value = password},
                    new SqlParameter("@IP",SqlDbType.VarChar,15) { Value =IP},
                    new SqlParameter("@OnOff",SqlDbType.TinyInt) { Value = 1}
             };

            DataRow row = ReturnDataTableByProcedure(_LoginClientUser, ServerManager.settings.DBDev, regparams).Rows[0];

            LoginStatus status = new LoginStatus()
            {
                Success = row.Field<bool>("Success"),
                Notification = row.Field<string>("Message"),
                SecurityGroup = row.Field<byte>("SecurityGroup"),
                UserName = row.Field<string>("AccountName"),
            };
            return status;
        }

        ///  <summary>
        /// EXEC <see cref="_LoginClientUser"/> UserName, Pasword, IP, OnOff
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="UserIP"></param>
        /// <returns><see cref="LoginStatus"/></returns>
        internal static LoginStatus CheckLogout(string userName, string UserIP)
        {
            SqlParameter[] logoutParameter = new SqlParameter[]
                  {
                        new SqlParameter("@UserName" ,System.Data.SqlDbType.VarChar,64) { Value = userName },
                        new SqlParameter("@Password" ,System.Data.SqlDbType.VarChar,128) { Value = "non" },
                        new SqlParameter("@IP" ,System.Data.SqlDbType.VarChar,15) { Value = UserIP },
                        new SqlParameter("@OnOff" , System.Data.SqlDbType.TinyInt) { Value = 0 }
                  };
            DataRow row = SQL.ReturnDataTableByProcedure(_LoginClientUser, ServerManager.settings.DBDev, logoutParameter).Rows[0];
            LoginStatus status = new LoginStatus()
            {
                Success = row.Field<bool>("Success"),
                Notification = row.Field<string>("Message"),
                SecurityGroup = row.Field<byte>("SecurityGroup"),
                UserName = row.Field<string>("AccountName"),
            };
            return status;
        }

        /// <summary>
        /// Sends out the latest version.
        /// <see cref="SELECT_ToolUpdatesMaxVersion"/>
        /// </summary>
        /// <returns></returns>
        internal static int LatestVersion()
        {
            using (SqlCommand command = new SqlCommand(SELECT_ToolUpdatesMaxVersion, sqlConnection))
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                sqlConnection.ChangeDatabase(ServerManager.settings.DBDev);

                command.CommandType = CommandType.Text;
                object version = command.ExecuteScalar();

                command.Connection.Close();

                if (int.TryParse(version.ToString(), out int ver))
                {
                    return ver;
                }

                return 0;
            }
        }

        /// <summary>
        /// Logout everyone.
        /// <br><see cref="LOGOUT_ClientUser"/></br>
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        internal static bool LogoutEveryone(out int count)
        {
            count = ExecuteQuery(LOGOUT_ClientUser, ServerManager.settings.DBDev);
            return count > 0;
        }

        /// <summary>
        /// Selects all files to update from _ToolUpdates.
        /// </summary>
        /// <param name="latestClientVersion"></param>
        /// <returns></returns>
        internal static DataTable RequestFilesToUpdate(int latestClientVersion)
            => ReturnDataTableByQuery(
                $"SELECT * from _ToolUpdates where ToBePatched = 1 and Version > {latestClientVersion};",
                ServerManager.settings.DBDev
                );

        /// <summary>
        /// Updates files to the patcher.
        /// </summary>
        /// <param name="paramse"></param>
        internal static void UpdateToolFiles(SqlParameter[] paramse)
            => ReturnDataTableByProcedure(
                _Update_Tool_Files,
                ServerManager.settings.DBDev,
                paramse
                );




    }
}
