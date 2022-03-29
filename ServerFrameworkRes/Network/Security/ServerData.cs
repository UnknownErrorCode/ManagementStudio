namespace ServerFrameworkRes.Network.Security
{
    public class ServerData
    {
        #region Public Fields

        public string AccountName;
        public byte[] m_certification_buffer;
        public bool m_connected;
        public SecurityManager m_security = new SecurityManager();

        // obsolete
        public string UserIP;

        #endregion Public Fields

        #region Public Constructors

        // obsolete
        public ServerData()
        {
            m_connected = false;
        }

        #endregion Public Constructors
    }
}