using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Utility
{
    internal class ServerClientData : ServerFrameworkRes.Network.Security.ServerData
    {
        //internal string AccountName; 
        //  internal string UserIP; 


        internal ServerClientData(string userIP, byte[] user) : base()
        {

            base.UserIP = userIP;
            base.m_connected = true;
            base.m_certification_buffer = user;
            base.m_security.GenerateSecurity(false, false, false);
        }
    }
}
