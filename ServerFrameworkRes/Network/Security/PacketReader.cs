using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
    internal class PacketReader : BinaryReader
    {
        private byte[] _input;

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
