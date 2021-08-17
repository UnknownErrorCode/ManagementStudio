using ManagementServer.Network;
using ManagementServer.Utility;
using ServerFrameworkRes;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;

namespace ManagementServer
{
    class ServerInterface : IAsyncInterface
    {
        private static ServerPacketHandler Handler = new ServerPacketHandler();
        public bool OnConnect(AsyncContext context)
        {
            if (context.State.EndPoint == null)
                return false;


            ServerMemory.ClientDataPool.Add(
                $"{context.State.EndPoint}",
                new ServerClientData(
                     $"{context.State.EndPoint}".Split(':')[0],
                    (byte[])context.User));

            context.User = ServerMemory.ClientDataPool[$"{context.State.EndPoint}"];
            GC.Collect();
            ServerMemory.OnlineUser++;
            return true;
        }

        public void OnDisconnect(AsyncContext context)
        {
            //    ServerData context_data = (ServerData)context.User;
                context.Disconnect();
            //   context = null;
            //   context_data = null;
            ServerMemory.ClientDataPool.Remove($"{context.State.EndPoint}");
            context = null;
            GC.Collect();
            ServerMemory.OnlineUser--;


        }

        public void OnError(AsyncContext context, object user)
        {
            if (context != null && context.User != null)
            {
                OnDisconnect(context);
            }
        }

        public bool OnReceive(AsyncContext context, byte[] buffer, int count)
        {
            ServerClientData serverClientData = (ServerClientData)context.User;

            try
            {
                serverClientData.m_security.Recv(buffer, 0, count);
                List<Packet> packets = serverClientData.m_security.TransferIncoming();
                if (packets != null)
                {
                    foreach (Packet packet in packets)
                    {
                        PacketHandlerResult result =Handler.HandlePacketAction(serverClientData, packet).GetAwaiter().GetResult();
                        // byte[] payload = packet.GetBytes();
                        // StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("[{7}][{0:X4}][{1} bytes]{2}{3}{4}{5}{6}", packet.Opcode, payload.Length, packet.Encrypted ? "[Encrypted]" : "", packet.Massive ? "[Massive]" : "", Environment.NewLine, Utility.HexDump(payload), Environment.NewLine, context.Guid));
                        // StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("Received Package Opcode: {0:X4}", packet.Opcode));

                        switch (result)
                        {
                            case PacketHandlerResult.Block:
                            case PacketHandlerResult.Response:
                                continue;
                            case PacketHandlerResult.Error:
                            case PacketHandlerResult.Disconnect:
                                OnDisconnect(context);
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ex.Message);
                return false;
            }

            return true;
        }

        public void OnTick(AsyncContext context)
        {
            ServerClientData context_data = (ServerClientData)context.User;
            if (context_data == null)
                return;

            if (!context_data.m_connected)
                return;

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
