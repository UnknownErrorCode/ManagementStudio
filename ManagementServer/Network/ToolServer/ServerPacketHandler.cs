using ManagementFramework.Network.Security;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler : PacketHandler
    {
        #region Constructors

        public ServerPacketHandler()
        {
            base.AddEntry(0x2001, Reply0x2001);
            // client
            base.AddEntry(PacketID.Client.RequestDataTable, ResponseSecurityGroupDataTables);
            base.AddEntry(PacketID.Client.RequestPlugiDataTable, ResponsePluginDataTables);

            base.AddEntry(PacketID.Client.RequestAllowedPlugins, AllowedPlugins);
            base.AddEntry(PacketID.Client.Login, TryLogin);
            base.AddEntry(PacketID.Client.TopicLoadRequest, LoadTopics);
            base.AddEntry(PacketID.Client.TopicAddRequest, AddNewTopic);
            base.AddEntry(PacketID.Client.TopicEditRequest, Reply0x1003EditNewTopic);
            base.AddEntry(PacketID.Client.TopicDeleteRequest, DeleteTopic);

            // Trigger Editor - Update Entries
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefTrigger, EditRefTrigger);
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefTriggerAction, EditRefTriggerAction);
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefTriggerCondition, EditRefTriggerCondition);
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefTriggerEvent, EditRefTriggerEvent);
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefTriggerCategory, EditRefTriggerCategory);
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefTriggerActionParam, EditRefTriggerActionParam);
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefTriggerConditionParam, EditRefTriggerConditionParam);
            base.AddEntry(PacketID.Client.TriggerEditor_Update_RefGameWorld, EditRefGameWorld);

            // Trigger Editor - Add Entries
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefTrigger, AddRefTrigger);
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefTriggerAction, AddRefTriggerAction);
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefTriggerCondition, AddRefTriggerCondition);
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefTriggerEvent, AddRefTriggerEvent);
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefTriggerCategory, AddRefTriggerCategory);
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefTriggerActionParam, AddRefTriggerActionParam);
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefTriggerConditionParam, AddRefTriggerConditionParam);
            base.AddEntry(PacketID.Client.TriggerEditor_Add_RefGameWorld, AddRefGameWorld);

            // Trigger Editor - Link Entries
            // base.AddEntry(PacketID.Client.TriggerEditor_Link_RefTriggerToCategory, LinkRefTriggerToCategory);
            // base.AddEntry(PacketID.Client.TriggerEditor_Link_RefTriggerAction, LinkRefTriggerAction);
            // base.AddEntry(PacketID.Client.TriggerEditor_Link_RefTriggerCondition, LinkRefTriggerCondition);
            // base.AddEntry(PacketID.Client.TriggerEditor_Link_RefTriggerEvent, LinkRefTriggerEvent);
            // base.AddEntry(PacketID.Client.TriggerEditor_Link_RefTriggerCategoryToGameWorld, LinkRefTriggerCategoryToGameWorld);
            // base.AddEntry(PacketID.Client.TriggerEditor_Link_RefTriggerActionParam, LinkRefTriggerActionParam);
            // base.AddEntry(PacketID.Client.TriggerEditor_Link_RefTriggerConditionParam, LinkRefTriggerConditionParam);

            // launcher
            base.AddEntry(0x3000, SendFiles);
        }

        #endregion Constructors

        #region Methods

        private PacketHandlerResult Reply0x1003EditNewTopic(ServerData arg1, Packet arg2) => PacketHandlerResult.Block;

        /// <summary>
        /// Server receives handshake process packet and verifiels that user is using the originale Tool, no bot or other stuff...
        /// </summary>
        /// TODO: rewrite logics..
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0x2001(ServerData data, Packet packet)
        {
            var identity = packet.ReadAscii();
            byte flag = packet.ReadByte();
            if (identity == "Tool_Launcher" && flag == 1)
            {
                data.m_security.Send(PacketConstructors.LoginPacket.ServerVersion);
                return PacketHandlerResult.Response;
            }

            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}