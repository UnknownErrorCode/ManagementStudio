using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
   public class ServerData
    {
        public bool m_connected;
        public SecurityManager m_security = new SecurityManager();
        public byte[] m_certification_buffer;
        public string AccountName; // obsolete
        public string UserIP; // obsolete
        public ServerData()
        {
            m_connected = false;
        }
    }
}
