using ManagementServer.Utility;
using ServerFrameworkRes.Network.Security;

namespace ManagementServer.Network
{
    class ServerPacketHandler : PacketHandler
    {

        public ServerPacketHandler()
        {
            base.AddEntry(0x2001,Handle0x2001);
            base.AddEntry(0x1000, Handle0x1000);
        }



        private PacketHandlerResult Handle0x2001(ServerData data, Packet packet)
        {
            var identity = packet.ReadAscii();
            var flag = packet.ReadByte();

            if (identity == "Tool_Client" && flag == 1)
            {
                Packet loginDataRequestPacket = new Packet(0xA000);
                loginDataRequestPacket.WriteAscii("RequestAuthentification");
                data.m_security.Send(loginDataRequestPacket);
                return PacketHandlerResult.Response;
            }
            else
                return PacketHandlerResult.Block;
        }

        private PacketHandlerResult Handle0x1000( ServerData data, Packet packet) 
        {
            var acc = packet.ReadAscii();
            var pwd = packet.ReadAscii();
            //TODO: Version 

            string[] result = SQL.CheckLogin(acc, pwd, ((ServerClientData)data).UserIP);

            bool.TryParse(result[0], out bool success);
            if (success)
            {
                //Send all online user list to Client and open Form for Client
            }
            return PacketHandlerResult.Block;
        }
    }
}
