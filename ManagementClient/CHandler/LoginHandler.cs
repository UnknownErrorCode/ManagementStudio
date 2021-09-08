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

        internal static PacketHandlerResult AllowedPlugins(ServerData arg1, Packet arg2)
        {
            ClientMemory.AllowedPlugin = new string[arg2.ReadInt()];

            for (int i = 0; i < ClientMemory.AllowedPlugin.Length; i++)
                ClientMemory.AllowedPlugin[i] = arg2.ReadAscii();

            return PacketHandlerResult.Block;
        }

        internal static PacketHandlerResult AllowedDataTable(ServerData arg1, Packet arg2)
        {
            string[] tableNames = new string[arg2.ReadInt()];

            for (int i = 0; i < tableNames.Length; i++)
                tableNames[i] = arg2.ReadAscii();

            var listOfPackets = new List<Packet>(tableNames.Length);
            foreach (var table in tableNames)
            {
                ClientMemory.AllowedDataTables = new List<string>(tableNames.Length);
                ClientMemory.AllowedDataTables.Add(table);
                Packet tableRequestPacket = new Packet(0x0999, false, true);
                tableRequestPacket.WriteAscii(table);
                listOfPackets.Add(tableRequestPacket);
            }
            for (int i = 0; i < listOfPackets.Count; i++)
                arg1.m_security.Send(listOfPackets[i]);


            return PacketHandlerResult.Block;
        }

        internal static PacketHandlerResult ReceiveDataTable(ServerData arg1, Packet arg2)
        {
            var tableName = arg2.ReadAscii();
            var bytearr = arg2.ReadByteArray(arg2.Remaining);
            DataTable table = arg2.ReadDataTable(bytearr);
            table.TableName = tableName;

            ClientForm.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Received DataTable: {tableName}");

            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables.Contains(tableName))
                ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables.Remove(tableName);

            ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables.Add(table);

            ClientMemory.AllowedDataTables.Remove(tableName);
            if (ClientMemory.AllowedDataTables.Count==0)
            {
                ClientForm.Logger.WriteLogLine($"Successfully received  all DataTables!");
                ClientDataStorage.Client.Media.InitializeMedia();
                ManagementClient.Program.StaticClientForm.Invoke(new Action(() => Program.StaticClientForm.loadPluginsToolStripMenuItem.Enabled = true));
            }

            return PacketHandlerResult.Block;
        }
    }
}
