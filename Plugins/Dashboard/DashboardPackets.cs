using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    partial class DashboardControl
    {
        /// <summary>
        /// 0x1001 -- requests all topics from Server
        /// </summary>
        public static Packet RequestAllTopics { get => new Packet(0x1001); }

        /// <summary>
        /// 0x1002 -- returns Packet with DashboardMessage inside to broadcast to all clients
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal static Packet AddTopicToDashboard(DashboardMessage msg)
        {
            Packet packet = new Packet(0x1002);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);
            packet.WriteAscii(msg.Text);
            packet.WriteDateTime(msg.Created);

            return packet;
        }

        internal static Packet RequestDeleteTopicFromDashboard(DashboardMessage msg)
        {
            Packet packet = new Packet(0x1004);
            packet.WriteAscii(msg.Author);
            packet.WriteAscii(msg.Title);

            return packet;
        }



        private PacketHandlerResult TopicReceive(ServerData arg1, Packet arg2, bool isNew = false)
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
            if (listView1.InvokeRequired)
            {

                listView1.Invoke(new Action(() =>
                {
                    if (!listView1.Items.ContainsKey(msg.Title))
                        listView1.Items.Add(new ListViewItem(msg.Title) { Tag = msg, Name = msg.Title });
                }));
            }
            else if (!listView1.InvokeRequired)
                if (!listView1.Items.ContainsKey(msg.Title))
                    listView1.Items.Add(new ListViewItem(msg.Title) { Tag = msg, Name = msg.Title });


            if (isNew)
                ClientDataStorage.Log.Logger.WriteLogLine($"{arg1.AccountName} successfully added new  topic: {msg.Title} to dashboard!");

            return PacketHandlerResult.Block;
        }

        internal PacketHandlerResult TopicReceiveExisting(ServerData arg1, Packet arg2)
        {
            return TopicReceive(arg1, arg2);
        }

        internal PacketHandlerResult TopicRequestAddNew(ServerData arg1, Packet arg2)
        {
            return TopicReceive(arg1, arg2, true);
        }

        internal PacketHandlerResult TopicsFinishedLoading(ServerData arg1, Packet arg2)
        {
            ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load {listView1.Items.Count} topics to dashboard!");
            return PacketHandlerResult.Block;
        }


        internal PacketHandlerResult TopicDeleteResponse(ServerData arg1, Packet arg2)
        {
            var Author = arg2.ReadAscii();
            var Title = arg2.ReadAscii();
            var Remover = arg2.ReadAscii();
            listView1.Invoke(new Action(() => listView1.Items.RemoveByKey(Title)));
            ClientDataStorage.Log.Logger.WriteLogLine($"{Remover} successfully deleted topic: {Title} from {Author}!");
            return PacketHandlerResult.Block;
        }
    }
}
