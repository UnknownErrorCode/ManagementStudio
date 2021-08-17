using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer
{
    static class ServerMemory
    {
        internal static Dictionary<string, Utility.ServerClientData> ClientDataPool = new Dictionary<string, Utility.ServerClientData>(100);

        internal static int OnlineUser = 0;

    }
}
