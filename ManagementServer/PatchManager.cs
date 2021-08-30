using ManagementServer.Utility;
using ServerFrameworkRes.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementServer
{
    public partial class PatchManager : Form
    {
        public PatchManager()
        {
            InitializeComponent();
            this.Text = $"Studio Server Version: [{ServerManager.settings.Version}]";
            if (!Directory.Exists(ServerManager.settings.PatchFolderDirectory))
                Directory.CreateDirectory(ServerManager.settings.PatchFolderDirectory).Create();

            if (!Directory.Exists(ServerManager.settings.PatchFolderDirectory_Archiv))
                Directory.CreateDirectory(ServerManager.settings.PatchFolderDirectory_Archiv).Create();
        }

        private void PatchManager_Load(object sender, EventArgs e)
        {
            dataGridViewPatchHistory.DataSource = Utility.SQL.GetPatchHistory();
            listView1.Items.Clear();
            var patchSize = 0;
            var allFiles = Directory.GetFiles(ServerManager.settings.PatchFolderDirectory, "*", SearchOption.AllDirectories);
            foreach (var file in allFiles)
            {
                patchSize += File.ReadAllBytes(file).Length;
                listView1.Items.Add(new ListViewItem(file.Remove(0, ServerManager.settings.PatchFolderDirectory.Length+1)));
            }
            FileSize.Text = $"Patch size: {patchSize} bytes";
            FileCount.Text = $"File count: {allFiles.Length} files";
        }

        private void buttonPreparePatch_Click(object sender, EventArgs e)
        {
            this.buttonPreparePatch.Enabled = false;
            this.buttonCancelPatch.Enabled = true;
            this.buttonPatchShownFiles.Enabled = true;
            this.listView1.Enabled = false;
        }

        private void buttonCancelPatch_Click(object sender, EventArgs e)
        {
            PatchManager_Load(null, new EventArgs());
            this.buttonPreparePatch.Enabled = true;
            this.buttonCancelPatch.Enabled = false;
            this.buttonPatchShownFiles.Enabled = false;
            this.listView1.Enabled = true;
        }

        private void buttonPatchShownFiles_Click(object sender, EventArgs e)
        {
            Exaggurate();
        }



        public  void Exaggurate()
        {
           
            if (Directory.Exists(ServerManager.settings.PatchFolderDirectory) && Directory.Exists(ServerManager.settings.PatchFolderDirectory_Archiv))
            {
                var FilesinPatchFolderStringsFull = Directory.GetFiles(ServerManager.settings.PatchFolderDirectory, "*", SearchOption.AllDirectories);
                if (FilesinPatchFolderStringsFull.Length > 0)
                {
                    foreach (var item in FilesinPatchFolderStringsFull)
                    {
                        var byteFile = File.ReadAllBytes(item);
                        var FileNameWithAdditionDir = item.Remove(0, ServerManager.settings.PatchFolderDirectory.Length + 1); //+1 because the slash /
                        var splittta = FileNameWithAdditionDir.Split('\\').ToList();

                        var CFileDir = "";
                        if (splittta.Count > 1)
                        {
                            for (int i = 0; i < splittta.Count - 1; i++)
                            {
                                CFileDir = Path.Combine(CFileDir, splittta[i]);
                            }
                        }

                        var CFileName = splittta[splittta.Count - 1];

                        var paramse = new SqlParameter[]
                         {
                            new SqlParameter("@path",SqlDbType.VarChar,255) {Value =CFileDir},
                        new SqlParameter("@file", SqlDbType.VarChar, 128) { Value = CFileName },
                        new SqlParameter("@size", SqlDbType.Int) { Value = byteFile.Length },
                        new SqlParameter("@Version", SqlDbType.Int) { Value = ServerManager.settings.Version + 1 },
                        new SqlParameter("@ServerDirectoryToLoadFrom", SqlDbType.VarChar) { Value = Path.Combine(ServerManager.settings.PatchFolderDirectory, CFileDir, CFileName) },
                        };


                        SQL.UpdateToolFiles(paramse);

                        if (!Directory.Exists(Path.Combine(ServerManager.settings.PatchFolderDirectory_Archiv, CFileDir)))
                            Directory.CreateDirectory(Path.Combine(ServerManager.settings.PatchFolderDirectory_Archiv, CFileDir)).Create();
                       
                        using (FileStream stream = File.Create(item.Replace(ServerManager.settings.PatchFolderDirectory, ServerManager.settings.PatchFolderDirectory_Archiv)))
                        {
                            stream.Write(byteFile, 0, byteFile.Length);
                            stream.Close();
                        }
                        File.Delete(item);

                        PatchManager_Load(null, new EventArgs());

                    }
                    InitializeConfig.Cfg.IniWriteValue("StudioServer", "Version", $"{ ServerManager.settings.Version + 1}");
                    ServerManager.Logger.WriteLogLine(LogLevel.notify, $"Successfully patched: '{FilesinPatchFolderStringsFull.Length}' Files");
                }

                else
                {
                    ServerManager.Logger.WriteLogLine(LogLevel.warning, $"No files found in: '{ ServerManager.settings.PatchFolderDirectory}'");
                }
            }
            else
            {
                ServerManager.Logger.WriteLogLine(LogLevel.warning, $"Directory '{ ServerManager.settings.PatchFolderDirectory}'  or '{ServerManager.settings.PatchFolderDirectory_Archiv}'  does not exist!");
            }
        }
    }
}
