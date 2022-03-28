using Structs.Database;
using System;

namespace ServerFrameworkRes.Network.Security
{

    public enum EditAction : byte
    {
        Add = 0x00,
        Update = 0x01,
        Delete = 0x02,
    }

    public class PacketID
    {
        public static class Client
        {

            public const ushort RequestDataTable = 0x0999;
            public const ushort RequestPlugiDataTable = 0x0998;

            public const ushort Login = 0x1000;

            public const ushort TopicsRequest = 0x1001;
            public const ushort TopicAddRequest = 0x1002;
            public const ushort TopicEditRequest = 0x1003;
            public const ushort TopicDeleteRequest = 0x1004;


           


            public const ushort ShopDataRefPricePolicyOfItem = 0x1010;
            public const ushort RefPackageItem = 0x1011;
            public const ushort RefScrapOfPackageItem = 0x1012;
            public const ushort RefShopGood = 0x1013;

        }
        public static class Server
        {

            public const ushort AllowedPlugins= 0xB000;
            public const ushort DataTableNames= 0xB001;
            public const ushort DataTableSend= 0xB002;
            public const ushort LogNotification = 0xB003;
            public const ushort PluginDataSent = 0xB004;

            public const ushort LoginStatus= 0xC000;
            public const ushort TopicLoadRequest= 0xC001;
            public const ushort TopicAddNewResponse= 0xC002;
            public const ushort TopicsEndLoading= 0xC003;
            public const ushort TopicDeleteResponse= 0xC004;

        }
    }
}
