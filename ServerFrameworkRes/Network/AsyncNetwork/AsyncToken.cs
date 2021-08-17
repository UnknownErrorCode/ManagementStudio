using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public class AsyncToken
    {
        public Socket Socket { get; set; }
        public IAsyncInterface Interface { get; set; }
        public object User { get; set; }
    }
}
