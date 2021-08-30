using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class DashboardPackets
    {
        /// <summary>
        /// 0x1001 -- requests all topics from Server
        /// </summary>
        public static Packet RequestAllTopics { get => new Packet(0x1001);}

        /// <summary>
        /// 0x1002 -- returns Packet with DashboardMessage inside to broadcast to all clients
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal static Packet AddTopicToDashboard(DashboardMessage msg)
        {
            Packet packet = new Packet(0x1002);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);
            packet.WriteAscii(msg.Text);
            packet.WriteDateTime(msg.Created);

            return packet;
        }

        internal static Packet DeleteTopicFromDashboard(DashboardMessage msg)
        {
            Packet packet = new Packet(0x1004);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);

            return packet;
        }
    }
}
