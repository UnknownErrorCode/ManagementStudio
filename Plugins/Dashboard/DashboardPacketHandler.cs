using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;

namespace Dashboard
{
    public partial class DashboardControl
    {
        #region Methods

        internal PacketHandlerResult TopicDeleteResponse(ServerData arg1, Packet arg2)
        {
            string Author = arg2.ReadAscii();
            string Title = arg2.ReadAscii();
            string Remover = arg2.ReadAscii();
            vSroButtonList1.Invoke(new Action(() => vSroButtonList1.RemoveSingleButtonFromList(Title)));

            ClientDataStorage.Log.Logger.WriteLogLine($"User:[{Remover}] successfully deleted topic: [{Title}] from author: {Author}!");
            return PacketHandlerResult.Block;
        }

        internal PacketHandlerResult TopicReceiveExisting(ServerData arg1, Packet arg2)
        {
            return TopicReceive(arg1, arg2);
        }

        internal PacketHandlerResult TopicReceiveNew(ServerData arg1, Packet arg2)
        {
            return TopicReceive(arg1, arg2, true);
        }

        internal PacketHandlerResult TopicsFinishedLoading(ServerData arg1, Packet arg2)
        {
            ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load {listView1.Items.Count} topics to dashboard!");
            return PacketHandlerResult.Block;
        }

        private PacketHandlerResult TopicReceive(ServerData arg1, Packet arg2, bool isNew = false)
        {
            DashboardMessage msg = arg2.ReadStruct<DashboardMessage>();

            vSroButtonList1.Invoke(new Action(() =>
            {
                if (!vSroButtonList1.ContainsTitle(msg.Title))
                {
                    vSroButtonList1.AddSingleButtonToList(msg.Title, msg);
                }
            }));

            if (isNew)
            {
                ClientDataStorage.Log.Logger.WriteLogLine($"{arg1.AccountName} successfully added new  topic: {msg.Title} to dashboard!");
            }

            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}