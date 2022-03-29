using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;

namespace ManagementServer.PacketConstructors
{
    internal class TopicPacket
    {
        #region Internal Methods

        internal static Packet AddNew(DashboardMessage msg)
        {
            Packet newTopic = new Packet(PacketID.Server.TopicAddNewResponse);
            newTopic.WriteStruct<DashboardMessage>(msg);
            return newTopic;
        }

        #endregion Internal Methods
    }
}