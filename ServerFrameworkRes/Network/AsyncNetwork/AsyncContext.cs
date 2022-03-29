using System;

namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public class AsyncContext
    {
        #region Private Fields

        private Guid guid;

        #endregion Private Fields

        #region Public Constructors

        public AsyncContext()
        {
            guid = Guid.NewGuid();
        }

        #endregion Public Constructors

        #region Public Properties

        public Guid Guid => guid;

        public IAsyncInterface Interface { get; set; }
        public AsyncState State { get; set; }
        public object User { get; set; }

        #endregion Public Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}