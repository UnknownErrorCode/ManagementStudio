using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Trigger
{
    public class REQ_ADD_EVENT_TO_TRIGGER
    {
        #region Public Methods

        public static Packet EventToTrigger(Packet packet, string AccName)
        {
            string TriggerName = packet.ReadAscii();
            string TriggerCommonName = packet.ReadAscii();

            SqlParameter[] AddEventParams = new SqlParameter[]
            {
                new SqlParameter("@TriggerName",SqlDbType.VarChar,128) {Value=TriggerName },
                new SqlParameter("@EventName",SqlDbType.VarChar,128) {Value=  TriggerCommonName }
            };

            DataRow EventToTriggerRowResult = SQL.ReturnDataTableByProcedure("_ADD_TRIGGEREVENT_TO_TRIGGER", StudioServer.settings.DBDev, AddEventParams).Rows[0];

            bool ok = bool.Parse(EventToTriggerRowResult[0].ToString());
            string resultText = EventToTriggerRowResult[1].ToString();
            if (ok)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, resultText);
                ServerMembory.SendUpdateSuccessNoticeToAll(resultText, AccName);
                ServerMembory.RefreshTableForAll("_RefTriggerBindEvent");
                ServerMembory.RefreshTableForAll("_RefTriggerEvent");
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

        #endregion Public Methods
    }
}