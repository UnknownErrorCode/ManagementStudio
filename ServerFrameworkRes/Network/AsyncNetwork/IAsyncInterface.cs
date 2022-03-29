using ServerFrameworkRes.Network.AsyncNetwork;

namespace ServerFrameworkRes
{
    public interface IAsyncInterface
    {
        #region Public Methods

        bool OnConnect(AsyncContext context);

        void OnDisconnect(AsyncContext context);

        void OnError(AsyncContext context, object user);

        bool OnReceive(AsyncContext context, byte[] buffer, int count);

        void OnTick(AsyncContext context);

        #endregion Public Methods
    }
}