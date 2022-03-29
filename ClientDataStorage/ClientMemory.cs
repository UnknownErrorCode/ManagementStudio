using Structs.Dashboard;
using System.Collections.Generic;

namespace ClientDataStorage
{
    public static class ClientMemory
    {
        public static string[] AllowedDataTables;
        public static string[] AllowedPlugin;
        public static Dictionary<string, DashboardMessage> DashboardDictionary = new Dictionary<string, DashboardMessage>();
        public static List<string> UsedDataTables;
        public static List<string> UsedPlugins = new List<string>();
        public static string AccountName { get => ClientCore.AccountName; }
        public static bool LoggedIn { get; set; }
    }
}