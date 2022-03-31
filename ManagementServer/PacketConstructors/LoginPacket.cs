using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System.Data;

namespace ManagementServer.PacketConstructors
{
    internal class LoginPacket
    {
        #region Methods

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
                return NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
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
                return NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
        }

        internal static Packet[] DataTablePackets(string[] tableNames)
        {
            Packet[] list = new Packet[tableNames.Length];
            try
            {
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if (tableNames[i] == null)
                        continue;

                    string tableName = tableNames[i];
                    var table = Utility.SQL.GetRequestedDataTable(tableName);

                    list[i] = SendDataTable(tableName, table);
                }
            }
            catch
            { }

            return list;
        }

        internal static Packet OnlineUser()
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

        internal static Packet PluginDataReceiveConfirmation(PluginData pluginData)
        {
            Packet tablePacket = new Packet((ushort)pluginData);
            tablePacket.WriteAscii(pluginData.ToString());
            return tablePacket;
        }

        internal static Packet SendDataTable(string tableName, DataTable table)
        {
            Packet tablePacket = new Packet(PacketID.Server.DataTableResponse, false, true);
            tablePacket.WriteAscii(tableName);
            tablePacket.WriteDataTable(table);
            return tablePacket;
        }

        internal static Packet Status(LoginStatus status)
        {
            Packet LoginStatus = new Packet(PacketID.Server.LoginStatusResponse, false, true);
            LoginStatus.WriteStruct(status);
            return LoginStatus;
        }

        #endregion Methods
    }
}