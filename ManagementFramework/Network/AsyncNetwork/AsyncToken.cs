using System.Net.Sockets;

namespace ManagementFramework.Network.AsyncNetwork
{
    public class AsyncToken
    {
        #region Properties

        public IAsyncInterface Interface { get; set; }
        public Socket Socket { get; set; }
        public object User { get; set; }

        #endregion Properties
    }
}