using ServerFrameworkRes.Network.Security;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Login
{
    internal class REQUEST_LOGIN
    {
        #region Internal Methods

        /// <summary>
        /// Replies with 0xA101 about the Login Information
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="context_data"></param>
        /// <returns></returns>
        internal static Packet LoginPackage(Packet opcode, ServerFrameworkRes.Network.Security.ServerData context_data)
        {
            byte register = opcode.ReadByte();
            string accname = opcode.ReadAscii();
            string password = opcode.ReadAscii();

            SqlParameter[] regparams = new SqlParameter[4]
              {
                    new SqlParameter("@UserName",SqlDbType.VarChar,64) {Value = accname.ToLower() },
                    new SqlParameter("@Password",SqlDbType.VarChar,128) { Value = password},
                    new SqlParameter("@IP",SqlDbType.VarChar,15) { Value =context_data.UserIP},
                    new SqlParameter("@OnOff",SqlDbType.TinyInt) { Value = 1}
              };
            opcode = new Packet(0xA101);
            string procName = "";
            if (register == 1)
            {
                procName = "_RegisterToolUser";
            }
            else if (register == 0)
            {
                procName = "_LoginToolUser";
            }
            DataTable boolstring = SQL.ReturnDataTableByProcedure(procName, StudioServer.settings.DBDev, regparams);

            string test = boolstring.Rows[0][0].ToString();
            string restext = boolstring.Rows[0][1].ToString();
            string SecurityDesc = boolstring.Rows[0][2].ToString();
            opcode.WriteAscii(restext);

            if (test == "true")
            {
                string RealAccountName = boolstring.Rows[0][3].ToString();
                opcode.WriteBool(true);
                opcode.WriteByte(byte.Parse(SecurityDesc));
                opcode.WriteAscii(RealAccountName);
                context_data.AccountName = RealAccountName;
                ServerMembory.UserOnline.Add(RealAccountName, context_data);
                ServerMembory.SendPacketToAllOnlineMember(OutgoingPackets.PlayerLogin($"{RealAccountName}"));

                DataTable PluginsToUse = SQL.ReturnDataTable($"Select AllowedPlugins from _ToolPluginGroups where SecurityGroupID = {SecurityDesc}", StudioServer.settings.DBDev);
                StudioServer.StaticCertificationGrid.WriteLogLine($"User {RealAccountName} with Security {SecurityDesc} has logged in!");
                byte rowcount = byte.Parse(PluginsToUse.Rows.Count.ToString());
                if (rowcount > 0)
                {
                    opcode.WriteByte(rowcount);
                    List<string> ListOfTables = new List<string>();
                    foreach (DataRow item in PluginsToUse.Rows)
                    {
                        string PluginName = item.Field<string>("AllowedPlugins");
                        opcode.WriteAscii(PluginName);

                        if (ServerMembory.PluginDataaccess.ContainsKey(PluginName))
                        {
                            List<string> Liste = ServerMembory.PluginDataaccess[PluginName];
                            foreach (string tablename in Liste)
                            {
                                if (!ListOfTables.Contains(tablename))
                                {
                                    ListOfTables.Add(tablename);
                                }
                            }
                        }
                    }
                    byte tablecount = byte.Parse(ListOfTables.Count.ToString());
                    opcode.WriteByte(tablecount);

                    foreach (string item in ListOfTables)
                    {
                        opcode.WriteAscii(item);
                    }
                }
            }
            else
            {
                opcode.WriteBool(false);
                opcode.WriteByte(0);
                ServerMembory.RemoveUserOnline(context_data);
            }

            return opcode;
        }

        #endregion Internal Methods
    }
}