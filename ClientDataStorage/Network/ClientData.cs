using ServerFrameworkRes.Network.Security;

namespace ClientDataStorage.Network
{
    public class ClientData : ServerData
    {
        public ClientData() : base()
        {
            base.m_security.ChangeIdentity("Tool_Client", 1);
        }
    }
}