using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Drops
{
    internal class REQ_ADD_NEW_MONSTERDROP
    {
        internal static Packet AddNewMonsterAssignedDrop(Packet opcode, string accountName)
        {
			try
			{
				var Monster = opcode.ReadAscii();
				var Item = opcode.ReadAscii();
				var Min = opcode.ReadByte();
				var Max = opcode.ReadByte();
				var Rate = opcode.ReadFloat();
				var paramarray = new SqlParameter[]
				{
					 new SqlParameter("@Mob", System.Data.SqlDbType.VarChar,128){Value = Monster },
					 new SqlParameter("@Item", System.Data.SqlDbType.VarChar,128){Value = Item },
					 new SqlParameter("@DropAmountMin", System.Data.SqlDbType.TinyInt) {Value = Min } ,
					 new SqlParameter("@DropAmountMax", System.Data.SqlDbType.TinyInt){Value = Max },
					 new SqlParameter("@DropRatio", System.Data.SqlDbType.Real){Value = Rate }
				};
				var resultTable = SQL.ReturnDataTableByProcedure("_ADD_DROP_TO_MONSTER", StudioServer.settings.DBDev, paramarray).Rows[0];
				if (int.TryParse(resultTable[0].ToString(), out int resultInteger))
				{
					if (resultInteger==0)
					{
						opcode = OutgoingPackets.NotifyNoticePlayer(resultTable[1].ToString());
						ServerMembory.RefreshTableForAll("_RefMonster_AssignedItemDrop");
					}
					else if (resultInteger < 0)
					{
						opcode = OutgoingPackets.FailNoticePlayer(resultTable[1].ToString());
					}
				}
				else
				{
					opcode = OutgoingPackets.FailNoticePlayer("Failed to add the drop to the monster");
				}

				return opcode ;
			}
			catch (Exception)
			{
				StudioServer.StaticCertificationGrid.WriteLogLine($"[{accountName}] failed to add new MonsterDrop!");
				return OutgoingPackets.FailNoticePlayer("Failed to add new MonsterDrop!");
			}
        }
    }
}
