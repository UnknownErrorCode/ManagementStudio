using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekciDClient.Network
{
    class ClientPacketHandler : PacketHandler
    {

        public ClientPacketHandler()
        {
            base.AddEntry(0xA000, Reply0xA000);
            base.AddEntry(0xA001, Reply0xA001);
            base.AddEntry(0xA002, Reply0xA002);
        }


        /// <summary>
        /// SERVER_HANDSHAKE 
        /// -- Server sends request to the Client and forces to send login information to the server
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0xA000(ServerData arg1, Packet arg2)
        {
            var prove = arg2.ReadAscii();
            if (prove == "RequestAuthentification")
            {
                Packet requestLogin = new Packet(0x1000);
                requestLogin.WriteAscii(ClientMemory.LatestAccountName);
                requestLogin.WriteAscii(ClientMemory.LatestPassword);
                arg1.m_security.Send(requestLogin);
                return PacketHandlerResult.Response;
            }
            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// SERVER_VERSION 
        /// -- Server sends latest version to client to compare if update is nesseccary
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0xA001(ServerData arg1, Packet arg2)
        {
            var version = arg2.ReadInt();
            var ClientVersion = Program.MainConfig.ToolServerVersion();

            if (ClientVersion != version)
                arg1.m_security.Send(Handler.C_UPDATE.RequestFiles(arg1, ClientVersion));
            //else continue doing stuff...

            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// SERVER_UPDATE_FILE
        ///  -- Server sends file to Client to keep up to date
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0xA002(ServerData arg1, Packet arg2)
        {
            if (Handler.C_UPDATE.ReceiveFile(arg2))
                return PacketHandlerResult.Block;


            return PacketHandlerResult.Disconnect;
        }
    }
}
