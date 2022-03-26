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
         // LoginStatus.WriteBool(success);
         // LoginStatus.WriteAscii(notify);
         // LoginStatus.WriteAscii(securityGroup);
         // LoginStatus.WriteAscii(accName);
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
                var tableNameArray = PluginSecurityManager.GetRequiredTables(securityGroup);// Utility.SQL.GetRequiredTableNames(securityGroup);

                Packet tableNames = new Packet(0xB001);
               // tableNames.WriteInt(tableNameArray.Length);
                tableNames.WriteAsciiArray(tableNameArray);

               // for (int i = 0; i < tableNameArray.Length; i++)
               //     tableNames.WriteAscii(tableNameArray[i]);

                return tableNames;
            }
            catch (System.Exception ex)
            {
                return PacketConstructors.NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
        }
    }
}
