using ManagementFramework.Network.Security;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler : PacketHandler
    {
        #region Constructors

        public ServerPacketHandler()
        {
            base.AddEntry(0x2001, Reply0x2001);
            // client
            base.AddEntry(PacketID.Client.RequestDataTable, ResponseSecurityGroupDataTables);
            base.AddEntry(PacketID.Client.RequestPlugiDataTable, ResponsePluginDataTables);

            base.AddEntry(PacketID.Client.RequestAllowedPlugins, AllowedPlugins);
            base.AddEntry(PacketID.Client.Login, TryLogin);
            base.AddEntry(PacketID.Client.TopicLoadRequest, LoadTopics);
            base.AddEntry(PacketID.Client.TopicAddRequest, AddNewTopic);
            base.AddEntry(PacketID.Client.TopicEditRequest, Reply0x1003EditNewTopic);
            base.AddEntry(PacketID.Client.TopicDeleteRequest, DeleteTopic);

            //base.AddEntry(0x1010, Reply0x1010ShopItemPriceUpdate);

            // launcher
            base.AddEntry(0x3000, SendFiles);
        }

        #endregion Constructors

        #region Methods

        private PacketHandlerResult Reply0x1003EditNewTopic(ServerData arg1, Packet arg2) => PacketHandlerResult.Block;

        /// <summary>
        /// Server receives handshake process packet and verifiels that user is using the originale Tool, no bot or other stuff...
        /// </summary>
        /// TODO: rewrite logics..
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0x2001(ServerData data, Packet packet)
        {
            var identity = packet.ReadAscii();
            byte flag = packet.ReadByte();
            if (identity == "Tool_Launcher" && flag == 1)
            {
                data.m_security.Send(PacketConstructors.LoginPacket.ServerVersion);
                return PacketHandlerResult.Response;
            }

            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}