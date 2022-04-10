using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginFramework.Database
{
    public class DbQueryGenerator
    {
        private readonly Dictionary<string, string> UpdateValues = new Dictionary<string, string>();
        private string tableName;
        private string identityColumn;
        private string identityValue;

        public DbQueryGenerator(string tableName, string identityColumn, string identityValue)
        {
            this.tableName = tableName;
            this.identityColumn = identityColumn;
            this.identityValue = identityValue;
        }

        public bool HasUpdates => UpdateValues.Count > 0;

        public void ReassignIdentifier(string _identityValue)
        {
            UpdateValues.Clear();
            identityValue = _identityValue;
        }

        /// <summary>
        /// Stores the update values and columns inside a Dictionary to avoid updating non changed values.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public void UpdateObject(string column, string value)
        {
            if (!UpdateValues.ContainsKey(column))
                UpdateValues.Add(column, value);
            else
                UpdateValues[column] = value;
        }

        /// <summary>
        /// Generates the query from <see cref="UpdateValues"/>.
        /// </summary>
        /// <param name="query"></param>
        /// <returns> <see cref="bool"/>
        /// <br>-Weather the Dictionary contains sequence to update the Table.</br>
        /// </returns>
        public bool GenerateQuery(out string query)
        {
            query = $"Update {tableName} SET \n";

            if (UpdateValues.Count == 0)
                return false;

            foreach (KeyValuePair<string, string> item in UpdateValues)
            {
                query += $" [{item.Key}] = '{item.Value}'\n,";
            }

            query = query.Remove(query.Length - 1, 1);
            query += $" where [{identityColumn}] = '{identityValue}';";

            return true;
        }
    }
}