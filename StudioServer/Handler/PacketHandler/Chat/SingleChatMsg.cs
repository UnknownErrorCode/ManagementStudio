using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Chat
{
    public class ChatStructs
    {

        [StructLayout(LayoutKind.Sequential, Size =1024)]  //16AccName + 8 Date  +1000 Text
        public struct SingleAllChatMsg
        {
            [MarshalAs(UnmanagedType.HString, SizeConst = 16)]
            public string Sender;
            [MarshalAs(UnmanagedType.HString, SizeConst = 1000)]
            public string Text;
            [MarshalAs(UnmanagedType.HString, SizeConst = 8)]
            public string Sent;
        }
        [StructLayout(LayoutKind.Sequential, Size = 1040)]
        public struct SinglePrivateChatMsg
        {
            [MarshalAs(UnmanagedType.HString, SizeConst = 16)]
            public string Sender;
            [MarshalAs(UnmanagedType.HString, SizeConst = 1000)]
            public string Text;
            [MarshalAs(UnmanagedType.HString, SizeConst = 8)]
            public string Sent;
            [MarshalAs(UnmanagedType.HString, SizeConst = 16)]
            public string Receiver;
        }

        public struct AllPastPrivateChats
        {
            public string Receiver;
            public Dictionary<string, SinglePrivateChatMsg> AllLoggedPrivateChats;
        }
        
    }
}
