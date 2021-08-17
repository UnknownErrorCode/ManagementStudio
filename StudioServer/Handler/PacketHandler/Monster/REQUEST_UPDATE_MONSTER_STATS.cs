using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Monster
{
    internal static class REQUEST_UPDATE_MONSTER_STATS
    {
        internal static Packet UpdateMonsterStat(Packet packet, string accountName)
        {
            if (accountName==null)
            {
                OutgoingPackets.FailNoticePlayer("Please reconnect with your tool  in order to establish a connection again!");
                return null;
            }
         var MonsterCharID = packet.ReadInt();
         var MonsterLevel=   packet.ReadByte();
         var MonsterHP  = packet.ReadInt();
         var MonsterRarity = packet.ReadByte();
            var sqlparameter = new SqlParameter[]
                {
                    new SqlParameter("@MonsterCharID",System.Data.SqlDbType.Int) { Value =MonsterCharID },
                    new SqlParameter("@MonsterLevel",System.Data.SqlDbType.TinyInt) { Value =MonsterLevel },
                    new SqlParameter("@MonsterHP"   ,System.Data.SqlDbType.Int) { Value =MonsterHP },
                    new SqlParameter("@MonsterRarity",System.Data.SqlDbType.TinyInt) { Value =MonsterRarity }
                };
            var rowcount = SQL.ReturnDataTableByProcedure("_UPDATE_MONSTERSTATS",StudioServer.settings.DBDev,sqlparameter).Rows[0];

            int valueReturn =int.Parse( rowcount[0].ToString());
            string textReturn = rowcount[1].ToString();
            if (valueReturn >0)
            {
                ServerMembory.SendUpdateSuccessNoticeToAll(textReturn, accountName);
                ServerMembory.RefreshTableForAll("_RefObjCommon");
                ServerMembory.RefreshTableForAll("_RefObjChar");
            }
            else
            {
                return OutgoingPackets.FailNoticePlayer(textReturn);
            }

            return null;
        }
    }
}
