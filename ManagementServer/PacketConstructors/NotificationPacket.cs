using ServerFrameworkRes.Network.Security;

namespace ManagementServer.PacketConstructors
{
    internal static class NotificationPacket
    {
        #region Methods

        internal static Packet NotifyPacket(ServerFrameworkRes.Ressources.LogLevel type, string message)
        {
            Packet packet = new Packet(PacketID.Server.LogNotification);
            packet.WriteByte((byte)type);
            packet.WriteAscii(message);
            return packet;
        }
        internal static Packet NotifyPacket(System.Exception ex, string message)
        {
            Packet packet = new Packet(PacketID.Server.LogNotification);
            packet.WriteByte((byte)ServerFrameworkRes.Ressources.LogLevel.fatal);
            packet.WriteAscii(message);
            return packet;
        }

        #endregion Methods
    }
}