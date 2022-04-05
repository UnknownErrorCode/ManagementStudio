using ManagementCertification.Network;
using System;
using System.Collections.Generic;

namespace ManagementCertification
{
    internal static class LizenceMemory
    {
        #region Fields

        internal static Dictionary<string, ServerLizenceData> UserDataPool = new Dictionary<string, ServerLizenceData>(100);

        #endregion Fields

        #region Properties

        internal static int OnlineUser => UserDataPool.Count;

        #endregion Properties

        #region Methods

        internal static void BroadcastPacket(ServerFrameworkRes.Network.Security.Packet packet)
        {
            try
            {
                foreach (KeyValuePair<string, ServerLizenceData> client in UserDataPool)
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