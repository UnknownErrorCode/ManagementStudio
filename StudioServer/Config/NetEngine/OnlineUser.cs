using ServerFrameworkRes.Network.ServerBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Config.NetEngine
{
    public class OnlineUser 
    {
        public ISeries OnlineUserSeries { get; set; }
        public int UserCount { get => OnlineUserSeries.CurrentYValue; }

        public OnlineUser(string textName, string RealName, int cy)
        {
            OnlineUserSeries = new ISeries(textName, RealName, cy);
        }


    }
}
