using ManagementServer.Utility;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagementServer
{
    internal static class PluginSecurityManager
    {
        internal static DataTable _ToolPluginDataAccessDataTable;


        private static Dictionary<string, string[]> ToolPluginDataAccess;
        private static Dictionary<byte, string[]> SecurityGroupDataAccess;
        private static Dictionary<byte, string[]> _ToolPluginGroups;

        public static int SecurityGroupCount => _ToolPluginGroups.Count;

        public static bool IsRefreshed => TryRefreshSecurityManager();

        internal static string[] GetPluginDataTableNames(string pluginname)
        {
            if (ToolPluginDataAccess.TryGetValue(pluginname, out string[] tableNames))
            {
                return tableNames;
            }

            return null;
        }

        internal static string[] GetSecurityDataTableNames(byte securityGroupID)
        {
            if (SecurityGroupDataAccess.ContainsKey(securityGroupID))
            {
                return SecurityGroupDataAccess[securityGroupID];
            }

            return null;
        }

        internal static string[] GetSecurityPluginNames(byte securityGroup)
        {
            if (_ToolPluginGroups.ContainsKey(securityGroup))
            {
                return _ToolPluginGroups[securityGroup];
            }

            return null;
        }

        internal static bool IsAllowed(string pluginName, byte securityGroup)
        {
            if (!_ToolPluginGroups.ContainsKey(securityGroup))
            {
                return false;
            }

            return _ToolPluginGroups[securityGroup].Contains(pluginName);
        }

        private static bool TryRefreshSecurityManager()
        {
            if (_ToolPluginDataAccessDataTable == null)
            {
                return false;
            }
            ToolPluginDataAccess = new Dictionary<string, string[]>();
            _ToolPluginGroups = new Dictionary<byte, string[]>();
            // _ToolPluginDataAccessDataTable = SQL.GetPluginDataAccess();
            DataTable dt2 = SQL.GetSecurityPluginAccess();

            foreach (DataRow row in _ToolPluginDataAccessDataTable.Rows)
            {
                if (ToolPluginDataAccess.ContainsKey(row.Field<string>("PluginName")))
                {
                    continue;
                }

                List<string> list = new List<string>();
                foreach (DataRow pRow in _ToolPluginDataAccessDataTable.Rows)
                {
                    if (pRow.Field<string>("PluginName").Equals(row.Field<string>("PluginName")))
                    {
                        list.Add(pRow.Field<string>("TableName"));
                    }
                }
                ToolPluginDataAccess.Add(row.Field<string>("PluginName"), list.ToArray());
            }

            foreach (DataRow row in dt2.Rows)
            {
                if (_ToolPluginGroups.ContainsKey(row.Field<byte>("SecurityGroupID")))
                {
                    continue;
                }

                List<string> list = new List<string>();
                foreach (DataRow pRow in dt2.Rows)
                {
                    if (pRow.Field<byte>("SecurityGroupID").Equals(row.Field<byte>("SecurityGroupID")))
                    {
                        list.Add(pRow.Field<string>("AllowedPlugins"));
                    }
                }
                _ToolPluginGroups.Add(row.Field<byte>("SecurityGroupID"), list.ToArray());
            }

            SecurityGroupDataAccess = new Dictionary<byte, string[]>(_ToolPluginGroups.Count);

            foreach (KeyValuePair<byte, string[]> securityGroup in _ToolPluginGroups)
            {
                List<string> list = new List<string>();
                foreach (string pluginName in securityGroup.Value)
                {
                    if (!ToolPluginDataAccess.ContainsKey(pluginName))
                    {
                        continue;
                    }

                    foreach (string item in ToolPluginDataAccess[pluginName])
                    {
                        if (!list.Contains(item))
                        {
                            list.Add(item);
                        }
                    }
                }
                SecurityGroupDataAccess.Add(securityGroup.Key, list.ToArray());
            }
            return true;
        }

    }
}