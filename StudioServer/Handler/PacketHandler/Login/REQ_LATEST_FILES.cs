using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Login
{
    class REQ_LATEST_FILES
    {
        public static Packet AllFiles(Packet packet, SecurityManager incomeSocketData)
        {
            var version = packet.ReadInt();
            if (version != StudioServer.settings.Version)//not CurrentVersion
            {
              
                DataTable ToBePatched = SQL.ReturnDataTable($"SELECT * from _ToolUpdates where ToBePatched = 1 and Version > {version.ToString()};", StudioServer.settings.DBDev);

                foreach (DataRow row in ToBePatched.Rows)
                {
                    var ToClientDir = row.Field<string>("CFilePath");
                    var verson = row.Field<int>("Version");
                    var ToClientFileName = row.Field<string>("CFileName");
                    var FileitselfStringPath = Path.Combine(StudioServer.settings.PatchFolderDirectory_Archiv, ToClientDir, ToClientFileName);
                    if (File.Exists(FileitselfStringPath))
                    {
                        var BinaryFile = File.ReadAllBytes(FileitselfStringPath);
                        var packeta = new Packet(0xD101, false, true);
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
                var P = new Packet(0xD110);
                P.WriteInt(StudioServer.settings.Version);
                return P;
            }
            return null;
        }
    }
}
