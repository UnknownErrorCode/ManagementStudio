using ManagementServer.Utility;
using ManagementFramework.Network.Security;
using Structs.Tool;
using System;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        #region Methods

        /// <summary>
        /// Sends 0xC000 with LoginStatus, message and SecurityGroup.
        /// <br>Also sends 0xB000 on success login with all plugins to load.</br>
        ///  <br>Also sends 0xB001 on success login with DataTables to load from Database</br>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        internal PacketHandlerResult TryLogin(ServerData data, Packet packet)
        {
            ServerClientData serverData = (ServerClientData)data;
            string acc = packet.ReadAscii();
            string pwd = packet.ReadAscii();
            //TODO: Version
            try
            {
                Structs.Tool.LoginStatus result = SQL.CheckLogin(acc, pwd, serverData.UserIP);

                data.m_security.Send(PacketConstructors.LoginPacket.Status(result));

                if (result.Success)
                {
                    serverData.AccountName = result.UserName;
                    serverData.SecurityGroup = result.SecurityGroup;
                    data.m_security.Send(PacketConstructors.LoginPacket.AllowedDataTableNames(result.SecurityGroup));

                    ServerManager.Logger.WriteLogLine($"User: {result.UserName} successfully logged on!");
                }
                else
                {
                    ServerManager.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.warning, $"Failed login on user: {result.UserName} {result.Notification}");
                }

                return PacketHandlerResult.Response;
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ex, $"Failed to convert login status of User: {((ServerClientData)data).UserIP}");
            }
            return PacketHandlerResult.Block;
        }



        internal static PacketHandlerResult ResponsePluginDataTables(ServerData arg1, Packet arg2)
        {
            try
            {
                var clientData = (ServerClientData)arg1;
                var pluginName = arg2.ReadAscii();
                PluginData pluginData = (PluginData)arg2.ReadUShort();

                if (!PluginSecurityManager.IsAllowed(pluginName, clientData.SecurityGroup))
                {
                    return PacketHandlerResult.Block;
                }

                string[] tableNameArray = PluginSecurityManager.GetPluginDataTableNames(pluginName);// Utility.SQL.GetRequiredTableNames(arg1.SecurityGroup);

                if (tableNameArray == null || tableNameArray?.Length == 0)
                    return PacketHandlerResult.Block;

                arg1.m_security.Send(PacketConstructors.DataTablePacket.GetAllTables(tableNameArray));
                arg1.m_security.Send(PacketConstructors.DataTablePacket.PluginDataReceiveConfirmation(pluginData));

            }
            catch (System.Exception)
            { }
            System.GC.Collect(2);
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}