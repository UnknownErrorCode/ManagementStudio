using System.Net.Sockets;

namespace ManagementLauncher.Network.AsyncClient
{
    public class AsyncToken
    {
        public Socket Socket { get; set; }
        public IAsyncInterface Interface { get; set; }
        public object User { get; set; }
    }
}
