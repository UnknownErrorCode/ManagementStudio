using ManagementFramework.Network.Security;
using Structs.Dashboard;
using System;

namespace Dashboard
{
    public partial class DashboardControl
    {
        #region Methods

        /// <summary>
        /// Deletes the topic visually when server broadcasts the packet.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns><see cref="PacketHandlerResult"/></returns>
        private PacketHandlerResult TopicDeleteResponse(ServerData arg1, Packet arg2)
        {
            string Author = arg2.ReadAscii();
            string Title = arg2.ReadAscii();
            string Remover = arg2.ReadAscii();
            vSroButtonList1.Invoke(new Action(() => vSroButtonList1.RemoveButton(Title)));

            ManagementFramework.Log.Logger.WriteLogLine($"User:[{Remover}] successfully deleted topic: [{Title}] from author: {Author}!");
            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Load the existing topics.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns><see cref="PacketHandlerResult"/></returns>
        private PacketHandlerResult TopicReceiveExisting(ServerData arg1, Packet arg2) => TopicReceive(arg1, arg2);

        /// <summary>
        /// Load a new topic to the dashboard.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns><see cref="PacketHandlerResult"/></returns>
        private PacketHandlerResult TopicReceiveNew(ServerData arg1, Packet arg2) => TopicReceive(arg1, arg2, true);

        /// <summary>
        /// Notification from server when initialisation is done.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns><see cref="PacketHandlerResult"/></returns>
        private PacketHandlerResult TopicsFinishedLoading(ServerData arg1, Packet arg2)
        {
            ManagementFramework.Log.Logger.WriteLogLine($"Successfully load {listView1.Items.Count} topics to dashboard!");
            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Illustrate other online tool user.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private PacketHandlerResult UserLogOnOff(ServerData arg1, Packet arg2)
        {
            var count = arg2.ReadInt();
            for (int i = 0; i < count; i++)
            {
                var login = arg2.ReadBool();
                var user = arg2.ReadAscii();
                if (login)
                    vSroButtonListOnlineUser.Invoke(new Action(() => vSroButtonListOnlineUser.AddSingleButtonToList(user)));
                else
                    vSroButtonListOnlineUser.Invoke(new Action(() => vSroButtonListOnlineUser.RemoveButton(user)));
            }
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
                ManagementFramework.Log.Logger.WriteLogLine($"{arg1.AccountName} successfully added new  topic: {msg.Title} to dashboard!");
            }

            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}