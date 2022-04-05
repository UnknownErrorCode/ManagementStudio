using System;
using System.Net;
using System.Net.Sockets;

namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public class AsyncClient : AsyncBase
    {
        #region Methods

        public bool TryConnect(string host, int port, IAsyncInterface @interface, object data)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (!IPAddress.TryParse(host, out IPAddress address))
            {
                IPHostEntry host_entry = Dns.GetHostEntry(host);
                address = host_entry.AddressList[0];
            }

            AsyncToken token = new AsyncToken
            {
                Socket = socket,
                User = data,
                Interface = @interface
            };

            SocketAsyncEventArgs connectEvtArgs = new SocketAsyncEventArgs
            {
                UserToken = token
            };
            //connectEvtArgs.Completed += NetworkOnConnect;
            connectEvtArgs.RemoteEndPoint = new IPEndPoint(address, port);
            connectEvtArgs.Completed += NetworkOnConnect;

            return TryProcessConnect(connectEvtArgs);

        }

        public void Connect(string host, int port, IAsyncInterface @interface, object user)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (!IPAddress.TryParse(host, out IPAddress address))
            {
                IPHostEntry host_entry = Dns.GetHostEntry(host);
                address = host_entry.AddressList[0];
            }

            AsyncToken token = new AsyncToken
            {
                Socket = socket,
                User = user,
                Interface = @interface
            };

            SocketAsyncEventArgs connectEvtArgs = new SocketAsyncEventArgs
            {
                UserToken = token
            };
            connectEvtArgs.Completed += NetworkOnConnect;
            connectEvtArgs.RemoteEndPoint = new IPEndPoint(address, port);
            ProcessConnect(connectEvtArgs);
        }

        private void NetworkOnConnect(object sender, SocketAsyncEventArgs e)
        {
            AsyncToken token = (AsyncToken)e.UserToken;

            Socket socket = e.ConnectSocket;

            if (socket == null) // The connection failed
            {
                token.Interface.OnError(null, token.User); // There is no state object yet, so pass the user object
                return;
            }

            AsyncState state = new AsyncState(this, socket, AsyncOperation.Connect, token.Interface, token.User); // Now handle the current connection.

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

                state.Cleanup(); // Cleanup the object
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


        private bool TryNetworkOnConnect(object sender, SocketAsyncEventArgs e)
        {
            AsyncToken token = (AsyncToken)e.UserToken;

            Socket socket = e.ConnectSocket;

            if (socket == null) // The connection failed
            {
                token.Interface.OnError(null, token.User); // There is no state object yet, so pass the user object
                return false;
            }

            AsyncState state = new AsyncState(this, socket, AsyncOperation.Connect, token.Interface, token.User); // Now handle the current connection.

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

                state.Cleanup(); // Cleanup the object
                return false;
            }

            try
            {
                state.Read(); // Begin receiving data on the socket
            }
            catch (Exception)
            {
                state.Cleanup(); // Cleanup the object
                return false;
            }

            AddState(state); // Store the state to keep it alive
            return result;
        }



        private void ProcessConnect(SocketAsyncEventArgs e)
        {
            AsyncToken token = (AsyncToken)e.UserToken;

            if (!token.Socket.ConnectAsync(e))
            {
                NetworkOnConnect(null, e);
            }
        }

        private bool TryProcessConnect(SocketAsyncEventArgs e)
        {
            AsyncToken token = (AsyncToken)e.UserToken;

            if (!token.Socket.ConnectAsync(e))
            {
               NetworkOnConnect(null, e);
                return false;
            }
            return true;
        }

        #endregion Methods
    }
}