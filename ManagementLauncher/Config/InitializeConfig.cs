using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLauncher.Config
{
    class InitializeConfig
    {
        internal static readonly string ConfigString = "Config/LauncherInfo.ini";
        internal static InitializeFile ConfigFile = new InitializeFile(ConfigString);
        
        internal protected string HostIP { get => GetHostIP(); }
        internal protected ushort HostPort { get => GetHostPort(); }
        internal protected int Version { get => GetVersion(); }

        internal InitializeConfig()
        {
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Config")))
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Config")).Create();

            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), ConfigString)))
            {
                File.Create(Path.Combine(Directory.GetCurrentDirectory(), ConfigString)).Close();

                ConfigFile.IniWriteValue("ToolServer", "Host", "127.0.0.1");
                ConfigFile.IniWriteValue("ToolServer", "Port", "15755");
                ConfigFile.IniWriteValue("ToolServer", "Version", "1");
            }
        }

        private string GetHostIP()
        {
            try
            {
                return ConfigFile.IniReadValue("ToolServer", "Host");
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private ushort GetHostPort()
        {
            try
            {
                if (ushort.TryParse(ConfigFile.IniReadValue("ToolServer", "Port"), out ushort port))
                    return port;
            }
            catch (Exception ex)
            {
            }
            return 0;
        }

        private int GetVersion()
        {
            try
            {
                if (int.TryParse(ConfigFile.IniReadValue("ToolServer", "Version"), out int ver))
                    return ver;
            }
            catch (Exception ex)
            {
            }
            return 0;
        }
    }
}
