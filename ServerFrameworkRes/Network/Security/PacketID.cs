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

        #region Public Classes

        public static class Client
        {

            #region Public Fields
            // Framework
            public const ushort Login = 0x1000;
            public const ushort RequestOnlineUser = 0x0001;
            public const ushort RequestAllowedPlugins = 0x0002;
            public const ushort RequestAllowedDataTableNames = 0x0003;

            public const ushort RequestDataTable = 0x0999;
            public const ushort RequestPlugiDataTable = 0x0998;


            // Topic
            public const ushort TopicLoadRequest = 0x1001;
            public const ushort TopicAddRequest = 0x1002;
            public const ushort TopicEditRequest = 0x1003;
            public const ushort TopicDeleteRequest = 0x1004;



            #endregion Public Fields

        }

        public static class Server
        {

            #region Public Fields 

            //Framework
            public const ushort LogNotification = 0xA000;
            public const ushort UserLogOnOff = 0xA001;

            // Client
            public const ushort LoginStatusResponse = 0xB001;
            public const ushort AllowedPluginResponse = 0xB002;
            public const ushort AllowedDataTableNameResponse = 0xB003;
            public const ushort DataTableResponse = 0xB004;


            //Topic
            public const ushort TopicLoadResponse = 0xC001;
            public const ushort TopicAddResponse = 0xC002;
            public const ushort TopicsEndLoading = 0xC003;
            public const ushort TopicEditResponse = 0xC004;
            public const ushort TopicDeleteResponse = 0xC005;

            #endregion Public Fields

        }

        #endregion Public Classes

    }
}