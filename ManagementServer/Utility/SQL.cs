using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManagementServer.Utility
{
    internal static class SQL
    {
        #region Private Fields

        private static SqlConnection sqlConnection;

        #endregion Private Fields

        #region Private Properties

        private static string SqlConnectionString => ServerManager.settings.SQL_ConnectionString;

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// EXEC _LoginToolUser UserName, Pasword, IP, OnOff
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static LoginStatus CheckLogin(string userName, string password, string IP)
        {
            SqlParameter[] regparams = new SqlParameter[4]
             {
                    new SqlParameter("@UserName",SqlDbType.VarChar,64) {Value = userName.ToLower() },
                    new SqlParameter("@Password",SqlDbType.VarChar,128) { Value = password},
                    new SqlParameter("@IP",SqlDbType.VarChar,15) { Value =IP},
                    new SqlParameter("@OnOff",SqlDbType.TinyInt) { Value = 1}
             };

            DataRow row = ReturnDataTableByProcedure("_LoginToolUser", ServerManager.settings.DBDev, regparams).Rows[0];

            LoginStatus status = new LoginStatus()
            {
                Success = row.Field<bool>("Success"),
                Notification = row.Field<string>("Message"),
                SecurityGroup = row.Field<byte>("SecurityGroup"),
                UserName = row.Field<string>("AccountName"),
            };
            return status;
        }

        public static string[] CheckLogout(string userName, string UserIP)
        {
            SqlParameter[] logoutParameter = new SqlParameter[]
                  {
                        new SqlParameter("@UserName" ,System.Data.SqlDbType.VarChar,64) { Value = userName },
                        new SqlParameter("@Password" ,System.Data.SqlDbType.VarChar,128) { Value = "non" },
                        new SqlParameter("@IP" ,System.Data.SqlDbType.VarChar,15) { Value = UserIP },
                        new SqlParameter("@OnOff" , System.Data.SqlDbType.TinyInt) { Value = 0 }
                  };
            DataRow logoutResut = SQL.ReturnDataTableByProcedure("_LoginToolUser", ServerManager.settings.DBDev, logoutParameter).Rows[0];

            string[] forsfor = new string[logoutResut.ItemArray.Length];

            for (int i = 0; i < forsfor.Length; i++)
            {
                forsfor[i] = logoutResut.ItemArray[i].ToString();
            }

            return forsfor;
        }

        #endregion Public Methods

        #region Internal Methods

        internal static DataTable AllowedPlugins(byte securityDescription)
        {
            return ReturnDataTableByQuery($"Select AllowedPlugins from _ToolPluginGroups where SecurityGroupID = {securityDescription}", ServerManager.settings.DBDev);
        }

        internal static DataTable GetPatchHistory()
        {
            return ReturnDataTableByQuery("SELECT * FROM _ToolUpdates;", ServerManager.settings.DBDev);
        }

        internal static DataTable GetPluginDataAccess()
        {
            return ReturnDataTableByQuery($"SELECT [PluginName], [LoadIndex], [TableName] FROM [dbo].[_ToolPluginDataAccess]", ServerManager.settings.DBDev);
        }

        internal static DataTable GetRequestedDataTable(string tableName)
        {
            return ReturnDataTableByQuery($"SELECT * FROM {tableName}", ServerManager.settings.DBSha);
        }

        internal static string[] GetRequiredTableNames(byte securityGroup)
        {
            DataRowCollection names = ReturnDataTableByQuery($"Select DISTINCT TableName from _ToolPluginDataAccess ta join _ToolPluginGroups tg on tg.AllowedPlugins = ta.PluginName where tg.SecurityGroupID = {securityGroup} ", ServerManager.settings.DBDev).Rows;
            string[] nameArray = new string[names.Count];

            for (int i = 0; i < names.Count; i++)
            {
                nameArray[i] = names[i].Field<string>("TableName");
            }

            return nameArray;
        }

        internal static DataTable GetSecurityPluginAccess()
        {
            return ReturnDataTableByQuery($"SELECT [SecurityGroupID], [AllowedPlugins] FROM [dbo].[_ToolPluginGroups]", ServerManager.settings.DBDev);
        }

        internal static int LatestVersion()
        {
            using (SqlCommand command = new SqlCommand("Select TOP 1 MAX(Version) from _ToolUpdates where ToBePatched = 1", sqlConnection))
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

        internal static void LogoutEveryone()
        {
            using (SqlCommand command = new SqlCommand("UPDATE _ToolUser SET Active = 0 ", sqlConnection))
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                command.Connection.ChangeDatabase(ServerManager.settings.DBDev);
                command.CommandType = CommandType.Text;

                command.ExecuteNonQuery();
                // command.Connection.Close();
            }
        }

        internal static DataTable RequestFilesToUpdate(int latestClientVersion)
        {
            return ReturnDataTableByQuery($"SELECT * from _ToolUpdates where ToBePatched = 1 and Version > {latestClientVersion};", ServerManager.settings.DBDev);
        }

        internal static bool TestSQLConnection(string sQL_ConnectionString)
        {
            sqlConnection = new SqlConnection(SqlConnectionString);
            ServerManager.Logger.WriteLogLine("Testing SQL Connection...");

            try
            {
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    ServerManager.Logger.WriteLogLine($"Established connection to: {sqlConnection.DataSource} ");
                    //sqlConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine($"Failed connecting to DatabaseEngine\n Exception: {ex}");
            }
            return false;
        }

        internal static void UpdateToolFiles(SqlParameter[] paramse)
        {
            ReturnDataTableByProcedure("_Update_Tool_Files", ServerManager.settings.DBDev, paramse);
        }

        #endregion Internal Methods

        #region Private Methods

        private static DataTable ReturnDataTableByProcedure(string procedureName, string DB, SqlParameter[] param)
        {
            DataTable dataTableProcedure = new DataTable();

            using (SqlCommand command = new SqlCommand(procedureName, sqlConnection))
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                command.Parameters.AddRange(param);
                command.Connection.ChangeDatabase(DB);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter addi = new SqlDataAdapter(command);

                addi.Fill(dataTableProcedure);
                //command.Connection.Close();
            }

            List<string> listOfParams = new List<string>();
            foreach (SqlParameter item in param)
            {
                if (item.SqlDbType == SqlDbType.VarChar)
                {
                    listOfParams.Add($"'{item.Value}',");
                }
                else
                {
                    listOfParams.Add($"{item.Value},");
                }
            }

            string paramstring = "";
            foreach (string item in listOfParams)
            {
                if (item != listOfParams[listOfParams.Count - 1])
                {
                    paramstring += item;
                }
                else
                {
                    paramstring += item.Replace(",", "");
                }
            }

            ServerManager.Logger.WriteLogLine($"EXEC {DB}.dbo.{procedureName} {paramstring}");
            return dataTableProcedure;
        }

        private static DataTable ReturnDataTableByQuery(string query, string database)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                {
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    sqlConnection.ChangeDatabase(database);
                    adapter.Fill(dataTable);
                }

                ServerManager.Logger.WriteLogLine(query);
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, ex.Message);
            }

            return dataTable;
        }

        #endregion Private Methods
    }
}