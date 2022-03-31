using ManagementServer.Utility;
using ServerFrameworkRes.Network.Security;
using System.Data;
using System.IO;

namespace ManagementServer.Network
{
    internal partial class ServerPacketHandler
    {
        #region Methods

        /// <summary>
        /// SERVER_UPDATE_SEND_FILES -- C_0x1001 -> S_0xA002 -- contains a file with directory information for the Client
        /// </summary>
        /// <param name="data"></param>
        /// <param name="latestClientVersion"></param>
        internal PacketHandlerResult SendFiles(ServerData data, Packet packet)
        {
            int latestClientVersion = packet.ReadInt();
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

        /// <summary>
        /// SERVER => CLIENT
        /// <br>0xA001</br>
        /// <br>Sends latest version to client.</br>
        /// </summary>
        /// <returns></returns>
        internal Packet SendServerVersion()
        {
            var connectionSuccess = new Packet(0xA001);
            connectionSuccess.WriteInt(SQL.LatestVersion());
            return connectionSuccess;
        }

        #endregion Methods
    }
}