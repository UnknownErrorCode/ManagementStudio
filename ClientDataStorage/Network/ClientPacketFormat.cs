using ServerFrameworkRes.Network.Security;
using System;

namespace ClientDataStorage.Network
{
    partial class ClientPacketHandler
    {

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
