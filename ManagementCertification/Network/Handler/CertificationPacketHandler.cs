using ManagementCertification.Utility;
using ServerFrameworkRes.Network.Security;
using System;

namespace ManagementCertification.Network
{
    internal partial class LizenceServerPacketHandler
    {
        #region Methods


        internal PacketHandlerResult LizenceResponse(ServerData data, Packet packet)
        {
            ServerLizenceData serverData = (ServerLizenceData)data;
            string acc = packet.ReadAscii();
            string pwd = packet.ReadAscii();

            try
            {
                Structs.Tool.LoginStatus result = SQL.CheckLizence(acc, pwd, serverData.UserIP);

                data.m_security.Send(PacketConstructors.InitializeServer.Status(result));

                if (result.Success)
                {
                    serverData.AccountName = result.UserName;
                    serverData.LizenceGroup = result.SecurityGroup;
                    data.m_security.Send(PacketConstructors.InitializeServer.Send_ToolPluginDataAccess(result.SecurityGroup));

                    CertificationManager.Logger.WriteLogLine($"User: {result.UserName} successfully logged on!");
                }
                else
                {
                    CertificationManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Failed login on user: {result.UserName} {result.Notification}");
                }

                return PacketHandlerResult.Response;
            }
            catch (Exception ex)
            {
                CertificationManager.Logger.WriteLogLine(ex, $"Failed to convert login status of User: {((ServerLizenceData)data).UserIP}");
            }
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}