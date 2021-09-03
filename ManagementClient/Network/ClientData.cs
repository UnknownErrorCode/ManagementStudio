using ServerFrameworkRes.Network.Security;

namespace ManagementClient.Network
{
    internal class ClientData : ServerData
    {
      

        internal string AccountName;
        internal ClientData() : base()
        {
            base.m_security.ChangeIdentity("Tool_Client", 1);
        }
    }
}