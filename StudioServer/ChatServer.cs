using StudioServer.Handler;
using StudioServer.Handler.PacketHandler.Chat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudioServer
{
    public static class ChatServer
    {
        private static readonly List<ChatStructs.SingleAllChatMsg> AllChat = new List<ChatStructs.SingleAllChatMsg>();
        private static readonly List<ChatStructs.SinglePrivateChatMsg> PrivateChat = new List<ChatStructs.SinglePrivateChatMsg>();
        internal static string AllChatLogDir = Path.Combine(StudioServer.settings.ChatLogPath, "ChatLog");
        internal static string AllChatLogTXT = Path.Combine(StudioServer.settings.ChatLogPath, "ChatLog", "AllChat.log");
        internal static string PrivateChatLogDir = Path.Combine(StudioServer.settings.ChatLogPath, "ChatLog", "PrivateChats");



        internal static void SendSingleAllChatMessage(ChatStructs.SingleAllChatMsg singleMessageStruct)
        {
            AllChat.Add(singleMessageStruct);
            ServerMembory.SendPacketToAllOnlineMember(OutgoingPackets.SingleAllChatMsgPacket(singleMessageStruct));
            StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("Received All Chat: Sender: {0}  Text:{1}", singleMessageStruct.Sender, singleMessageStruct.Text));
        }


        public static void SendSinglePrivateMessage(ChatStructs.SinglePrivateChatMsg singleMessageStruct)
        {
            PrivateChat.Add(singleMessageStruct);
            ServerMembory.SendPacketToSpecificOnlineMember(OutgoingPackets.SinglePrivateChatMsgPacket(singleMessageStruct), singleMessageStruct.Receiver);
            ServerMembory.SendPacketToSpecificOnlineMember(OutgoingPackets.SinglePrivateChatMsgPacket(singleMessageStruct), singleMessageStruct.Sender);
            StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("Received Private Chat: Sender: {0}  Receiver: {2} Text:{1}", singleMessageStruct.Sender, singleMessageStruct.Text, singleMessageStruct.Receiver));
        }


        internal static void LogChatsOnServerDevice()
        {

            lock (AllChat)
            {
                List<string> tempChatList = new List<string>(AllChat.Count);
                AllChat.ForEach(singleAllChatToLog => tempChatList.Add($"{singleAllChatToLog.Sent}►{singleAllChatToLog.Sender}→{singleAllChatToLog.Text}↓"));
                File.AppendAllLines(AllChatLogTXT, tempChatList.AsEnumerable());
                AllChat.Clear();
            }

            Dictionary<string, List<string>> tempChatList2 = new Dictionary<string, List<string>>(PrivateChat.Count);

            if (PrivateChat.Count > 0)
            {
                //Prevent of wrong Packages
                if (PrivateChat[0].Receiver == null || PrivateChat[0].Sender == null)
                {
                    PrivateChat.RemoveAt(0);
                    return;
                }
                string FileName = $"@{PrivateChat[0].Receiver}.log";
                string FileName2 = $"@{PrivateChat[0].Sender}.log";
                if (!Directory.Exists(Path.Combine(PrivateChatLogDir, PrivateChat[0].Sender)))
                {
                    Directory.CreateDirectory(Path.Combine(PrivateChatLogDir, PrivateChat[0].Sender)).Create();
                }
                if (!Directory.Exists(Path.Combine(PrivateChatLogDir, PrivateChat[0].Receiver)))
                {
                    Directory.CreateDirectory(Path.Combine(PrivateChatLogDir, PrivateChat[0].Receiver)).Create();
                }
                File.AppendAllText(Path.Combine(PrivateChatLogDir, PrivateChat[0].Sender, FileName), $"{PrivateChat[0].Sent}→{PrivateChat[0].Sender}↓{PrivateChat[0].Text.Replace(Environment.NewLine, "†")}{Environment.NewLine}");
                File.AppendAllText(Path.Combine(PrivateChatLogDir, PrivateChat[0].Receiver, FileName2), $"{PrivateChat[0].Sent}→{PrivateChat[0].Sender}↓{PrivateChat[0].Text.Replace(Environment.NewLine, "†")}{Environment.NewLine}");

                PrivateChat.RemoveAt(0);
            }


        }

        internal static bool HasChatToLog()
        {
            if (AllChat.Count > 0 || PrivateChat.Count > 0)
            {
                return true;
            }
            return false;
        }


    }
}
