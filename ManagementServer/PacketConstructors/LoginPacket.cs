using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System;
using System.Data;

namespace ManagementServer.PacketConstructors
{
    class LoginPacket
    {


        internal static Packet Status(LoginStatus status)
        {
            Packet LoginStatus = new Packet(PacketID.Server.LoginStatus, false, true);
            LoginStatus.WriteStruct(status);
            return LoginStatus;
        }


        /// <summary>
        /// Sends 0xB000 with all Plugins to load to the Client in order to warrant security group authority
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet SendAllowedPlugins(byte securityGroup)
        {
            try
            {
                var pluginNames = PluginSecurityManager.GetSecurityPluginNames(securityGroup);
                Packet packet = new Packet(0xB000);
                packet.WriteAsciiArray(pluginNames);
                return packet;
            }
            catch (System.Exception ex)
            {
                return PacketConstructors.NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
        }

        internal static Packet PluginDataReceiveConfirmation(string pluginName)
        {
            var tablePacket = new Packet(PacketID.Server.PluginDataSent);
            tablePacket.WriteAscii(pluginName);
            return tablePacket;
        }

        internal static Packet SendDataTable(string tableName, DataTable table)
        {
            var tablePacket = new Packet(PacketID.Server.DataTableSend, false, true);
            tablePacket.WriteAscii(tableName);
            tablePacket.WriteDataTable(table);
            return tablePacket;

        }


        /// <summary>
        /// Sends 0xB001 with all required DataTable names as string array to Client
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet AllowedDataTableNames(byte securityGroup)
        {
            try
            {
                Packet tableNames = new Packet(PacketID.Server.DataTableNames);
                tableNames.WriteAsciiArray(PluginSecurityManager.GetSecurityDataTableNames(securityGroup));
                return tableNames;
            }
            catch (System.Exception ex)
            {
                return NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
        }
    }
}
