using ManagementFramework.Network.Security;
using Structs.Dashboard;

namespace Dashboard
{
    public static class DashboardPackets
    {
        #region Properties

        /// <summary>
        /// 0x1001 -- requests all topics from Server
        /// </summary>
        public static Packet RequestAllTopics => new Packet(PacketID.Client.TopicLoadRequest);

        /// <summary>
        /// Requests the list of online user.
        /// </summary>
        public static Packet RequestOnlineUser => new Packet(PacketID.Client.RequestOnlineUser);

        #endregion Properties

        #region Methods

        /// <summary>
        /// 0x1002 -- returns Packet with DashboardMessage inside to broadcast to all clients
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal static Packet RequestAddTopicToDashboard(DashboardMessage msg)
        {
            Packet packet = new Packet(PacketID.Client.TopicAddRequest);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);
            packet.WriteAscii(msg.Text);

            return packet;
        }

        /// <summary>
        /// Sent a request to delete a topic to the server
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal static Packet RequestDeleteTopicFromDashboard(DashboardMessage msg)
        {
            Packet packet = new Packet(PacketID.Client.TopicDeleteRequest);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);
            return packet;
        }

        #endregion Methods
    }
}