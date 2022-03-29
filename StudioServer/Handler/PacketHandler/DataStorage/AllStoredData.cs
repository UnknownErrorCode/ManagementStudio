using ServerFrameworkRes.Network.Security;
using System.IO;

namespace StudioServer.Handler.PacketHandler.DataStorage
{
    internal static class AllStoredData
    {
        #region Internal Methods

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
            string requestedFileName = opcode.ReadAscii();
            string FilePath = Path.Combine(Worker.DataStorage.DataStoragePath, requestedFileName);

            if (Worker.DataStorage.Contains(requestedFileName))
            {
                return OutgoingPackets.SingleStoredData(requestedFileName, File.ReadAllBytes(FilePath));
            }
            return new Packet(0x3098);
        }

        #endregion Internal Methods
    }
}