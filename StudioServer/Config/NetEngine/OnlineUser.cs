using ServerFrameworkRes.Network.ServerBody;

namespace StudioServer.Config.NetEngine
{
    public class OnlineUser
    {
        #region Public Constructors

        public OnlineUser(string textName, string RealName, int cy)
        {
            OnlineUserSeries = new ISeries(textName, RealName, cy);
        }

        #endregion Public Constructors

        #region Public Properties

        public ISeries OnlineUserSeries { get; set; }
        public int UserCount => OnlineUserSeries.CurrentYValue;

        #endregion Public Properties
    }
}