using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudioServer.Handler.PacketHandler
{
    internal class REQ_UPDATE_TABLE
    {
        #region Internal Methods

        /// <summary>
        /// 0x7500
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="accountName"></param>
        /// <returns></returns>
        internal static Packet UpdateTable(Packet opcode, string accountName)
        {
            Dictionary<string, string> allColumns = new Dictionary<string, string>();
            Dictionary<string, string> indicators = new Dictionary<string, string>();

            try
            {
                string tableName = opcode.ReadAscii();

                int IndCount = opcode.ReadInt();
                for (int i = 0; i < IndCount; i++)
                {
                    string indicator = opcode.ReadAscii();
                    string indicatorValue = opcode.ReadAscii();
                    indicators.Add(indicator, indicatorValue);
                }
                int ColCount = opcode.ReadInt();
                for (int i = 0; i < ColCount; i++)
                {
                    string headerName = opcode.ReadAscii();
                    string headerValue = opcode.ReadAscii();
                    allColumns.Add(headerName, headerValue);
                }
                string UpdateString = GenerateUpdateString(tableName, allColumns, indicators);
                opcode = OutgoingPackets.NotifyNoticePlayer(UpdateString);
            }
            catch (Exception ex)
            {
                opcode = null;
            }
            return opcode;
        }

        #endregion Internal Methods

        #region Private Methods

        private static string GenerateUpdateString(string name, Dictionary<string, string> columns, Dictionary<string, string> Indicators)
        {
            string QueryText = $"UPDATE {name} SET ";
            try
            {
                foreach (KeyValuePair<string, string> item in columns)
                {
                    QueryText = $"{QueryText} {item.Key} = {item.Value} ,";
                }
                QueryText = QueryText.Remove(QueryText.Length - 1, 1);
                QueryText = $"{QueryText} where {Indicators.Keys.First()} = '{Indicators.Values.First()}' ";
                //Indicators.Remove(Indicators.Keys.First());
                for (int i = 1; i < Indicators.Count; i++)
                {
                    string value = Indicators.Keys.ToList()[i];
                    QueryText = $"{QueryText} and {value} = '{Indicators[value]}' ";
                }
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, $"Update Table {name} with {QueryText}");
            }
            catch (Exception ex)
            {
                QueryText = null;
            }

            return QueryText;
        }

        #endregion Private Methods
    }
}