using System;
using System.IO;
using ServerFrameworkRes.Network.Security;
using StudioServer.Handler.PacketHandler.Dashboard;

namespace StudioServer.Handler.PacketHandler.Login
{
    internal class REQUEST_ALL_GUIDES
    {
        private static string GuidePath { get => StudioServer.settings.GuidePath; }
        internal static Packet GetFromDirectory(SecurityManager data)
        {
            if (!Directory.Exists(GuidePath)) 
            {
                Directory.CreateDirectory(GuidePath);
            }

            foreach (var dir in Directory.GetDirectories(GuidePath,"*",SearchOption.TopDirectoryOnly))
            {
                foreach (var file in Directory.GetFiles(dir, "*.log", SearchOption.TopDirectoryOnly))
                {
                    string Topic = file.Remove(0, dir.Length + 1).Replace(".log","").Replace("_question_","?").Replace("_appostroph_","`");
                    string AllText = File.ReadAllText(file);
                    var author = dir.Remove(0, GuidePath.Length + 1);
                    SingleTopic singleTopic = new SingleTopic()
                    { Author = author, Title = Topic, Text = AllText };
                    data.Send(OutgoingPackets.AllDashboardSections(singleTopic));
                }
            }
         
            return null; //TODO Guides sent rdy approve
        }
    }
}