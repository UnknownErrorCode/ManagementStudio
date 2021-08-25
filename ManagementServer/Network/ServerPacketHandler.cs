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
            // launcher
            base.AddEntry(0x3000, ReplyRequestUpdate);
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
            var acc = packet.ReadAscii();
            var pwd = packet.ReadAscii();
            //TODO: Version 
            string[] result = SQL.CheckLogin(acc, pwd, ((ServerClientData)data).UserIP);

            bool.TryParse(result[0], out bool success);
            if (success)
                data.m_security.Send(Handler.S_UPDATE.SendServerVersion());

            return PacketHandlerResult.Block;
        }


        private PacketHandlerResult ReplyRequestUpdate(ServerData data, Packet packet)
        {
            var latestClientVersion = packet.ReadInt();

            Handler.S_UPDATE.SendFiles(data, latestClientVersion);

            return PacketHandlerResult.Block;
        }
    }
}
