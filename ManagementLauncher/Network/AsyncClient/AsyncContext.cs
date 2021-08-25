using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLauncher.Network.AsyncClient
{ 
    public class AsyncContext
    {
        public AsyncState State { get; set; }
        public Guid Guid { get { return guid; } }
        public IAsyncInterface Interface { get; set; }
        public object User { get; set; }

        private Guid guid;

        public AsyncContext()
        {
            guid = Guid.NewGuid();
        }

        public void Disconnect()
        {
            State.Disconnect();
        }

        public void Send(byte[] buffer)
        {
            State.Write(new AsyncBuffer(buffer));
        }

        public void Send(byte[] buffer, int offset, int count)
        {
            State.Write(new AsyncBuffer(buffer, offset, count));
        }
    }
}
