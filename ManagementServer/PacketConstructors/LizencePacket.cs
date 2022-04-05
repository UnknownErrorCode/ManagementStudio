using ServerFrameworkRes.Network.Security;

namespace ManagementServer.PacketConstructors
{
    class LizencePacket
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
            pack.WriteAscii("Rising-Online");
            pack.WriteAscii(ServerFrameworkRes.Utility.MD5Generator.MD5String("anelamela"));
            return pack;
        }
    }
}
