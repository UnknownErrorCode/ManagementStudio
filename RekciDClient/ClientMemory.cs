using Structs.Dashboard;
using System.Collections.Generic;

namespace ManagementClient
{
    internal static class ClientMemory
    {
        public static bool LoggedIn { get; internal set; }
        public static string[] AllowedPlugin { get; internal set; }
        public static Dictionary<string, DashboardMessage> DashboardDictionary { get; internal set; } = new Dictionary<string, DashboardMessage>();
    }
}