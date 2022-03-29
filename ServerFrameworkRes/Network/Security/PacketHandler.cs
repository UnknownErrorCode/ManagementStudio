using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
    public class PacketHandler : IPacketHandler
    {
        #region Private Fields

        private readonly Dictionary<ushort, Func<ServerData, Packet, PacketHandlerResult>> PacketHandlerDictionary;

        #endregion Private Fields

        #region Public Constructors

        public PacketHandler()
        {
            PacketHandlerDictionary = new Dictionary<ushort, Func<ServerData, Packet, PacketHandlerResult>>();
        }

        #endregion Public Constructors

        #region Public Methods

        public void AddEntry(ushort opcode, Func<ServerData, Packet, PacketHandlerResult> func)
        {
            if (!PacketHandlerDictionary.ContainsKey(opcode))
            {
                PacketHandlerDictionary.Add(opcode, func);
            }
        }

        public async Task<PacketHandlerResult> HandlePacketAction(ServerData data, Packet packet)
        {
            if (PacketHandlerDictionary.ContainsKey(packet.Opcode))
            {
                return PacketHandlerDictionary[packet.Opcode](data, packet);
            }

            return PacketHandlerResult.Block; //Put to disconnect if done to avoid malicious packets
        }

        #endregion Public Methods
    }
}