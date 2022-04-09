using ManagementFramework;
using System;
using System.IO;

namespace ManagementCertification.Utility
{
    public class InitializeConfig
    {
        #region Fields

        public const string ConfigString = "Config/settings.ini";
        private static InitializeFile Cfg = new InitializeFile(ConfigString);

        #endregion Fields

        #region Methods
        internal static string IniReadValue(string section, string key) => Cfg.IniReadValue(section, key);
        internal static void IniWriteValue(string section, string key, string value) => Cfg.IniWriteValue(section, key, value);
        public static bool InitializeConfigFile(string configPath, out string msg)
        {
            msg = "Start Initialize ConfigLibrary.dll";

            if (!Directory.Exists("Config"))
            {
                Directory.CreateDirectory("Config").Create();
            }

            try
            {
                if (!File.Exists(configPath))
                {
                    File.Create(configPath).Dispose();

                    Cfg.IniWriteValue("SQL", "Host", ".\\SQLEXPRESS");
                    Cfg.IniWriteValue("SQL", "User", "sa");
                    Cfg.IniWriteValue("SQL", "Password", "password123");

                    
                    Cfg.IniWriteValue("DBs", "Developement", "StudioServer");
                  

                    Cfg.IniWriteValue("StudioServer", "IP", "127.0.0.1");
                    Cfg.IniWriteValue("StudioServer", "Port", "15555");
                    Cfg.IniWriteValue("StudioServer", "Version", "0");
                    Cfg.IniWriteValue("StudioServer", "PatchFolderArchiv", "C:\\PatchFolderArchiv");
                    Cfg.IniWriteValue("StudioServer", "PatchFolderDirectory", "C:\\RisingSecurity");
                    Cfg.IniWriteValue("StudioServer", "ChatLogPath", "C:\\StudioServerChatLog");

                    return InitializeConfigFile(configPath, out msg);
                }
                else
                {
                    msg = $"Successfully initialized: {configPath}";
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg = "CFG: Error loading settings, please check your configuration or restart the tool! " + ex;
                return false;
            }
        }

        #endregion Methods
    }
}