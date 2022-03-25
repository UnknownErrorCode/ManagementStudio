using ClientDataStorage.Dashboard;
using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Network
{
    internal partial class ClientPacketHandler : PacketHandler
    {

        public Action OnReceiveAllTables;
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
        internal static PacketHandlerResult AllowedPlugins(ServerData arg1, Packet arg2)
        {
            ClientMemory.AllowedPlugin = new string[arg2.ReadInt()];

            for (int i = 0; i < ClientMemory.AllowedPlugin.Length; i++)
                ClientMemory.AllowedPlugin[i] = arg2.ReadAscii();

            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Receives a string[] of all DataTables that the application is permitted to load.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        internal static PacketHandlerResult AllowedDataTable(ServerData arg1, Packet arg2)
        {
            string[] tableNames = new string[arg2.ReadInt()];

            for (int i = 0; i < tableNames.Length; i++)
                tableNames[i] = arg2.ReadAscii();

            ClientMemory.AllowedDataTables = tableNames.ToList();// new List<string>(tableNames.Length);

            Packet tableRequestPacket = new Packet(PacketID.Client.RequestDataTable, false, true);
            tableRequestPacket.WriteByte((byte)tableNames.Length);
            foreach (var table in tableNames)
            {
                tableRequestPacket.WriteAscii(table);
            }

            arg1.m_security.Send(tableRequestPacket);



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
            var arg3 = arg2.ReadByteArray(arg2.Remaining);
            DataTable table = arg2.ReadDataTable(arg3);
            Database.SRO_VT_SHARD.PoolDataTable(tableName, table);

            Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Received DataTable: {tableName}");

            if (ClientMemory.AllowedDataTables.Count == 0)
            {
                Log.Logger.WriteLogLine($"Successfully received  all DataTables!");

                Log.Logger.WriteLogLine($"Start initialize Databases for Client usage...");
                Database.SRO_VT_SHARD.InitializeDBShard();
                Log.Logger.WriteLogLine($"Finished initialize Databases");
                OnReceiveAllTables();
                //   Program.StaticClientForm.Invoke(new Action(() => Program.StaticClientForm.loadPluginsToolStripMenuItem.Enabled = true));
            }

            return PacketHandlerResult.Block;
        }

    }
}
