using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Login
{
    internal class REQUEST_LOGIN
    {

        


        /// <summary>
        /// Replies with 0xA101 about the Login Information
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="context_data"></param>
        /// <returns></returns>
        internal static Packet LoginPackage(Packet opcode, ServerFrameworkRes.Network.Security.ServerData context_data)
        {

            byte register = opcode.ReadByte();
            var accname = opcode.ReadAscii();
            var password = opcode.ReadAscii();

            SqlParameter[] regparams = new SqlParameter[4]
              {
                    new SqlParameter("@UserName",SqlDbType.VarChar,64) {Value = accname.ToLower() },
                    new SqlParameter("@Password",SqlDbType.VarChar,128) { Value = password},
                    new SqlParameter("@IP",SqlDbType.VarChar,15) { Value =context_data.UserIP},
                    new SqlParameter("@OnOff",SqlDbType.TinyInt) { Value = 1}
              };
            opcode = new Packet(0xA101);
            var procName = "";
            if (register == 1)
            {
                procName = "_RegisterToolUser";
            }
            else if (register == 0)
            {
                procName = "_LoginToolUser";
            }
            DataTable boolstring = SQL.ReturnDataTableByProcedure(procName, StudioServer.settings.DBDev, regparams);

            var test = boolstring.Rows[0][0].ToString();
            var restext = boolstring.Rows[0][1].ToString();
            var SecurityDesc = boolstring.Rows[0][2].ToString();
            opcode.WriteAscii(restext);

            if (test == "true")
            {
                var RealAccountName = boolstring.Rows[0][3].ToString();
                opcode.WriteBool(true);
                opcode.WriteByte(byte.Parse(SecurityDesc));
                opcode.WriteAscii((string)RealAccountName);
                context_data.AccountName = (string)RealAccountName;
                ServerMembory.UserOnline.Add((string)RealAccountName, context_data);
                ServerMembory.SendPacketToAllOnlineMember(OutgoingPackets.PlayerLogin($"{(string)RealAccountName}"));
                
                DataTable PluginsToUse = SQL.ReturnDataTable($"Select AllowedPlugins from _ToolPluginGroups where SecurityGroupID = {SecurityDesc}", StudioServer.settings.DBDev);
                StudioServer.StaticCertificationGrid.WriteLogLine($"User {(string)RealAccountName} with Security {SecurityDesc} has logged in!");
                var rowcount = byte.Parse(PluginsToUse.Rows.Count.ToString());
                if (rowcount>0)
                {
                    opcode.WriteByte(rowcount);
                    var ListOfTables = new List<string>();
                    foreach (DataRow item in PluginsToUse.Rows)
                    {
                        var PluginName = item.Field<string>("AllowedPlugins");
                        opcode.WriteAscii(PluginName);

                        if (ServerMembory.PluginDataaccess.ContainsKey(PluginName))
                        {
                            var Liste = ServerMembory.PluginDataaccess[PluginName];
                            foreach (var tablename in Liste)
                            {
                                if (!ListOfTables.Contains(tablename))
                                {
                                    ListOfTables.Add(tablename);
                                }
                            }

                        }
                    }
                    var tablecount = byte.Parse(ListOfTables.Count.ToString());
                    opcode.WriteByte(tablecount);

                    foreach (var item in ListOfTables)
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

    }
}
