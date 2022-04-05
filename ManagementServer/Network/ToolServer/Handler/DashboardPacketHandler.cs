using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System.IO;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        #region Methods

        /// <summary>
        /// Broadcasts  0xC002 to each client in order to append new Topic on runtime
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal PacketHandlerResult AddNewTopic(ServerData arg1, Packet arg2)
        {
            DashboardMessage msg = arg2.ReadStruct<DashboardMessage>();

            Directory.CreateDirectory(Path.Combine(ServerManager.settings.GuidePath, msg.Author)).Create();

            if (!File.Exists(Path.Combine(ServerManager.settings.GuidePath, msg.Author, $"{msg.Title}.log")))
            {
                File.AppendAllText(Path.Combine(ServerManager.settings.GuidePath, msg.Author, $"{msg.Title}.log"), $"{msg.Title}\n\n{msg.Text}\n\nCreated:{System.DateTime.Now}\n\n Author:{msg.Author}");
            }

            ServerMemory.BroadcastPacket(PacketConstructors.TopicPacket.AddNew(msg));

            return PacketHandlerResult.Response;
        }

        /// <summary>
        /// Response to <see cref="PacketID.Client.TopicDeleteRequest"/>
        /// <br>Broadcasts <see cref="PacketID.Server.TopicDeleteResponse"/> to each client to delete a topic on runtime.</br>
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal PacketHandlerResult DeleteTopic(ServerData arg1, Packet arg2)
        {
            string Author = arg2.ReadAscii();
            string Title = arg2.ReadAscii();
            string fileName = Path.Combine(ServerManager.settings.GuidePath, Author, $"{Title}.log");
            if (File.Exists(fileName))
            {
                if (!Directory.Exists(Path.Combine(ServerManager.settings.DeletedGuidePath, Author)))
                {
                    Directory.CreateDirectory(Path.Combine(ServerManager.settings.DeletedGuidePath, Author)).Create();
                }

                File.Copy(fileName, Path.Combine(ServerManager.settings.DeletedGuidePath, Author, $"{Title}.log"), true);
                File.Delete(fileName);

                Packet deleteTopic = new Packet(PacketID.Server.TopicDeleteResponse);
                deleteTopic.WriteAscii(Author);
                deleteTopic.WriteAscii(Title);
                deleteTopic.WriteAscii(arg1.AccountName);
                ServerMemory.BroadcastPacket(deleteTopic);
            }

            return PacketHandlerResult.Block;
        }

        internal PacketHandlerResult EditTopic(ServerData arg1, Packet arg2)
        {
            DashboardMessage msg = arg2.ReadStruct<DashboardMessage>();
            DashboardMessage msgnew = arg2.ReadStruct<DashboardMessage>();

            string fileName = Path.Combine(ServerManager.settings.GuidePath, msg.Author, $"{msg.Title}.log");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            if (!Directory.Exists(Path.Combine(ServerManager.settings.GuidePath, msg.Author)))
            {
                Directory.CreateDirectory(Path.Combine(ServerManager.settings.GuidePath, msg.Author)).Create();
            }

            if (!File.Exists(Path.Combine(ServerManager.settings.GuidePath, msg.Author, $"{msg.Title}.log")))
            {
                File.AppendAllText(Path.Combine(ServerManager.settings.GuidePath, msg.Author, $"{msgnew.Title}.log"), $"{msgnew.Title}\n\n{msgnew.Text}\n\nCreated:{System.DateTime.Now}\n\n Author:{msg.Author}");
            }

            ServerMemory.BroadcastPacket(PacketConstructors.TopicPacket.Edit(msg, msgnew));

            return PacketHandlerResult.Response;
        }

        /// <summary>
        /// Sends <see cref="PacketID.Server.TopicLoadResponse"/> with guides and <see cref="PacketID.Server.TopicsEndLoading"/> on successful transfer
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        internal PacketHandlerResult LoadTopics(ServerData arg1, Packet arg2)
        {
            Directory.CreateDirectory(ServerManager.settings.GuidePath);

            //TODO: create a static DashboardManager who does the dirty shit...
            foreach (string dir in Directory.GetDirectories(ServerManager.settings.GuidePath, "*", SearchOption.TopDirectoryOnly))
            {
                foreach (string file in Directory.GetFiles(dir, "*.log", SearchOption.TopDirectoryOnly))
                {
                    string title = file.Remove(0, dir.Length + 1).Replace(".log", "").Replace("_question_", "?").Replace("_appostroph_", "`");
                    string text = File.ReadAllText(file);
                    string author = dir.Remove(0, ServerManager.settings.GuidePath.Length + 1);
                    arg1.m_security.Send(PacketConstructors.TopicPacket.Load(new DashboardMessage(title, text, author)));
                }
            }

            arg1.m_security.Send(new Packet(PacketID.Server.TopicsEndLoading));
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}