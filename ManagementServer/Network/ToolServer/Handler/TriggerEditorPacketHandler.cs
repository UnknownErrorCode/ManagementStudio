using ManagementFramework.Network.Security;
using ManagementServer.PacketConstructors;
using ManagementServer.Utility;
using Structs.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        private PacketHandlerResult HandleUpdatePacket<T>(
    ServerData serverData,
    Packet packet,
    Func<T, bool> saveFunction,
    ushort responsePacketId,
    string structName) where T : struct
        {
            try
            {
                // Deserialize the struct from the packet
                var data = packet.ReadStruct<T>();

                // Save the data using the provided save function
                bool success = saveFunction(data);

                if (success)
                {
                    // Notify the user of a successful update
                    serverData.m_security.Send(NotificationPacket.NotifyPacket(
                        ManagementFramework.Ressources.LogLevel.notify,
                        $"{structName} updated successfully."));

                    // Send response packet to the client
                    var responsePacket = new Packet(responsePacketId);
                    serverData.m_security.Send(responsePacket);

                    return PacketHandlerResult.Response;
                }
                else
                {
                    // Notify the user of a failure
                    serverData.m_security.Send(NotificationPacket.NotifyPacket(
                        ManagementFramework.Ressources.LogLevel.warning,
                        $"Failed to update {structName}."));
                    return PacketHandlerResult.Block;
                }
            }
            catch (Exception ex)
            {
                // Notify the user of a critical error
                serverData.m_security.Send(NotificationPacket.NotifyPacket(
                    ManagementFramework.Ressources.LogLevel.fatal,
                    $"An error occurred while updating {structName}: {ex.Message}"));
                return PacketHandlerResult.Block;
            }
        }

        internal PacketHandlerResult EditRefTrigger(ServerData serverData, Packet packet)
        {
            try
            {

                var size = Marshal.SizeOf<RefTrigger>();
                // Deserialize RefTrigger from the packet
                var trigger = packet.ReadStruct<RefTrigger>();

                // Basic validation
                if (trigger.ID <= 0)
                {
                    serverData.m_security.Send(NotificationPacket.NotifyPacket(
                        ManagementFramework.Ressources.LogLevel.warning,
                        "Invalid RefTrigger ID. Update aborted."));
                    return PacketHandlerResult.Block;
                }

                // Save to database
                bool success = SQL.SaveRefTrigger(serverData.AccountName,trigger, out string status, out string message);

                if (success)
                {
                    // Notify the user of a successful update

                    ServerMemory.BroadcastPacket(NotificationPacket.NotifyPacket(
                        ManagementFramework.Ressources.LogLevel.notify,
                        $"RefTrigger updated successfully: {trigger.CodeName128} (ID: {trigger.ID})"));

                    // Send success response to the client
                    var responsePacket = new Packet(PacketID.Client.TriggerEditor_Update_RefTrigger);
                   
                    serverData.m_security.Send(responsePacket);

                    return PacketHandlerResult.Response;
                }
                else
                {
                    // Notify the user of a failure
                    serverData.m_security.Send(NotificationPacket.NotifyPacket(
                        ManagementFramework.Ressources.LogLevel.warning,
                        "Failed to update RefTrigger."));
                    return PacketHandlerResult.Block;
                }
            }
            catch (Exception ex)
            {
                // Notify the user of a critical error
                serverData.m_security.Send(NotificationPacket.NotifyPacket(
                    ManagementFramework.Ressources.LogLevel.fatal,
                    $"An error occurred while updating RefTrigger: {ex.Message}"));
                return PacketHandlerResult.Block;
            }
        }
    }
}
