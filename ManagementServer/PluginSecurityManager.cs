﻿using ManagementServer.Utility;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagementServer
{
    static class PluginSecurityManager
    {
        static Dictionary<string, string[]> PluginDataTableBindings; //= new Dictionary<string, string[]>();

        static Dictionary<byte, string[]> SecurityGroupPluginBindings;

        static Dictionary<byte, string[]> SecurityGroupDataAccess;

        internal static bool IsAllowed(string pluginName, byte securityGroup)
        {
            if (!SecurityGroupPluginBindings.ContainsKey(securityGroup))
                return false;

            return SecurityGroupPluginBindings[securityGroup].Contains(pluginName);
        }

        internal static bool TryRefreshSecurityManager()
        {
            PluginDataTableBindings = new Dictionary<string, string[]>();
            SecurityGroupPluginBindings = new Dictionary<byte, string[]>();
            DataTable dt = SQL.GetPluginDataAccess();
            DataTable dt2 = SQL.GetSecurityPluginAccess();

            foreach (DataRow row in dt.Rows)
            {
                if (PluginDataTableBindings.ContainsKey(row.Field<string>("PluginName")))
                    continue;
                var list = new List<string>();
                foreach (DataRow pRow in dt.Rows)
                {
                    if (pRow.Field<string>("PluginName").Equals(row.Field<string>("PluginName")))
                        list.Add(pRow.Field<string>("TableName"));
                }
                PluginDataTableBindings.Add(row.Field<string>("PluginName"), list.ToArray());
            }

            foreach (DataRow row in dt2.Rows)
            {
                if (SecurityGroupPluginBindings.ContainsKey(row.Field<byte>("SecurityGroupID")))
                    continue;
                var list = new List<string>();
                foreach (DataRow pRow in dt2.Rows)
                {
                    if (pRow.Field<byte>("SecurityGroupID").Equals(row.Field<byte>("SecurityGroupID")))
                        list.Add(pRow.Field<string>("AllowedPlugins"));
                }
                SecurityGroupPluginBindings.Add(row.Field<byte>("SecurityGroupID"), list.ToArray());
            }

            SecurityGroupDataAccess = new Dictionary<byte, string[]>(SecurityGroupPluginBindings.Count);

            foreach (var securityGroup in SecurityGroupPluginBindings)
            {
                var list = new List<string>();
                foreach (var pluginName in securityGroup.Value)
                {
                    if (!PluginDataTableBindings.ContainsKey(pluginName))
                        continue;

                    foreach (var item in PluginDataTableBindings[pluginName])
                    {
                        if (!list.Contains(item))
                            list.Add(item);
                    }
                }
                SecurityGroupDataAccess.Add(securityGroup.Key, list.ToArray());
            }
            return true;
        }

        internal static string[] GetSecurityPluginNames(byte securityGroup)
        {
            if (SecurityGroupPluginBindings.ContainsKey(securityGroup))
                return SecurityGroupPluginBindings[securityGroup];
            return null;
        }

        internal static string[] GetSecurityDataTableNames(byte securityGroupID)
        {
            if (SecurityGroupDataAccess.ContainsKey(securityGroupID))
                return SecurityGroupDataAccess[securityGroupID];
            return null;
        }

        internal static string[] GetPluginDataTableNames(string pluginname)
        {
            if (PluginDataTableBindings.TryGetValue(pluginname, out string[] tableNames))
                return tableNames;
            return null;
        }
    }
}