﻿using Structs.Dashboard;
using System.Collections.Generic;

namespace PluginFramework.Dashboard
{
    public static class DashboardHelper
    {
        #region Fields

        public static bool ChangesAviable = false;
        public static Dictionary<string, DashboardMessage> TopicDictionary = new Dictionary<string, DashboardMessage>();

        #endregion Fields
    }
}