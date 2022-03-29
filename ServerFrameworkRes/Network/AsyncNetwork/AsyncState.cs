using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public class AsyncState
    {
        #region Private Fields

        private readonly AsyncOperation m_operation;
        private readonly byte[] m_read_buffer;
        private readonly SocketAsyncEventArgs m_read_event_args;
        private readonly AsyncBase m_server;
        private readonly Socket m_socket;
        private readonly Queue<AsyncBuffer> m_write_buffers;
        private readonly SocketAsyncEventArgs m_write_event_args;
        private AsyncBuffer m_current_write_buffer;

        #endregion Private Fields

        #region Public Constructors

        public AsyncState(AsyncBase server, Socket socket, AsyncOperation operation, IAsyncInterface interface_, object user)
        {
            m_server = server;
            m_socket = socket;
            m_operation = operation;

            m_current_write_buffer = null;

            m_read_buffer = new byte[8192];

            m_read_event_args = new SocketAsyncEventArgs();
            m_read_event_args.Completed += OnIO;
            m_read_event_args.UserToken = this;
            m_read_event_args.SetBuffer(m_read_buffer, 0, m_read_buffer.Length);

            m_write_event_args = new SocketAsyncEventArgs();
            m_write_event_args.Completed += OnIO;
            m_write_event_args.UserToken = this;

            m_write_buffers = new Queue<AsyncBuffer>();

            Context = new AsyncContext
            {
                State = this,
                User = user,
                Interface = interface_
            };
        }

        #endregion Public Constructors

        #region Public Properties

        public AsyncContext Context { get; set; }

        public EndPoint EndPoint => m_socket.RemoteEndPoint;

        public AsyncOperation Operation => m_operation;

        #endregion Public Properties

        #region Internal Methods

        internal void Cleanup()
        {
            try
            {
                m_socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception) { }

            try
            {
                m_socket.Close();
            }
            catch (Exception) { }
        }

        internal void Disconnect()
        {
            try
            {
                m_socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception) { }
        }

        internal void Read()
        {
            if (!m_socket.ReceiveAsync(m_read_event_args))
            {
                ProcessRecv(m_read_event_args);
            }
        }

        internal void Write(AsyncBuffer buffer)
        {
            lock (m_write_buffers)
            {
                m_write_buffers.Enqueue(buffer); // Save the buffer

                CheckWrite(); // Perform the logic to check for the next write. NOTE: This stays inside the lock to keep FIFO order.
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private void CheckWrite()
        {
            lock (m_write_buffers)
            {
                if (m_current_write_buffer == null) // If no write is in progress
                {
                    if (m_write_buffers.Count > 0) // There is pending data
                    {
                        m_current_write_buffer = m_write_buffers.Dequeue(); // Get the next buffer

                        m_write_event_args.SetBuffer(m_current_write_buffer.Buffer, m_current_write_buffer.Offset, m_current_write_buffer.Count); // Setup the async write

                        DispatchWrite(); // Begin the write
                    }
                }
            }
        }

        private void DispatchWrite()
        {
            if (!m_socket.SendAsync(m_write_event_args)) // Attempt the write
            {
                ProcessSend(m_write_event_args); // It completed immediately, we must manually invoke the handler
            }
        }

        private void OnIO(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    {
                        ProcessRecv(e);
                    }
                    break;

                case SocketAsyncOperation.Send:
                    {
                        ProcessSend(e);
                    }
                    break;

                default:
                    throw new NotImplementedException("The code will only handle send and receive operations.");
            }
        }

        private bool ProcessRead(SocketAsyncEventArgs e)
        {
            try
            {
                if (e.BytesTransferred <= 0 || e.SocketError != SocketError.Success)
                {
                    try
                    {
                        Context.Interface.OnDisconnect(Context);
                    }
                    catch (Exception) { }
                    Cleanup();
                    return false;
                }

                bool result = false;
                try
                {
                    result = Context.Interface.OnReceive(Context, m_read_buffer, e.BytesTransferred);
                }
                catch (Exception) { }

                if (!result)
                {
                    try
                    {
                        Context.Interface.OnDisconnect(Context);
                    }
                    catch (Exception) { }
                    Cleanup();
                    return false;
                }

                Read();
            }
            catch (Exception)
            {
                Cleanup();
                return false;
            }
            return true;
        }

        private void ProcessRecv(SocketAsyncEventArgs e)
        {
            AsyncState state = e.UserToken as AsyncState;

            if (state.ProcessRead(e))
            {
                return;
            }

            m_server.RemoveState(this);
        }

        private void ProcessSend(SocketAsyncEventArgs e)
        {
            AsyncState state = e.UserToken as AsyncState;

            if (state.ProcessWrite(e))
            {
                return;
            }

            m_server.RemoveState(this);
        }

        private bool ProcessWrite(SocketAsyncEventArgs e)
        {
            try
            {
                if (e.BytesTransferred <= 0 || e.SocketError != SocketError.Success) // Check for errors
                {
                    try
                    {
                        Context.Interface.OnDisconnect(Context);
                    }
                    catch (Exception) { }
                    Cleanup();
                    return false;
                }

                lock (m_write_buffers)
                {
                    m_current_write_buffer.Offset += e.BytesTransferred; // Update index
                    m_current_write_buffer.Count -= e.BytesTransferred; // Update count

                    if (m_current_write_buffer.Count > 0) // If there is data left to be sent
                    {
                        m_write_event_args.SetBuffer(m_current_write_buffer.Offset, m_current_write_buffer.Count); // Setup the next async write
                        DispatchWrite(); // Begin the next write
                        return true; // Everything is fine
                    }

                    m_current_write_buffer = null; // Clear out the last write object
                    CheckWrite(); // Perform the logic to check for the next write
                }
            }
            catch (Exception)
            {
                Cleanup();
                return false;
            }
            return true; // Everything is fine
        }

        #endregion Private Methods
    }
}