using ServerFrameworkRes;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;

namespace StudioServer
{
    class ServerInterface : IAsyncInterface
    {
        public bool OnConnect(AsyncContext context)
        {
            ServerData context_data = new ServerData
            {
                m_certification_buffer = (byte[])context.User,
                m_connected = true,
                UserIP = context.State.EndPoint.ToString()
            };
            context.User = context_data;

            return true;
        }

        public void OnDisconnect(AsyncContext context)
        {
            ServerData context_data = (ServerData)context.User;
            context_data.m_connected = false;

            ServerMembory.RemoveUserOnline(context_data);

        }

        public void OnError(AsyncContext context, object user)
        {
            if (context != null && context.User != null)
            {
                ServerData context_data = (ServerData)context.User;
                context_data.m_connected = false;
                ServerMembory.RemoveUserOnline(context_data);
            }
        }

        public bool OnReceive(AsyncContext context, byte[] buffer, int count)
        {
            ServerData context_data = (ServerData)context.User;

            try
            {
                context_data.m_security.Recv(buffer, 0, count);
                List<Packet> packets = context_data.m_security.TransferIncoming();
                if (packets != null)
                {
                    foreach (Packet packet in packets)
                    {
                        // byte[] payload = packet.GetBytes();
                        // StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("[{7}][{0:X4}][{1} bytes]{2}{3}{4}{5}{6}", packet.Opcode, payload.Length, packet.Encrypted ? "[Encrypted]" : "", packet.Massive ? "[Massive]" : "", Environment.NewLine, Utility.HexDump(payload), Environment.NewLine, context.Guid));
                        // StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("Received Package Opcode: {0:X4}", packet.Opcode));

                        Packet result = Handler.IncomePackage.HandlePackage(packet, context_data);
                        if (result != null)
                        {
                            context_data.m_security.Send(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ex.Message);
                return false;
            }

            return true;
        }

        public void OnTick(AsyncContext context)
        {
            ServerData context_data = (ServerData)context.User;
            if (context_data == null)
            {
                return;
            }

            if (!context_data.m_connected)
            {
                return;
            }

            List<KeyValuePair<TransferBuffer, Packet>> buffers = context_data.m_security.TransferOutgoing();
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
