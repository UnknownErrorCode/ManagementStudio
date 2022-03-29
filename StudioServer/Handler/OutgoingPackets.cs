using ServerFrameworkRes.Network.Security;
using StudioServer.Handler.PacketHandler.Dashboard;

namespace StudioServer.Handler
{
    public static class OutgoingPackets
    {
        #region Login

        /// <summary>
        /// Returns Packet 0x3099 with all FileTitles
        /// </summary>
        /// <returns></returns>
        internal static Packet AllStoredDataTitles()
        {
            Packet packet = new Packet(0x2099);
            packet.WriteInt(Worker.DataStorage.DataCount);
            string[] array = Worker.DataStorage.AllFilesAsArray();
            foreach (string item in array)
            {
                packet.WriteAscii(item);
            }

            return packet;
        }

        internal static Packet CurrentVersion()
        {
            Packet version = new Packet(0xD000);
            version.WriteInt(StudioServer.settings.Version);
            return version;
        }

        /// <summary>
        /// Get 0xDEAC with RemoveText and SingleTopic to Delete
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        internal static Packet DeleteDashboardTopic(string Text, SingleTopic topic)
        {
            Packet packet = new Packet(0xDEAC);
            packet.WriteAscii(Text);
            packet.WriteAscii(topic.Author);
            packet.WriteAscii(topic.Title);
            packet.WriteAscii(topic.Text);
            return packet;
        }

        internal static Packet NewDashboardTopic(SingleTopic topic)
        {
            Packet packet = new Packet(0xD2AC);
            packet.WriteAscii(topic.Author);
            packet.WriteAscii(topic.Title);
            packet.WriteAscii(topic.Text);
            return packet;
        }

        internal static Packet SingleStoredData(string requestedFileName, byte[] fileAsByteArray)
        {
            Packet pack = new Packet(0x2098, false, true);
            pack.WriteAscii(requestedFileName);
            pack.WriteByteArray(fileAsByteArray);
            return pack;
        }

        internal static Packet SuccessOfCertification(object str)
        {
            Packet pp = new Packet(0x2006);
            pp.WriteAscii("Success");
            return pp;
        }

        #endregion Login

        /// <summary>
        /// partner is the AccountName of the chatpartner. The Array suppose to be the txt file in format of each single Chat
        /// </summary>
        /// <param name="partner"></param>
        /// <param name="arr"></param>
        /// <returns></returns>

        #region Chats

        internal static Packet FailNoticePlayer(string text)
        {
            Packet successpacket = new Packet(0xA009);
            successpacket.WriteAscii(text);
            return successpacket;
        }

        internal static Packet NotifyNoticePlayer(string text)
        {
            Packet successpacket = new Packet(0xA010);
            successpacket.WriteAscii(text);
            return successpacket;
        }

        /// <summary>
        /// Server sends 0x1717 with All Chats as Array
        /// </summary>
        /// <param name="allChatAsByte"></param>
        /// <returns></returns>
        internal static Packet PastAllChatPacket(byte[] allChatAsByte)
        {
            Packet returner = new Packet(0x1717, false, true);
            returner.WriteBool(true);
            returner.WriteByteArray(allChatAsByte);
            return returner;
        }

        /// <summary>
        /// Server sends 0x1717 with empty results
        /// </summary>
        /// <param name="empty"></param>
        /// <returns></returns>
        internal static Packet PastAllChatPacket(bool empty)
        {
            Packet ereturn = new Packet(0x1717);
            ereturn.WriteBool(false);
            return ereturn;
        }

        internal static Packet PastPrivateChatPacket(string partner, byte[] arr)
        {
            Packet SinglePCPacket = new Packet(0x1818, false, true);
            SinglePCPacket.WriteAscii(partner);
            SinglePCPacket.WriteByteArray(arr);
            return SinglePCPacket;
        }

        internal static Packet PlayerLogin(string userName)
        {
            Packet successpacket = new Packet(0xA060);
            successpacket.WriteAscii(userName);
            return successpacket;
        }

        internal static Packet PlayerLogoff(string OffTextWithMinutes)
        {
            Packet successpacket = new Packet(0xA061);
            successpacket.WriteAscii(OffTextWithMinutes);
            return successpacket;
        }

        internal static Packet SingleAllChatMsgPacket(PacketHandler.Chat.ChatStructs.SingleAllChatMsg singleMessageStruct)
        {
            Packet SingleAllChatMsgPacket = new Packet(0x0101);
            SingleAllChatMsgPacket.WriteAscii(singleMessageStruct.Sender);
            SingleAllChatMsgPacket.WriteAscii(singleMessageStruct.Text);
            SingleAllChatMsgPacket.WriteAscii(singleMessageStruct.Sent);
            return SingleAllChatMsgPacket;
        }

        /// <summary>
        /// Server sends 0x0102 after receive the packet to both accounts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="text"></param>
        /// <param name="sent"></param>
        /// <returns></returns>
        internal static Packet SinglePrivateChatMsgPacket(PacketHandler.Chat.ChatStructs.SinglePrivateChatMsg singlePrivateStruct)
        {
            Packet packet = new Packet(0x0102);
            packet.WriteAscii(singlePrivateStruct.Sender);
            packet.WriteAscii(singlePrivateStruct.Text);
            packet.WriteAscii(singlePrivateStruct.Sent);
            packet.WriteAscii(singlePrivateStruct.Receiver);
            return packet;
        }

        /// <summary>
        /// Sends Packet 0xA011 to all online Clients
        /// </summary>
        /// <param name="text"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        internal static Packet SuccessNoticePlayer(string text, string userName)
        {
            Packet successpacket = new Packet(0xA011);
            successpacket.WriteAscii(userName);
            successpacket.WriteAscii(text);
            return successpacket;
        }

        #endregion Chats

        #region Internal Methods

        /// <summary>
        /// Get 0xD300 with SingleTopic
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        internal static Packet AllDashboardSections(SingleTopic content)
        {
            Packet pack = new Packet(0xD300);
            pack.WriteAscii(content.Author);
            pack.WriteAscii(content.Title);
            pack.WriteAscii(content.Text);
            return pack;
        }

        #endregion Internal Methods
    }
}