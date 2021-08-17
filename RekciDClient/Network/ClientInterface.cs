using ServerFrameworkRes;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using System.Collections.Generic;

namespace RekciDClient.Network
{
    internal class ClientInterface : IAsyncInterface
    {
        internal ClientData cData = new ClientData();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool OnConnect(AsyncContext context)
        {
            //cData = new ClientData();
            cData.m_connected = true;
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
            {
                OnDisconnect(context);
            }
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
                    foreach (Packet item in incomePacket)
                    {
                        switch (item.Opcode)
                        {
                            case 0xA000:
                                var authentificcation = item.ReadAscii();
                                if (authentificcation == "RequestAuthentification")
                                {
                                    Packet packet = new Packet(0x1000);
                                    packet.WriteAscii(ClientMemory.LatestAccountName);
                                    packet.WriteAscii(ClientMemory.LatestPassword);
                                    cData.m_security.Send(packet);
                                    //TODO: Version request
                                    continue; //do stuff here
                                }
                                break;
                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
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
                {
                    context.Send(buffer.Key.Buffer, 0, buffer.Key.Size);
                }
            }
        }
    }
}