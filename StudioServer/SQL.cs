using ServerFrameworkRes.Network.Security;
using StudioServer.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer
{
    public static class SQL
    {
        #region Public Properties

        public static string SqlConnectionString => cfg.SQL_ConnectionString;

        #endregion Public Properties

        #region Private Properties

        private static Settings cfg => new Settings();

        #endregion Private Properties

        #region Public Methods

        public static int ExecuteQuery(string Query, string DB)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                cmd.CommandType = CommandType.Text;
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.Connection.ChangeDatabase(DB);

                int returner = cmd.ExecuteNonQuery();
                StudioServer.StaticCertificationGrid.WriteLogLine($"{Query} ; Affected Rows:{returner}");
                return returner;
            }
        }

        public static DataTable ReturnDataTable(string query, string DB)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                con.Open();
                con.ChangeDatabase(DB);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                sqlDataAdapter.Fill(dataTable);
                con.Close();
            }
            StudioServer.StaticCertificationGrid.WriteLogLine(query);
            return dataTable;
        }

        public static Packet ReturnDataTableAsPacket(ushort opcode, DataTable blancDataTable)
        {
            int[] columnsNrows = new int[2] { blancDataTable.Columns.Count, blancDataTable.Rows.Count };

            Packet ReturnDataTablePacket = new Packet(opcode, false, true);
            ReturnDataTablePacket.WriteIntArray(columnsNrows);

            foreach (DataRow item in blancDataTable.Rows)
            {
                ReturnDataTablePacket.WriteAsciiArray(item.ItemArray);
            }

            return ReturnDataTablePacket;
        }

        public static DataTable ReturnDataTableByProcedure(string procedureName, string DB, SqlParameter[] param)
        {
            DataTable dataTableProcedure = new DataTable();
            SqlConnection con = new SqlConnection(SqlConnectionString);

            using (SqlCommand command = new SqlCommand(procedureName, con))
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                command.Connection.ChangeDatabase(DB);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(param);

                SqlDataAdapter addi = new SqlDataAdapter(command);
                addi.Fill(dataTableProcedure);

                command.Connection.Close();
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
            StudioServer.StaticCertificationGrid.WriteLogLine($"EXEC {DB}.dbo.{procedureName} {paramstring}");
            return dataTableProcedure;
        }

        public static string ReturnStringByQuery(string query, string DB)
        {
            string returnstring = null;
            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                con.Open();
                con.ChangeDatabase(DB);

                SqlCommand cmd = new SqlCommand(query, con);
                returnstring = (string)cmd.ExecuteScalar();
                con.Close();
            }
            StudioServer.StaticCertificationGrid.WriteLogLine(query);
            return returnstring;
        }

        public static KeyValuePair<string, bool> TestSqlConnection()
        {
            string testString = "";
            bool testOK = false;
            try
            {
                using (SqlConnection contest = new SqlConnection(SqlConnectionString))
                {
                    contest.Open();
                    if (contest.State == ConnectionState.Open)
                    {
                        testString = $"Established connection to: {contest.DataSource} ";
                        testOK = true;
                        contest.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                testString = $"Failed connecting to DatabaseEngine\n Exception: {ex}";
                testOK = false;
            }
            KeyValuePair<string, bool> SqlTestPair = new KeyValuePair<string, bool>(testString, testOK);
            return SqlTestPair;
        }

        public static KeyValuePair<string, bool> TestSqlConnection(string database)
        {
            string testString = "";
            bool testOK = false;
            try
            {
                using (SqlConnection contest = new SqlConnection(SqlConnectionString))
                {
                    contest.Open();
                    contest.ChangeDatabase(database);
                    if (contest.State == ConnectionState.Open)
                    {
                        testString = $"Established connection to: {contest.DataSource} ";
                        testOK = true;
                        contest.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                testString = $"Failed connecting to DatabaseEngine\n Exception: {ex}";
                testOK = false;
            }
            KeyValuePair<string, bool> SqlTestPair = new KeyValuePair<string, bool>(testString, testOK);
            return SqlTestPair;
        }

        #endregion Public Methods
    }
}