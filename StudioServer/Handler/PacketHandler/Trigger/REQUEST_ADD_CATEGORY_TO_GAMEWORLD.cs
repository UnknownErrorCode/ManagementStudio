using ServerFrameworkRes.Network.Security;
using System.Data;
using System.Data.SqlClient;

namespace StudioServer.Handler.PacketHandler.Trigger
{
    internal class REQUEST_ADD_CATEGORY_TO_GAMEWORLD
    {
        #region Internal Methods

        internal static Packet TriggerCategoryToGameWorld(Packet opcode, string AccountName) //0x7001
        {
            int WorldID = opcode.ReadInt();
            string CategoryName = opcode.ReadAscii();
            string CategoryDescription = opcode.ReadAscii();
            SqlParameter[] AddCategoryToWorldParams = new SqlParameter[]
                    {
                new SqlParameter("@WorldID",SqlDbType.Int) { Value = WorldID},
                new SqlParameter("@TriggerCategoryName",SqlDbType.VarChar,129) { Value = CategoryName},
                new SqlParameter("@CategoryDesc",SqlDbType.VarChar,129) { Value = CategoryDescription},
                    };
            DataRow CategoryToGameWorldResult = SQL.ReturnDataTableByProcedure("_ADD_TRIGGERCATEGORY_TO_WORLD", StudioServer.settings.DBDev, AddCategoryToWorldParams).Rows[0];
            bool test = bool.Parse(CategoryToGameWorldResult[0].ToString());
            string resString = CategoryToGameWorldResult[1].ToString();
            if (test)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, resString);

                ServerMembory.RefreshTableForAll("_RefTriggerCategory");
                ServerMembory.RefreshTableForAll("_RefGameWorldBindTriggerCategory");
                ServerMembory.SendUpdateSuccessNoticeToAll(resString, AccountName);
            }
            else
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, resString);
                opcode = new Packet(0xA009);
                opcode.WriteAscii(resString);
                return opcode;
            }
            return null;
        }

        #endregion Internal Methods
    }
}