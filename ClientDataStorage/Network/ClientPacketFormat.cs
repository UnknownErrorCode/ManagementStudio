using ServerFrameworkRes.Network.Security;
using System;

namespace ClientDataStorage.Network
{
    partial class ClientPacketHandler
    {

        private Packet RequestPluginDataTables(string plugin)
        {
            var packet = new Packet(PacketID.Client.RequestPlugiDataTable);
            packet.WriteAscii(plugin);
            return packet;
        }

        static bool RequestDataTable(string[] tables, out Packet packet)
        {
            packet = new Packet(PacketID.Client.RequestDataTable, false, true);
            try
            {
                packet.WriteAsciiArray(tables);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
