using ManagementLauncher.Network.AsyncClient;
using ManagementLauncher.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLauncher.Network
{
    class LauncherInterface : IAsyncInterface
    {
        public bool OnConnect(AsyncContext context)
        {
            LauncherClient.LData = new LauncherData();
            LauncherClient.LData.m_connected = true;
            context.User = LauncherClient.LData;
            return true;
        }

        public void OnDisconnect(AsyncContext context)
        {
            LauncherClient.LData = (LauncherData)context.User;
            LauncherClient.LData.m_connected = false;
        }

        public void OnError(AsyncContext context, object user)
        {
            if (context != null && context.User != null)
            {
                LauncherClient.LData = (LauncherData)context.User;
                LauncherClient.LData.m_connected = false;
            }
        }

        public bool OnReceive(AsyncContext context, byte[] buffer, int count)
        {
            LauncherClient.LData = (LauncherData)context.User;

            LauncherClient.LData.m_security.Recv(buffer, 0, count);
            List<Packet> packets = LauncherClient.LData.m_security.TransferIncoming();

            foreach (var packet in packets)
            {
                if (packet.Opcode == 0xA001)
                {
                    var version = packet.ReadInt();

                }
            }

            return true;
        }

        public void OnTick(AsyncContext context)
        {
            LauncherClient.LData = (LauncherData)context.User;

            if (LauncherClient.LData == null)
                return;

            if (!LauncherClient.LData.m_connected)
                return;

            List<KeyValuePair<TransferBuffer, Packet>> buffers = LauncherClient.LData.m_security.TransferOutgoing();
            if (buffers != null)
            {
                foreach (KeyValuePair<TransferBuffer, Packet> buffer in buffers)
                {
                    context.Send(buffer.Key.Buffer, 0, buffer.Key.Size);
                }
            }
        }
    }
}
