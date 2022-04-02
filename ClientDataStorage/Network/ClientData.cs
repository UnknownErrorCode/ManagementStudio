using ServerFrameworkRes.Network.Security;

namespace ClientFrameworkRes.Network
{
    public class ClientData : ServerData
    {
        #region Constructors

        public ClientData() : base()
        {
            base.m_security.ChangeIdentity("Tool_Client", 1);
        }

        #endregion Constructors
    }
}