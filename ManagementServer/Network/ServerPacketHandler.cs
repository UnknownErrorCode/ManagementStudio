using ManagementServer.Utility;
using ServerFrameworkRes.Network.Security;
using System.Data;

namespace ManagementServer.Network
{
    class ServerPacketHandler : PacketHandler
    {

        public ServerPacketHandler()
        {
            base.AddEntry(0x2001, Reply0x2001);
            // client
            base.AddEntry(0x1000, ReplyLoginRequest);
            base.AddEntry(0x1001, ReplyAddNewTopicToDashboard);
            // launcher
            base.AddEntry(0x3000, ReplyRequestUpdate);

        }

        private PacketHandlerResult ReplyAddNewTopicToDashboard(ServerData arg1, Packet arg2)
        {

            return Handler.S_DASHBOARD.TryAddNewTopic(arg1, arg2);
        }


        /// <summary>
        /// Server receives handshake process packet and verifiels that user is using the originale Tool, no bot or other stuff...
        /// </summary>
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0x2001(ServerData data, Packet packet)
        {
            var identity = packet.ReadAscii();
            var flag = packet.ReadByte();

            if (identity == "Tool_Client" && flag == 1)
            {
                Packet loginDataRequestPacket = new Packet(0xC000);
                loginDataRequestPacket.WriteAscii("RequestAuthentification");
                data.m_security.Send(loginDataRequestPacket);
                return PacketHandlerResult.Response;
            }
            else if (identity == "Tool_Launcher" && flag == 1)
            {
                data.m_security.Send(Handler.S_UPDATE.SendServerVersion());
                return PacketHandlerResult.Response;
            }
            else
                return PacketHandlerResult.Block;
        }

        /// <summary>
        /// 0x1000 includes login data
        /// Client sends login information and server checks its validation
        /// </summary>
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult ReplyLoginRequest(ServerData data, Packet packet)
        {
            return Handler.S_LOGIN.TryLogin(data, packet);
        }

        /// <summary>
        /// CLIENT_SERVER -- Client sends this packet if the version does not match the current version.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult ReplyRequestUpdate(ServerData data, Packet packet)
        {
            var latestClientVersion = packet.ReadInt();

            Handler.S_UPDATE.SendFiles(data, latestClientVersion);

            return PacketHandlerResult.Block;
        }
    }
}
