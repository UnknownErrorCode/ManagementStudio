using ServerFrameworkRes.Network.Security;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Monster
{
    internal static class REQUEST_UPDATE_MONSTER_STATS
    {
        #region Internal Methods

        internal static Packet UpdateMonsterStat(Packet packet, string accountName)
        {
            if (accountName == null)
            {
                OutgoingPackets.FailNoticePlayer("Please reconnect with your tool  in order to establish a connection again!");
                return null;
            }
            int MonsterCharID = packet.ReadInt();
            byte MonsterLevel = packet.ReadByte();
            int MonsterHP = packet.ReadInt();
            byte MonsterRarity = packet.ReadByte();
            SqlParameter[] sqlparameter = new SqlParameter[]
                {
                    new SqlParameter("@MonsterCharID",System.Data.SqlDbType.Int) { Value =MonsterCharID },
                    new SqlParameter("@MonsterLevel",System.Data.SqlDbType.TinyInt) { Value =MonsterLevel },
                    new SqlParameter("@MonsterHP"   ,System.Data.SqlDbType.Int) { Value =MonsterHP },
                    new SqlParameter("@MonsterRarity",System.Data.SqlDbType.TinyInt) { Value =MonsterRarity }
                };
            System.Data.DataRow rowcount = SQL.ReturnDataTableByProcedure("_UPDATE_MONSTERSTATS", StudioServer.settings.DBDev, sqlparameter).Rows[0];

            int valueReturn = int.Parse(rowcount[0].ToString());
            string textReturn = rowcount[1].ToString();
            if (valueReturn > 0)
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

        #endregion Internal Methods
    }
}