using ManagementFramework.Network.Security;

namespace ManagementCertification.PacketConstructors
{
    internal static class NotificationPacket
    {
        #region Methods

        internal static Packet NotifyPacket(ManagementFramework.Ressources.LogLevel type, string message)
        {
            Packet packet = new Packet(PacketID.Server.LogNotification);
            packet.WriteByte((byte)type);
            packet.WriteAscii(message);
            return packet;
        }

        #endregion Methods
    }
}