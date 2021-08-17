using ServerFrameworkRes.Network.Security;
using StudioServer.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Skills
{
    internal static class REQ_UPDATE_SKILL
    {
        /// <summary>
        /// 0x7021 reads int and string[] to identify how many skills needs to be update
        /// </summary>
        /// <param name="updatePacket"></param>
        /// <returns></returns>
        internal static Packet UPDATE_SKILL(Packet updatePacket, string accountName)
        {
            int CountSkillsToUpdate = updatePacket.ReadInt();
            List<string> Queries = new List<string>(CountSkillsToUpdate);

            for (int i = 0; i < CountSkillsToUpdate; i++)
            {
                var strinng = updatePacket.ReadAscii();
                Queries.Add($"UPDATE _RefSkill SET { strinng} WHERE ID = {updatePacket.ReadInt()}");
            }

            if (Queries.Count>0)
            {
                var wasFinallyUpdated = false;
                foreach (var item in Queries)
                {
                    var rowCount =SQL.ExecuteQuery(item, StudioServer.settings.DBSha);
                    if (rowCount>0)
                    {
                        ServerMembory.SendUpdateSuccessNoticeToAll($"Successfully updated Skill! Query: {item}", accountName);
                        wasFinallyUpdated = true;
                    }
                }
                if (wasFinallyUpdated)
                {
                    ServerMembory.RefreshTableForAll("_RefSkill");
                }
            }
            else
            {
                updatePacket = new Packet(0xA009);
                updatePacket.WriteAscii("No rows updated!");
                return updatePacket;
            }
            return null;
        }
    }
}
