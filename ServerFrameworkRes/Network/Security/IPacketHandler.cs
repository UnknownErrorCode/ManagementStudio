using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
    public interface IPacketHandler
    {
        Task<PacketHandlerResult> HandlePacketAction(ServerData data, Packet packet);
    }
}
