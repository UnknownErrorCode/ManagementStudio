using ClientDataStorage.Dashboard;
using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementClient.Network
{
    class ClientPacketHandler : PacketHandler
    {

        public ClientPacketHandler()
        {
            base.AddEntry(0xC000, Reply0xC000LoginStatus);
            base.AddEntry(0xC001, Reply0xC001LoadTopicRequest);
            base.AddEntry(0xC002, Reply0xC002NewTopicRequest);
            base.AddEntry(0xC003, Reply0xC003FinishedLoadingTopics);
            base.AddEntry(0xC004, Reply0xC004DeleteTopics);

        }





        private PacketHandlerResult Reply0xC000LoginStatus(ServerData arg1, Packet arg2)
        {
            var ok = arg2.ReadBool();
            var msg = arg2.ReadAscii();
            var securityGroup = int.Parse(arg2.ReadAscii());
            var accountName = arg2.ReadAscii();
            if (ok)
            {
                ClientMemory.LoggedIn = true;
                arg1.AccountName = accountName;
                Program.StaticLoginForm.Invoke(new Action(() => Program.StaticLoginForm.OnHide()));
                //   Program.StaticClientForm.Invoke( new Action( () => Program.StaticClientForm.Show()));
            }
            else
            {
                vSroMessageBox.Show($"Login failed! \n{msg}");
                return PacketHandlerResult.Block;
            }

            return PacketHandlerResult.Block;
        }



        private PacketHandlerResult Reply0xC001LoadTopicRequest(ServerData arg1, Packet arg2)
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

        private PacketHandlerResult Reply0xC002NewTopicRequest(ServerData arg1, Packet arg2)
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

        private PacketHandlerResult Reply0xC003FinishedLoadingTopics(ServerData arg1, Packet arg2)
        {
            ClientForm.Logger.WriteLogLine($"Successfully load {DashboardMemory.TopicDictionary.Count} topics to dashboard!");
            return PacketHandlerResult.Block;
        }

        private PacketHandlerResult Reply0xC004DeleteTopics(ServerData arg1, Packet arg2)
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
