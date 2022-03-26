using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;

namespace ManagementServer.PacketConstructors
{
    internal class TopicPacket
    {
        internal static Packet AddNew(DashboardMessage msg)
        {
            var newTopic = new Packet(PacketID.Server.TopicAddNewResponse);
            newTopic.WriteStruct<DashboardMessage>(msg);
            return newTopic;
        }
    }
}