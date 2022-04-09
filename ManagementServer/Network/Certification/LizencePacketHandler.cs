using ManagementFramework.Network.Security;
using Structs.Tool;

namespace ManagementServer.Network
{
    internal class LizencePacketHandler : PacketHandler
    {
        public LizencePacketHandler()
        {
            base.AddEntry(0x2001, Reply0x2001);
            base.AddEntry(PacketID.CertificationServer.LIZENCEREQUEST, LizenceResponse);
            base.AddEntry(PacketID.CertificationServer.LIZENCERESPONSE, CheckLizence);
            base.AddEntry(PacketID.CertificationServer.LIZENCE_ToolPluginDataAccess, ToolPluginDataAccess);

            //TODO:
        }

        private PacketHandlerResult LizenceResponse(ServerData arg1, Packet arg2)
        {
            arg1.m_security.Send(PacketConstructors.LizencePacket.RequestLizence);// ServerManager.settings.Version);
            ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.loading, "Requesting service...");
            return PacketHandlerResult.Response;
        }

        /// <summary>
        /// Receives the Database table "_ToolPluginDataAccess".
        /// <br>This table is required to refresh the <see cref="PluginSecurityManager"/></br>
        /// <br>The DataTable gets directly assigned to <see cref="PluginSecurityManager._ToolPluginDataAccessDataTable"/></br>
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private PacketHandlerResult ToolPluginDataAccess(ServerData arg1, Packet arg2)
        {
            var n = arg2.ReadAscii();
            PluginSecurityManager._ToolPluginDataAccessDataTable = arg2.ReadDataTable(arg2.ReadByteArray(arg2.Remaining));
            PluginSecurityManager._ToolPluginDataAccessDataTable.TableName = n;
            ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.success, "_ToolPluginDataAccess received.");

            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// #1 Checking Version.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0x2001(ServerData data, Packet packet)
        {
            var identity = packet.ReadAscii();
            byte flag = packet.ReadByte();
            if (identity == "Tool_Server" && flag == 1)
            {
                data.m_security.Send(PacketConstructors.LizencePacket.RequestLizence);// ServerManager.settings.Version);
                return PacketHandlerResult.Response;
            }

            return PacketHandlerResult.Block;
        }

        private PacketHandlerResult CheckLizence(ServerData data, Packet packet)
        {
            //data.m_security.Send(PacketConstructors.LizencePacket.RequestLizence);// ServerManager.settings.Version);
            var str = packet.ReadStruct<LoginStatus>();
            ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.notify, str.Notification);

            return PacketHandlerResult.Block;
        }
    }
}