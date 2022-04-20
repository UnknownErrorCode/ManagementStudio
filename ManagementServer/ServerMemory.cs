using ManagementServer.Network;
using System;
using System.Collections.Generic;

namespace ManagementServer
{
    internal static class ServerMemory
    {
        internal static Dictionary<string, ServerClientData> ClientDataPool = new Dictionary<string, ServerClientData>(100);

        internal static int OnlineUser => ClientDataPool.Count;

        internal static void BroadcastPacket(ManagementFramework.Network.Security.Packet packet)
        {
            try
            {
                foreach (KeyValuePair<string, ServerClientData> client in ClientDataPool)
                {
                    if (client.Value.m_connected)
                    {
                        client.Value.m_security.Send(packet);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}