using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Teleporter
{
    internal sealed class REQ_UPDATE_TELEPORT
    {
        #region Internal Methods

        internal static Packet UpdateTeleport(Packet updatePacket, string accountName)
        {
            int TeleportID = updatePacket.ReadInt();
            int Service = updatePacket.ReadBool() == true ? 1 : 0;
            string CodeName128 = updatePacket.ReadAscii();
            string AssocRefObjCodeName = updatePacket.ReadAscii();
            int AssicRefObjID = updatePacket.ReadInt();
            string ZoneName128 = updatePacket.ReadAscii();
            short RegionID = updatePacket.ReadShort();
            short X = updatePacket.ReadShort();
            short Y = updatePacket.ReadShort();
            short Z = updatePacket.ReadShort();
            short GenerateRadius = updatePacket.ReadShort();
            int CanBeRessurectPos = updatePacket.ReadBool() ? 1 : 0;
            int CanGoToRessurect = updatePacket.ReadBool() ? 1 : 0;
            short GenerateWorldID = updatePacket.ReadShort();
            int BindInteractMask = updatePacket.ReadBool() ? 1 : 0;
            int FixedService = updatePacket.ReadBool() ? 1 : 0;

            SqlParameter[] ParamArray = new SqlParameter[]
            {
                new SqlParameter("@TeleportID", SqlDbType.Int) {Value = TeleportID},
                new SqlParameter("@Service", SqlDbType.Int) {Value = Service},
                new SqlParameter("@CodeName128", SqlDbType.VarChar, 128) {Value = CodeName128},
                new SqlParameter("@AssocRefObjCodeName128", SqlDbType.VarChar, 128) {Value = AssocRefObjCodeName},
                new SqlParameter("@AssocRefObjID", SqlDbType.Int) {Value = AssicRefObjID},
                new SqlParameter("@ZoneName128", SqlDbType.VarChar, 128) {Value = ZoneName128},
                new SqlParameter("@GenRegionID", SqlDbType.SmallInt) {Value = RegionID},
                new SqlParameter("@GenPos_X", SqlDbType.SmallInt) {Value = X},
                new SqlParameter("@GenPos_Y", SqlDbType.SmallInt) {Value = Y},
                new SqlParameter("@GenPos_Z", SqlDbType.SmallInt) {Value = Z},
                new SqlParameter("@GenAreaRadius", SqlDbType.SmallInt) {Value = GenerateRadius},
                new SqlParameter("@CanBeResurrectPos", SqlDbType.TinyInt) {Value = CanBeRessurectPos},
                new SqlParameter("@CanGotoResurrectPos", SqlDbType.TinyInt) {Value = CanGoToRessurect},
                new SqlParameter("@GenWorldID", SqlDbType.SmallInt) {Value = GenerateWorldID},
                new SqlParameter("@BindInteractionMask", SqlDbType.TinyInt) {Value = BindInteractMask},
                new SqlParameter("@FixedService", SqlDbType.TinyInt) {Value = FixedService},
            };

            DataTable res = SQL.ReturnDataTableByProcedure("_UPDATE_TELEPORT", StudioServer.settings.DBDev, ParamArray);

            return null;
        }

        #endregion Internal Methods
    }
}