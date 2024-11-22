﻿using ManagementFramework.Network.Security;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        #region Methods

        internal PacketHandlerResult AllowedPlugins(ServerData arg1, Packet arg2)
        {
            arg1.m_security.Send(PacketConstructors.LoginPacket.AllowedPluginNames(((ServerClientData)arg1).SecurityGroup));
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}