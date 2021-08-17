using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Utility
{
   public class Settings
    {
        public string SQL_Host { get => InitializeConfig.Cfg.IniReadValue("SQL", "Host"); }
        public string SQL_User { get => InitializeConfig.Cfg.IniReadValue("SQL", "User"); }
        public string SQL_Password { get => InitializeConfig.Cfg.IniReadValue("SQL", "Password"); }
        public string SQL_ConnectionString { get => $"Server={SQL_Host};database={"master"};User ID={SQL_User};Password={SQL_Password};MultipleActiveResultSets=True"; }
        public string DBAcc { get => InitializeConfig.Cfg.IniReadValue("DBs", "Account"); }
        public string DBLog { get => InitializeConfig.Cfg.IniReadValue("DBs", "Log"); }
        public string DBSha { get => InitializeConfig.Cfg.IniReadValue("DBs", "Shard"); }
        public string DBDev { get => InitializeConfig.Cfg.IniReadValue("DBs", "Developement"); }
        public string DBBot { get => InitializeConfig.Cfg.IniReadValue("DBs", "Bot"); }
        public string DBFilter { get => InitializeConfig.Cfg.IniReadValue("DBs", "Filter"); }
        public string IP { get => InitializeConfig.Cfg.IniReadValue("StudioServer", "IP"); }
        public int Port { get => int.Parse(InitializeConfig.Cfg.IniReadValue("StudioServer", "Port")); }
        public int Version { get => int.Parse(InitializeConfig.Cfg.IniReadValue("StudioServer", "Version")); }
        public string PatchFolderDirectory_Archiv { get => InitializeConfig.Cfg.IniReadValue("StudioServer", "PatchFolderArchiv"); }
        public string PatchFolderDirectory { get => InitializeConfig.Cfg.IniReadValue("StudioServer", "PatchFolderDirectory"); }
        public string ChatLogPath { get => InitializeConfig.Cfg.IniReadValue("StudioServer", "ChatLogPath"); }
        public string GuidePath { get => Path.Combine(Directory.GetCurrentDirectory(), "Dashboard", "Topics"); }
        public string DeletedGuidePath { get => Path.Combine(Directory.GetCurrentDirectory(), "Dashboard", "DeletedTopics"); }


        public KeyValuePair<string, bool> InitializeSettings = InitializeConfig.InitializeConfigFile(InitializeConfig.ConfigString);
    }
}
