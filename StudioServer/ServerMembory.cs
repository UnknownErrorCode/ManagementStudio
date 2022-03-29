using ServerFrameworkRes.Network.Security;
using StudioServer.Handler;
using StudioServer.Handler.PacketHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace StudioServer
{
    public class ServerMembory
    {
        public static Config.NetEngine.OnlineUser OnlineUserSerie { get; set; }
        public static Int32 OnlineUsers => UserOnline.Count;
        public static Dictionary<string, ServerData> UserOnline = new Dictionary<string, ServerData>();
        public static Dictionary<string, List<string>> PluginDataaccess = InitializePluginsAllowed();


        public static void RemoveUserOnline(ServerData dataToRemove)
        {
            if (dataToRemove.AccountName != null)
            {
                if (UserOnline.ContainsKey(dataToRemove.AccountName))
                {
                    UserOnline.Remove(dataToRemove.AccountName);
                    SqlParameter[] logoutParameter = new SqlParameter[]
                    {
                        new SqlParameter("@UserName" ,System.Data.SqlDbType.VarChar,64) { Value = dataToRemove.AccountName },
                        new SqlParameter("@Password" ,System.Data.SqlDbType.VarChar,128) { Value = "non" },
                        new SqlParameter("@IP" ,System.Data.SqlDbType.VarChar,15) { Value = dataToRemove.UserIP },
                        new SqlParameter("@OnOff" , System.Data.SqlDbType.TinyInt) { Value = 0 }

                    };
                    DataTable logoutResut = SQL.ReturnDataTableByProcedure("_LoginToolUser", StudioServer.settings.DBDev, logoutParameter);
                    string restext = logoutResut.Rows[0][1].ToString();
                    SendPacketToAllOnlineMember(OutgoingPackets.PlayerLogoff(restext));
                    StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, restext);
                }
            }
        }

        internal static void SendPacketToSpecificOnlineMember(Packet retreiveChat, string receiver)
        {
            if (retreiveChat != null)
            {
                if (UserOnline.ContainsKey(receiver))
                {
                    ServerData dataToSend = UserOnline.Values.Single(user => user.AccountName == receiver);
                    if (dataToSend != null)
                    {
                        dataToSend.m_security.Send(retreiveChat);
                    }
                }
            }
        }

        public static void RefreshTableForAll(string tablename)
        {
            Packet packet = REQUEST_SINGLE_DATATABLE_STRING.Request(tablename);
            ServerMembory.SendPacketToAllOnlineMember(packet);
        }


        public static void SendPacketToAllOnlineMember(Packet packet)
        {
            if (packet != null)
            {
                foreach (ServerData singleAccountOnline in UserOnline.Values)
                {
                    singleAccountOnline.m_security.Send(packet);
                }
            }
        }
        public static void SendUpdateSuccessNoticeToAll(string text, string UserName)
        {
            SendPacketToAllOnlineMember(OutgoingPackets.SuccessNoticePlayer(text, UserName));
            SQL.ExecuteQuery($"UPDATE _ToolUser SET UpdatedRows +=1 where Account = '{UserName}'", StudioServer.settings.DBDev);
        }

        internal static Dictionary<string, List<string>> InitializePluginsAllowed()
        {
            DataTable allInfos = SQL.ReturnDataTable("SELECT * FROM _ToolPluginDataAccess order by PluginName, LoadIndex", StudioServer.settings.DBDev);
            Dictionary<string, List<string>> Dataaccess = new Dictionary<string, List<string>>();
            foreach (DataRow item in allInfos.Rows)
            {
                string name = item.Field<string>("PluginName");
                string tableName = item.Field<string>("TableName");
                if (Dataaccess.ContainsKey(name))
                {
                    Dataaccess[name].Add(tableName);
                }
                else
                {
                    Dataaccess.Add(name, new List<string>());
                    Dataaccess[name].Add(tableName);
                }
            }
            return Dataaccess;
        }


    }
}
