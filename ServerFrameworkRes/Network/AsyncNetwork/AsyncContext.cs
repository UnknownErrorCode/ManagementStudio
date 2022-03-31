using System;

namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public class AsyncContext
    {
        #region Fields

        private Guid guid;

        #endregion Fields

        #region Constructors

        public AsyncContext()
        {
            guid = Guid.NewGuid();
        }

        #endregion Constructors

        #region Properties

        public Guid Guid => guid;

        public IAsyncInterface Interface { get; set; }
        public AsyncState State { get; set; }
        public object User { get; set; }

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}