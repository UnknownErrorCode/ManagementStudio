using ServerFrameworkRes.Ressources;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace StudioServer.Patch
{
    internal class PatchProces
    {
        #region Public Methods

        public static void Exaggurate()
        {
            if (!Directory.Exists(StudioServer.settings.PatchFolderDirectory))
            {
                Directory.CreateDirectory(StudioServer.settings.PatchFolderDirectory).Create();
            }
            if (!Directory.Exists(StudioServer.settings.PatchFolderDirectory_Archiv))
            {
                Directory.CreateDirectory(StudioServer.settings.PatchFolderDirectory_Archiv).Create();
            }
            if (Directory.Exists(StudioServer.settings.PatchFolderDirectory) && Directory.Exists(StudioServer.settings.PatchFolderDirectory_Archiv))
            {
                string[] FilesinPatchFolderStringsFull = Directory.GetFiles(StudioServer.settings.PatchFolderDirectory, "*", SearchOption.AllDirectories);
                if (FilesinPatchFolderStringsFull.Length > 0)
                {
                    foreach (string item in FilesinPatchFolderStringsFull)
                    {
                        byte[] byteFile = File.ReadAllBytes(item);
                        string FileNameWithAdditionDir = item.Remove(0, StudioServer.settings.PatchFolderDirectory.Length + 1); //+1 because the slash /
                        List<string> splittta = FileNameWithAdditionDir.Split('\\').ToList();

                        string CFileDir = "";
                        if (splittta.Count > 1)
                        {
                            for (int i = 0; i < splittta.Count - 1; i++)
                            {
                                CFileDir = Path.Combine(CFileDir, splittta[i]);
                            }
                        }

                        string CFileName = splittta[splittta.Count - 1];

                        SqlParameter[] paramse = new SqlParameter[]
                         {
                            new SqlParameter("@path",SqlDbType.VarChar,255) {Value =CFileDir},
                        new SqlParameter("@file", SqlDbType.VarChar, 128) { Value = CFileName },
                        new SqlParameter("@size", SqlDbType.Int) { Value = byteFile.Length },
                        new SqlParameter("@Version", SqlDbType.Int) { Value = StudioServer.settings.Version + 1 },
                        new SqlParameter("@ServerDirectoryToLoadFrom", SqlDbType.VarChar) { Value = Path.Combine(StudioServer.settings.PatchFolderDirectory, CFileDir, CFileName) },
                        };

                        SQL.ReturnDataTableByProcedure("_Update_Tool_Files", StudioServer.settings.DBDev, paramse);

                        if (!Directory.Exists(Path.Combine(StudioServer.settings.PatchFolderDirectory_Archiv, CFileDir)))
                        {
                            Directory.CreateDirectory(Path.Combine(StudioServer.settings.PatchFolderDirectory_Archiv, CFileDir)).Create();
                        }
                        using (FileStream stream = File.Create(item.Replace(StudioServer.settings.PatchFolderDirectory, StudioServer.settings.PatchFolderDirectory_Archiv)))
                        {
                            stream.Write(byteFile, 0, byteFile.Length);
                            stream.Close();
                        }
                        File.Delete(item);
                    }
                    Config.InitializeConfig.Cfg.IniWriteValue("StudioServer", "Version", $"{StudioServer.settings.Version + 1}");
                    StudioServer.StaticCertificationGrid.WriteLogLine(LogLevel.notify, $"Successfully patched: '{FilesinPatchFolderStringsFull.Length}' Files");
                }
                else
                {
                    StudioServer.StaticCertificationGrid.WriteLogLine(LogLevel.warning, $"No files found in: '{StudioServer.settings.PatchFolderDirectory}'");
                }
            }
            else
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(LogLevel.warning, $"Directory '{StudioServer.settings.PatchFolderDirectory}'  or '{StudioServer.settings.PatchFolderDirectory_Archiv}'  does not exist!");
            }
        }

        #endregion Public Methods
    }
}