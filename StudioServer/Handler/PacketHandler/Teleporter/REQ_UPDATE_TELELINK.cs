using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Teleporter
{
    class REQ_UPDATE_TELELINK
    {

        internal static Packet UpdateTeleLink(Packet updatePacket, string AccountName)
        {

            var Service = updatePacket.ReadInt();
            int OwnerTeleport = updatePacket.ReadInt();
            var TargetTeleport = updatePacket.ReadInt();
            var Fee = updatePacket.ReadInt();
            var RestrictBindMethod = updatePacket.ReadByte();
            var RunTimeTeleportMethod = updatePacket.ReadByte();
            var CheckResult = updatePacket.ReadByte();
            var Restrict1 = updatePacket.ReadInt();
            var Data1_1 = updatePacket.ReadInt();
            var Data1_2 = updatePacket.ReadInt();
            var Restrict2 = updatePacket.ReadInt();
            var Data2_1 = updatePacket.ReadInt();
            var Data2_2 = updatePacket.ReadInt();
            var Restrict3 = updatePacket.ReadInt();
            var Data3_1 = updatePacket.ReadInt();
            var Data3_2 = updatePacket.ReadInt();
            var Restrict4 = updatePacket.ReadInt();
            var Data4_1 = updatePacket.ReadInt();
            var Data4_2 = updatePacket.ReadInt();
            var Restrict5 = updatePacket.ReadInt();
            var Data5_1 = updatePacket.ReadInt();
            var Data5_2 = updatePacket.ReadInt();


            var ParamArray = new SqlParameter[]
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

            var rowcount = SQL.ReturnDataTableByProcedure("_UPDATE_TELELINK", StudioServer.settings.DBDev, ParamArray).Rows[0];

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
    }
}
