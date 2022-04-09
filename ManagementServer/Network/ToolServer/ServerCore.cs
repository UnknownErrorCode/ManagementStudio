using ManagementFramework.Network.AsyncNetwork;
using System.Threading;

namespace ManagementServer.Network
{
    internal static class ServerCore
    {
        private static AsyncServer Server = new AsyncServer();
        // private static ServerInterface Interface;
        internal static bool IsConnected => Server.IsConnected;
        internal static void Listen(string iP, int port, int outstanding, ServerInterface serverInterface, byte[] buffer) => Server.Accept(iP, port, outstanding, serverInterface, buffer);

        internal static void Stop() => Server.Stop();

        internal static void Tick() => Server.Tick();



        internal static void TickThread()
        {
            while (Server.IsConnected)
            {
                Network.ServerCore.Tick();
                Thread.Sleep(1);
            }

        }

    }
}
