using ManagementFramework;
using ManagementFramework.Network.AsyncNetwork;
using ManagementFramework.Network.Security;
using System;
using System.Collections.Generic;

namespace ManagementServer.Network
{
    class LizenceInterface : IAsyncInterface
    {
        internal LizenceData CertData = new LizenceData();
        internal LizencePacketHandler CHandler = new LizencePacketHandler();

        public bool OnConnect(AsyncContext context)
        {
            CertData.m_connected = true;
            CertData.UserIP = context.State.EndPoint.ToString().Split(':')[0];
            context.User = CertData;

            return true;
        }

        public void OnDisconnect(AsyncContext context)
        {
            ServerData context_data = (ServerClientData)context.User;

            CertData = (LizenceData)context.User;
            CertData.m_connected = false;
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
            LizenceData serverClientData = (LizenceData)context.User;

            try
            {
                serverClientData.m_security.Recv(buffer, 0, count);
                List<Packet> packets = serverClientData.m_security.TransferIncoming();
                if (packets != null)
                {
                    foreach (Packet packet in packets)
                    {
                        try
                        {
                            PacketHandlerResult result = CHandler.HandlePacketAction(serverClientData, packet).GetAwaiter().GetResult();
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
                        catch (Exception ex)
                        {
                            ServerManager.Logger.WriteLogLine(ex, $"OnReceive:{serverClientData?.UserIP}");
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
            try
            {
                LizenceData context_data = (LizenceData)context.User;
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
            catch (Exception e)
            {
                ServerManager.Logger.WriteLogLine(e, "OnTick: ");
            }
        }
    }
}
