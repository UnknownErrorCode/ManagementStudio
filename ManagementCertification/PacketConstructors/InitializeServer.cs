using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System.Data;

namespace ManagementCertification.PacketConstructors
{
    internal class InitializeServer
    {
        #region Methods

        /// <summary>
        /// Sends <see cref="PacketID.Server.AllowedDataTableNameResponse"/> with all required <see cref="DataTable"/> names as string array to the Client.
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet Send_ToolPluginDataAccess(byte securityGroup)
        {
            try
            {
                var _ToolPluginDataAccess = Utility.SQL.GetPluginDataAccess();
                Packet tableNames = new Packet((ushort)PacketID.CertificationServer.LIZENCE_ToolPluginDataAccess);
                tableNames.WriteAscii("_ToolPluginDataAccess");
                tableNames.WriteDataTable(_ToolPluginDataAccess);
                return tableNames;
            }
            catch (System.Exception ex)
            {
                return NotificationPacket.NotifyPacket(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
        }



        private static Packet SendDataTable(string tableName, DataTable table)
        {
            Packet tablePacket = new Packet(PacketID.Server.DataTableResponse, false, true);
            tablePacket.WriteAscii(tableName);
            tablePacket.WriteDataTable(table);
            return tablePacket;
        }

        internal static Packet Status(LoginStatus status)
        {
            Packet LoginStatus = new Packet(PacketID.CertificationServer.LIZENCERESPONSE, false, true);
            LoginStatus.WriteStruct(status);
            return LoginStatus;
        }


        internal static Packet PluginSecuritySetup => SendDataTable("_ToolPluginDataAccess", Utility.SQL.GetPluginDataAccess());


        #endregion Methods
    }
}