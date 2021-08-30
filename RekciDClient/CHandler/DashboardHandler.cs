using ClientDataStorage.Dashboard;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementClient.CHandler
{
    class DashboardHandler
    {

        internal static PacketHandlerResult LoadTopicRequest(ServerData arg1, Packet arg2)
        {
            var author = arg2.ReadAscii();
            var title = arg2.ReadAscii();
            var text = arg2.ReadAscii();

            DashboardMessage msg = new DashboardMessage()
            {
                Author = author,
                Title = title,
                Text = text
            };
            if (!DashboardMemory.TopicDictionary.ContainsKey(msg.Title))
                DashboardMemory.TopicDictionary.Add(msg.Title, msg);

            DashboardMemory.ChangesAviable = true;

            return PacketHandlerResult.Block;
        }

        internal static PacketHandlerResult NewTopicRequest(ServerData arg1, Packet arg2)
        {
            var author = arg2.ReadAscii();
            var title = arg2.ReadAscii();
            var text = arg2.ReadAscii();

            DashboardMessage msg = new DashboardMessage()
            {
                Author = author,
                Title = title,
                Text = text
            };
            if (!DashboardMemory.TopicDictionary.ContainsKey(msg.Title))
                DashboardMemory.TopicDictionary.Add(msg.Title, msg);

            DashboardMemory.ChangesAviable = true;

            ClientForm.Logger.WriteLogLine($"User: {author} added new Topic:{title} to dashboard!");
            return PacketHandlerResult.Block;
        }


        internal static  PacketHandlerResult FinishedLoadingTopics(ServerData arg1, Packet arg2)
        {
            ClientForm.Logger.WriteLogLine($"Successfully load {DashboardMemory.TopicDictionary.Count} topics to dashboard!");
            return PacketHandlerResult.Block;
        }


        internal static PacketHandlerResult DeleteTopic(ServerData arg1, Packet arg2)
        {
            var Author = arg2.ReadAscii();
            var Title = arg2.ReadAscii();
            var Remover = arg2.ReadAscii();

            if (DashboardMemory.TopicDictionary.ContainsKey(Title))
                DashboardMemory.TopicDictionary.Remove(Title);

            DashboardMemory.ChangesAviable = true;
            ClientForm.Logger.WriteLogLine($"{Remover} successfully deleted topic: {Title} from {Author}!");
            return PacketHandlerResult.Block;
        }
    }
}
