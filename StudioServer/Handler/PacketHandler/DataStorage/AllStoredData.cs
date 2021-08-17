using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.DataStorage
{
    internal static class AllStoredData
    {
        /// <summary>
        /// Returns Packet 0x3099 with all FileTitles
        /// </summary>
        /// <returns></returns>
        internal static Packet SendAllStoredDataStrings()
        {
            return OutgoingPackets.AllStoredDataTitles();
        }
        /// <summary>
        /// Returns Packet 0x3098 with File inside, or null!
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        internal static Packet SendSingleData(Packet opcode)
        {
            var requestedFileName = opcode.ReadAscii();
            var FilePath = Path.Combine(Worker.DataStorage.DataStoragePath, requestedFileName);

            if (Worker.DataStorage.Contains(requestedFileName))
            {
                return OutgoingPackets.SingleStoredData(requestedFileName,File.ReadAllBytes(FilePath));
            }
            return new Packet(0x3098);
        }
    }
}
