using ManagementFramework.Network.Security;
using ManagementServer.PacketConstructors;
using ManagementServer.Utility;
using Structs.Database;
using System;
using static ManagementServer.Utility.SQL;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        private PacketHandlerResult HandleUpdatePacket<T>(
     ServerData serverData,
     Packet packet,
     Func<string, T, SaveResult> saveFunction,
     ushort responsePacketId,
     string structName) where T : struct
        {
            try
            {
                // Deserialize the structure from the packet
                T data = packet.ReadStruct<T>();

                // Call the save function
                SaveResult result = saveFunction(serverData.AccountName, data);

                if (result.Success)
                {

                    ServerManager.Logger.WriteLogLine(
                            ManagementFramework.Ressources.LogLevel.success,
                            $"Account: {serverData.AccountName} - {structName} updated successfully. Status: {result.Status}, Message: {result.Message}");
                    // Notify the client of a successful update
                    ServerMemory.BroadcastPacket2(NotificationPacket.NotifyPacket(
                        ManagementFramework.Ressources.LogLevel.success,
                        $"Account: {serverData.AccountName} updated {structName} successfully. Status: {result.Status}, Message: {result.Message}"));

                    // Send response packet back to the client
                    //var responsePacket = new Packet(responsePacketId);
                    serverData.m_security.Send(new Packet(responsePacketId));
                    return PacketHandlerResult.Response;
                }
                else
                {
                    // Notify the client of a failure
                    serverData.m_security.Send(NotificationPacket.NotifyPacket(
                        ManagementFramework.Ressources.LogLevel.warning,
                        $"Account: {serverData.AccountName} Failed to update {structName}. Status: {result.Status}, Message: {result.Message}"));

                    ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.sql,
                        $"Account: {serverData.AccountName} Failed to update {structName}. Status: {result.Status}, Message: {result.Message}");



                    return PacketHandlerResult.Block;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                serverData.m_security.Send(NotificationPacket.NotifyPacket(
                    ManagementFramework.Ressources.LogLevel.fatal,
                    $"Account: {serverData.AccountName} Error processing {structName} update: {ex.Message}"));

                return PacketHandlerResult.Block;
            }
        }


        internal PacketHandlerResult EditRefTrigger(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTrigger>(
       serverData,
       packet,
       SQL.SaveRefTrigger, // Updated save function
       PacketID.Client.TriggerEditor_Update_RefTrigger, // Response packet ID
       "RefTrigger" // Struct name for logging
            );
        }



        internal PacketHandlerResult EditRefTriggerAction(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerAction>(
       serverData,
       packet,
       SQL.SaveRefTriggerAction, // Updated save function
       PacketID.Client.TriggerEditor_Update_RefTriggerAction, // Response packet ID
       "RefTriggerAction" // Struct name for logging
            );
        }

        internal PacketHandlerResult EditRefTriggerCondition(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerCondition>(
                serverData,
                packet,
                SQL.SaveRefTriggerCondition,
                PacketID.Client.TriggerEditor_Update_RefTriggerCondition,
                "RefTriggerCondition"
            );
        }

        internal PacketHandlerResult EditRefTriggerEvent(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerEvent>(
                serverData,
                packet,
                SQL.SaveRefTriggerEvent,
                PacketID.Client.TriggerEditor_Update_RefTriggerEvent,
                "RefTriggerEvent"
            );
        }

        internal PacketHandlerResult EditRefTriggerCategory(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerCategory>(
                serverData,
                packet,
                SQL.SaveRefTriggerCategory,
                PacketID.Client.TriggerEditor_Update_RefTriggerCategory,
                "RefTriggerCategory"
            );
        }
        internal PacketHandlerResult EditRefTriggerActionParam(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerActionParam>(
                serverData,
                packet,
                SQL.SaveRefTriggerActionParam,
                PacketID.Client.TriggerEditor_Update_RefTriggerActionParam,
                "RefTriggerActionParam"
            );
        }

        internal PacketHandlerResult EditRefTriggerConditionParam(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerConditionParam>(
                serverData,
                packet,
                SQL.SaveRefTriggerConditionParam,
                PacketID.Client.TriggerEditor_Update_RefTriggerConditionParam,
                "RefTriggerConditionParam"
            );
        }



    }
}
