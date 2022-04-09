using ManagementServer.Network;
using System;
using System.Collections.Generic;

namespace ManagementServer
{
    internal static class ServerMemory
    {
        #region Fields

        internal static Dictionary<string, ServerClientData> ClientDataPool = new Dictionary<string, ServerClientData>(100);



        #endregion Fields

        #region Properties

        internal static int OnlineUser => ClientDataPool.Count;

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}