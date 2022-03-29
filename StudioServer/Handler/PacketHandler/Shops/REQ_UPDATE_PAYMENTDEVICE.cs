using ServerFrameworkRes.Network.Security;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Shops
{
    internal class REQ_UPDATE_PAYMENTDEVICE
    {
        #region Public Methods

        public static Packet UpdateDevice(Packet packet, string AccountName)
        {
            if (AccountName == null)
            {
                OutgoingPackets.FailNoticePlayer("Please reconnect with your tool in order to establish a connection again!");
                return null;
            }
            string PackageCodeName = packet.ReadAscii();
            int Device = packet.ReadInt();
            long Price = packet.ReadLong();
            bool Delete = packet.ReadBool();
            SqlParameter[] sqlparameter = new SqlParameter[]
                {
                    new SqlParameter("@PackageItemCodeName128",System.Data.SqlDbType.VarChar, 128) { Value =PackageCodeName },
                    new SqlParameter("@Device",System.Data.SqlDbType.Int) { Value =Device },
                    new SqlParameter("@Price"   ,System.Data.SqlDbType.BigInt) { Value =Price },
                    new SqlParameter("@Delete"   ,System.Data.SqlDbType.Bit) { Value =Delete },
                };
            System.Data.DataRow rowcount = SQL.ReturnDataTableByProcedure("_ADD_PRICE_TO_ITEM", StudioServer.settings.DBDev, sqlparameter).Rows[0];

            int valueReturn = int.Parse(rowcount[0].ToString());
            string textReturn = rowcount[1].ToString();
            if (valueReturn > 0)
            {
                ServerMembory.SendUpdateSuccessNoticeToAll(textReturn, AccountName);
                ServerMembory.RefreshTableForAll("_RefPricePolicyOfItem");
            }
            else
            {
                return OutgoingPackets.FailNoticePlayer(textReturn);
            }

            return null;
        }

        #endregion Public Methods
    }
}