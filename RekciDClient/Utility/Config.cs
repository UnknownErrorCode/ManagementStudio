using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekciDClient.Utility
{
    internal class Config : ConfigLoader, ConfigInterface
    {
        public Config()
        {
            base.Initialize();
        }

        public string ClientDataPath() { return base.ConfigEditor.IniReadValue("Client", "Path"); }
        public string ClientIP() { return base.ConfigEditor.IniReadValue("Client", "IP"); }
        public int ClientPort() { return int.Parse(base.ConfigEditor.IniReadValue("Client", "Port")); }
        public string ClientVersion() { return base.ConfigEditor.IniReadValue("Client", "Version"); }
        public string ClientLocale() { return base.ConfigEditor.IniReadValue("Client", "Locale"); }
        public string ClientDivision() {return  base.ConfigEditor.IniReadValue("Client", "Division"); }
        public string ClientCaptcha() {return base.ConfigEditor.IniReadValue("Client", "Captcha"); }
        public string ClientShardID() {return base.ConfigEditor.IniReadValue("Client", "ShardID"); }


        public string ToolServerIP() { return  base.ConfigEditor.IniReadValue("ToolServer", "Host"); }
        public int ToolServerPort() { return  int.Parse(base.ConfigEditor.IniReadValue("ToolServer", "Port")); }
        public int ToolServerVersion() { return  int.Parse(base.ConfigEditor.IniReadValue("ToolServer", "Version")); }


        public bool ToolSaveUserData() { return  bool.Parse(base.ConfigEditor.IniReadValue("ToolClient", "SaveUserData")); }
        public string ToolUser() { return  base.ConfigEditor.IniReadValue("ToolClient", "User"); }
        public string ToolUserPassword() { return  base.ConfigEditor.IniReadValue("ToolClient", "ToolPassword"); }
        public bool ToolQuickLogin() { return  bool.Parse(base.ConfigEditor.IniReadValue("ToolClient", "QuickLogin")); }
        public bool ShowPwInText() { return bool.Parse(base.ConfigEditor.IniReadValue("ToolClient", "ShowPW"));  }
        public string ClientExtracted() { return base.ConfigEditor.IniReadValue("ToolClient", "StudioRessources"); }


    }
}
