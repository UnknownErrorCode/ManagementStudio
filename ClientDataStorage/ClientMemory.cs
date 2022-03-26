using Structs.Dashboard;
using System.Collections.Generic;

namespace ClientDataStorage
{
    public static class ClientMemory
    {
        public static bool LoggedIn { get; set; }
        public static string[] AllowedPlugin;
        public static List<string> UsedPlugins  = new List<string>();
        public static Dictionary<string, DashboardMessage> DashboardDictionary = new Dictionary<string, DashboardMessage>();
        public static string[] AllowedDataTables;
        public static List<string> UsedDataTables;
        public static string AccountName { get => Network.ClientCore.AccountName; }
    }
}
