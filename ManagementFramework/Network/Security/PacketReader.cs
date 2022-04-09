using System.IO;

namespace ManagementFramework.Network.Security
{
    internal class PacketReader : BinaryReader
    {
        #region Fields

        private readonly byte[] _input;

        #endregion Fields

        #region Constructors

        public PacketReader(byte[] input)
            : base(new MemoryStream(input, false))
        {
            _input = input;
        }

        public PacketReader(byte[] input, int index, int count)
            : base(new MemoryStream(input, index, count, false))
        {
            _input = input;
        }

        #endregion Constructors
    }
}