using ManagementCertification.Network;
using ManagementCertification.Utility;
using ServerFrameworkRes;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;

namespace ManagementCertification
{
    internal class LizenceServerInterface : IAsyncInterface
    {
        #region Fields

        private static readonly LizenceServerPacketHandler Handler = new LizenceServerPacketHandler();

        #endregion Fields

        #region Methods

        public bool OnConnect(AsyncContext context)
        {
            if (context.State.EndPoint == null)
                return false;

            LizenceMemory.UserDataPool.Add(
                $"{context.State.EndPoint}",
                new ServerLizenceData(
                     $"{context.State.EndPoint}".Split(':')[0],
                    (byte[])context.User));

            context.User = LizenceMemory.UserDataPool[$"{context.State.EndPoint}"];
            GC.Collect();
            return true;
        }

        public void OnDisconnect(AsyncContext context)
        {
            ServerData context_data = (ServerLizenceData)context.User;

            LizenceMemory.UserDataPool.Remove($"{context.State.EndPoint}");

            if (context_data.AccountName != null)
                CertificationManager.Logger.WriteLogLine(SQL.CheckLogout(context_data.AccountName, context_data.UserIP));

            context.Disconnect();
            GC.Collect();
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
            ServerLizenceData serverClientData = (ServerLizenceData)context.User;

            try
            {
                serverClientData.m_security.Recv(buffer, 0, count);
                List<Packet> packets = serverClientData.m_security.TransferIncoming();
                if (packets != null)
                {
                    foreach (ServerFrameworkRes.Network.Security.Packet packet in packets)
                    {
                        try
                        {
                            PacketHandlerResult result = Handler.HandlePacketAction(serverClientData, packet).GetAwaiter().GetResult();
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
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CertificationManager.Logger.WriteLogLine(ex, "LizenceSercerInterface onReceive");
                return false;
            }
            return true;
        }

        public void OnTick(AsyncContext context)
        {
            try
            {
                ServerLizenceData context_data = (ServerLizenceData)context.User;
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
                CertificationManager.Logger.WriteLogLine(e.Message);
            }
        }

        #endregion Methods
    }
}