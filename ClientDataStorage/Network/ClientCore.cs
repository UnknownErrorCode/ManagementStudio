﻿using System;
using System.Collections.Generic;
using ServerFrameworkRes.Network.AsyncNetwork;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ServerFrameworkRes.Network.Security;

namespace ClientDataStorage.Network
{
    public static class ClientCore
    {
        private static AsyncClient ClientNetwork = new AsyncClient();
        private static ClientInterface CInterface = new ClientInterface();


        public static Action OnDataReceived { get => CInterface.CHandler.OnReceiveAllTables; set => CInterface.CHandler.OnReceiveAllTables = value; }

        public static void RequestPluginDataTable(string pluginName)
        {
            
        }

        public static bool Connected { get => CInterface.cData.m_connected; }
        internal static string AccountName { get => CInterface.cData.AccountName; }

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
        public static void Send(Packet packet)
        {
            if (CInterface.cData.m_connected)
                CInterface.cData.m_security.Send(packet);
        }
        public static void Disconnect()
        {
            if (CInterface.cData.m_connected)
                CInterface.cData.m_connected = false;
        }
        private static void TickerThread()
        {
            while (CInterface.cData.m_connected)
                ClientNetwork.Tick();
        }

        public static void AddEntry(ushort packetID, Func<ServerData, Packet, PacketHandlerResult> handler)
        {
            CInterface.CHandler.AddEntry(packetID, handler);
        }
    }
}