using ServerFrameworkRes.Network.Security;
using System.Linq;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        #region Methods



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

                arg1.m_security.Send(PacketConstructors.DataTablePacket.GetAllTables(array.Where(tableName => tableNameArray.Contains(tableName)).ToArray()));
            }
            catch (System.Exception ex)
            { ServerManager.Logger.WriteLogLine(ex, "ResponseSecurityGroupDataTables"); }
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}