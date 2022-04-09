using ManagementFramework.Network.AsyncNetwork;
using ManagementFramework.Network.Security;
using System;
using System.Threading;

namespace ManagementServer.Network
{
    internal static class LizenceCore
    {
        private static readonly LizenceInterface CInterface = new LizenceInterface();
        private static readonly AsyncClient ClientNetwork = new AsyncClient();
        private static readonly Thread LizenceTickThread;

        static LizenceCore()
        {
            LizenceTickThread = new Thread(LizenceCore.TickerThread);
        }

        public static bool IsConnected => CInterface.CertData.m_connected;

        #region Methods

        public static void AddEntry(ushort packetID, Func<ServerData, Packet, PacketHandlerResult> handler) => CInterface.CHandler.AddEntry(packetID, handler);

        public static void Disconnect()
        {
            CInterface.CertData.m_connected = false;
            LizenceTickThread.Abort();
        }

        public static void Send(Packet packet) => CInterface.CertData.m_security.Send(packet);

        public static bool TryConnect()
        {
            try
            {
                if (!ClientNetwork.TryConnect(ServerManager.settings.CertIP, ServerManager.settings.CertPort, CInterface, CInterface.CertData))
                {
                    return false;
                }

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    if (CInterface.CertData.m_connected)
                    {
                        break;
                    }
                }

                if (!CInterface.CertData.m_connected)
                {
                    return false;
                }

                LizenceTickThread.Start();

                return CInterface.CertData.m_connected;
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ex, "LizenceCore: Start()");
                return false;
            }
        }

        private static void TickerThread()
        {
            while (CInterface.CertData.m_connected)
            {
                ClientNetwork.Tick();
                Thread.Sleep(1);
            }
        }

        #endregion Methods
    }
}