using ManagementFramework.Network.Security;

namespace ManagementServer.PacketConstructors
{
    internal class LizencePacket
    {
        internal static Packet RequestLizence => GetOwnLizence();

        /// <summary>
        /// <see cref="Packet"/> that contains all information to confirm the lizence..
        /// TODO: just fix the shit nigga...
        /// </summary>
        /// <returns></returns>
        private static Packet GetOwnLizence()
        {
            Packet pack = new Packet(PacketID.CertificationClient.LIZENCEREQUEST);
            pack.WriteAscii(ServerManager.settings.LizenceUser);
            pack.WriteAscii(ManagementFramework.Utility.MD5Generator.MD5String(ServerManager.settings.LizencePassword));
            return pack;
        }
    }
}