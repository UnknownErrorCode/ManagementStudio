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
            base.AddEntry(0xB000, Reply0xB000AllowedPlugins);
            base.AddEntry(0xB001, Reply0xB001AllowedDataTableNames);
            base.AddEntry(0xB002, Reply0xB002ReceiveDataTable);


            base.AddEntry(0xC000, Reply0xC000LoginStatus);
            base.AddEntry(0xC001, Reply0xC001LoadTopicRequest);
            base.AddEntry(0xC002, Reply0xC002NewTopicRequest);
            base.AddEntry(0xC003, Reply0xC003FinishedLoadingTopics);
            base.AddEntry(0xC004, Reply0xC004DeleteTopics);

        }

        private PacketHandlerResult Reply0xB000AllowedPlugins(ServerData arg1, Packet arg2)
            => CHandler.LoginHandler.AllowedPlugins(arg1, arg2);
        private PacketHandlerResult Reply0xB001AllowedDataTableNames(ServerData arg1, Packet arg2)
            => CHandler.LoginHandler.AllowedDataTable(arg1, arg2);
        private PacketHandlerResult Reply0xB002ReceiveDataTable(ServerData arg1, Packet arg2)
            => CHandler.LoginHandler.ReceiveDataTable(arg1, arg2);


        private PacketHandlerResult Reply0xC000LoginStatus(ServerData arg1, Packet arg2)
            => CHandler.LoginHandler.LoginStatus(arg1, arg2);

        private PacketHandlerResult Reply0xC001LoadTopicRequest(ServerData arg1, Packet arg2)
            => CHandler.DashboardHandler.LoadTopicRequest(arg1, arg2);

        private PacketHandlerResult Reply0xC002NewTopicRequest(ServerData arg1, Packet arg2)
            => CHandler.DashboardHandler.NewTopicRequest(arg1, arg2);

        private PacketHandlerResult Reply0xC003FinishedLoadingTopics(ServerData arg1, Packet arg2)
            => CHandler.DashboardHandler.FinishedLoadingTopics(arg1, arg2);

        private PacketHandlerResult Reply0xC004DeleteTopics(ServerData arg1, Packet arg2)
            => CHandler.DashboardHandler.DeleteTopic(arg1, arg2);
    }
}
