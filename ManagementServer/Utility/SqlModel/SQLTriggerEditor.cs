using Structs.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Utility
{
    internal partial class SQL
    {


        internal static bool SaveRefTrigger(string accountName, RefTrigger trigger, out string status, out string message)
        {
            try
            {
                // Log the operation attempt
                ServerManager.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.sql,
                    $"Executing _EDIT_RefTrigger for ID: {trigger.ID}, CodeName: {trigger.CodeName128}");

                // Use SQL utility to execute the procedure with parameters
                DataTable result = SQL.ReturnDataTableByProcedure(
                    "_EDIT_RefTrigger", // Assume this is your stored procedure name
                    ServerManager.settings.DBDev,
                    trigger.ToSqlParameters()
                );

                // Assuming the result has a single row
                status = result.Rows[0]["Status"].ToString();
                message = result.Rows[0]["Message"].ToString();

                return result.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.fatal, $"Error saving RefTrigger: {ex.Message}");
                status = "FAILED";
                message = ex.Message;
                return false;
            }
        }
    }
}
