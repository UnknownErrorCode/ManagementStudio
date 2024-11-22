namespace ManagementFramework.Network.Security
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

            // Topic

            public const ushort TopicAddRequest = 0x1002;
            public const ushort TopicDeleteRequest = 0x1004;
            public const ushort TopicEditRequest = 0x1003;
            public const ushort TopicLoadRequest = 0x1001;

            public const ushort WMSE_Update_Tab_RefNest = 0x1100;
            public const ushort WMSE_Update_Tab_RefHive = 0x1101;
            public const ushort WMSE_Update_Tab_RefTactics = 0x1102;
            public const ushort WMSE_Update_RefObjCommon = 0x1103;
            public const ushort WMSE_Update_RefObjChar = 0x1104;

            // Trigger Editor

            public const ushort TriggerEditor_Update_RefTrigger = 0x1200;
            public const ushort TriggerEditor_Update_RefTriggerAction = 0x1201;
            public const ushort TriggerEditor_Update_RefTriggerCondition = 0x1202;
            public const ushort TriggerEditor_Update_RefTriggerEvent = 0x1203;
            public const ushort TriggerEditor_Update_RefTriggerCategory = 0x1204;
            public const ushort TriggerEditor_Update_RefTriggerActionParam = 0x1205;
            public const ushort TriggerEditor_Update_RefTriggerConditionParam = 0x1206;
            public const ushort TriggerEditor_Update_RefGameWorld = 0x1207;
            public const ushort TriggerEditor_Update_RefGameWorldBindTriggerCategory = 0x1208;

            // Trigger Editor - Add Operations
            public const ushort TriggerEditor_Add_RefTrigger = 0x1210;               // Add a new trigger

            public const ushort TriggerEditor_Add_RefTriggerAction = 0x1211;         // Add a new trigger action
            public const ushort TriggerEditor_Add_RefTriggerCondition = 0x1212;      // Add a new trigger condition
            public const ushort TriggerEditor_Add_RefTriggerEvent = 0x1213;          // Add a new trigger event
            public const ushort TriggerEditor_Add_RefTriggerCategory = 0x1214;       // Add a new trigger category
            public const ushort TriggerEditor_Add_RefTriggerActionParam = 0x1215;    // Add new action parameters for a trigger
            public const ushort TriggerEditor_Add_RefTriggerConditionParam = 0x1216; // Add new condition parameters for a trigger
            public const ushort TriggerEditor_Add_RefGameWorld = 0x1217;             // Add a new game world
            public const ushort TriggerEditor_Add_RefGameWorldBindTriggerCategory = 0x1218; // Add binding between a trigger category and a game world

            // Trigger Editor - Link Operations
            public const ushort TriggerEditor_Link_RefTriggerToCategory = 0x1220;           // Link a trigger to a category

            public const ushort TriggerEditor_Link_RefTriggerAction = 0x1221;               // Link a trigger action to a trigger
            public const ushort TriggerEditor_Link_RefTriggerCondition = 0x1222;            // Link a trigger condition to a trigger
            public const ushort TriggerEditor_Link_RefTriggerEvent = 0x1223;                // Link a trigger event to a trigger
            public const ushort TriggerEditor_Link_RefTriggerCategoryToGameWorld = 0x1224;  // Link a trigger category to a game world
            public const ushort TriggerEditor_Link_RefTriggerActionParam = 0x1225;          // Link action parameters to an action
            public const ushort TriggerEditor_Link_RefTriggerConditionParam = 0x1226;       // Link condition parameters to a condition

            #endregion Fields
        }

        public static class Server
        {
            #region Fields

            // Client

            public const ushort LoginStatusResponse = 0xB001;
            public const ushort AllowedPluginResponse = 0xB002;
            public const ushort AllowedDataTableNameResponse = 0xB003;
            public const ushort DataTableResponse = 0xB004;
            public const ushort UserLogOnOff = 0xB005;

            //Framework

            public const ushort LogNotification = 0xA000;
            public const ushort StudioVersion = 0xA001;

            //Topic

            public const ushort TopicLoadResponse = 0xC001;
            public const ushort TopicAddResponse = 0xC002;
            public const ushort TopicsEndLoading = 0xC003;
            public const ushort TopicEditResponse = 0xC004;
            public const ushort TopicDeleteResponse = 0xC005;

            #endregion Fields
        }

        public static class CertificationClient
        {
            public const ushort LIZENCEREQUEST = 0xF000;
        }

        public static class CertificationServer
        {
            public const ushort LIZENCERESPONSE = 0xC000;

            public const ushort LIZENCE_ToolPluginDataAccess = 0xC001;

            public const ushort LIZENCEREQUEST = 0xC002;
        }

        #endregion Classes
    }
}