using ManagementServer.Utility;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Handler
{
    class S_UPDATE
    {
        /// <summary>
        /// SERVER => CLIENT  0xA001 include latest version
        /// -- Sends latest version to client.
        /// </summary>
        /// <returns></returns>

        internal static Packet SendServerVersion()
        {
            Packet loginSuccessPacket = new Packet(0xA001);
            loginSuccessPacket.WriteInt(SQL.LatestVersion());
            return loginSuccessPacket;
        }

        /// <summary>
        /// SERVER_UPDATE_SEND_FILES -- C_0x1001 -> S_0xA002 -- contains a file with directory information for the Client
        /// </summary>
        /// <param name="data"></param>
        /// <param name="latestClientVersion"></param>
        internal static void SendFiles(ServerData data, int latestClientVersion)
        {
            DataTable ToBePatched = SQL.RequestFilesToUpdate(latestClientVersion);

            foreach (DataRow row in ToBePatched.Rows)
            {
                var ToClientDir = row.Field<string>("CFilePath");
                var version = row.Field<int>("Version");
                var ToClientFileName = row.Field<string>("CFileName");
                var FileitselfStringPath = Path.Combine(ServerManager.settings.PatchFolderDirectory_Archiv, ToClientDir, ToClientFileName);
                if (File.Exists(FileitselfStringPath))
                {
                    var BinaryFile = File.ReadAllBytes(FileitselfStringPath);
                    var packeta = new Packet(0xA002, false, true);
                    packeta.WriteInt(version);
                    packeta.WriteAscii(ToClientFileName);
                    packeta.WriteAscii(ToClientDir);
                    packeta.WriteByteArray(BinaryFile);
                    data.m_security.Send(packeta);
                }
            }

            var updateSuccess = new Packet(0xA003);
            updateSuccess.WriteInt(SQL.LatestVersion());
            data.m_security.Send(updateSuccess);
        }

      
    }
}
