using Structs.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security.PacketFormat
{
    public static class C_S_ShopItemContext
    {
        public static Packet RefPricePolicyOfItemToPacket(RefPricePolicyOfItem arg1, EditAction action)
        {
            var p = new Packet(PacketID.Client.ShopDataRefPricePolicyOfItem);
            p.WriteByte(action);
            p.WriteStruct(arg1);
            return p; // new Packet((ushort)PacketID.Client.RefShopData.RefPricePolicyOfItem);
        }
    }
}
