using ManagementFramework.Network.AsyncNetwork;

namespace ManagementFramework
{
    public interface IAsyncInterface
    {
        #region Methods

        bool OnConnect(AsyncContext context);

        void OnDisconnect(AsyncContext context);

        void OnError(AsyncContext context, object user);

        bool OnReceive(AsyncContext context, byte[] buffer, int count);

        void OnTick(AsyncContext context);

        #endregion Methods
    }
}