using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System;
using System.Threading;

namespace ManagementServer.Network
{
    internal static class LizenceCore
    {
        private static readonly LizenceInterface CInterface = new LizenceInterface();
        private static readonly AsyncClient ClientNetwork = new AsyncClient();

        public static bool CanStart => Start();

        public static bool IsConnected => CInterface.CertData.m_connected;

        #region Methods

        public static void AddEntry(ushort packetID, Func<ServerData, Packet, PacketHandlerResult> handler)
        {
            CInterface.CHandler.AddEntry(packetID, handler);
        }

        public static void Disconnect()
        {
            if (CInterface.CertData.m_connected)
            {
                CInterface.CertData.m_connected = false;
            }
        }

        public static void Send(Packet packet)
        {
            if (CInterface.CertData.m_connected)
            {
                CInterface.CertData.m_security.Send(packet);
            }
        }

        public static bool Start()
        {
            ClientNetwork.Connect(ServerManager.settings.IP, 15555, CInterface, CInterface.CertData);

            for (int i = 0; i < 500; i++)
            {
                if (CInterface.CertData.m_connected)
                {
                    break;//ToDo: wtf....
                }

                Thread.Sleep(1);
            }

            if (CInterface.CertData.m_connected)
            {
                Thread TickThread = new Thread(TickerThread);
                TickThread.Start();
            }

            return CInterface.CertData.m_connected;
        }

        private static void TickerThread()
        {
            while (CInterface.CertData.m_connected)
            {
                ClientNetwork.Tick();
            }
        }

        #endregion Methods
    }
}