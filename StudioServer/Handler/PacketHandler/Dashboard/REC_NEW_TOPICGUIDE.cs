using ServerFrameworkRes.Network.Security;
using System;
using System.IO;

namespace StudioServer.Handler.PacketHandler.Dashboard
{
    internal class REC_NEW_TOPICGUIDE
    {
        #region Internal Methods

        internal static Packet WriteNewTopic(Packet packet)
        {
            string author = packet.ReadAscii();
            string title = packet.ReadAscii();
            string text = packet.ReadAscii();
            string pathtitle = title.Replace("?", "_question_").Replace("`", "_appostroph_").Replace("´", "_appostroph_");
            string dir = Path.Combine(StudioServer.settings.GuidePath, author);
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir).Create();
                }
                SingleTopic topic = new SingleTopic()
                { Author = author, Title = title, Text = text };
                File.AppendAllText(Path.Combine(dir, pathtitle + ".log"), text);
                ServerMembory.SendPacketToAllOnlineMember(OutgoingPackets.NewDashboardTopic(topic));
                ServerMembory.SendUpdateSuccessNoticeToAll($"Successfully added new Topic {title} ", author);
                return null;
            }
            catch (Exception ex)
            {
                return OutgoingPackets.FailNoticePlayer($"Failed to added new Topic {title} {ex.Message}");
            }
        }

        #endregion Internal Methods
    }
}