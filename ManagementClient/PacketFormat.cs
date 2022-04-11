using ManagementFramework.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementClient
{
    internal static class PacketFormat
    {
        internal static Packet LoginRequest(string account, string pwnoMd5)
        {
            Packet packet = new Packet(PacketID.Client.Login);
            packet.WriteAscii(account);
            packet.WriteAscii(ManagementFramework.Utility.MD5Generator.MD5String(pwnoMd5));
            return packet;
        }
    }
}