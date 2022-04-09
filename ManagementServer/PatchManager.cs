using ManagementServer.Utility;
using ManagementFramework.Ressources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ManagementServer
{
    public partial class PatchManager : Form
    {
        #region Constructors

        public PatchManager()
        {
            InitializeComponent();
            Text = $"Studio Server Version: [{ServerManager.settings.Version}]";
            if (!Directory.Exists(ServerManager.settings.PatchFolderDirectory))
            {
                Directory.CreateDirectory(ServerManager.settings.PatchFolderDirectory).Create();
            }

            if (!Directory.Exists(ServerManager.settings.PatchFolderDirectory_Archiv))
            {
                Directory.CreateDirectory(ServerManager.settings.PatchFolderDirectory_Archiv).Create();
            }
        }

        #endregion Constructors

        #region Methods

        public void Exaggurate()
        {
            if (Directory.Exists(ServerManager.settings.PatchFolderDirectory) && Directory.Exists(ServerManager.settings.PatchFolderDirectory_Archiv))
            {
                string[] FilesinPatchFolderStringsFull = Directory.GetFiles(ServerManager.settings.PatchFolderDirectory, "*", SearchOption.AllDirectories);
                if (FilesinPatchFolderStringsFull.Length > 0)
                {
                    foreach (string item in FilesinPatchFolderStringsFull)
                    {
                        byte[] byteFile = File.ReadAllBytes(item);
                        string FileNameWithAdditionDir = item.Remove(0, ServerManager.settings.PatchFolderDirectory.Length + 1); //+1 because the slash /
                        System.Collections.Generic.List<string> splittta = FileNameWithAdditionDir.Split('\\').ToList();

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
                        new SqlParameter("@Version", SqlDbType.Int) { Value = ServerManager.settings.Version + 1 },
                        new SqlParameter("@ServerDirectoryToLoadFrom", SqlDbType.VarChar) { Value = Path.Combine(ServerManager.settings.PatchFolderDirectory, CFileDir, CFileName) },
                        };

                        SQL.UpdateToolFiles(paramse);

                        if (!Directory.Exists(Path.Combine(ServerManager.settings.PatchFolderDirectory_Archiv, CFileDir)))
                        {
                            Directory.CreateDirectory(Path.Combine(ServerManager.settings.PatchFolderDirectory_Archiv, CFileDir)).Create();
                        }

                        using (FileStream stream = File.Create(item.Replace(ServerManager.settings.PatchFolderDirectory, ServerManager.settings.PatchFolderDirectory_Archiv)))
                        {
                            stream.Write(byteFile, 0, byteFile.Length);
                            stream.Close();
                        }
                        File.Delete(item);

                        PatchManager_Load(null, new EventArgs());
                        Text = $"Studio Server Version: [{ServerManager.settings.Version}]";
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

        private void buttonCancelPatch_Click(object sender, EventArgs e)
        {
            PatchManager_Load(null, new EventArgs());
            buttonPreparePatch.Enabled = true;
            buttonCancelPatch.Enabled = false;
            buttonPatchShownFiles.Enabled = false;
            listView1.Enabled = true;
        }

        private void buttonPatchShownFiles_Click(object sender, EventArgs e)
        {
            Exaggurate();
        }

        private void buttonPreparePatch_Click(object sender, EventArgs e)
        {
            buttonPreparePatch.Enabled = false;
            buttonCancelPatch.Enabled = true;
            buttonPatchShownFiles.Enabled = true;
            listView1.Enabled = false;
        }

        private void PatchManager_Load(object sender, EventArgs e)
        {
            dataGridViewPatchHistory.DataSource = Utility.SQL.GetPatchHistory();
            listView1.Items.Clear();
            int patchSize = 0;
            string[] allFiles = Directory.GetFiles(ServerManager.settings.PatchFolderDirectory, "*", SearchOption.AllDirectories);
            foreach (string file in allFiles)
            {
                patchSize += File.ReadAllBytes(file).Length;
                listView1.Items.Add(new ListViewItem(file.Remove(0, ServerManager.settings.PatchFolderDirectory.Length + 1)));
            }
            FileSize.Text = $"Patch size: {patchSize} bytes";
            FileCount.Text = $"File count: {allFiles.Length} files";
        }

        #endregion Methods
    }
}