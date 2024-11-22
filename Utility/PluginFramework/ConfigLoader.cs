﻿using System.IO;

namespace PluginFramework
{
    public abstract class ConfigLoader
    {
        #region Fields

        public ManagementFramework.InitializeFile ConfigEditor;

        #endregion Fields

        #region Properties

        private string ConfigFile => "settings.ini";
        private string ConfigFilePath => Path.Combine(ConfigPath, ConfigFile);
        private string ConfigPath => Path.Combine(Directory.GetCurrentDirectory(), "Config");

        #endregion Properties

        #region Methods

        internal void Initialize()
        {
            if (!Directory.Exists(ConfigPath))
            {
                Directory.CreateDirectory(ConfigPath).Create();
            }

            if (!File.Exists(ConfigFilePath))
            {
                File.Create(ConfigFilePath).Dispose();

                ConfigEditor = new ManagementFramework.InitializeFile(ConfigFilePath);

                ConfigEditor.IniWriteValue("ToolServer", "Host", "127.0.0.1");
                ConfigEditor.IniWriteValue("ToolServer", "Port", "15755");
                ConfigEditor.IniWriteValue("ToolServer", "Version", "1");

                ConfigEditor.IniWriteValue("ToolClient", "SaveUserData", "true");
                ConfigEditor.IniWriteValue("ToolClient", "User", "User");
                ConfigEditor.IniWriteValue("ToolClient", "ToolPassword", "password");
                ConfigEditor.IniWriteValue("ToolClient", "QuickLogin", "false");
                ConfigEditor.IniWriteValue("ToolClient", "ShowPW", "false");
                ConfigEditor.IniWriteValue("ToolClient", "StudioRessources", "C:\\ClientExtracted");

                ConfigEditor.IniWriteValue("Client", "IP", "111.111.111.111");
                ConfigEditor.IniWriteValue("Client", "Port", "15779");
                ConfigEditor.IniWriteValue("Client", "Version", "188");
                ConfigEditor.IniWriteValue("Client", "Locale", "22");
                ConfigEditor.IniWriteValue("Client", "Division", "DIV01");
                ConfigEditor.IniWriteValue("Client", "Captcha", "E");
                ConfigEditor.IniWriteValue("Client", "ShardID", "64");
                ConfigEditor.IniWriteValue("Client", "Path", "C:\\Client");
            }
            else
            {
                ConfigEditor = new ManagementFramework.InitializeFile(ConfigFilePath);
            }
        }

        #endregion Methods
    }
}