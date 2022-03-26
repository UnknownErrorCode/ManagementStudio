using ServerFrameworkRes.Network.Security;

namespace ManagementServer.PacketConstructors
{
    static class NotificationPacket
    {

        internal static Packet NotifyPacket(ServerFrameworkRes.Ressources.LogLevel type, string message)
        {
            var packet = new Packet(PacketID.Server.LogNotification);
            packet.WriteByte((byte)type);
            packet.WriteAscii(message);
            return packet;
        }
    }
}
