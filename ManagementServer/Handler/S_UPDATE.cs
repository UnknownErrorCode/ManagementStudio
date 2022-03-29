using ManagementServer.Utility;
using ServerFrameworkRes.Network.Security;
using System.Data;
using System.IO;

namespace ManagementServer.Handler
{
    internal class S_UPDATE
    {
        /// <summary>
        /// SERVER => CLIENT  0xA001 include latest version
        /// -- Sends latest version to client.
        /// </summary>
        /// <returns></returns>

        #region Internal Methods

        /// <summary>
        /// SERVER_UPDATE_SEND_FILES -- C_0x1001 -> S_0xA002 -- contains a file with directory information for the Client
        /// </summary>
        /// <param name="data"></param>
        /// <param name="latestClientVersion"></param>
        internal static PacketHandlerResult SendFiles(ServerData data, int latestClientVersion)
        {
            DataTable ToBePatched = SQL.RequestFilesToUpdate(latestClientVersion);

            foreach (DataRow row in ToBePatched.Rows)
            {
                string ToClientDir = row.Field<string>("CFilePath");
                int version = row.Field<int>("Version");
                string ToClientFileName = row.Field<string>("CFileName");
                string FileitselfStringPath = Path.Combine(ServerManager.settings.PatchFolderDirectory_Archiv, ToClientDir, ToClientFileName);
                if (File.Exists(FileitselfStringPath))
                {
                    byte[] BinaryFile = File.ReadAllBytes(FileitselfStringPath);
                    Packet packeta = new Packet(0xA002, false, true);
                    packeta.WriteInt(version);
                    packeta.WriteAscii(ToClientFileName);
                    packeta.WriteAscii(ToClientDir);
                    packeta.WriteByteArray(BinaryFile);
                    data.m_security.Send(packeta);
                }
            }

            Packet updateSuccess = new Packet(0xA003);
            updateSuccess.WriteInt(SQL.LatestVersion());
            data.m_security.Send(updateSuccess);

            return PacketHandlerResult.Block;
        }

        internal static ServerFrameworkRes.Network.Security.Packet SendServerVersion()
        {
            ServerFrameworkRes.Network.Security.Packet loginSuccessPacket = new Packet(0xA001);
            loginSuccessPacket.WriteInt(SQL.LatestVersion());
            return loginSuccessPacket;
        }

        #endregion Internal Methods
    }
}