using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Dashboard
{
    class REC_NEW_TOPICGUIDE
    {

        internal static Packet WriteNewTopic(Packet packet)
        {
            var author = packet.ReadAscii();
            var title = packet.ReadAscii();
            var text = packet.ReadAscii();
            var pathtitle = title.Replace("?", "_question_").Replace("`", "_appostroph_").Replace("´", "_appostroph_");
            var dir = Path.Combine(StudioServer.settings.GuidePath, author);
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
    }
}
