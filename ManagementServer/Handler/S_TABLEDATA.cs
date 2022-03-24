using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Linq;

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

        internal static PacketHandlerResult SendTableData(Utility.ServerClientData arg1, Packet arg2)
        {
            try
            {
                var tableNameArray = Utility.SQL.GetRequiredTableNames(arg1.SecurityGroup.ToString());

                var tableCount = arg2.ReadByte();
                string[] array = new string[tableCount];
                for (int i = 0; i < tableCount; i++)
                {
                    var tName = arg2.ReadAscii();
                    if (tableNameArray.Contains(tName))
                    {
                        array[i] = tName;
                    }
                }
                arg1.m_security.Send(DataTablePackets(array));
                
            }
            catch
            { }
           // System.GC.Collect(2);
            return PacketHandlerResult.Block;
        }

        internal static Packet[] DataTablePackets(string[] tableNames)
        {
            var list = new Packet[tableNames.Length];
            try
            {
                for (int i = 0; i < tableNames.Length; i++)
                {
                    var tableName = tableNames[i];

                    var tablePacket = new Packet(PacketID.Server.DataTableSend, false, true);
                    tablePacket.WriteAscii(tableName);
                    tablePacket.WriteDataTable(Utility.SQL.GetRequestedDataTable(tableName));

                    list[i] = tablePacket;
                }
            }
            catch
            { }

            return list;
        }
    }
}