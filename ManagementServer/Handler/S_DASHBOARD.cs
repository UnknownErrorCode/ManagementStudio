using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Handler
{
    class S_DASHBOARD
    {
        /// <summary>
        /// Sends 0xC001 with guides and 0xC003 on successful transfer
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal static PacketHandlerResult LoadTopics(ServerData arg1, Packet arg2)
        {
            if (!Directory.Exists(ServerManager.settings.GuidePath))
                Directory.CreateDirectory(ServerManager.settings.GuidePath);

            foreach (var dir in Directory.GetDirectories(ServerManager.settings.GuidePath, "*", SearchOption.TopDirectoryOnly))
                foreach (var file in Directory.GetFiles(dir, "*.log", SearchOption.TopDirectoryOnly))
                {
                    string title = file.Remove(0, dir.Length + 1).Replace(".log", "").Replace("_question_", "?").Replace("_appostroph_", "`");
                    string text = File.ReadAllText(file);
                    var author = dir.Remove(0, ServerManager.settings.GuidePath.Length + 1);
                    var topicPack = new Packet(0xC001);
                    topicPack.WriteAscii(author);
                    topicPack.WriteAscii(title);
                    topicPack.WriteAscii(text);
                    arg1.m_security.Send(topicPack);
                }

            arg1.m_security.Send(new Packet(0xC003));
            return PacketHandlerResult.Block;
        }
        /// <summary>
        /// Broadcasts  0xC002 to each client in order to append new Topic on runtime
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal static PacketHandlerResult TryAddNewTopic(ServerData arg1, Packet arg2)
        {
            var Author = arg2.ReadAscii();
            var Title = arg2.ReadAscii();
            var Text = arg2.ReadAscii();
            var created = arg2.ReadDateTime();

            if (!Directory.Exists(Path.Combine(ServerManager.settings.GuidePath, Author)))
                Directory.CreateDirectory(Path.Combine(ServerManager.settings.GuidePath, Author)).Create();

            if (!File.Exists(Path.Combine(ServerManager.settings.GuidePath, Author,$"{Title}.log")))
                File.AppendAllText(Path.Combine(ServerManager.settings.GuidePath, Author, $"{Title}.log"), $"{Title}\n\n{Text}\n\nCreated:{created.ToString()}\n\n Author:{Author}");

            var newTopic = new Packet(0xC002);
            newTopic.WriteAscii(Author);
            newTopic.WriteAscii(Title);
            newTopic.WriteAscii(Text);
            ServerMemory.BroadcastPacket(newTopic);

            return PacketHandlerResult.Response;
        }

        /// <summary>
        /// Broadcasts 0xC004 to each client to delete a topic on runtime.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal static PacketHandlerResult DeleteTopic(ServerData arg1, Packet arg2)
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

                var deleteTopic = new Packet(0xC004);
                deleteTopic.WriteAscii(Author);
                deleteTopic.WriteAscii(Title);
                deleteTopic.WriteAscii(arg1.AccountName);
                ServerMemory.BroadcastPacket(deleteTopic);
            }

            return PacketHandlerResult.Block;
        }
    }
}
