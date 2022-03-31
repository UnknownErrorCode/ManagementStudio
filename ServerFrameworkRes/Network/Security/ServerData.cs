namespace ServerFrameworkRes.Network.Security
{
    public class ServerData
    {
        #region Public Fields

        public string AccountName;
        public string UserIP;

        public byte[] m_certification_buffer;
        public bool m_connected;
        public SecurityManager m_security = new SecurityManager();

        #endregion Public Fields

        #region Public Constructors

        public ServerData()
        {
            m_connected = false;
        }

        #endregion Public Constructors
    }
}