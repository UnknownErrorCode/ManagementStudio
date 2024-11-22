using ManagementFramework.Network.Security;
using ManagementServer.PacketConstructors;
using ManagementServer.Utility;
using Structs.Database;
using System;
using static ManagementServer.Utility.SQL;

namespace ManagementServer.Network
{
    /// <summary>
    /// Defines the <see cref="ServerPacketHandler" />
    /// </summary>
    internal partial class ServerPacketHandler
    {
        #region Methods

        internal PacketHandlerResult AddRefTrigger(ServerData serverData, Packet packet)
        {
            return HandleAddPacket<RefTrigger>(
                serverData,
                packet,
                SQL.AddRefTrigger, // Specific save function for adding a new trigger
                PacketID.Client.TriggerEditor_Add_RefTrigger, // Use the appropriate PacketID for adding triggers
                "RefTrigger" // Specify the struct name for logging
            );
        }

        internal PacketHandlerResult AddRefTriggerCategory(ServerData serverData, Packet packet)
        {
            return HandleAddPacket<RefTriggerCategory>(
                serverData,
                packet,
                SQL.AddRefTriggerCategory, // Specific save function for adding a new category
                PacketID.Client.TriggerEditor_Add_RefTriggerCategory, // Use the appropriate PacketID for adding categories
                "RefTriggerCategory" // Specify the struct name for logging
            );
        }

        internal PacketHandlerResult AddRefTriggerAction(ServerData serverData, Packet packet)
        {
            return HandleAddPacket<RefTriggerAction>(
                serverData,
                packet,
                SQL.AddRefTriggerAction, // Specific save function for adding a new action
                PacketID.Client.TriggerEditor_Add_RefTriggerAction, // Use the appropriate PacketID for adding actions
                "RefTriggerAction" // Specify the struct name for logging
            );
        }

        internal PacketHandlerResult AddRefTriggerActionParam(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerActionParam>(
                serverData,
                packet,
                SQL.AddRefTriggerActionParam, // Specific save function for adding action parameters
                PacketID.Client.TriggerEditor_Add_RefTriggerActionParam, // Use the appropriate PacketID for adding action parameters
                "RefTriggerActionParam" // Specify the struct name for logging
            );
        }

        internal PacketHandlerResult AddRefTriggerCondition(ServerData serverData, Packet packet)
        {
            return HandleAddPacket<RefTriggerCondition>(
                serverData,
                packet,
                SQL.AddRefTriggerCondition, // Specific save function for adding a new condition
                PacketID.Client.TriggerEditor_Add_RefTriggerCondition, // Use the appropriate PacketID for adding conditions
                "RefTriggerCondition" // Specify the struct name for logging
            );
        }

        internal PacketHandlerResult AddRefTriggerConditionParam(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefTriggerConditionParam>(
                serverData,
                packet,
                SQL.AddRefTriggerConditionParam, // Specific save function for adding condition parameters
                PacketID.Client.TriggerEditor_Add_RefTriggerConditionParam, // Use the appropriate PacketID for adding condition parameters
                "RefTriggerConditionParam" // Specify the struct name for logging
            );
        }

        internal PacketHandlerResult AddRefTriggerEvent(ServerData serverData, Packet packet)
        {
            return HandleAddPacket<RefTriggerEvent>(
                serverData,
                packet,
                SQL.AddRefTriggerEvent, // Specific save function for adding a new event
                PacketID.Client.TriggerEditor_Add_RefTriggerEvent, // Use the appropriate PacketID for adding events
                "RefTriggerEvent" // Specify the struct name for logging
            );
        }

        internal PacketHandlerResult AddRefGameWorld(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefGame_World>(
                serverData,
                packet,
                SQL.AddRefGameWorld, // Specific save function for adding a new game world
                PacketID.Client.TriggerEditor_Add_RefGameWorld, // Use the appropriate PacketID for adding game worlds
                "RefGameWorld" // Specify the struct name for logging
            );
        }

        /// <summary>
        /// The EditRefTrigger
        /// </summary>
        /// <param name="serverData">The serverData<see cref="ServerData"/></param>
        /// <param name="packet">The packet<see cref="Packet"/></param>
        /// <returns>The <see cref="PacketHandlerResult"/></returns>
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

        /// <summary>
        /// The EditRefTriggerAction
        /// </summary>
        /// <param name="serverData">The serverData<see cref="ServerData"/></param>
        /// <param name="packet">The packet<see cref="Packet"/></param>
        /// <returns>The <see cref="PacketHandlerResult"/></returns>
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

        /// <summary>
        /// The EditRefTriggerActionParam
        /// </summary>
        /// <param name="serverData">The serverData<see cref="ServerData"/></param>
        /// <param name="packet">The packet<see cref="Packet"/></param>
        /// <returns>The <see cref="PacketHandlerResult"/></returns>
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

        /// <summary>
        /// The EditRefTriggerCategory
        /// </summary>
        /// <param name="serverData">The serverData<see cref="ServerData"/></param>
        /// <param name="packet">The packet<see cref="Packet"/></param>
        /// <returns>The <see cref="PacketHandlerResult"/></returns>
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

        /// <summary>
        /// The EditRefTriggerCondition
        /// </summary>
        /// <param name="serverData">The serverData<see cref="ServerData"/></param>
        /// <param name="packet">The packet<see cref="Packet"/></param>
        /// <returns>The <see cref="PacketHandlerResult"/></returns>
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

        /// <summary>
        /// The EditRefTriggerConditionParam
        /// </summary>
        /// <param name="serverData">The serverData<see cref="ServerData"/></param>
        /// <param name="packet">The packet<see cref="Packet"/></param>
        /// <returns>The <see cref="PacketHandlerResult"/></returns>
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

        /// <summary>
        /// The EditRefTriggerEvent
        /// </summary>
        /// <param name="serverData">The serverData<see cref="ServerData"/></param>
        /// <param name="packet">The packet<see cref="Packet"/></param>
        /// <returns>The <see cref="PacketHandlerResult"/></returns>
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

        internal PacketHandlerResult EditRefGameWorld(ServerData serverData, Packet packet)
        {
            return HandleUpdatePacket<RefGame_World>(
                serverData,
                packet,
                SQL.SaveRefGameWorld, // Call the specific save function for GameWorld
                PacketID.Client.TriggerEditor_Update_RefGameWorld, // Use the appropriate PacketID
                "RefGame_World" // Specify the struct name for logging
            );
        }

        private PacketHandlerResult HandleAddPacket<T>(
            ServerData serverData,
            Packet packet,
            Func<string, T, int?, SaveResult> addFunction,
            ushort responsePacketId,
            string structName) where T : struct
        {
            try
            {
                // Deserialize the structure from the packet
                T data = packet.ReadStruct<T>();

                int? link = 0;
                if (packet.Remaining >= sizeof(int))
                    link = packet.ReadInt();
                // Call the save function
                SaveResult result = addFunction(serverData.AccountName, data, link);

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

        #endregion Methods
    }
}