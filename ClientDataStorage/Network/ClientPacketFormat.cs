using ServerFrameworkRes.Network.Security;
using System;

namespace PluginFramework.Network
{
    public static class ClientPacketFormat
    {
        #region Methods

        public static Packet RequestPluginDataTables(string plugin, ushort packetID)
        {
            Packet packet = new Packet(PacketID.Client.RequestPlugiDataTable);
            packet.WriteAscii(plugin);
            packet.WriteUShort(packetID);
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

        #endregion Methods
    }
}