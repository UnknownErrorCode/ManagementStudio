using ServerFrameworkRes.Network.Security;
using System.IO;

namespace StudioServer.Handler.PacketHandler.Dashboard
{
    internal class DELETE_TOPIC
    {
        internal static Packet DELETE(Packet opcode)
        {
            SingleTopic t = new SingleTopic()
            {
                Author = opcode.ReadAscii(),
                Title = opcode.ReadAscii(),
                Text = opcode.ReadAscii()
            };
            string fileName = Path.Combine(StudioServer.settings.GuidePath, t.Author, $"{t.Title}.log");
            if (File.Exists(fileName))
            {
                if (!Directory.Exists(Path.Combine(StudioServer.settings.DeletedGuidePath, t.Author)))
                {
                    Directory.CreateDirectory(Path.Combine(StudioServer.settings.DeletedGuidePath, t.Author)).Create();
                }
                File.Copy(fileName, Path.Combine(StudioServer.settings.DeletedGuidePath, t.Author, $"{t.Title}.log"), true);
                File.Delete(fileName);
            }
            ServerMembory.SendPacketToAllOnlineMember(OutgoingPackets.DeleteDashboardTopic("Topic Guide successfully removed!", t));

            return null;
        }
    }
}