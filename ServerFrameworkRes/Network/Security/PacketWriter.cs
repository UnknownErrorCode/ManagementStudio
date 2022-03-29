using System.IO;

namespace ServerFrameworkRes.Network.Security
{
    internal class PacketWriter : BinaryWriter
    {
        #region Public Constructors

        public PacketWriter() : base(new MemoryStream())
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public byte[] GetBytes()
        {
            return ((MemoryStream)base.OutStream).ToArray();
        }

        #endregion Public Methods
    }
}