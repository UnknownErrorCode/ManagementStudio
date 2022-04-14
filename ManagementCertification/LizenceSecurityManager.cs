using ManagementCertification.Utility;
using System.Collections.Generic;
using System.Data;

namespace ManagementCertification
{
    internal static class LizenceSecurityManager
    {
        private static Dictionary<byte, string[]> _LizencePluginGroups;
        private static Dictionary<string, string[]> _ToolPluginDataAccess; //= new Dictionary<string, string[]>();

        /// <summary>
        /// Binds the LizenceGroup to its DataTables
        /// </summary>
        private static Dictionary<byte, string[]> LizenceGroupDataAccess;

        public static int SecurityGroupCount => _LizencePluginGroups.Count;

        internal static string[] GetSecurityDataTableNames(byte securityGroupID)
        {
            if (LizenceGroupDataAccess.ContainsKey(securityGroupID))
            {
                return LizenceGroupDataAccess[securityGroupID];
            }

            return null;
        }

        internal static string[] GetSecurityPluginNames(byte securityGroup)
        {
            if (_LizencePluginGroups.ContainsKey(securityGroup))
            {
                return _LizencePluginGroups[securityGroup];
            }

            return null;
        }

        internal static bool TryRefreshSecurityManager()
        {
            _ToolPluginDataAccess = new Dictionary<string, string[]>();
            _LizencePluginGroups = new Dictionary<byte, string[]>();
            DataTable dt = SQL.GetPluginDataAccess();
            DataTable dt2 = SQL.GetSecurityPluginAccess();

            foreach (DataRow row in dt.Rows)
            {
                if (_ToolPluginDataAccess.ContainsKey(row.Field<string>("PluginName")))
                {
                    continue;
                }

                List<string> list = new List<string>();
                foreach (DataRow pRow in dt.Rows)
                {
                    if (pRow.Field<string>("PluginName").Equals(row.Field<string>("PluginName")))
                    {
                        list.Add(pRow.Field<string>("TableName"));
                    }
                }
                _ToolPluginDataAccess.Add(row.Field<string>("PluginName"), list.ToArray());
            }

            foreach (DataRow row in dt2.Rows)
            {
                if (_LizencePluginGroups.ContainsKey(row.Field<byte>("SecurityGroupID")))
                {
                    continue;
                }

                List<string> list = new List<string>();
                foreach (DataRow pRow in dt2.Rows)
                {
                    if (pRow.Field<byte>("SecurityGroupID").Equals(row.Field<byte>("SecurityGroupID")))
                        list.Add(pRow.Field<string>("AllowedPlugins"));
                }
                _LizencePluginGroups.Add(row.Field<byte>("SecurityGroupID"), list.ToArray());
            }

            LizenceGroupDataAccess = new Dictionary<byte, string[]>(_LizencePluginGroups.Count);

            foreach (KeyValuePair<byte, string[]> securityGroup in _LizencePluginGroups)
            {
                List<string> list = new List<string>();
                foreach (string pluginName in securityGroup.Value)
                {
                    if (!_ToolPluginDataAccess.ContainsKey(pluginName))
                        continue;

                    foreach (string item in _ToolPluginDataAccess[pluginName])
                        if (!list.Contains(item))
                            list.Add(item);
                }
                LizenceGroupDataAccess.Add(securityGroup.Key, list.ToArray());
            }
            return true;
        }
    }
}