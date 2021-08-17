using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Login
{
    class REQUEST_ONLINE_ACCOUNTS
    {
        /// <summary>
        /// Sends 0xA105 to the Client, containing all Online Users 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public static Packet NAMES(Packet packet)
        {
            var accnameTest = packet.ReadAscii();
            if (ServerMembory.UserOnline.ContainsKey(accnameTest))
            {
                packet = new Packet(0xA105);
                packet.WriteAscii(accnameTest);
                packet.WriteByte((byte)ServerMembory.UserOnline.Count);
                foreach (var item in ServerMembory.UserOnline)
                {
                    packet.WriteAscii(item.Key);
                }
            }
            else
            {
                packet = null;
            }
            return packet;
        }
    }
}
