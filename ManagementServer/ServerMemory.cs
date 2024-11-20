using ManagementServer.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        internal static void BroadcastPacket2(ManagementFramework.Network.Security.Packet packet)
        {
            try
            {
                Parallel.ForEach(ClientDataPool, client =>
                {
                    if (client.Value.m_connected)
                    {
                        try
                        {
                            client.Value.m_security.Send(packet);
                        }
                        catch (Exception ex)
                        {
                            ServerManager.Logger.WriteLogLine(
                                ManagementFramework.Ressources.LogLevel.warning,
                                $"Failed to send packet to client: {client.Key}. Exception: {ex.Message}");
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(
                    ManagementFramework.Ressources.LogLevel.fatal,
                    $"BroadcastPacket encountered an error: {ex.Message}");
            }
        }

    }
}