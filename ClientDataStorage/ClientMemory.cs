using Structs.Dashboard;
using System.Collections.Generic;

namespace PluginFramework
{
    public static class ClientMemory
    {
        #region Fields

        public static string[] AllowedDataTables;
        public static string[] AllowedPlugin;
        public static Dictionary<string, DashboardMessage> DashboardDictionary = new Dictionary<string, DashboardMessage>();
        public static List<string> UsedPlugins = new List<string>();

        #endregion Fields

        #region Properties

        public static string AccountName => ClientCore.AccountName;

        #endregion Properties
    }
}