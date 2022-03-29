using ServerFrameworkRes.Network.Security;

namespace ManagementServer.PacketConstructors
{
    internal static class NotificationPacket
    {
        #region Internal Methods

        internal static Packet NotifyPacket(ServerFrameworkRes.Ressources.LogLevel type, string message)
        {
            Packet packet = new Packet(PacketID.Server.LogNotification);
            packet.WriteByte((byte)type);
            packet.WriteAscii(message);
            return packet;
        }

        #endregion Internal Methods
    }
}