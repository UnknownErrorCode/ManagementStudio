using Structs.Database;
using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ManagementServer.Utility
{
    internal static partial class SQL
    {
        private const string _LoginClientUser = "_LoginClientUser";
        private const string SELECT_ToolUpdates = "SELECT * FROM _ToolUpdates;";
        private const string SELECT_ToolPluginGroups = "SELECT [SecurityGroupID], [AllowedPlugins] FROM [dbo].[_ToolPluginGroups]";
        private const string SELECT_ToolUpdatesMaxVersion = "Select TOP 1 MAX(Version) from _ToolUpdates where ToBePatched = 1";
        private const string LOGOUT_ClientUser = "UPDATE _ClientUser SET Active = 0  where Active >0 ";
        private const string _Update_Tool_Files = "_Update_Tool_Files";
        private static SqlConnection sqlConnection;
        internal static bool ConnectionSuccess => TestSQLConnection(ServerManager.settings.SQL_ConnectionString);

        private static string SqlConnectionString => ServerManager.settings.SQL_ConnectionString;

     

        /// <summary>
        /// SELECT * FROM _ToolUpdates
        /// </summary>
        /// <returns><see cref="DataTable"/></returns>
        internal static DataTable GetPatchHistory() => ReturnDataTableByQuery(SELECT_ToolUpdates, ServerManager.settings.DBDev);

        /// <summary>
        /// SELECT * FROM <paramref name="tableName".
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns><see cref="DataTable"/></returns>
        internal static DataTable GetRequestedDataTable(string tableName) => ReturnDataTableByQuery($"SELECT * FROM {tableName}", ServerManager.settings.DBSha);

        /// <summary>
        /// SELECT [SecurityGroupID], [AllowedPlugins] FROM [dbo].[_ToolPluginGroups]
        /// </summary>
        /// <returns></returns>
        internal static DataTable GetSecurityPluginAccess() => ReturnDataTableByQuery(SELECT_ToolPluginGroups, ServerManager.settings.DBDev);

       

        private static bool TestSQLConnection(string sQL_ConnectionString)
        {
            sqlConnection = new SqlConnection(SqlConnectionString);
            ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.loading, "Testing SQL Connection...");

            try
            {
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.success, $"Established connection to: {sqlConnection.DataSource} ");
                    //sqlConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.fatal, $"Failed connecting to DatabaseEngine\n Exception: {ex}");
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
            int counter = 0;
            foreach (string item in listOfParams)
            {
                counter++;
                if (listOfParams.Count != counter)
                {
                    paramstring += item;
                }
                else
                {
                    paramstring += item.Replace(",", "");
                }
            }

            ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.sql, $"EXEC {DB}.dbo.{procedureName} {paramstring}");
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

                ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.sql, query);
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.warning, ex.Message);
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
                    ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.sql, $"Executed query:USING {database} [{query}]");
                    return ret;
                }
            }
            catch (Exception)
            {
                ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.warning, $"Failed executing query:USING {database} [{query}]");
            }

            return 0;
        }
    }
}