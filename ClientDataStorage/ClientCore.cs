using PluginFramework.Network;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System;
using System.Threading;

namespace PluginFramework
{
    public static class ClientCore
    {
        #region Fields

        private static readonly ClientInterface CInterface = new ClientInterface();
        private static readonly AsyncClient ClientNetwork = new AsyncClient();

        #endregion Fields

        #region Properties

        public static bool Connected => CInterface.cData.m_connected;
        public static Action OnAllowedPluginReceived { get => CInterface.CHandler.OnAllowedPluginReceived; set => CInterface.CHandler.OnAllowedPluginReceived = value; }
        internal static string AccountName => CInterface.cData.AccountName;

        #endregion Properties

        #region Methods

        public static void AddEntry(ushort packetID, Func<ServerData, Packet, PacketHandlerResult> handler)
        {
            CInterface.CHandler.AddEntry(packetID, handler);
        }

        public static void Disconnect()
        {
            if (CInterface.cData.m_connected)
            {
                CInterface.cData.m_connected = false;
            }
        }

        public static void Send(Packet packet)
        {
            if (CInterface.cData.m_connected)
            {
                CInterface.cData.m_security.Send(packet);
            }
        }

        public static bool Start()
        {
            ClientNetwork.Connect(Config.StaticConfig.ToolServerIP, Config.StaticConfig.ToolServerPort, CInterface, CInterface.cData);

            for (int i = 0; i < 500; i++)
            {
                if (CInterface.cData.m_connected)
                {
                    break;
                }

                Thread.Sleep(1);
            }

            if (Connected)
            {
                Thread TickThread = new Thread(ClientCore.TickerThread);
                TickThread.Start();
            }

            return CInterface.cData.m_connected;
        }

        private static void TickerThread()
        {
            while (CInterface.cData.m_connected)
            {
                ClientNetwork.Tick();
            }
        }

        #endregion Methods
    }
}