using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Trigger
{
    internal class REQ_ADD_TRIGGER_TO_CATEGORY
    {
        #region Internal Methods

        internal static Packet TriggerToCategory(Packet packet, string contentUser)
        {
            string CategoryName = packet.ReadAscii();
            string TriggerName = packet.ReadAscii();
            int IsRepeatable = packet.ReadInt();
            string TriggerDescription = packet.ReadAscii();
            SqlParameter[] AddTriggerToCategoryParams = new SqlParameter[]
               {
                new SqlParameter("@BindToCategoryName",SqlDbType.VarChar,128) { Value = CategoryName},
                new SqlParameter("@TriggerName",SqlDbType.VarChar,124) { Value = TriggerName},
                new SqlParameter("@IsRepeat",SqlDbType.Int) { Value = IsRepeatable},
                new SqlParameter("@PersonalComment",SqlDbType.VarChar,513) { Value = TriggerDescription}
               };
            DataRow prepare = SQL.ReturnDataTableByProcedure("_ADD_TRIGGER_TO_CATEGORY", StudioServer.settings.DBDev, AddTriggerToCategoryParams).Rows[0];
            bool ok = bool.Parse(prepare[0].ToString());
            string resultText = prepare[1].ToString();

            if (ok)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, resultText);

                ServerMembory.SendUpdateSuccessNoticeToAll(resultText, contentUser);
                ServerMembory.RefreshTableForAll("_RefTrigger");
                ServerMembory.RefreshTableForAll("_RefTriggerCategoryBindTrigger");
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