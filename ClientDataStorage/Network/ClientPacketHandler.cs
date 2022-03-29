using ServerFrameworkRes.Network.Security;
using System;
using System.Data;
using System.Linq;

namespace ClientDataStorage.Network
{
    internal partial class ClientPacketHandler : PacketHandler
    {
        public Action OnReceiveAllTables;
        public Action OnAllowedPluginReceived;

        internal ClientPacketHandler()
        {
            base.AddEntry(0xB000, AllowedPlugins);
            base.AddEntry(0xB001, AllowedDataTable);
            base.AddEntry(0xB002, ReceiveDataTable);

            base.AddEntry(0xB003, ReceiveNotification);
        }

        private PacketHandlerResult ReceiveNotification(ServerData arg1, Packet arg2)
        {
            var type = (ServerFrameworkRes.Ressources.LogLevel)arg2.ReadByte();
            var text = arg2.ReadAscii();
            Log.Logger.WriteLogLine(type, text);
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
        /// Receives a DataTable from the server and stores it into the SRO_VT_SHARD DataSet.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        internal PacketHandlerResult ReceiveDataTable(ServerData arg1, Packet arg2)
        {
            var tableName = arg2.ReadAscii();

            if (!ClientMemory.AllowedDataTables.Contains(tableName))
                return PacketHandlerResult.Disconnect;

            var arg3 = arg2.ReadByteArray(arg2.Remaining);
            DataTable table = arg2.ReadDataTable(arg3);
            Database.SRO_VT_SHARD.PoolDataTable(tableName, table);

            Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Received DataTable: {tableName}");

            if (ClientMemory.UsedDataTables?.Count == 0)
            {
                Log.Logger.WriteLogLine($"Successfully received  all DataTables!");

                Log.Logger.WriteLogLine($"Start initialize Databases for Client usage...");
                // Database.SRO_VT_SHARD.InitializeDBShard();
                Log.Logger.WriteLogLine($"Finished initialize Databases");
                OnReceiveAllTables();
            }
            return PacketHandlerResult.Block;
        }
    }
}