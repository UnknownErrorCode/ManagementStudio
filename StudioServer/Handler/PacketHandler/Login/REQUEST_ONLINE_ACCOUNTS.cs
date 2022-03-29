using ServerFrameworkRes.Network.Security;
using System.Collections.Generic;

namespace StudioServer.Handler.PacketHandler.Login
{
    internal class REQUEST_ONLINE_ACCOUNTS
    {
        #region Public Methods

        /// <summary>
        /// Sends 0xA105 to the Client, containing all Online Users
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public static Packet NAMES(Packet packet)
        {
            string accnameTest = packet.ReadAscii();
            if (ServerMembory.UserOnline.ContainsKey(accnameTest))
            {
                packet = new Packet(0xA105);
                packet.WriteAscii(accnameTest);
                packet.WriteByte((byte)ServerMembory.UserOnline.Count);
                foreach (KeyValuePair<string, ServerData> item in ServerMembory.UserOnline)
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

        #endregion Public Methods
    }
}