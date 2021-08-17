using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Trigger
{
   public class REQ_ADD_CONDITION_TO_TRIGGER
    {
        internal static Packet AddConditionToTrigger(Packet packet, string AccName)
        {
            var TriggerName = packet.ReadAscii();
            var ConditionName = packet.ReadAscii();
            var obj = packet.ReadAscii();


            SqlParameter[] AddConditionWithActionParams = new SqlParameter[]
               {
                     new SqlParameter("@TriggerName",SqlDbType.VarChar,128){ Value= TriggerName },
                     new SqlParameter("@CommonCondition",SqlDbType.VarChar,129){ Value= ConditionName},
                     new SqlParameter("@Value1",SqlDbType.VarChar,128){ Value= obj }
               };
            DataRow ConditionToTriggerRow = SQL.ReturnDataTableByProcedure("_ADD_TRIGGERCONDITION", StudioServer.settings.DBDev, AddConditionWithActionParams).Rows[0];
            var ok = bool.Parse(ConditionToTriggerRow[0].ToString());
            var resultText = ConditionToTriggerRow[1].ToString();

            if (ok)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, resultText);

                ServerMembory.SendUpdateSuccessNoticeToAll(resultText, AccName);
                ServerMembory.RefreshTableForAll("_RefTriggerBindCondition");
                ServerMembory.RefreshTableForAll("_RefTriggerCondition");
                ServerMembory.RefreshTableForAll("_RefTriggerConditionParam");

            }
            else
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, resultText);
                packet = new Packet(0xA009);
                packet.WriteAscii(resultText);
                return packet;
            }
            return null;
        }
    }
}
