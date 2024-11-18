using ManagementFramework.Network.Security;
using Structs.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerEditor.PacketFormat
{
    internal static class TriggerEditorPacket
    {
        internal static Packet UpdateRefTrigger(RefTrigger obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTrigger);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefTriggerAction(RefTriggerAction obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerAction);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefTriggerCondition(RefTriggerCondition obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerCondition);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefTriggerEvent(RefTriggerEvent obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerEvent);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefTriggerCategory(RefTriggerCategory obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerCategory);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefTriggerActionParam(RefTriggerActionParam obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerActionParam);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefTriggerConditionParam(RefTriggerConditionParam obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerConditionParam);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefGameWorld(RefGame_World obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefGameWorld);
            packet.WriteStruct(obj);
            return packet;
        }

        internal static Packet UpdateRefGameWorldBindTriggerCategory(RefGameWorldBindTriggerCategory obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefGameWorldBindTriggerCategory);
            packet.WriteStruct(obj);
            return packet;
        }
    }
}
