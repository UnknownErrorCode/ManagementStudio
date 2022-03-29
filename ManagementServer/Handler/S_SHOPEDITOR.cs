using ServerFrameworkRes.Network.Security;
using Structs.Database;
using System;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        #region Private Methods

        private PacketHandlerResult ShopDataPricePolicyOfItem(ServerData arg1, ServerFrameworkRes.Network.Security.Packet arg2)
        {
            if (arg2.Opcode != PacketID.Client.ShopDataRefPricePolicyOfItem)
            {
                return PacketHandlerResult.Block;
            }

            try
            {
                EditAction type = (EditAction)arg2.ReadByte();
                RefPricePolicyOfItem pricepolicyofitem = arg2.ReadStruct<RefPricePolicyOfItem>();

                switch (type)
                {
                    case EditAction.Add:
                        break;

                    case EditAction.Update:
                        break;

                    case EditAction.Delete:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ServerManager.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.fatal, ex.Message);
            }

            return PacketHandlerResult.Block;
        }

        #endregion Private Methods
    }
}