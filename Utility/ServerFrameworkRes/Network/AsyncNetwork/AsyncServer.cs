using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public class AsyncServer : AsyncBase
    {
        #region Fields

        private Socket socket;

        #endregion Fields

        #region Properties

        public bool IsConnected => socket == null ? false : socket.IsBound;
        #endregion
        #region Methods

        public void Accept(string host, int port, int outstanding, IAsyncInterface @interface)
        {
            Accept(host, port, outstanding, @interface, null);
        }

        public void Accept(string host, int port, int outstanding, IAsyncInterface @interface, object user)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (!IPAddress.TryParse(host, out IPAddress address))
            {
                IPHostEntry host_entry = Dns.GetHostEntry(host);
                address = host_entry.AddressList[0];
            }
            socket.Bind(new IPEndPoint(address, port));

            socket.Listen(outstanding);

            for (int x = 0; x < outstanding; ++x)
            {
                AsyncToken token = new AsyncToken
                {
                    Socket = socket,
                    User = user,
                    Interface = @interface
                };

                SocketAsyncEventArgs acceptEvtArgs = new SocketAsyncEventArgs
                {
                    UserToken = token
                };
                acceptEvtArgs.Completed += NetworkOnAccept;
                ProcessAccept(acceptEvtArgs);
            }
        }

        public void Stop()
        {
            try
            {
                socket?.Dispose();
            }
            catch (SocketException ex)
            {
                throw ex;
            }
        }

        private void DispatchAccept(object param)
        {
            SocketAsyncEventArgs e = (SocketAsyncEventArgs)param;

            NetworkOnAccept(null, e);
        }

        private void NetworkOnAccept(object sender, SocketAsyncEventArgs e)
        {
            AsyncToken token = (AsyncToken)e.UserToken;

            Socket socket = e.AcceptSocket;

            ProcessAccept(e); // Start the next accept asap.

            if (socket == null)
            {
                return; // Ignore errors because there is nothing to do
            }

            AsyncState state = new AsyncState(this, socket, AsyncOperation.Accept, token.Interface, token.User); // Now handle the current connection.

            bool result = false;
            try
            {
                result = state.Context.Interface.OnConnect(state.Context);
            }
            catch (Exception) { }
            if (!result)
            {
                try
                {
                    state.Context.Interface.OnError(state.Context, token.User); // Ensure the user can cleanup anything before the object dies
                }
                catch (Exception) { }

                state.Cleanup(); // Cleanup the socket

                return;
            }

            try
            {
                state.Read(); // Begin receiving data on the socket
            }
            catch (Exception)
            {
                state.Cleanup(); // Cleanup the object
                return;
            }

            AddState(state); // Store the state to keep it alive
        }

        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.OperationAborted)
            {
                AsyncToken token = (AsyncToken)e.UserToken;

                e.AcceptSocket = null;

                if (!token.Socket.AcceptAsync(e))
                {
                    ThreadPool.QueueUserWorkItem(DispatchAccept, e);
                }
            }
        }

        #endregion Methods
    }
}