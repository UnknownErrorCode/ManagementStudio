using ManagementFramework.Network.Security;
using Structs.Database;

namespace TriggerEditor.PacketFormat
{
    internal static class TriggerEditorPacket
    {
        #region GameWorld Methods

        /// <summary>
        /// Add or update a GameWorld.
        /// </summary>
        internal static Packet UpdateRefGameWorld(RefGame_World obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefGameWorld);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add a new GameWorld.
        /// </summary>
        internal static Packet AddRefGameWorld(RefGame_World obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefGameWorld);
            packet.WriteStruct(obj);
            return packet;
        }

        #endregion GameWorld Methods

        #region TriggerCategory Methods

        /// <summary>
        /// Add or update a TriggerCategory.
        /// </summary>
        internal static Packet UpdateRefTriggerCategory(RefTriggerCategory obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerCategory);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add a new TriggerCategory.
        /// </summary>
        internal static Packet AddRefTriggerCategory(RefTriggerCategory obj, int worldID = -1)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefTriggerCategory);
            packet.WriteStruct(obj);
            packet.WriteInt(worldID);
            return packet;
        }

        /// <summary>
        /// Link a TriggerCategory to a GameWorld.
        /// </summary>
        internal static Packet LinkRefTriggerCategoryToGameWorld(int categoryId, int gameWorldId)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Link_RefTriggerCategoryToGameWorld);
            packet.WriteInt(categoryId);
            packet.WriteInt(gameWorldId);
            return packet;
        }

        #endregion TriggerCategory Methods

        #region Trigger Methods

        /// <summary>
        /// Add or update a Trigger.
        /// </summary>
        internal static Packet UpdateRefTrigger(RefTrigger obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTrigger);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add a new Trigger.
        /// </summary>
        internal static Packet AddRefTrigger(RefTrigger obj, int categoryIDLink = 0)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefTrigger);
            packet.WriteStruct(obj);
            packet.WriteInt(categoryIDLink);
            return packet;
        }

        /// <summary>
        /// Link a Trigger to a TriggerCategory.
        /// </summary>
        internal static Packet LinkRefTriggerToCategory(int triggerId, int categoryId)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Link_RefTriggerToCategory);
            packet.WriteInt(triggerId);
            packet.WriteInt(categoryId);
            return packet;
        }

        #endregion Trigger Methods

        #region Action Methods

        /// <summary>
        /// Add or update an Action.
        /// </summary>
        internal static Packet UpdateRefTriggerAction(RefTriggerAction obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerAction);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add a new Action.
        /// </summary>
        internal static Packet AddRefTriggerAction(RefTriggerAction obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefTriggerAction);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Link an Action to a Trigger.
        /// </summary>
        internal static Packet LinkRefTriggerAction(int actionId, int triggerId)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Link_RefTriggerAction);
            packet.WriteInt(actionId);
            packet.WriteInt(triggerId);
            return packet;
        }

        /// <summary>
        /// Add or update an Action Parameter.
        /// </summary>
        internal static Packet UpdateRefTriggerActionParam(RefTriggerActionParam obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerActionParam);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add new Action Parameters.
        /// </summary>
        internal static Packet AddRefTriggerActionParam(RefTriggerActionParam obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefTriggerActionParam);
            packet.WriteStruct(obj);
            return packet;
        }

        #endregion Action Methods

        #region Event Methods

        /// <summary>
        /// Add or update an Event.
        /// </summary>
        internal static Packet UpdateRefTriggerEvent(RefTriggerEvent obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerEvent);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add a new Event.
        /// </summary>
        internal static Packet AddRefTriggerEvent(RefTriggerEvent obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefTriggerEvent);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Link an Event to a Trigger.
        /// </summary>
        internal static Packet LinkRefTriggerEvent(int eventId, int triggerId)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Link_RefTriggerEvent);
            packet.WriteInt(eventId);
            packet.WriteInt(triggerId);
            return packet;
        }

        #endregion Event Methods

        #region Condition Methods

        /// <summary>
        /// Add or update a Condition.
        /// </summary>
        internal static Packet UpdateRefTriggerCondition(RefTriggerCondition obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerCondition);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add a new Condition.
        /// </summary>
        internal static Packet AddRefTriggerCondition(RefTriggerCondition obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefTriggerCondition);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Link a Condition to a Trigger.
        /// </summary>
        internal static Packet LinkRefTriggerCondition(int conditionId, int triggerId)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Link_RefTriggerCondition);
            packet.WriteInt(conditionId);
            packet.WriteInt(triggerId);
            return packet;
        }

        /// <summary>
        /// Add or update a Condition Parameter.
        /// </summary>
        internal static Packet UpdateRefTriggerConditionParam(RefTriggerConditionParam obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Update_RefTriggerConditionParam);
            packet.WriteStruct(obj);
            return packet;
        }

        /// <summary>
        /// Add new Condition Parameters.
        /// </summary>
        internal static Packet AddRefTriggerConditionParam(RefTriggerConditionParam obj)
        {
            var packet = new Packet(PacketID.Client.TriggerEditor_Add_RefTriggerConditionParam);
            packet.WriteStruct(obj);
            return packet;
        }

        #endregion Condition Methods
    }
}