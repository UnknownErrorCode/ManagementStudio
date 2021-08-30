using ManagementServer.Utility;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Handler
{
    class S_LOGIN
    {
        internal static PacketHandlerResult TryLogin(ServerData data, Packet packet)
        {

            var acc = packet.ReadAscii();
            var pwd = packet.ReadAscii();
            //TODO: Version 
            string[] result = SQL.CheckLogin(acc, pwd, ((ServerClientData)data).UserIP);

            if (bool.TryParse(result[0], out bool success))
            {
                var LoginStatus = new Packet(0xC000);
                LoginStatus.WriteBool(success);
                LoginStatus.WriteAscii(result[1]);
                LoginStatus.WriteAscii(result[2]);
                LoginStatus.WriteAscii(result[3]);
                data.m_security.Send(LoginStatus);
                if (success)
                {
                    data.AccountName = result[3];
                    ServerManager.Logger.WriteLogLine($"User: {((ServerClientData)data).AccountName} successfully logged on! ");
                }
                else
                    ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Failed login on user: {result[3]} {result[1]}");

                
                return PacketHandlerResult.Response;

            }

            ServerManager.Logger.WriteLogLine($"Failed to convert login status of User: {((ServerClientData)data).UserIP}");

            return PacketHandlerResult.Block;
        }
    }
}
