namespace ManagementServer.Network
{
    internal class ServerClientData : ServerFrameworkRes.Network.Security.ServerData
    {
        #region Fields

        internal byte SecurityGroup;

        #endregion Fields

        #region Constructors

        internal ServerClientData(string userIP, byte[] user) : base()
        {
            base.UserIP = userIP;
            base.m_connected = true;
            base.m_certification_buffer = user;
            base.m_security.GenerateSecurity(false, false, false);
        }

        #endregion Constructors
    }
}