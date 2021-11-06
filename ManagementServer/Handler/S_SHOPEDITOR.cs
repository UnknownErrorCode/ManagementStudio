using ServerFrameworkRes.Network.Security;
using Structs.Database;
using System;

namespace ManagementServer.Handler
{
    internal class S_SHOPEDITOR
    {
        internal static PacketHandlerResult UpdatePrice(ServerData arg1, Packet arg2)
        {

            try
            {
               
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }
          
            return PacketHandlerResult.Block;
        }
    }
}