using System;
using System.Collections.Generic;

namespace ManagementServer
{
    internal static class ServerMemory
    {
        #region Internal Fields

        internal static Dictionary<string, Utility.ServerClientData> ClientDataPool = new Dictionary<string, Utility.ServerClientData>(100);

        internal static int OnlineUser = 0;

        #endregion Internal Fields

        #region Internal Methods

        internal static void BroadcastPacket(ServerFrameworkRes.Network.Security.Packet packet)
        {
            try
            {
                foreach (KeyValuePair<string, Utility.ServerClientData> client in ClientDataPool)
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