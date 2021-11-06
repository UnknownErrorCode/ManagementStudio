using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security.PacketFormat
{
    public static class C_S_UpdateShopItemPrice
    {
        public static Packet BuildFromPacket(Packet arg1)
        {

            return new Packet((ushort)PacketID.Client.ShopItem.PriceUpdate);
        }
    }
}
