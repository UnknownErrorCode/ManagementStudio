using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Chat
{
    class ManageChat
    {
        public static Packet IncomeAllChat(Packet incomeChat, ServerData context_user)
        {
            var singleMessage = new ChatStructs.SingleAllChatMsg();
            singleMessage.Sender = context_user.AccountName;
            singleMessage.Text = incomeChat.ReadAscii();
            singleMessage.Sent = incomeChat.ReadAscii();

            ChatServer.SendSingleAllChatMessage(singleMessage);
            return null;
        }

        public static Packet IncomePrivateChat(Packet incomeChat, ServerData context_user)
        {
            var singleMessage = new ChatStructs.SinglePrivateChatMsg();
            singleMessage.Sender = context_user.AccountName;
            singleMessage.Text = incomeChat.ReadAscii();
            singleMessage.Sent = incomeChat.ReadAscii();
            singleMessage.Receiver = incomeChat.ReadAscii();

            ChatServer.SendSinglePrivateMessage(singleMessage);
            return null;
        }

        internal static Packet RequestAll_AllChatLog(string logFilePath)
        {
            if (File.Exists(logFilePath))
            {
                
                var arr = ASCIIEncoding.UTF8.GetBytes(File.ReadAllText(logFilePath));

              //  var AllChatAsByte = new byte[logfiletxt.Length * sizeof(char)];
             //   Buffer.BlockCopy(logfiletxt.ToCharArray(), 0, AllChatAsByte, 0, AllChatAsByte.Length);
                return OutgoingPackets.PastAllChatPacket(arr);
            }
            else
            {
                return OutgoingPackets.PastAllChatPacket(false);
            }
        }
        /// <summary>
        /// Sends all stored chats to the Account that requested 0x1818
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="context_data"></param>
        /// <returns></returns>
        internal static Packet RequestAllPrivateChatLog(Packet opcode, ServerData context_data)
        {
            if (!Directory.Exists(Path.Combine(ChatServer.PrivateChatLogDir, context_data.AccountName)))
            {
                Directory.CreateDirectory(Path.Combine(ChatServer.PrivateChatLogDir, context_data.AccountName));
            }
            if (Directory.GetFileSystemEntries(Path.Combine( ChatServer.PrivateChatLogDir, context_data.AccountName), $"@*.log", SearchOption.TopDirectoryOnly).Length>0)
            {

                foreach (var item in Directory.GetFileSystemEntries(Path.Combine(ChatServer.PrivateChatLogDir, context_data.AccountName), $"@*.log", SearchOption.TopDirectoryOnly))
                {
                    var partner = item.Replace(".log", "").Split('@')[1];
                   
                    ServerMembory.SendPacketToSpecificOnlineMember(OutgoingPackets.PastPrivateChatPacket(partner, ASCIIEncoding.UTF8.GetBytes(File.ReadAllText(item))),context_data.AccountName);
                }
            }
          
            return OutgoingPackets.SuccessNoticePlayer("Private Chat-Backup successfully sent!", context_data.AccountName);
        }
    }
}
