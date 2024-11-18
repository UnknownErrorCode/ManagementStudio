using ManagementFramework.Network.Security;
using Structs.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor
{
    internal static class SpawnEditorPacket
    {
        internal static Packet UpdateTabRefNest(TabRefNest obj)
        {
            var packet = new Packet(PacketID.Client.WMSE_Update_Tab_RefNest);
            packet.WriteStruct(obj);

            return packet;
        }

        internal static Packet UpdateTabRefHive(Tab_RefHive obj)
        {
            var packet = new Packet(PacketID.Client.WMSE_Update_Tab_RefHive);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateTabRefTactics(Tab_RefTactics obj)
        {
            var packet = new Packet(PacketID.Client.WMSE_Update_Tab_RefTactics);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefObjCommon(RefObjCommon obj)
        {
            var packet = new Packet(PacketID.Client.WMSE_Update_RefObjCommon);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefObjChar(RefObjChar obj)
        {
            var packet = new Packet(PacketID.Client.WMSE_Update_RefObjChar);
            packet.WriteStruct(obj);
            return packet;
        }
    }
}