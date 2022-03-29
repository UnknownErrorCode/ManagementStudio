using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace StudioServer.Handler.PacketHandler.Chat
{
    public class ChatStructs
    {
        #region Public Structs

        public struct AllPastPrivateChats
        {
            #region Public Fields

            public Dictionary<string, SinglePrivateChatMsg> AllLoggedPrivateChats;
            public string Receiver;

            #endregion Public Fields
        }

        [StructLayout(LayoutKind.Sequential, Size = 1024)]  //16AccName + 8 Date  +1000 Text
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

        #endregion Public Structs
    }
}