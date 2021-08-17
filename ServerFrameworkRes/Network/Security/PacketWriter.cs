using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
    internal class PacketWriter : BinaryWriter
    {
        public PacketWriter() : base(new MemoryStream())
        {
        }

        public byte[] GetBytes()
        {
            return ((MemoryStream)base.OutStream).ToArray();
        }
    }
}
