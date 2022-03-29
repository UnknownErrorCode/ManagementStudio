using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Teleporter
{
    internal class REQ_UPDATE_TELELINK
    {
        #region Internal Methods

        internal static Packet UpdateTeleLink(Packet updatePacket, string AccountName)
        {
            int Service = updatePacket.ReadInt();
            int OwnerTeleport = updatePacket.ReadInt();
            int TargetTeleport = updatePacket.ReadInt();
            int Fee = updatePacket.ReadInt();
            byte RestrictBindMethod = updatePacket.ReadByte();
            byte RunTimeTeleportMethod = updatePacket.ReadByte();
            byte CheckResult = updatePacket.ReadByte();
            int Restrict1 = updatePacket.ReadInt();
            int Data1_1 = updatePacket.ReadInt();
            int Data1_2 = updatePacket.ReadInt();
            int Restrict2 = updatePacket.ReadInt();
            int Data2_1 = updatePacket.ReadInt();
            int Data2_2 = updatePacket.ReadInt();
            int Restrict3 = updatePacket.ReadInt();
            int Data3_1 = updatePacket.ReadInt();
            int Data3_2 = updatePacket.ReadInt();
            int Restrict4 = updatePacket.ReadInt();
            int Data4_1 = updatePacket.ReadInt();
            int Data4_2 = updatePacket.ReadInt();
            int Restrict5 = updatePacket.ReadInt();
            int Data5_1 = updatePacket.ReadInt();
            int Data5_2 = updatePacket.ReadInt();

            SqlParameter[] ParamArray = new SqlParameter[]
            {
                new SqlParameter("@Service"  ,              SqlDbType.Int)                    {Value = Service               }  ,
                new SqlParameter("@OwnerTeleport"  ,        SqlDbType.Int)                    {Value = OwnerTeleport        }   ,
                new SqlParameter("@TargetTeleport"  ,       SqlDbType.Int)           {Value = TargetTeleport        }   ,
                new SqlParameter("@Fee"  ,                  SqlDbType.Int)           {Value = Fee                    }  ,
                new SqlParameter("@RestrictBindMethod"  ,   SqlDbType.TinyInt)                    {Value = RestrictBindMethod   }   ,
                new SqlParameter("@RunTimeTeleportMethod",  SqlDbType.TinyInt)           {Value = RunTimeTeleportMethod}    ,
                new SqlParameter("@CheckResult"  ,          SqlDbType.TinyInt)               {Value = CheckResult            }  ,
                new SqlParameter("@Restrict1" ,             SqlDbType.Int)               {Value = Restrict1             }  ,
                new SqlParameter("@Data1_1"  ,              SqlDbType.Int)               {Value = Data1_1                }  ,
                new SqlParameter("@Data1_2"  ,              SqlDbType.Int)               {Value = Data1_2                }  ,
                new SqlParameter("@Restrict2"  ,            SqlDbType.Int)               {Value = Restrict2         }   ,
                new SqlParameter("@Data2_1"  ,              SqlDbType.Int)                {Value = Data2_1               }  ,
                new SqlParameter("@Data2_2"  ,              SqlDbType.Int)                {Value = Data2_2               }  ,
                new SqlParameter("@Restrict3"  ,            SqlDbType.Int)               {Value = Restrict3         }   ,
                new SqlParameter("@Data3_1"  ,              SqlDbType.Int)                {Value = Data3_1               }  ,
                new SqlParameter("@Data3_2" ,               SqlDbType.Int)                {Value = Data3_2               }  ,
                new SqlParameter("@Restrict4" ,             SqlDbType.Int)                    {Value = Restrict4             }  ,
                new SqlParameter("@Data4_1" ,               SqlDbType.Int)                    {Value = Data4_1               }  ,
                new SqlParameter("@Data4_2" ,               SqlDbType.Int)                    {Value = Data4_2               }  ,
                new SqlParameter("@Restrict5" ,             SqlDbType.Int)                    {Value = Restrict5             }  ,
                new SqlParameter("@Data5_1" ,               SqlDbType.Int)                    {Value = Data5_1               }  ,
                new SqlParameter("@Data5_2" ,               SqlDbType.Int)                    {Value = Data5_2 }
            };

            DataRow rowcount = SQL.ReturnDataTableByProcedure("_UPDATE_TELELINK", StudioServer.settings.DBDev, ParamArray).Rows[0];

            int valueReturn = int.Parse(rowcount[0].ToString());
            string textReturn = rowcount[1].ToString();
            if (valueReturn > 0)
            {
                ServerMembory.SendUpdateSuccessNoticeToAll(textReturn, AccountName);
                ServerMembory.RefreshTableForAll("_RefTeleLink");
            }
            else
            {
                return OutgoingPackets.FailNoticePlayer(textReturn);
            }

            return null;
        }

        #endregion Internal Methods
    }
}