using ManagementFramework;
using System;
using System.IO;

namespace ManagementServer.Utility
{
    public class InitializeConfig
    {
        public const string ConfigString = "Config/settings.ini";
        public static InitializeFile Cfg = new InitializeFile(ConfigString);

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
                    Cfg.IniWriteValue("SQL", "Password", "FuckYou");

                    Cfg.IniWriteValue("DBs", "Account", "SRO_VT_ACCOUNT");
                    Cfg.IniWriteValue("DBs", "Log", "SRO_VT_LOG");
                    Cfg.IniWriteValue("DBs", "Shard", "SRO_VT_SHARD");
                    Cfg.IniWriteValue("DBs", "Developement", "StudioClient");

                    Cfg.IniWriteValue("Certification", "IP", "127.0.0.1");
                    Cfg.IniWriteValue("Certification", "Port", "15555");

                    Cfg.IniWriteValue("StudioServer", "IP", "127.0.0.1");
                    Cfg.IniWriteValue("StudioServer", "Port", "15755");
                    Cfg.IniWriteValue("StudioServer", "Version", "0");
                    Cfg.IniWriteValue("StudioServer", "PatchFolderArchiv", "C:\\PatchFolderArchiv");
                    Cfg.IniWriteValue("StudioServer", "PatchFolderDirectory", "C:\\RisingSecurity");
                    Cfg.IniWriteValue("StudioServer", "ChatLogPath", "C:\\StudioServerChatLog");

                    Cfg.IniWriteValue("Lizence", "User", "default");
                    Cfg.IniWriteValue("Lizence", "Password", "default");
                    Cfg.IniWriteValue("Lizence", "Key", "default");

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
    }
}