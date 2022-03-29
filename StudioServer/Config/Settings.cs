using System.Collections.Generic;
using System.IO;

namespace StudioServer.Config
{
    public class Settings
    {
        #region Public Fields

        public KeyValuePair<string, bool> InitializeSettings = InitializeConfig.InitializeConfigFile(InitializeConfig.ConfigString);

        #endregion Public Fields

        #region Public Properties

        public string ChatLogPath => InitializeConfig.Cfg.IniReadValue("StudioServer", "ChatLogPath");
        public string DBAcc => InitializeConfig.Cfg.IniReadValue("DBs", "Account");
        public string DBBot => InitializeConfig.Cfg.IniReadValue("DBs", "Bot");
        public string DBDev => InitializeConfig.Cfg.IniReadValue("DBs", "Developement");
        public string DBFilter => InitializeConfig.Cfg.IniReadValue("DBs", "Filter");
        public string DBLog => InitializeConfig.Cfg.IniReadValue("DBs", "Log");
        public string DBSha => InitializeConfig.Cfg.IniReadValue("DBs", "Shard");
        public string DeletedGuidePath => Path.Combine(Directory.GetCurrentDirectory(), "Dashboard", "DeletedTopics");
        public string GuidePath => Path.Combine(Directory.GetCurrentDirectory(), "Dashboard", "Topics");
        public string IP => InitializeConfig.Cfg.IniReadValue("StudioServer", "IP");
        public string PatchFolderDirectory => InitializeConfig.Cfg.IniReadValue("StudioServer", "PatchFolderDirectory");
        public string PatchFolderDirectory_Archiv => InitializeConfig.Cfg.IniReadValue("StudioServer", "PatchFolderArchiv");
        public int Port => int.Parse(InitializeConfig.Cfg.IniReadValue("StudioServer", "Port"));
        public string SQL_ConnectionString => $"Server={SQL_Host};database={"master"};User ID={SQL_User};Password={SQL_Password};MultipleActiveResultSets=True";
        public string SQL_Host => InitializeConfig.Cfg.IniReadValue("SQL", "Host");
        public string SQL_Password => InitializeConfig.Cfg.IniReadValue("SQL", "Password");
        public string SQL_User => InitializeConfig.Cfg.IniReadValue("SQL", "User");
        public int Version => int.Parse(InitializeConfig.Cfg.IniReadValue("StudioServer", "Version"));

        #endregion Public Properties
    }
}