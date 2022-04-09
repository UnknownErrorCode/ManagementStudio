using ManagementFramework.Network.Security;
using Structs.Tool;
using System.Data;

namespace ManagementServer.PacketConstructors
{
    internal class LoginPacket
    {
        /// <summary>
        /// Gets the name and online-status of all users.
        /// </summary>
        internal static Packet OnlineUser => GetOnlineUser();

        /// <summary>
        /// SERVER => CLIENT
        /// <br>0xA001</br>
        /// <br>Sends latest version to client.</br>
        /// </summary>
        /// <returns><see cref="Packet"/> including 1x <see cref="int"/> as latest Server Version</returns>
        internal static Packet ServerVersion => GetServerVersion();

        /// <summary>
        /// Sends <see cref="PacketID.Server.AllowedDataTableNameResponse"/> with all required <see cref="DataTable"/> names as string array to the Client.
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet AllowedDataTableNames(byte securityGroup)
        {
            try
            {
                Packet tableNames = new Packet(PacketID.Server.AllowedDataTableNameResponse);
                tableNames.WriteAsciiArray(PluginSecurityManager.GetSecurityDataTableNames(securityGroup));
                return tableNames;
            }
            catch (System.Exception ex)
            {
                return NotificationPacket.NotifyPacket(ex, "AllowedDataTableNames");
            }
        }

        /// <summary>
        /// Sends 0xB002 with all Plugins to load to the Client in order to warrant security group authority
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet AllowedPluginNames(byte securityGroup)
        {
            try
            {
                string[] pluginNames = PluginSecurityManager.GetSecurityPluginNames(securityGroup);
                Packet packet = new Packet(PacketID.Server.AllowedPluginResponse);
                packet.WriteAsciiArray(pluginNames);
                return packet;
            }
            catch (System.Exception ex)
            {
                return NotificationPacket.NotifyPacket(ManagementFramework.Ressources.LogLevel.fatal, ex.Message);
            }
        }

        /// <summary>
        /// <seealso cref="PacketID.Server.LoginStatusResponse"/> contains a <see cref="LoginStatus"/>.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        internal static Packet Status(LoginStatus status)
        {
            Packet LoginStatus = new Packet(PacketID.Server.LoginStatusResponse, false, true);
            LoginStatus.WriteStruct(status);
            return LoginStatus;
        }

        private static Packet GetOnlineUser()
        {
            var packet = new Packet(PacketID.Server.UserLogOnOff);
            packet.WriteInt(ServerMemory.ClientDataPool.Count);
            foreach (var item in ServerMemory.ClientDataPool.Values)
            {
                packet.WriteBool(true);
                packet.WriteAscii(item.AccountName);
            }
            return packet;
        }

        private static Packet GetServerVersion()
        {
            var packet = new Packet(0xA001);
            packet.WriteInt(Utility.SQL.LatestVersion());
            return packet;
        }
    }
}