using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementClient.CHandler
{
    class LoginHandler
    {
        /// <summary>
        /// The Login user status consists of either success or fail, resultMessage, Security Group and real AccountName. 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        internal static PacketHandlerResult LoginStatus(ServerData arg1, Packet arg2)
        {
            var ok = arg2.ReadBool();
            var msg = arg2.ReadAscii();
            var securityGroup = int.Parse(arg2.ReadAscii());
            var accountName = arg2.ReadAscii();
            if (ok)
            {
                ClientMemory.LoggedIn = true;
                arg1.AccountName = accountName;
                Program.StaticLoginForm.Invoke(new Action(() => Program.StaticLoginForm.OnHide()));
            }
            else
                vSroMessageBox.Show($"Login failed! \n{msg}");


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

            var listOfPackets = new List<Packet>(tableNames.Length);
            ClientMemory.AllowedDataTables = new List<string>(tableNames.Length);
            foreach (var table in tableNames)
            {
                ClientMemory.AllowedDataTables.Add(table);
                Packet tableRequestPacket = new Packet(0x0999, false, true);
                tableRequestPacket.WriteAscii(table);
                listOfPackets.Add(tableRequestPacket);
            }
            for (int i = 0; i < listOfPackets.Count; i++)
                arg1.m_security.Send(listOfPackets[i]);


            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Receives a DataTable from the server and stores it into the SRO_VT_SHARD DataSet.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        internal static PacketHandlerResult ReceiveDataTable(ServerData arg1, Packet arg2)
        {
            var tableName = arg2.ReadAscii();
            PoolDataTable(tableName, arg2);

            ClientDataStorage.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Received DataTable: {tableName}");

            if (ClientMemory.AllowedDataTables.Count == 0)
            {
                Program.StaticClientForm.Invoke(new Action(() => Program.StaticClientForm.loadPluginsToolStripMenuItem.Enabled = true));
                ClientDataStorage.Log.Logger.WriteLogLine($"Successfully received  all DataTables!");
            }

            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Save or update the Table in memory
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="arg2"></param>
        private static async void PoolDataTable(string tableName, Packet arg2)
        {
            var bytearr = arg2.ReadByteArray(arg2.Remaining);
            DataTable table = arg2.ReadDataTable(bytearr);
            table.TableName = tableName;

            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables.Contains(tableName))
                ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables.Remove(tableName);

            ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables.Add(table);

            ClientMemory.AllowedDataTables.Remove(tableName);

            await Task.Delay(1);
        }
    }
}
