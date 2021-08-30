using Structs.Dashboard;
using System.Collections.Generic;

namespace ClientDataStorage.Dashboard
{
    public static class DashboardMemory
    {
        public static bool ChangesAviable = false;
       public static Dictionary<string, DashboardMessage> TopicDictionary = new Dictionary<string, DashboardMessage>();
    }
}
