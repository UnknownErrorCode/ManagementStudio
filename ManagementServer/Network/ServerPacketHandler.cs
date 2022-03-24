using ManagementServer.Utility;
using ServerFrameworkRes.Network.Security;
using System.Data;

namespace ManagementServer.Network
{
    partial class ServerPacketHandler : PacketHandler 
    {

        public ServerPacketHandler()
        {
            base.AddEntry(0x2001, Reply0x2001);
            // client
            base.AddEntry(PacketID.Client.RequestDataTable, Reply0x0999DataTableRequest);
            base.AddEntry(PacketID.Client.Login, Reply0x1000LoginRequest);
            base.AddEntry(PacketID.Client.TopicsRequest, Reply0x1001RequestAllTopics);
            base.AddEntry(PacketID.Client.TopicAddRequest, Reply0x1002AddNewTopic);
            base.AddEntry(PacketID.Client.TopicDeleteRequest, Reply0x1004DeleteTopic);

            base.AddEntry(0x1010, Reply0x1010ShopItemPriceUpdate);


            // launcher
            base.AddEntry(0x3000, Reply0x3000RequestUpdate);

        }

        

        private PacketHandlerResult Reply0x0999DataTableRequest(ServerData arg1, Packet arg2)
          => Handler.S_TABLEDATA.SendTableData((ServerClientData)arg1, arg2);

        private PacketHandlerResult Reply0x1001RequestAllTopics(ServerData arg1, Packet arg2)
            => LoadTopics(arg1, arg2);

        private PacketHandlerResult Reply0x1002AddNewTopic(ServerData arg1, Packet arg2)
         => TryAddNewTopic(arg1, arg2);

        private PacketHandlerResult Reply0x1004DeleteTopic(ServerData arg1, Packet arg2)
         => DeleteTopic(arg1, arg2);

        private PacketHandlerResult Reply0x1010ShopItemPriceUpdate(ServerData arg1, Packet arg2)
            => ShopDataPricePolicyOfItem(arg1, arg2);


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
        private PacketHandlerResult Reply0x1000LoginRequest(ServerData data, Packet packet)
        => Handler.S_LOGIN.TryLogin(data, packet);


        /// <summary>
        /// CLIENT_SERVER -- Client sends this packet if the version does not match the current version.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0x3000RequestUpdate(ServerData data, Packet packet)
          => Handler.S_UPDATE.SendFiles(data, packet.ReadInt());

    }
}
