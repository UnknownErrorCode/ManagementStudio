using ServerFrameworkRes.Network.Security;
using System.Linq;

namespace ManagementServer.Handler
{
    internal class S_TABLEDATA
    {
        

        internal static PacketHandlerResult ResponseAllowedTables(Utility.ServerClientData arg1, ServerFrameworkRes.Network.Security.Packet arg2)
        {
            try
            {
                var tableNameArray = Utility.SQL.GetRequiredTableNames(arg1.SecurityGroup);

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
            catch (System.Exception )
            { }
           // System.GC.Collect(2);
            return PacketHandlerResult.Block;
        }

        internal static ServerFrameworkRes.Network.Security.Packet[] DataTablePackets(string[] tableNames)
        {
            var list = new Packet[tableNames.Length];
            try
            {
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if (tableNames[i] == null)
                        continue;
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