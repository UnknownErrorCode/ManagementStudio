using ServerFrameworkRes.Network.Security;

namespace StudioServer.Handler.PacketHandler.Login
{
    internal class REQUEST_CURRENT_VERSION
    {
        #region Public Methods

        public static Packet VersionSame(Packet packet, SecurityManager incomeSocketData)
        {
            int version = packet.ReadInt();
            if (version != StudioServer.settings.Version)//not CurrentVersion
            {
                packet = new Packet(0xD011);
                packet.WriteInt(StudioServer.settings.Version);
                packet.WriteAscii($"Your version '{version}' is incompatible,please launch vSroStudioLauncher to get the newest version: {StudioServer.settings.Version}");
                return packet;
            }
            else
            {
                packet = new Packet(0xD011);
                packet.WriteInt(version);
                packet.WriteAscii($"Successfully load vSroStudio v.{version}");
                return packet;
            }
        }

        #endregion Public Methods
    }
}