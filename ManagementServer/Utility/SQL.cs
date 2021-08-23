using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManagementServer.Utility
{
    internal static class SQL
    {
        static SqlConnection sqlConnection;
        static string SqlConnectionString { get => ServerManager.settings.SQL_ConnectionString; }



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
                    sqlConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine($"Failed connecting to DatabaseEngine\n Exception: {ex}");
            }
            return false;
        }

        private static DataTable ReturnDataTableByProcedure(string procedureName, string DB, SqlParameter[] param)
        {
            DataTable dataTableProcedure = new DataTable();
            

            using (SqlCommand command = new SqlCommand(procedureName, sqlConnection))
            {
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();
                
                command.Parameters.AddRange(param);
                command.Connection.ChangeDatabase(DB);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter addi = new SqlDataAdapter(command);

                addi.Fill(dataTableProcedure);
                command.Connection.Close();
            }

            var listOfParams = new List<string>();
            foreach (var item in param)
            {
                if (item.SqlDbType == SqlDbType.VarChar)
                    listOfParams.Add($"'{item.Value}',");
                else
                    listOfParams.Add($"{item.Value},");
            }

            var paramstring = "";
            foreach (var item in listOfParams)
            {
                if (item != listOfParams[listOfParams.Count - 1])
                    paramstring += item;
                else
                    paramstring += item.Replace(",", "");
            }

            ServerManager.Logger.WriteLogLine($"EXEC {DB}.dbo.{procedureName} {paramstring}");
            return dataTableProcedure;
        }

        public static DataTable ReturnDataTableByQuery(string query, string database)
        {

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                sqlConnection.ChangeDatabase(database);
                adapter.Fill(dataTable);
            }

            ServerManager.Logger.WriteLogLine(query);
            return dataTable;
        }

        public static string[] CheckLogin(string userName, string password, string IP)
        {
            SqlParameter[] regparams = new SqlParameter[4]
             {
                    new SqlParameter("@UserName",SqlDbType.VarChar,64) {Value = userName.ToLower() },
                    new SqlParameter("@Password",SqlDbType.VarChar,128) { Value = password},
                    new SqlParameter("@IP",SqlDbType.VarChar,15) { Value =IP},
                    new SqlParameter("@OnOff",SqlDbType.TinyInt) { Value = 1}
             };

            DataRow row = ReturnDataTableByProcedure("_LoginToolUser", ServerManager.settings.DBDev, regparams).Rows[0];

            string[] forsfor = new string[row.ItemArray.Length];

            for (int i = 0; i < forsfor.Length; i++)
                forsfor[i] = row.ItemArray[i].ToString();

            return forsfor;
        }
    }
}
