using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Teleporter
{
    sealed class REQ_UPDATE_TELEPORT
    {

        internal static Packet UpdateTeleport(Packet updatePacket, string accountName)
        {

            var TeleportID = updatePacket.ReadInt();
            int Service = updatePacket.ReadBool()==true ? 1:0;
            var CodeName128 = updatePacket.ReadAscii();
            var AssocRefObjCodeName = updatePacket.ReadAscii();
            var AssicRefObjID = updatePacket.ReadInt();
            var ZoneName128 = updatePacket.ReadAscii();
            var RegionID = updatePacket.ReadShort();
            var X = updatePacket.ReadShort();
            var Y = updatePacket.ReadShort();
            var Z = updatePacket.ReadShort();
            var GenerateRadius = updatePacket.ReadShort();
            var CanBeRessurectPos = updatePacket.ReadBool() ? 1 : 0;
            var CanGoToRessurect = updatePacket.ReadBool() ? 1 : 0;
            var GenerateWorldID = updatePacket.ReadShort();
            var BindInteractMask = updatePacket.ReadBool() ? 1:0;
            var FixedService = updatePacket.ReadBool() ? 1 : 0;



            var ParamArray = new SqlParameter[]
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

            var res = SQL.ReturnDataTableByProcedure("_UPDATE_TELEPORT", StudioServer.settings.DBDev, ParamArray);



            return null;
        }
    }
}
