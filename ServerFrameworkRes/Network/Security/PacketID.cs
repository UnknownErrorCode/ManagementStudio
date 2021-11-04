using Structs.Database;
using System;

namespace ServerFrameworkRes.Network.Security
{
    public class PacketID
    {
        public static class Client
        {

            public static readonly ushort RequestDataTable = 0x0999;
            public static readonly ushort Login = 0x1000;

            public enum Topic : ushort
            {
                Add = 0x1002,
                Refresh = 0x1001,
                Delete = 0x1004,
            }

            public enum ShopItem : ushort
            {
                PriceUpdate = 0x1010,
            }



            public static bool ShopItemPriceUpdate(RefPricePolicyOfItem refPricePolicyOfItem, out Packet packet)
            {
                try
                {
                    packet = new Packet((ushort)ShopItem.PriceUpdate, false, true);
                    packet.WriteStruct(refPricePolicyOfItem);
                    return true;
                }
                catch ( Exception ex)
                {
                    packet = null;
                    return false;
                }
            }

          
        }
        public static class Server
        {

            public const ushort AllowedPlugins= 0xB000;
            public const ushort AllowedDataTableNames= 0xB001;
            public const ushort AllowedDataTable= 0xB002;

            public const ushort LoginStatus= 0xC000;
            public const ushort LoadTopicRequest= 0xC001;
            public const ushort NewTopicRequest= 0xC002;
            public const ushort FinishedLoadingTopics= 0xC003;
            public const ushort DeleteTopics= 0xC004;


        }
    }
}
