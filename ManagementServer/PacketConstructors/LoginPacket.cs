using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System.Data;

namespace ManagementServer.PacketConstructors
{
    class LoginPacket
    {

        internal static Packet Status(LoginStatus status)
        {
            var LoginStatus = new Packet(PacketID.Server.LoginStatus, false, true);
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
                var PluginDataRowCollection = Utility.SQL.AllowedPlugins(securityGroup).Rows;

                Packet AllowedPlugins = new Packet(0xB000);
                AllowedPlugins.WriteInt(PluginDataRowCollection.Count);

                foreach (System.Data.DataRow row in PluginDataRowCollection)
                    AllowedPlugins.WriteAscii(row.Field<string>("AllowedPlugins"));

                return AllowedPlugins;
            }
            catch (System.Exception ex)
            {
                return PacketConstructors.NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
        }


        /// <summary>
        /// Sends 0xB001 with all required DataTable names as string array to Client
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet AllowedDataTables(byte securityGroup)
        {
            try
            {
                //var tableNameArray =  Utility.SQL.GetRequiredTableNames(securityGroup);
                using (Packet tableNames = new Packet(0xB001))
                {
                    tableNames.WriteAsciiArray(PluginSecurityManager.GetRequiredTables(securityGroup));
                    return tableNames;
                }
            }
            catch (System.Exception ex)
            {
                return NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
        }
    }
}
