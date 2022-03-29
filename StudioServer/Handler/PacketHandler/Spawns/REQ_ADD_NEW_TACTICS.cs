using ServerFrameworkRes.Network.Security;
using StudioServer.Handler.PacketHandler.Spawns.SpawnInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Spawns
{
    public class REQ_ADD_NEW_TACTICS
    {
        #region Public Methods

        public static Packet NEW_TACTICS(Packet packet, string AccName) //7010
        {
            string MobName = packet.ReadAscii();
            bool Aggro = packet.ReadBool();
            string Desc = packet.ReadAscii();
            bool AddAsMonster = packet.ReadBool();
            ITabRefTacticsAdder tacticinterface = new ITabRefTacticsAdder(MobName, Aggro, Desc);
            SqlParameter[] array = new SqlParameter[4]
                {
                new SqlParameter("@MobCodeName",SqlDbType.VarChar,128)  { Value = tacticinterface.MobName},
                new SqlParameter("@Aggressive",SqlDbType.TinyInt)  { Value = tacticinterface.Aggro},
                new SqlParameter("@Desc",SqlDbType.VarChar,128)  { Value = tacticinterface.Desc},
                new SqlParameter("@AddAsMonster",SqlDbType.TinyInt)  { Value = AddAsMonster?(byte)1:(byte)0},
                };

            DataRow tb = SQL.ReturnDataTableByProcedure("_ADD_NEW_TACTICS", StudioServer.settings.DBDev, array).Rows[0];
            bool ok = bool.Parse(tb[0].ToString());
            string resultText = tb[1].ToString();
            if (ok)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, resultText);
                ServerMembory.SendUpdateSuccessNoticeToAll(resultText, AccName);
                ServerMembory.RefreshTableForAll("Tab_RefTactics");
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