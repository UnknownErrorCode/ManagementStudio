namespace ManagementCertification.Utility
{
    public class Settings
    {
        public string ChatLogPath { get => InitializeConfig.IniReadValue("StudioServer", "ChatLogPath"); set => InitializeConfig.IniWriteValue("StudioServer", "ChatLogPath", value); }

        public string DBDev { get => InitializeConfig.IniReadValue("DBs", "Developement"); set => InitializeConfig.IniWriteValue("DBs", "Developement", value); }

        public string IP { get => InitializeConfig.IniReadValue("StudioServer", "IP"); set => InitializeConfig.IniWriteValue("StudioServer", "IP", value); }

        public string PatchFolderDirectory { get => InitializeConfig.IniReadValue("StudioServer", "PatchFolderDirectory"); set => InitializeConfig.IniWriteValue("StudioServer", "PatchFolderDirectory", value); }

        public string PatchFolderDirectory_Archiv { get => InitializeConfig.IniReadValue("StudioServer", "PatchFolderArchiv"); set => InitializeConfig.IniWriteValue("StudioServer", "PatchFolderArchiv", value); }

        public int Port { get => int.Parse(InitializeConfig.IniReadValue("StudioServer", "Port")); set => InitializeConfig.IniWriteValue("StudioServer", "Port", value.ToString()); }

        public string SQL_ConnectionString => $"Server={SQL_Host};database={DBDev};User ID={SQL_User};Password={SQL_Password};MultipleActiveResultSets=True";

        public string SQL_Host { get => InitializeConfig.IniReadValue("SQL", "Host"); set => InitializeConfig.IniWriteValue("SQL", "Host", value); }

        public string SQL_Password { get => InitializeConfig.IniReadValue("SQL", "Password"); set => InitializeConfig.IniWriteValue("SQL", "Password", value); }

        public string SQL_User { get => InitializeConfig.IniReadValue("SQL", "User"); set => InitializeConfig.IniWriteValue("SQL", "User", value); }

        public int Version { get => int.Parse(InitializeConfig.IniReadValue("StudioServer", "Version")); set => InitializeConfig.IniWriteValue("StudioServer", "Version", value.ToString()); }

        public bool InitializeSettings(out string msg)
        { return InitializeConfig.InitializeConfigFile(InitializeConfig.ConfigString, out msg); }
    }
}