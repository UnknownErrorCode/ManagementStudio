namespace ManagementCertification.Network
{
    internal class ServerLizenceData : ManagementFramework.Network.Security.ServerData
    {

        internal byte LizenceGroup;

        internal ServerLizenceData(string userIP, byte[] user) : base()
        {
            base.UserIP = userIP;
            base.m_connected = true;
            base.m_certification_buffer = user;
            base.m_security.GenerateSecurity(false, false, false);
        }

    }
}