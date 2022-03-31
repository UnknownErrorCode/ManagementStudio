namespace ServerFrameworkRes.Network.Security
{
    public class ServerData
    {
        #region Fields

        public string AccountName;
        public byte[] m_certification_buffer;
        public bool m_connected;
        public SecurityManager m_security = new SecurityManager();
        public string UserIP;

        #endregion Fields

        #region Constructors

        public ServerData()
        {
            m_connected = false;
        }

        #endregion Constructors
    }
}