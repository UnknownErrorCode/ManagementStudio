namespace PluginFramework
{
    public class Config : ConfigLoader
    {
        #region Fields

        public static Config StaticConfig = new Config();

        #endregion Fields

        #region Constructors

        public Config()
        {
            base.Initialize();
        }

        #endregion Constructors

        #region Properties

        public string ClientCaptcha { get => base.ConfigEditor.IniReadValue("Client", "Captcha"); set => base.ConfigEditor.IniWriteValue("Client", "Captcha", value); }
        public string ClientDivision { get => base.ConfigEditor.IniReadValue("Client", "Division"); set => base.ConfigEditor.IniWriteValue("Client", "Division", value); }
        public string ClientExtracted { get => base.ConfigEditor.IniReadValue("ToolClient", "StudioRessources"); set => base.ConfigEditor.IniWriteValue("ToolClient", "StudioRessources", value); }
        public string ClientIP { get => base.ConfigEditor.IniReadValue("Client", "IP"); set => base.ConfigEditor.IniWriteValue("Client", "IP", value); }
        public string ClientLocale { get => base.ConfigEditor.IniReadValue("Client", "Locale"); set => base.ConfigEditor.IniWriteValue("Client", "Locale", value); }
        public string ClientPath { get => base.ConfigEditor.IniReadValue("Client", "Path"); set => base.ConfigEditor.IniWriteValue("Client", "Path", value); }
        public int ClientPort { get => int.Parse(base.ConfigEditor.IniReadValue("Client", "Port")); set => base.ConfigEditor.IniWriteValue("Client", "Port", value.ToString()); }
        public string ClientShardID { get => base.ConfigEditor.IniReadValue("Client", "ShardID"); set => base.ConfigEditor.IniWriteValue("Client", "ShardID", value); }
        public string ClientVersion { get => base.ConfigEditor.IniReadValue("Client", "Version"); set => base.ConfigEditor.IniWriteValue("Client", "Version", value.ToString()); }
        public string PToolUser { get => base.ConfigEditor.IniReadValue("ToolClient", "User"); set => base.ConfigEditor.IniWriteValue("ToolClient", "User", value); }
        public string PToolUserPassword { get => base.ConfigEditor.IniReadValue("ToolClient", "ToolPassword").Replace('"'.ToString(),""); set => base.ConfigEditor.IniWriteValue("ToolClient", "ToolPassword", $"{'"'}{value}{'"'}"); }
        public bool ShowPwInText { get => bool.Parse(base.ConfigEditor.IniReadValue("ToolClient", "ShowPW")); set => base.ConfigEditor.IniWriteValue("ToolClient", "ShowPW", value.ToString()); }
        public bool ToolQuickLogin { get => bool.Parse(base.ConfigEditor.IniReadValue("ToolClient", "QuickLogin")); set => base.ConfigEditor.IniWriteValue("ToolClient", "QuickLogin", value.ToString()); }
        public bool ToolSaveUserData { get => bool.Parse(base.ConfigEditor.IniReadValue("ToolClient", "SaveUserData")); set => base.ConfigEditor.IniWriteValue("ToolClient", "SaveUserData", value.ToString()); }
        public string ToolServerIP { get => base.ConfigEditor.IniReadValue("ToolServer", "Host"); set => base.ConfigEditor.IniWriteValue("ToolServer", "Host", value); }
        public int ToolServerPort { get => int.Parse(base.ConfigEditor.IniReadValue("ToolServer", "Port")); set => base.ConfigEditor.IniWriteValue("ToolServer", "Port", value.ToString()); }
        public int ToolServerVersion { get => int.Parse(base.ConfigEditor.IniReadValue("ToolServer", "Version")); set => base.ConfigEditor.IniWriteValue("ToolServer", "Version", value.ToString()); }

        #endregion Properties
    }
}