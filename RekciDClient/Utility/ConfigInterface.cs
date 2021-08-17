using System.Collections.Generic;

namespace RekciDClient.Utility
{
    internal interface ConfigInterface
    {
        string ClientDataPath();
        string ClientExtracted();
        string ClientIP();
        int ClientPort();
        string ClientVersion();
        string ClientLocale();
        string ClientDivision();
        string ClientCaptcha();
        string ClientShardID();



        string ToolServerIP();
        int ToolServerPort();
        int ToolServerVersion();
        bool ToolSaveUserData();
        string ToolUser();
        string ToolUserPassword();
        bool ToolQuickLogin();
        bool ShowPwInText();





    }
}