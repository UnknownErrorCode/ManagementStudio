﻿namespace ServerFrameworkRes.Network.Security
{
    public enum EditAction : byte
    {
        Add = 0x00,
        Update = 0x01,
        Delete = 0x02,
    }

    public class PacketID
    {
        #region Classes

        public static class Client
        {
            #region Fields

            // Framework
            public const ushort Login = 0x1000;

            public const ushort RequestAllowedDataTableNames = 0x0003;
            public const ushort RequestAllowedPlugins = 0x0002;
            public const ushort RequestDataTable = 0x0999;
            public const ushort RequestOnlineUser = 0x0001;
            public const ushort RequestPlugiDataTable = 0x0998;

            public const ushort TopicAddRequest = 0x1002;

            public const ushort TopicDeleteRequest = 0x1004;

            public const ushort TopicEditRequest = 0x1003;

            // Topic
            public const ushort TopicLoadRequest = 0x1001;

            #endregion Fields
        }

        public static class Server
        {
            #region Fields

            public const ushort AllowedDataTableNameResponse = 0xB003;

            public const ushort AllowedPluginResponse = 0xB002;

            public const ushort DataTableResponse = 0xB004;

            // Client
            public const ushort LoginStatusResponse = 0xB001;

            //Framework
            public const ushort LogNotification = 0xA000;

            public const ushort TopicAddResponse = 0xC002;
            public const ushort TopicDeleteResponse = 0xC005;
            public const ushort TopicEditResponse = 0xC004;

            //Topic
            public const ushort TopicLoadResponse = 0xC001;

            public const ushort TopicsEndLoading = 0xC003;
            public const ushort UserLogOnOff = 0xA001;

            #endregion Fields
        }

        #endregion Classes
    }
}