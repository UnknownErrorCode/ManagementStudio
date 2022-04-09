using ManagementFramework.Network.Security;
using System;
using System.Linq;

namespace PluginFramework.Network
{
    internal partial class ClientPacketHandler : PacketHandler
    {
        #region Fields

        public Action OnAllowedPluginReceived;

        #endregion Fields

        #region Constructors

        internal ClientPacketHandler()
        {
            base.AddEntry(PacketID.Server.AllowedPluginResponse, AllowedPlugins);
            base.AddEntry(PacketID.Server.AllowedDataTableNameResponse, AllowedDataTable);
            base.AddEntry(PacketID.Server.DataTableResponse, ReceiveDataTable);

            base.AddEntry(PacketID.Server.LogNotification, ReceiveNotification);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Receives a string[] of all DataTables that the application is permitted to load.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        internal PacketHandlerResult AllowedDataTable(ServerData arg1, Packet arg2)
        {
            ClientMemory.AllowedDataTables = arg2.ReadAsciiArray();
            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Receives a string[] of all .dll Plugins that the application is permitted to load.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        internal PacketHandlerResult AllowedPlugins(ServerData arg1, Packet arg2)
        {
            ClientMemory.AllowedPlugin = arg2.ReadAsciiArray();
            OnAllowedPluginReceived();
            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Receives a DataTable from the server and stores it into the SRO_VT_SHARD DataSet.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        internal PacketHandlerResult ReceiveDataTable(ServerData arg1, Packet arg2)
        {
            string tableName = arg2.ReadAscii();

            if (!ClientMemory.AllowedDataTables.Contains(tableName))
            {
                ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.fatal, $"Not allowed to use DataTable: {tableName}");

                return PacketHandlerResult.Disconnect;
            }

            var arg3 = arg2.ReadByteArray(arg2.Remaining);
            var table = arg2.ReadDataTable(arg3);
            Database.SRO_VT_SHARD.PoolDataTable(tableName, table);

            ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.sql, $"Received DataTable: {tableName}");

            return PacketHandlerResult.Block;
        }

        private PacketHandlerResult ReceiveNotification(ServerData arg1, Packet arg2)
        {
            ManagementFramework.Ressources.LogLevel type = (ManagementFramework.Ressources.LogLevel)arg2.ReadByte();
            string text = arg2.ReadAscii();
            ManagementFramework.Log.Logger.WriteLogLine(type, text);
            return PacketHandlerResult.Block;
        }

        #endregion Methods
    }
}