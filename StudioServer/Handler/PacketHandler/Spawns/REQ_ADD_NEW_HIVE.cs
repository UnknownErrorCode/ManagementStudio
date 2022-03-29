using ServerFrameworkRes.Network.Security;
using StudioServer.Handler.PacketHandler.Spawns.SpawnInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Spawns
{
    public static class REQ_ADD_NEW_HIVE
    {
        #region Public Methods

        public static Packet AddNewHive(Packet packet, string AccName)
        {
            ITabRefHiveUpdater test = new ITabRefHiveUpdater()
            {
                btKeepMonsterCountType = packet.ReadAscii(),
                dwOverwriteMaxTotalCount = packet.ReadAscii(),
                fMonsterCountPerPC = packet.ReadAscii(),
                dwSpawnSpeedIncreaseRate = packet.ReadAscii(),
                dwMaxIncreaseRate = packet.ReadAscii(),
                btFlag = packet.ReadAscii(),
                GameWorldID = packet.ReadAscii(),
                HatchObjType = packet.ReadAscii(),
                szDescString128 = packet.ReadAscii(),
            };

            /*
                PROCEDURE _ADD_NEW_HIVE
                @btKeepMonsterCountType tinyint =1 ,
                @dwOverwriteMaxTotalCount int = 1,
                @fMonsterCountPerPC real = 0,
                @dwSpawnSpeedIncreaseRate int = 0,
                @dwMaxIncreaseRate int = 0,
                @btFlag tinyint= 0,
                @GameWorldID smallint,
                @HatchObjType smallint= 1,
                @szDescString128 varchar(128)
              */
            SqlParameter[] parameterForHive = new SqlParameter[]
               {
                    new SqlParameter("@btKeepMonsterCountType",SqlDbType.TinyInt) {Value = test.btKeepMonsterCountType},
                    new SqlParameter("@dwOverwriteMaxTotalCount",SqlDbType.Int) {Value = test.dwOverwriteMaxTotalCount},
                    new SqlParameter("@fMonsterCountPerPC",SqlDbType.Real) {Value = test.fMonsterCountPerPC},
                    new SqlParameter("@dwSpawnSpeedIncreaseRate",SqlDbType.Int) {Value = test.dwSpawnSpeedIncreaseRate},
                    new SqlParameter("@dwMaxIncreaseRate",SqlDbType.Int) {Value = test.dwMaxIncreaseRate},
                    new SqlParameter("@btFlag",SqlDbType.TinyInt) {Value = test.btFlag},
                    new SqlParameter("@GameWorldID",SqlDbType.SmallInt) {Value = test.GameWorldID},
                    new SqlParameter("@HatchObjType",SqlDbType.SmallInt) {Value = test.HatchObjType},
                    new SqlParameter("@szDescString128",SqlDbType.VarChar,128) {Value = test.szDescString128},
               };
            DataRow HiveResult = SQL.ReturnDataTableByProcedure("_ADD_NEW_HIVE", StudioServer.settings.DBDev, parameterForHive).Rows[0];
            bool ok = bool.Parse(HiveResult.ItemArray[0].ToString());
            string resultText = HiveResult.ItemArray[1].ToString();
            if (ok)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, resultText);
                ServerMembory.SendUpdateSuccessNoticeToAll(resultText, AccName);
                ServerMembory.RefreshTableForAll("Tab_RefHive");
            }
            else
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"{AccName} : {resultText}");
                packet = new Packet(0xA009);
                packet.WriteAscii(resultText);
                return packet;
            }
            return null;
        }

        #endregion Public Methods
    }
}