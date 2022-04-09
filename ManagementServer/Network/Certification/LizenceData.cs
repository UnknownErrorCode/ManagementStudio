using ManagementFramework.Network.Security;

namespace ManagementServer.Network
{
    public class LizenceData : ServerData
    {
        #region Constructors

        public LizenceData() : base()
        {
            base.m_security.ChangeIdentity("Tool_Server", 1);
        }

        #endregion Constructors
    }
}