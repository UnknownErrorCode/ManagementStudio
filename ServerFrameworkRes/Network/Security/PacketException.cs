using System;
using System.Runtime.Serialization;

namespace ServerFrameworkRes.Network.Security
{
    [Serializable]
    public class PacketException : Exception
    {
        #region Public Constructors

        public PacketException()
        {
        }

        public PacketException(string message) : base(message)
        {
        }

        public PacketException(string message, Exception inner) : base(message, inner)
        {
        }

        #endregion Public Constructors

        #region Protected Constructors

        protected PacketException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        { }

        #endregion Protected Constructors
    }
}