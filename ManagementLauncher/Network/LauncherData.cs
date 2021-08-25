using ManagementLauncher.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLauncher.Network
{
    internal class LauncherData
    {
        public bool m_connected;
        public SecurityManager m_security = new SecurityManager();
        public byte[] m_certification_buffer;
        public string AccountName;

        internal LauncherData()
        {
            m_security.ChangeIdentity("Tool_Launcher", 1);
            m_connected = false;
        }
    }
}
