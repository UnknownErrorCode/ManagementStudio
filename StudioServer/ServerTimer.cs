using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudioServer
{
    internal class ServerTimer
    {
        internal static Dictionary<string, Timer> TimerFactory = new Dictionary<string, Timer>();
        private static readonly string ChatLogKey = "ChatLogTimer";

        /// <summary>
        /// Starts all timer and returns its start message.
        /// </summary>
        /// <returns> object[]</returns>
        internal static object[] OnBegin()
        {
            return new object[] { (ChatLogTimer(10) ? $"Started {ChatLogKey}" : $"{ChatLogKey} already started!") };
        }




        /// <summary>
        /// Starts to log the AllChat & PrivateChat to:
        /// Path.Combine(Directory.GetCurrentDirectory(), "ChatLog", "AllChat.txt");
        /// and: 
        /// Path.Combine(Directory.GetCurrentDirectory(), "ChatLog", "PrivateChats");
        /// </summary>
        /// <param name="interv"></param>


        private static bool ChatLogTimer(int interv)
        {
            if (!Directory.Exists(ChatServer.AllChatLogDir))
            {
                Directory.CreateDirectory(ChatServer.AllChatLogDir).Create();
            }
            if (!Directory.Exists(ChatServer.PrivateChatLogDir))
            {
                Directory.CreateDirectory(ChatServer.PrivateChatLogDir).Create();
            }
            if (TimerFactory.ContainsKey(ChatLogKey))
            {
                return false;
            }
            var t =  new Timer()
            { Interval = interv ,
             Enabled = true};
            t.Tick += ChatLogTick;
            TimerFactory.Add(ChatLogKey, t);
            return true;
        }

        private static void ChatLogTick(object sender, EventArgs e)
        {
            if (ChatServer.HasChatToLog())
            {
                ChatServer.LogChatsOnServerDevice();
            }
        }
    }
}
