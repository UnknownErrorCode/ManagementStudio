using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Spawns
{
   internal static class REQ_UPDATE_NEST
    {
        internal static Packet UpdateNest (Packet packet, string AccountName)
        {





            string query = $"UPDATE {StudioServer.settings.DBSha}.dbo.Tab_RefNest SET " +

                             $"dwHiveID =     {packet.ReadAscii()}, " +
                             $"dwTacticsID =  {packet.ReadAscii()}," +
                             $"nRegionDBID =  '{packet.ReadAscii()}', " +
                             $"fLocalPosX =  '{packet.ReadAscii().Replace(",", ".")}', " +
                             $"fLocalPosY =  '{packet.ReadAscii().ToString().Replace(",", ".")}', " +
                             $"fLocalPosZ =  '{packet.ReadAscii().ToString().Replace(",", ".")}', " +
                             $"wInitialDir =  '{packet.ReadAscii().ToString().Replace(",", ".")}', " +
                             $"nRadius =  {packet.ReadAscii()}, " +
                             $"nGenerateRadius =  {packet.ReadAscii()}, " +
                             $"nChampionGenPercentage =  {packet.ReadAscii()}, " +
                             $"dwDelayTimeMin =  {packet.ReadAscii()}, " +
                             $"dwDelayTimeMax =  {packet.ReadAscii()}, " +
                             $"dwMaxTotalCount =  {packet.ReadAscii()}, " +
                             $"btFlag =  {packet.ReadAscii()}, " +
                             $"btRespawn =  {packet.ReadAscii()}, " +
                             $"btType =  {packet.ReadAscii()} where dwNestID = {packet.ReadInt()};";
            var AffectedRows = 0;
            try
            {
                AffectedRows = SQL.ExecuteQuery(query, StudioServer.settings.DBSha);
            }
            catch (Exception ex)
            {
                packet = new Packet(0xA009);
                packet.WriteAscii(ex.Message);
                return packet;
            }
            if (AffectedRows >=1)
            {
                    ServerMembory.SendUpdateSuccessNoticeToAll($"Successfully affected {AffectedRows} rows with NestUpdater => Query '{query}'!", AccountName);
                    ServerMembory.RefreshTableForAll("Tab_RefNest");
            }
            else
            {
                packet = new Packet(0xA009);
                packet.WriteAscii("No rows updated!");
                return packet;
            }
            return null;
        }
    }
}
