using ServerFrameworkRes;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System.Collections.Generic;

namespace ClientDataStorage.Network
{
    internal class ClientInterface : IAsyncInterface
    {
        internal ClientData cData = new ClientData();
        internal ClientPacketHandler CHandler = new ClientPacketHandler();

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool OnConnect(AsyncContext context)
        {
            cData.m_connected = true;
            cData.UserIP = context.State.EndPoint.ToString().Split(':')[0];
            context.User = cData;

            return true;
        }

        public void OnDisconnect(AsyncContext context)
        {
            cData = (ClientData)context.User;
            cData.m_connected = false;
        }

        public void OnError(AsyncContext context, object user)
        {
            if (context != null && context.User != null)
                OnDisconnect(context);
        }

        public bool OnReceive(AsyncContext context, byte[] buffer, int count)
        {
            cData = (ClientData)context.User;
            try
            {
                cData.m_security.Recv(buffer, 0, count);
                List<Packet> incomePacket = cData.m_security.TransferIncoming();
                if (incomePacket != null)
                {
                    foreach (Packet packet in incomePacket)
                    {
                        PacketHandlerResult result = CHandler.HandlePacketAction(cData, packet).GetAwaiter().GetResult();

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
            catch (System.Exception ex)
            {
                Log.Logger.WriteLogLine(ex.Message);
                return false;
            }

            return true;
        }

        public void OnTick(AsyncContext context)
        {
            cData = (ClientData)context.User;

            if (cData == null)
                return;

            if (!cData.m_connected)
                return;

            List<KeyValuePair<TransferBuffer, Packet>> buffers = cData.m_security.TransferOutgoing();
            if (buffers != null)
            {
                foreach (KeyValuePair<TransferBuffer, Packet> buffer in buffers)
                    context.Send(buffer.Key.Buffer, 0, buffer.Key.Size);
            }
        }
    }
}