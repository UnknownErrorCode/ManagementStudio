using System.IO;

namespace ManagementLauncher.Network.Security
{
    internal class PacketReader : BinaryReader
    {
        private readonly byte[] _input;

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
    }
}
