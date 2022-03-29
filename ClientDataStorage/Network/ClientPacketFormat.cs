using ServerFrameworkRes.Network.Security;
using System;

namespace ClientDataStorage.Network
{
    public static class ClientPacketFormat
    {
        public static Packet RequestPluginDataTables(string plugin)
        {
            var packet = new Packet(PacketID.Client.RequestPlugiDataTable);
            packet.WriteAscii(plugin);
            return packet;
        }

        private static Packet RequestDataTable(string[] tables)
        {
            Packet packet = new Packet(PacketID.Client.RequestDataTable, false, true);
            try
            {
                packet.WriteAsciiArray(tables);
                return packet;
            }
            catch (Exception)
            {
                return packet;
            }
        }
    }
}