using System.IO;

namespace ManagementFramework.Network.Security
{
    internal class PacketWriter : BinaryWriter
    {
        #region Constructors

        public PacketWriter() : base(new MemoryStream())
        {
        }

        #endregion Constructors

        #region Methods

        public byte[] GetBytes()
        {
            return ((MemoryStream)base.OutStream).ToArray();
        }

        #endregion Methods
    }
}