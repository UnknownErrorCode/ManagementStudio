using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Shops
{
    internal class REQ_ADD_GOOD_TO_TAB
    {
        internal static Packet Add(Packet opcode, string AccountName)
        {
            string PackageItemCodeName128 = opcode.ReadAscii();
            string StoreTabName = opcode.ReadAscii();
            int Slot = opcode.ReadInt();


            SqlParameter[] ParamArray = new SqlParameter[]
            {
                new SqlParameter("@PackageItemCodeName128",SqlDbType.VarChar, 128) {Value = PackageItemCodeName128},
                new SqlParameter("@StoreTabName", SqlDbType.VarChar, 128) {Value = StoreTabName},
                new SqlParameter("@Slot", SqlDbType.Int) {Value = Slot}
            };
            DataRow rowcount = SQL.ReturnDataTableByProcedure("_ADD_SHOPGOOD_TO_TAB", StudioServer.settings.DBDev, ParamArray).Rows[0];

            int valueReturn = int.Parse(rowcount[0].ToString());
            string textReturn = rowcount[1].ToString();
            if (valueReturn > 0)
            {
                ServerMembory.SendUpdateSuccessNoticeToAll(textReturn, AccountName);
                ServerMembory.RefreshTableForAll("_RefShopGoods");
            }
            else
            {
                return OutgoingPackets.FailNoticePlayer(textReturn);
            }
            return null;

        }
    }
}