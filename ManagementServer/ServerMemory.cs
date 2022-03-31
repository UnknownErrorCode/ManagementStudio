using ManagementServer.Network;
using System;
using System.Collections.Generic;

namespace ManagementServer
{
    internal static class ServerMemory
    {
        #region Internal Fields

        internal static Dictionary<string, ServerClientData> ClientDataPool = new Dictionary<string, ServerClientData>(100);

        #endregion Internal Fields

        #region Internal Properties

        internal static int OnlineUser => ClientDataPool.Count;

        #endregion Internal Properties

        #region Internal Methods

        internal static void BroadcastPacket(ServerFrameworkRes.Network.Security.Packet packet)
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

        #endregion Internal Methods
    }
}