using ServerFrameworkRes.Network.Security;
using System.Data;

namespace ManagementServer.Handler
{
    class S_SECURITYGROUP
    {
        /// <summary>
        /// Sends all Plugins to load to the Client in order to warrant security group authority
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        internal static Packet SendAllowedPlugins(string securityGroup)
        {
            var PluginDataRowCollection = Utility.SQL.AllowedPlugins(securityGroup).Rows;

            Packet AllowedPlugins = new Packet(0xB000);
            AllowedPlugins.WriteInt(PluginDataRowCollection.Count);

            foreach (DataRow row in PluginDataRowCollection)
                AllowedPlugins.WriteAscii(row.Field<string>("AllowedPlugins"));

            return AllowedPlugins;
        }
    }
}
