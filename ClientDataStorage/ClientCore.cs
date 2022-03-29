using ClientDataStorage.Network;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDataStorage
{
    public static class ClientCore
    {
        private static ClientInterface CInterface = new ClientInterface();
        private static AsyncClient ClientNetwork = new AsyncClient();
        public static bool Connected { get => CInterface.cData.m_connected; }
        public static Action OnAllowedPluginReceived { get => CInterface.CHandler.OnAllowedPluginReceived; set => CInterface.CHandler.OnAllowedPluginReceived = value; }
        public static Action OnDataReceived { get => CInterface.CHandler.OnReceiveAllTables; set => CInterface.CHandler.OnReceiveAllTables = value; }
        internal static string AccountName { get => CInterface.cData.AccountName; }

        public static void AddEntry(ushort packetID, Func<ServerData, Packet, PacketHandlerResult> handler)
        {
            CInterface.CHandler.AddEntry(packetID, handler);
        }

        public static void Disconnect()
        {
            if (CInterface.cData.m_connected)
                CInterface.cData.m_connected = false;
        }

        public static void Send(Packet packet)
        {
            if (CInterface.cData.m_connected)
                CInterface.cData.m_security.Send(packet);
        }

        public static async Task<bool> Start()
        {
            ClientNetwork.Connect(Config.StaticConfig.ToolServerIP, Config.StaticConfig.ToolServerPort, CInterface, CInterface.cData);

            for (int i = 0; i < 500; i++)
            {
                if (CInterface.cData.m_connected)
                    break;
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
                ClientNetwork.Tick();
        }
    }
}