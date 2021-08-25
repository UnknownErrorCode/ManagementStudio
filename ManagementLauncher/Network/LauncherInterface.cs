using ManagementLauncher.Network.AsyncClient;
using ManagementLauncher.Network.Security;
using System;
using System.Collections.Generic;
using System.IO;
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
                    if (Launcher.LConfig.Version!= version)
                    {
                        Packet RequestUpdate = new Packet(0x3000);
                        RequestUpdate.WriteInt(Launcher.LConfig.Version);
                        LauncherClient.LData.m_security.Send(RequestUpdate);
                    }
                }
                else if (packet.Opcode == 0xA002)
                {
                    var cversion = packet.ReadInt();
                    var fileName = packet.ReadAscii();
                    var fileDire = packet.ReadAscii();
                    var cBinaryF = packet.ReadByteArray(packet.Remaining);


                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire)))
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), fileDire));

                    //if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)))
                    File.Create(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)).Write(cBinaryF, 0, cBinaryF.Length);

                    if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)))
                        return true;

                    return false;
                }
                else if (packet.Opcode == 0xA003)
                {
                    Launcher.WriteStaticLine("Update finished!");

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
