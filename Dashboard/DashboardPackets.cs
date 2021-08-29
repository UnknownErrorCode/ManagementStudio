using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class DashboardPackets
    {

        internal static Packet AddTopicToDashboard(DashboardMessage.DashboardMessageStruct msg)
        {
            Packet packet = new Packet(0x1001);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);
            packet.WriteAscii(msg.Text);
            packet.WriteDateTime(msg.Created);
            packet.WriteDateTime(msg.Edited);

            return packet;
        }
    }
}
