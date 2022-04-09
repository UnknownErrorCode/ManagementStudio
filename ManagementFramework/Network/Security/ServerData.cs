namespace ManagementFramework.Network.Security
{
    public abstract class ServerData
    {
        #region Fields

        public string AccountName;
        public byte[] m_certification_buffer;
        public bool m_connected;
        public SecurityManager m_security = new SecurityManager();
        public string UserIP;

        #endregion Fields

        #region Constructors

        protected ServerData()
        {
            m_connected = false;
        }

        #endregion Constructors
    }
}