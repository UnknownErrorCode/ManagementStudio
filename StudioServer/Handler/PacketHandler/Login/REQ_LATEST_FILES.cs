using ServerFrameworkRes.Network.Security;
using System.Data;
using System.IO;

namespace StudioServer.Handler.PacketHandler.Login
{
    class REQ_LATEST_FILES
    {
        public static Packet AllFiles(Packet packet, SecurityManager incomeSocketData)
        {
            int version = packet.ReadInt();
            if (version != StudioServer.settings.Version)//not CurrentVersion
            {

                DataTable ToBePatched = SQL.ReturnDataTable($"SELECT * from _ToolUpdates where ToBePatched = 1 and Version > {version.ToString()};", StudioServer.settings.DBDev);

                foreach (DataRow row in ToBePatched.Rows)
                {
                    string ToClientDir = row.Field<string>("CFilePath");
                    int verson = row.Field<int>("Version");
                    string ToClientFileName = row.Field<string>("CFileName");
                    string FileitselfStringPath = Path.Combine(StudioServer.settings.PatchFolderDirectory_Archiv, ToClientDir, ToClientFileName);
                    if (File.Exists(FileitselfStringPath))
                    {
                        byte[] BinaryFile = File.ReadAllBytes(FileitselfStringPath);
                        Packet packeta = new Packet(0xD101, false, true);
                        packeta.WriteInt(verson);
                        packeta.WriteAscii(ToClientFileName);
                        packeta.WriteAscii(ToClientDir);
                        packeta.WriteByteArray(BinaryFile);
                        incomeSocketData.Send(packeta);
                    }
                    else
                    {

                    }
                }
                Packet P = new Packet(0xD110);
                P.WriteInt(StudioServer.settings.Version);
                return P;
            }
            return null;
        }
    }
}
