using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Trigger
{
    public class REQ_ADD_CONDITION_TO_TRIGGER
    {
        #region Internal Methods

        internal static Packet AddConditionToTrigger(Packet packet, string AccName)
        {
            string TriggerName = packet.ReadAscii();
            string ConditionName = packet.ReadAscii();
            string obj = packet.ReadAscii();

            SqlParameter[] AddConditionWithActionParams = new SqlParameter[]
               {
                     new SqlParameter("@TriggerName",SqlDbType.VarChar,128){ Value= TriggerName },
                     new SqlParameter("@CommonCondition",SqlDbType.VarChar,129){ Value= ConditionName},
                     new SqlParameter("@Value1",SqlDbType.VarChar,128){ Value= obj }
               };
            DataRow ConditionToTriggerRow = SQL.ReturnDataTableByProcedure("_ADD_TRIGGERCONDITION", StudioServer.settings.DBDev, AddConditionWithActionParams).Rows[0];
            bool ok = bool.Parse(ConditionToTriggerRow[0].ToString());
            string resultText = ConditionToTriggerRow[1].ToString();

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

        #endregion Internal Methods
    }
}