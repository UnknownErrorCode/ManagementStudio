using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace StudioServer
{
    internal class ServerTimer
    {
        #region Internal Fields

        internal static Dictionary<string, Timer> TimerFactory = new Dictionary<string, Timer>();

        #endregion Internal Fields

        #region Private Fields

        private static readonly string ChatLogKey = "ChatLogTimer";

        #endregion Private Fields

        #region Internal Methods

        /// <summary>
        /// Starts all timer and returns its start message.
        /// </summary>
        /// <returns> object[]</returns>
        internal static object[] OnBegin()
        {
            return new object[] { (ChatLogTimer(10) ? $"Started {ChatLogKey}" : $"{ChatLogKey} already started!") };
        }

        #endregion Internal Methods

        /// <summary>
        /// Starts to log the AllChat & PrivateChat to:
        /// Path.Combine(Directory.GetCurrentDirectory(), "ChatLog", "AllChat.txt");
        /// and:
        /// Path.Combine(Directory.GetCurrentDirectory(), "ChatLog", "PrivateChats");
        /// </summary>
        /// <param name="interv"></param>

        #region Private Methods

        private static void ChatLogTick(object sender, EventArgs e)
        {
            if (ChatServer.HasChatToLog())
            {
                ChatServer.LogChatsOnServerDevice();
            }
        }

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
            Timer t = new Timer()
            {
                Interval = interv,
                Enabled = true
            };
            t.Tick += ChatLogTick;
            TimerFactory.Add(ChatLogKey, t);
            return true;
        }

        #endregion Private Methods
    }
}