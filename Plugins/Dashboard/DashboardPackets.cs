using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;

namespace Dashboard
{
    partial class DashboardControl
    {
        /// <summary>
        /// 0x1001 -- requests all topics from Server
        /// </summary>
        public static Packet RequestAllTopics { get => new Packet(PacketID.Client.TopicsRequest); }

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

        internal static Packet RequestDeleteTopicFromDashboard(DashboardMessage msg)
        {
            Packet packet = new Packet(PacketID.Client.TopicDeleteRequest);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);
            return packet;
        }
    }
}
