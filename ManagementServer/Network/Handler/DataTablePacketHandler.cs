using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System.Linq;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        #region Internal Methods



        /// <summary>
        /// Sends all certificated DataTables to the Client.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal static PacketHandlerResult ResponseSecurityGroupDataTables(ServerData arg1, Packet arg2)
        {

            try
            {
                string[] tableNameArray = PluginSecurityManager.GetSecurityDataTableNames(((ServerClientData)arg1).SecurityGroup);

                string[] array = arg2.ReadAsciiArray();

                arg1.m_security.Send(PacketConstructors.LoginPacket.DataTablePackets(array.Where(tableName => tableNameArray.Contains(tableName)).ToArray()));
            }
            catch (System.Exception)
            { }
            return PacketHandlerResult.Block;
        }

        internal static PacketHandlerResult ResponsePluginDataTables(ServerData arg1, Packet arg2)
        {
            try
            {
                var clientData = (ServerClientData)arg1;
                var pluginName = arg2.ReadAscii();
                PluginData pluginData = (PluginData)arg2.ReadUShort();

                if (!PluginSecurityManager.IsAllowed(pluginName, clientData.SecurityGroup))
                {
                    return PacketHandlerResult.Block;
                }

                string[] tableNameArray = PluginSecurityManager.GetPluginDataTableNames(pluginName);// Utility.SQL.GetRequiredTableNames(arg1.SecurityGroup);

                if (tableNameArray == null || tableNameArray?.Length == 0)
                    return PacketHandlerResult.Block;

                arg1.m_security.Send(PacketConstructors.LoginPacket.DataTablePackets(tableNameArray));
                arg1.m_security.Send(PacketConstructors.LoginPacket.PluginDataReceiveConfirmation(pluginData));
            }
            catch (System.Exception)
            { }
            // System.GC.Collect(2);
            return PacketHandlerResult.Block;
        }

        #endregion Internal Methods
    }
}
