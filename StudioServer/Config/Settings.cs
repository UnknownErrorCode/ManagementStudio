using System.Collections.Generic;
using System.IO;

namespace StudioServer.Config
{
    public class Settings
    {
        public string SQL_Host => InitializeConfig.Cfg.IniReadValue("SQL", "Host");
        public string SQL_User => InitializeConfig.Cfg.IniReadValue("SQL", "User");
        public string SQL_Password => InitializeConfig.Cfg.IniReadValue("SQL", "Password");
        public string SQL_ConnectionString => $"Server={SQL_Host};database={"master"};User ID={SQL_User};Password={SQL_Password};MultipleActiveResultSets=True";
        public string DBAcc => InitializeConfig.Cfg.IniReadValue("DBs", "Account");
        public string DBLog => InitializeConfig.Cfg.IniReadValue("DBs", "Log");
        public string DBSha => InitializeConfig.Cfg.IniReadValue("DBs", "Shard");
        public string DBDev => InitializeConfig.Cfg.IniReadValue("DBs", "Developement");
        public string DBBot => InitializeConfig.Cfg.IniReadValue("DBs", "Bot");
        public string DBFilter => InitializeConfig.Cfg.IniReadValue("DBs", "Filter");
        public string IP => InitializeConfig.Cfg.IniReadValue("StudioServer", "IP");
        public int Port => int.Parse(InitializeConfig.Cfg.IniReadValue("StudioServer", "Port"));
        public int Version => int.Parse(InitializeConfig.Cfg.IniReadValue("StudioServer", "Version"));
        public string PatchFolderDirectory_Archiv => InitializeConfig.Cfg.IniReadValue("StudioServer", "PatchFolderArchiv");
        public string PatchFolderDirectory => InitializeConfig.Cfg.IniReadValue("StudioServer", "PatchFolderDirectory");
        public string ChatLogPath => InitializeConfig.Cfg.IniReadValue("StudioServer", "ChatLogPath");
        public string GuidePath => Path.Combine(Directory.GetCurrentDirectory(), "Dashboard", "Topics");
        public string DeletedGuidePath => Path.Combine(Directory.GetCurrentDirectory(), "Dashboard", "DeletedTopics");


        public KeyValuePair<string, bool> InitializeSettings = InitializeConfig.InitializeConfigFile(InitializeConfig.ConfigString);
    }
}
