using ServerFrameworkRes.Network.ServerBody;

namespace StudioServer.Config.NetEngine
{
    public class OnlineUser
    {
        public ISeries OnlineUserSeries { get; set; }
        public int UserCount => OnlineUserSeries.CurrentYValue;

        public OnlineUser(string textName, string RealName, int cy)
        {
            OnlineUserSeries = new ISeries(textName, RealName, cy);
        }


    }
}
