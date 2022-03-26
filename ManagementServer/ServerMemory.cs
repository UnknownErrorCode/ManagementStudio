using System;
using System.Collections.Generic;

namespace ManagementServer
{
    static class ServerMemory
    {
        internal static Dictionary<string, Utility.ServerClientData> ClientDataPool = new Dictionary<string, Utility.ServerClientData>(100);

        internal static int OnlineUser = 0;


        internal static void BroadcastPacket(ServerFrameworkRes.Network.Security.Packet packet)
        {
            try
            {
                foreach (var client in ClientDataPool)
                    if (client.Value.m_connected)
                        client.Value.m_security.Send(packet);
            }
            catch (Exception )
            {
            }
        }

    }
}
