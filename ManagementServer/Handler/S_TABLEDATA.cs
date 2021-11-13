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
            try
            {
                var tableCount = arg2.ReadByte();
                for (int i = 0; i < tableCount; i++)
                {
                    var tableName = arg2.ReadAscii();
                    Packet tablePacket = new Packet(0xB002, false, true);
                    tablePacket.WriteAscii(tableName);
                    tablePacket.WriteDataTable(Utility.SQL.GetRequestedDataTable(tableName));
                    arg1.m_security.Send(tablePacket);
                }
                // DataTable table = Utility.SQL.GetRequestedDataTable(tableName);
            }
            catch
            { }

            return PacketHandlerResult.Block;
        }
    }
}