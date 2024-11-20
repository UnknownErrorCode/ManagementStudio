using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace ManagementServer.Utility
{
    internal partial class SQL
    {


        /// <summary>
        /// Converts public properties of a struct into SqlParameter array.
        /// </summary>
        /// <typeparam name="T">The struct type.</typeparam>
        /// <param name="instance">The instance of the struct.</param>
        /// <returns>An array of SqlParameter representing the struct's public properties.</returns>
        private static SqlParameter[] ToSqlParameters<T>(T instance) where T : struct
        {
            // Get all public properties of the struct
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return properties
                .Select(property =>
                {
                    // Get the property name and value
                    string paramName = $"@{property.Name}";
                    object paramValue = property.GetValue(instance) ?? DBNull.Value;

                    // Infer SqlDbType based on the property type
                    SqlDbType sqlType = InferSqlDbType(property.PropertyType);

                    return new SqlParameter(paramName, sqlType)
                    {
                        Value = paramValue
                    };
                })
                .ToArray();
        }


        /// <summary>
        /// Infers SqlDbType from a .NET type.
        /// </summary>
        /// <param name="type">The .NET type.</param>
        /// <returns>The inferred SqlDbType.</returns>
        private static SqlDbType InferSqlDbType(Type type)
        {
            // Handle nullable types
            if (Nullable.GetUnderlyingType(type) != null)
            {
                type = Nullable.GetUnderlyingType(type);
            }

            // Map .NET types to SqlDbType
            if (type == typeof(int)) return SqlDbType.Int;
            if (type == typeof(string)) return SqlDbType.VarChar;
            if (type == typeof(byte)) return SqlDbType.TinyInt;
            if (type == typeof(short)) return SqlDbType.SmallInt;
            if (type == typeof(long)) return SqlDbType.BigInt;
            if (type == typeof(bool)) return SqlDbType.Bit;
            if (type == typeof(DateTime)) return SqlDbType.DateTime;
            if (type == typeof(decimal)) return SqlDbType.Decimal;
            if (type == typeof(float) || type == typeof(double)) return SqlDbType.Float;

            // Default case for unsupported types
            return SqlDbType.Variant;
        }


        /// <summary>
        /// Formats SQL parameters into a readable string for logging.
        /// </summary>
        /// <param name="parameters">The array of SqlParameter objects.</param>
        /// <returns>A formatted string representation of the parameters.</returns>
        private static string FormatParameters(SqlParameter[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
                return "No parameters provided.";

            return string.Join(", ", parameters.Select(p =>
                $"{p.ParameterName} = {(p.Value == DBNull.Value ? "NULL" : p.Value)}"));
        }

        /// <summary>
        /// Executes a stored procedure to save or update an entity, logs the operation's outcome, and returns the result.
        /// </summary>
        /// <param name="accountName">The account name for logging purposes.</param>
        /// <param name="entity">SQL parameters to pass to the stored procedure.</param>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <returns>
        /// A <see cref="SaveResult"/> indicating success, status, and any messages from the operation.
        /// </returns>
        /// <remarks>
        /// Logs the operation with appropriate log levels:
        /// - Info: When execution starts.
        /// - SQL: On success.
        /// - Warning: If no rows are affected.
        /// - Fatal: On exceptions.
        /// </remarks>
        /// <example>
        /// SaveEntity("TestAccount", parameters, "_EDIT_RefTrigger");
        /// </example>
        internal static SaveResult SaveEntity(string accountName, SqlParameter[] entity, string procedureName)

        {
            try
            {
                // Log the starting point with details about the procedure and parameters
                ServerManager.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.warning,
                    $"Account: {accountName} - Starting execution of procedure '{procedureName}' with parameters: {FormatParameters(entity)}");

                var resu = SQL.ExecuteStoredProcedure(procedureName, ServerManager.settings.DBDev, entity, accountName);

                // Handle success case
                if (resu.IsSuccess)
                {
                    ServerManager.Logger.WriteLogLine(
                        ManagementFramework.Ressources.LogLevel.sql,
                        $"Account: {accountName} - Procedure '{procedureName}' executed successfully. Message: {resu.Message}");

                    // Create and return the success result
                    CreateSaveResultSuccess(resu, out SaveResult saveResult);
                    return saveResult;
                }

                // Handle warning case (no rows updated)
                ServerManager.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.warning,
                    $"Account: {accountName} - Procedure '{procedureName}' completed but returned no rows. Parameters: {FormatParameters(entity)}");

                return new SaveResult
                {
                    Success = false,
                    Status = "FAILED",
                    Message = resu.Message != null ? resu.Message : "No rows returned from the procedure."
                };
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.fatal,
                    $"Account: {accountName} - Error saving {procedureName}. Exception: {ex.Message}");

                return new SaveResult
                {
                    Success = false,
                    Status = "FAILED",
                    Message = ex.Message
                };
            }
        }


        private static void CreateSaveResultSuccess((bool IsSuccess, string Message) resu, out SaveResult saveResult)
        {
            saveResult = new SaveResult
            {
                Success = resu.IsSuccess,
                Message = resu.Message
            };
        }
    }
}
