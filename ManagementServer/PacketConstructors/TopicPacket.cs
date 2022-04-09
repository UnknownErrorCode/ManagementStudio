using ManagementFramework.Network.Security;
using Structs.Dashboard;
using System;

namespace ManagementServer.PacketConstructors
{
    internal class TopicPacket
    {
        #region Fields

        internal static Packet FinishedLoading = new Packet(PacketID.Server.TopicsEndLoading);

        #endregion Fields

        #region Methods

        internal static Packet AddNew(DashboardMessage msg)
        {
            Packet newTopic = new Packet(PacketID.Server.TopicAddResponse);
            newTopic.WriteStruct<DashboardMessage>(msg);
            return newTopic;
        }

        internal static Packet Delete(DashboardMessage msg)
        {
            Packet newTopic = new Packet(PacketID.Server.TopicDeleteResponse);
            newTopic.WriteStruct<DashboardMessage>(msg);
            return newTopic;
        }

        [Obsolete]
        internal static Packet Delete(string author, string title, string remover)
        {
            Packet packet = new Packet(PacketID.Server.TopicDeleteResponse);
            packet.WriteAsciiArray(new string[3] { author, title, remover });
            return packet;
        }

        internal static Packet Edit(DashboardMessage msg, DashboardMessage newMsg)
        {
            var packet = new Packet(PacketID.Server.TopicEditResponse);
            packet.WriteStruct<DashboardMessage>(msg);
            packet.WriteStruct<DashboardMessage>(newMsg);
            return packet;
        }

        internal static Packet Load(DashboardMessage msg)
        {
            Packet newTopic = new Packet(PacketID.Server.TopicLoadResponse);
            newTopic.WriteStruct<DashboardMessage>(msg);
            return newTopic;
        }

        #endregion Methods
    }
}