using System;
using System.Collections.Generic;
using ServerFrameworkRes.Network.AsyncNetwork;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RekciDClient.Network
{
    internal static class ClientCore
    {
        private static AsyncClient ClientNetwork = new AsyncClient();
        private static ClientInterface CInterface = new ClientInterface();

        public static bool Connected { get => CInterface.cData.m_connected; }

        internal static async Task<bool> Start()
        {
            ClientNetwork.Connect(Program.MainConfig.ToolServerIP(), Program.MainConfig.ToolServerPort(), CInterface, CInterface.cData);

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

        internal static void Disconnect()
        {
            CInterface.cData.m_connected = false;
        }
        private static void TickerThread()
        {
            while (CInterface.cData.m_connected)
                ClientNetwork.Tick();
        }
    }
}
