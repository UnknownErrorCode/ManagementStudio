using ManagementFramework.Network.Security;

namespace ManagementServer.PacketConstructors
{
    internal static class NotificationPacket
    {
        #region Methods

        /// <summary>
        /// Constructs a notification packet with a log level and message.
        /// </summary>
        /// <param name="type">Log level of the notification.</param>
        /// <param name="message">Message to include in the notification.</param>
        /// <returns>A constructed notification packet.</returns>
        internal static Packet NotifyPacket(ManagementFramework.Ressources.LogLevel type, string message)
        {
            Packet packet = new Packet(PacketID.Server.LogNotification);
            packet.WriteByte((byte)type);
            packet.WriteAscii(message);
            return packet;
        }

        /// <summary>
        /// Constructs a notification packet for an exception with an optional custom message.
        /// </summary>
        /// <param name="ex">The exception to include in the notification.</param>
        /// <param name="message">Custom message to include with the exception details.</param>
        /// <returns>A constructed notification packet.</returns>
        internal static Packet NotifyPacket(System.Exception ex, string message)
        {
            Packet packet = new Packet(PacketID.Server.LogNotification);
            packet.WriteByte((byte)ManagementFramework.Ressources.LogLevel.fatal);
            packet.WriteAscii(message);
            return packet;
        }


        /// <summary>
        /// Constructs a simple notification packet with a default "info" log level.
        /// </summary>
        /// <param name="message">Message to include in the notification.</param>
        /// <returns>A constructed notification packet.</returns>
        internal static Packet NotifyPacket(string message)
        {
            return NotifyPacket(ManagementFramework.Ressources.LogLevel.notify, message);
        }

        #endregion Methods
    }
}