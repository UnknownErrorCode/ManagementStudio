using System.IO;

namespace ServerFrameworkRes.Network.Security
{
    internal class PacketReader : BinaryReader
    {
        #region Private Fields

        private readonly byte[] _input;

        #endregion Private Fields

        #region Public Constructors

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

        #endregion Public Constructors
    }
}