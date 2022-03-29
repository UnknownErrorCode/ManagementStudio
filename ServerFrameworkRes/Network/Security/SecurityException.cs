using System;
using System.Runtime.Serialization;

namespace ServerFrameworkRes.Network.Security
{
    public class SecurityException : Exception, ISerializable
    {
        #region Public Constructors

        public SecurityException()
        {
            // Add implementation.
        }

        public SecurityException(string message)
            : base(message)
        {
            // Add implementation.
        }

        public SecurityException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation.
        }

        #endregion Public Constructors

        #region Protected Constructors

        // This constructor is needed for serialization.
        protected SecurityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation.
        }

        #endregion Protected Constructors
    }
}