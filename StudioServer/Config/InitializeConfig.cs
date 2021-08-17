using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Config
{

    public class InitializeConfig
    {

        //statics
        public static string ConfigString = "Config/settings.ini";
        public static string FilterString = "Config/FilterSettings.ini";
        public static string EventBotString = "Config/EventBotSettings.ini";
        public string configString { get => ConfigString; }

        public static InitializeFile Cfg = new InitializeFile(ConfigString);
        public static InitializeFile FilterCfg = new InitializeFile(FilterString);
        public static InitializeFile EventBotCfg = new InitializeFile(EventBotString);


        public static KeyValuePair<string, bool> InitializeConfigFile(string configPath)
        {
            KeyValuePair<string, bool> cfgPair;
            string string1 = "Start Initialize ConfigLibrary.dll";
            bool bool1 = false;

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
                    Cfg.IniWriteValue("DBs", "Developement", "RisingSecurity");
                    Cfg.IniWriteValue("DBs", "Bot", "EventBot");
                    Cfg.IniWriteValue("DBs", "Filter", "RisingSecurity");

                    Cfg.IniWriteValue("StudioServer", "IP", "94.130.10.181");
                    Cfg.IniWriteValue("StudioServer", "Port", "15755");
                    Cfg.IniWriteValue("StudioServer", "Version", "0");
                    Cfg.IniWriteValue("StudioServer", "PatchFolderArchiv", "C:\\PatchFolderArchiv");
                    Cfg.IniWriteValue("StudioServer", "PatchFolderDirectory", "C:\\RisingSecurity");
                    Cfg.IniWriteValue("StudioServer", "ChatLogPath", "C:\\StudioServerChatLog");



                    KeyValuePair<string, bool> s = InitializeConfigFile(configPath);

                    string1 = $"Created Config.ini... Now loading \n{s.Key}";
                    bool1 = s.Value;
                }
                else
                {
                    string1 = $"Successfully initialized: {configPath}";
                    bool1 = true;
                }
            }
            catch (Exception ex)
            {
                bool1 = false;
                string1 = "CFG: Error loading settings, please check your configuration or restart the tool! " + ex;
            }

            finally
            {
                cfgPair = new KeyValuePair<string, bool>((string)string1, (bool)bool1);
            }
            return cfgPair;
        }
    }
}

