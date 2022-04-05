using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManagementServer.Utility
{
    internal static class SQL
    {
        private static SqlConnection sqlConnection;

        internal static bool ConnectionSuccess => TestSQLConnection(ServerManager.settings.SQL_ConnectionString);

        private static string SqlConnectionString => ServerManager.settings.SQL_ConnectionString;

        /// <summary>
        /// EXEC _LoginToolUser UserName, Pasword, IP, OnOff
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        internal static LoginStatus CheckLogin(string userName, string password, string IP)
        {
            SqlParameter[] regparams = new SqlParameter[4]
             {
                    new SqlParameter("@UserName",SqlDbType.VarChar,64) {Value = userName.ToLower() },
                    new SqlParameter("@Password",SqlDbType.VarChar,128) { Value = password},
                    new SqlParameter("@IP",SqlDbType.VarChar,15) { Value =IP},
                    new SqlParameter("@OnOff",SqlDbType.TinyInt) { Value = 1}
             };

            DataRow row = ReturnDataTableByProcedure("_LoginClientUser", ServerManager.settings.DBDev, regparams).Rows[0];

            LoginStatus status = new LoginStatus()
            {
                Success = row.Field<bool>("Success"),
                Notification = row.Field<string>("Message"),
                SecurityGroup = row.Field<byte>("SecurityGroup"),
                UserName = row.Field<string>("AccountName"),
            };
            return status;
        }

        internal static LoginStatus CheckLogout(string userName, string UserIP)
        {
            SqlParameter[] logoutParameter = new SqlParameter[]
                  {
                        new SqlParameter("@UserName" ,System.Data.SqlDbType.VarChar,64) { Value = userName },
                        new SqlParameter("@Password" ,System.Data.SqlDbType.VarChar,128) { Value = "non" },
                        new SqlParameter("@IP" ,System.Data.SqlDbType.VarChar,15) { Value = UserIP },
                        new SqlParameter("@OnOff" , System.Data.SqlDbType.TinyInt) { Value = 0 }
                  };
            DataRow row = SQL.ReturnDataTableByProcedure("_LoginClientUser", ServerManager.settings.DBDev, logoutParameter).Rows[0];
            LoginStatus status = new LoginStatus()
            {
                Success = row.Field<bool>("Success"),
                Notification = row.Field<string>("Message"),
                SecurityGroup = row.Field<byte>("SecurityGroup"),
                UserName = row.Field<string>("AccountName"),
            };
            return status;
        }

        internal static DataTable AllowedPlugins(byte securityDescription) => ReturnDataTableByQuery($"Select AllowedPlugins from _ToolPluginGroups where SecurityGroupID = {securityDescription}", ServerManager.settings.DBDev);

        internal static DataTable GetPatchHistory() => ReturnDataTableByQuery("SELECT * FROM _ToolUpdates;", ServerManager.settings.DBDev);

        internal static DataTable GetPluginDataAccess() => ReturnDataTableByQuery($"SELECT [PluginName], [LoadIndex], [TableName] FROM [dbo].[_ToolPluginDataAccess]", ServerManager.settings.DBDev);

        internal static DataTable GetRequestedDataTable(string tableName) => ReturnDataTableByQuery($"SELECT * FROM {tableName}", ServerManager.settings.DBSha);

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

        internal static DataTable GetSecurityPluginAccess() => ReturnDataTableByQuery($"SELECT [SecurityGroupID], [AllowedPlugins] FROM [dbo].[_ToolPluginGroups]", ServerManager.settings.DBDev);

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

        internal static bool LogoutEveryone(out int count)
        {
            count = ExecuteQuery("UPDATE _ClientUser SET Active = 0  where Active >0 ", ServerManager.settings.DBDev);
            return count > 0;
        }

        internal static DataTable RequestFilesToUpdate(int latestClientVersion) => ReturnDataTableByQuery($"SELECT * from _ToolUpdates where ToBePatched = 1 and Version > {latestClientVersion};", ServerManager.settings.DBDev);

        internal static void UpdateToolFiles(SqlParameter[] paramse) => ReturnDataTableByProcedure("_Update_Tool_Files", ServerManager.settings.DBDev, paramse);

        private static bool TestSQLConnection(string sQL_ConnectionString)
        {
            sqlConnection = new SqlConnection(SqlConnectionString);
            ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.loading, "Testing SQL Connection...");

            try
            {
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.success, $"Established connection to: {sqlConnection.DataSource} ");
                    //sqlConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.fatal, $"Failed connecting to DatabaseEngine\n Exception: {ex}");
            }
            return false;
        }

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

            ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.sql, $"EXEC {DB}.dbo.{procedureName} {paramstring}");
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

                ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.sql, query);
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, ex.Message);
            }

            return dataTable;
        }

        private static int ExecuteQuery(string query, string database)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    if (command.Connection.Database != database)
                    {
                        command.Connection.ChangeDatabase(database);
                    }
                    command.CommandType = CommandType.Text;
                    var ret = command.ExecuteNonQuery();
                    ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.sql, $"Executed query:USING {database} [{query}]");
                    return ret;
                }
            }
            catch (Exception)
            {
                ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Failed executing query:USING {database} [{query}]");
            }

            return 0;
        }
    }
}