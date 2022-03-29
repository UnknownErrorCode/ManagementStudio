using ServerFrameworkRes.Network.Security;
using StudioServer.Handler.PacketHandler.Spawns.SpawnInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Spawns
{
    internal class REQ_ADD_NEW_NEST
    {

        internal static Packet AddNewNest(Packet packet, string AccName)
        {

            ITabRefNestUpdater tab_RefNest = new ITabRefNestUpdater()
            {
                dwHiveID = packet.ReadAscii(),
                dwTacticsID = packet.ReadAscii(),
                CharName16 = packet.ReadAscii(),
                nRegionDBID = packet.ReadInt(),
                fLocalPosX = packet.ReadAscii(),
                fLocalPosY = packet.ReadAscii(),
                fLocalPosZ = packet.ReadAscii(),
                wInitialDir = packet.ReadAscii(),
                nRadius = packet.ReadAscii(),
                nGenerateRadius = packet.ReadAscii(),
                nChampionGenPercentage = packet.ReadAscii(),
                dwDelayTimeMin = packet.ReadAscii(),
                dwDelayTimeMax = packet.ReadAscii(),
                dwMaxTotalCount = packet.ReadAscii(),
                btFlag = packet.ReadAscii(),
                btRespawn = packet.ReadAscii(),
                btType = packet.ReadAscii(),
            };

            /*
             * PROCEDURE _ADD_NEW_NEST
             * @dwHiveID		INT,
             * @dwTacticsID		INT,
             * @nRegionID		INT,
             * @nPosX			REAL,
             * @nPosY			REAL,
             * @nPosZ			REAL,
             * @wInitDir		SMALLINT,
             * @nRadius			INT,
             * @nGenerateRadius	INT,
             * @nChampion		INT,
             * @dwDelayMin		INT,
             * @dwDelayMax		INT,
             * @dwMaxCount		INT,
             * @btFlag			TINYINT,
             * @btRespawn		TINYINT,
             * @btType			TINYINT
             */
            SqlParameter[] AddNestParams = new SqlParameter[]
               {
                    new SqlParameter("@dwHiveID",SqlDbType.Int) {Value=tab_RefNest.dwHiveID},
                    new SqlParameter("@dwTacticsID",SqlDbType.Int) {Value=tab_RefNest.dwTacticsID},
                    new SqlParameter("@nRegionID",SqlDbType.SmallInt) {Value=tab_RefNest.nRegionDBID},
                    new SqlParameter("@nPosX",SqlDbType.VarChar,64) {Value=tab_RefNest.fLocalPosX},
                    new SqlParameter("@nPosY",SqlDbType.VarChar,64) {Value=tab_RefNest.fLocalPosY},
                    new SqlParameter("@nPosZ",SqlDbType.VarChar,64) {Value=tab_RefNest.fLocalPosZ},
                    new SqlParameter("@wInitDir",SqlDbType.SmallInt) {Value=tab_RefNest.wInitialDir},
                    new SqlParameter("@nRadius",SqlDbType.Int) {Value=tab_RefNest.nRadius},
                    new SqlParameter("@nGenerateRadius",SqlDbType.Int) {Value=tab_RefNest.nGenerateRadius},
                    new SqlParameter("@nChampion",SqlDbType.Int) {Value=tab_RefNest.nChampionGenPercentage},
                    new SqlParameter("@dwDelayMin",SqlDbType.Int) {Value=tab_RefNest.dwDelayTimeMin},
                    new SqlParameter("@dwDelayMax",SqlDbType.Int) {Value=tab_RefNest.dwDelayTimeMax},
                    new SqlParameter("@dwMaxCount",SqlDbType.Int) {Value=tab_RefNest.dwMaxTotalCount},
                    new SqlParameter("@btFlag",SqlDbType.TinyInt) {Value=tab_RefNest.btFlag},
                    new SqlParameter("@btRespawn",SqlDbType.TinyInt) {Value=tab_RefNest.btRespawn},
                    new SqlParameter("@btType",SqlDbType.TinyInt) {Value=tab_RefNest.btType}
               };
            DataRow NestResult = SQL.ReturnDataTableByProcedure("_ADD_NEW_NEST", StudioServer.settings.DBDev, AddNestParams).Rows[0];
            bool booler = bool.Parse(NestResult[0].ToString());
            string returnString = NestResult[0].ToString();

            if (booler)
            {
                ServerMembory.SendUpdateSuccessNoticeToAll(returnString, AccName);
                ServerMembory.RefreshTableForAll("Tab_RefNest");
            }
            else
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"{AccName} : {returnString}");
                packet = new Packet(0xA009);
                packet.WriteAscii(returnString);
                return packet;
            }
            return null;
        }


    }
}
