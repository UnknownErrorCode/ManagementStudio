using Structs.Dashboard;
using System;
using System.Collections.Generic;

namespace ClientDataStorage
{
    public static class ClientMemory
    {
        public static bool LoggedIn { get;  set; }
        public static string[] AllowedPlugin { get;  set; }
        public static Dictionary<string, DashboardMessage> DashboardDictionary { get;  set; } = new Dictionary<string, DashboardMessage>();
        public static List<string> AllowedDataTables { get; set; }

      
    }
}
