using ManagementFramework.Network.Security;
using Structs.Tool;
using System.Data;

namespace ManagementServer.PacketConstructors
{
    internal class DataTablePacket
    {


        internal static Packet[] GetAllTables(string[] tableNames)
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
    }
}
