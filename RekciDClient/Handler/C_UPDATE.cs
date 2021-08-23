using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace RekciDClient.Handler
{
    internal class C_UPDATE
    {
        /// <summary>
        /// CLIENT_UPDATE_REQUEST -- 0x1001 -- Client request missing files from Server
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="clientVersion"></param>
        /// <returns></returns>
        internal static Packet RequestFiles(ServerData arg1, int clientVersion)
        {
            Packet requestUpdate = new Packet(0x1001);
            requestUpdate.WriteInt(clientVersion);

            return requestUpdate;
        }


        internal static bool ReceiveFile(Packet packet)
        {
            var cversion = packet.ReadInt();
            var fileName = packet.ReadAscii();
            var fileDire = packet.ReadAscii();
            var cBinaryF = packet.ReadByteArray(packet.Remaining);


            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire)))
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), fileDire));

            //if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)))
            File.Create(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)).Write(cBinaryF, 0, cBinaryF.Length);

            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)))
                return true;

            return false;
        }
    }
}
