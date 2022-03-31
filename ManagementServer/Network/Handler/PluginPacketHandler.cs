using ServerFrameworkRes.Network.Security;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {

        internal PacketHandlerResult AllowedPlugins(ServerData arg1, Packet arg2)
        {
            arg1.m_security.Send(PacketConstructors.LoginPacket.AllowedPluginNames(((ServerClientData)arg1).SecurityGroup));
            return PacketHandlerResult.Block;
        }
    }
}