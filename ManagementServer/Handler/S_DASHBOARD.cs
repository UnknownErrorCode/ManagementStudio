using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System.IO;

namespace ManagementServer.Network
{
    partial class ServerPacketHandler
    {
        /// <summary>
        /// Sends <see cref="PacketID.Server.TopicLoadRequest"/> with guides and <see cref="PacketID.Server.TopicsEndLoading"/> on successful transfer
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal PacketHandlerResult LoadTopics(ServerData arg1, Packet arg2)
        {
            if (!Directory.Exists(ServerManager.settings.GuidePath))
                Directory.CreateDirectory(ServerManager.settings.GuidePath);

            foreach (var dir in Directory.GetDirectories(ServerManager.settings.GuidePath, "*", SearchOption.TopDirectoryOnly))
                foreach (var file in Directory.GetFiles(dir, "*.log", SearchOption.TopDirectoryOnly))
                {
                    string title = file.Remove(0, dir.Length + 1).Replace(".log", "").Replace("_question_", "?").Replace("_appostroph_", "`");
                    string text = File.ReadAllText(file);
                    var author = dir.Remove(0, ServerManager.settings.GuidePath.Length + 1);
                    var topicPack = new Packet(PacketID.Server.TopicLoadRequest);
                    var msg = new DashboardMessage(title, text, author);
                    topicPack.WriteStruct(msg);
                    arg1.m_security.Send(topicPack);
                }

            arg1.m_security.Send(new Packet(PacketID.Server.TopicsEndLoading));
            return PacketHandlerResult.Block;
        }
        /// <summary>
        /// Broadcasts  0xC002 to each client in order to append new Topic on runtime
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal PacketHandlerResult TryAddNewTopic(ServerData arg1, Packet arg2)
        {
            var msg = arg2.ReadStruct<DashboardMessage>();
           
            if (!Directory.Exists(Path.Combine(ServerManager.settings.GuidePath, msg.Author)))
                Directory.CreateDirectory(Path.Combine(ServerManager.settings.GuidePath, msg.Author)).Create();

            if (!File.Exists(Path.Combine(ServerManager.settings.GuidePath, msg.Author, $"{msg.Title}.log")))
                File.AppendAllText(Path.Combine(ServerManager.settings.GuidePath, msg.Author, $"{msg.Title}.log"), $"{msg.Title}\n\n{msg.Text}\n\nCreated:{System.DateTime.Now}\n\n Author:{msg.Author}");

           
            ServerMemory.BroadcastPacket(PacketConstructors.TopicPacket.AddNew(msg));

            return PacketHandlerResult.Response;
        }

        /// <summary>
        /// Response to <see cref="PacketID.Client.TopicDeleteRequest"/>
        /// Broadcasts 0xC004 to each client to delete a topic on runtime.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal  PacketHandlerResult DeleteTopic(ServerData arg1, ServerFrameworkRes.Network.Security.Packet arg2)
        {
            var Author = arg2.ReadAscii();
            var Title = arg2.ReadAscii();
            var fileName = Path.Combine(ServerManager.settings.GuidePath, Author, $"{Title}.log");
            if (File.Exists(fileName))
            {
                if (!Directory.Exists(Path.Combine(ServerManager.settings.DeletedGuidePath, Author)))
                    Directory.CreateDirectory(Path.Combine(ServerManager.settings.DeletedGuidePath, Author)).Create();

                File.Copy(fileName, Path.Combine(ServerManager.settings.DeletedGuidePath, Author, $"{Title}.log"), true);
                File.Delete(fileName);

                var deleteTopic = new Packet(PacketID.Server.TopicDeleteResponse);
                deleteTopic.WriteAscii(Author);
                deleteTopic.WriteAscii(Title);
                deleteTopic.WriteAscii(arg1.AccountName);
                ServerMemory.BroadcastPacket(deleteTopic);
            }

            return PacketHandlerResult.Block;
        }
    }
}
