using ManagementFramework.Network.Security;

namespace ManagementCertification.Network
{
    internal partial class LizenceServerPacketHandler : PacketHandler
    {
        #region Constructors

        public LizenceServerPacketHandler()
        {
            base.AddEntry(0x2001, Reply0x2001);

            base.AddEntry(PacketID.CertificationClient.LIZENCEREQUEST, LizenceResponse);

            // launcher
            base.AddEntry(0x3000, SendFiles);
        }

        #endregion Constructors

        #region Methods


        /// <summary>
        /// Server receives handshake process packet and verifiels that user is using the originale Tool, no bot or other stuff...
        /// </summary>
        /// TODO: rewrite logics..
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0x2001(ServerData data, Packet packet)
        {
            var identity = packet.ReadAscii();
            byte flag = packet.ReadByte();
            if (identity == "Tool_Server" && flag == 1)
            {
                data.m_security.Send(new Packet(PacketID.CertificationServer.LIZENCEREQUEST));
                return PacketHandlerResult.Response;
            }

            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}