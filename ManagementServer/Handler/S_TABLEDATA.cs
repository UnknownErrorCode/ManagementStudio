using ServerFrameworkRes.Network.Security;
using System.Data;

namespace ManagementServer.Handler
{
    internal class S_TABLEDATA
    {
        /// <summary>
        /// Sends 0xB001 with all required DataTable names as string array to Client
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet GetDataTables(string securityGroup)
        {
            var tableNameArray = Utility.SQL.GetRequiredTableNames(securityGroup);

            Packet tableNames = new Packet(0xB001);
            tableNames.WriteInt(tableNameArray.Length);

            for (int i = 0; i < tableNameArray.Length; i++)
                tableNames.WriteAscii(tableNameArray[i]);

            return tableNames;
        }

        internal static PacketHandlerResult SendTableData(ServerData arg1, Packet arg2)
        {
            var tableName = arg2.ReadAscii();
            DataTable table = Utility.SQL.GetRequestedDataTable(tableName);
            Packet tablePacket = new Packet(0xB002, false, true);
            tablePacket.WriteAscii(tableName);
            tablePacket.WriteDataTable(table);

            arg1.m_security.Send(tablePacket);
            return PacketHandlerResult.Block;
        }
    }
}