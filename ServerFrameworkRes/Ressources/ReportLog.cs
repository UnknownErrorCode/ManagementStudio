using ServerFrameworkRes.Network.ServerStructs;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ServerFrameworkRes.Ressources
{
    public class ReportLog
    {
        #region Fields

        private const string Name = "ReportLog";

        #endregion Fields

        #region Constructors

        public ReportLog(ModuleType module)
        {
            ModuleReportLog = module;
        }

        #endregion Constructors

        #region Properties

        public virtual ModuleType ModuleReportLog { get => ModuleReportLog; set => ModuleName = value.ToString(); }

        protected string DirectoryLog => Path.Combine(DirectoryLogFolder, LogTxtName);
        protected string DirectoryLogFolder => Path.Combine(Directory.GetCurrentDirectory(), Name);

        private string LogTxtName { get => $"ReportLog_[{ModuleName}][{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}].txt"; set => LogTxtName = value; }
        private string ModuleName { get; set; }

        #endregion Properties

        #region Methods

        public string SaveReportLog(DataGridView dataGridView)
        {
            string[] LogText = dataGridView.Rows.OfType<DataGridViewRow>().Select(k => $"{k.Cells[0].Value}\t{k.Cells[1].Value}\t{k.Cells[2].Value}").ToArray();
            string LogTextFileInput = "";
            foreach (string item in LogText)
            {
                LogTextFileInput += $"{item}\n";
            }
            // var LogName = $"ReportLog_[{ModuleName}][{DateTime.Now.ToString("yyyy-mm-dd HH-MM-SS")}].txt";
            // var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), Name, LogTxtName);
            if (!Directory.Exists(DirectoryLogFolder))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), Name));
            }
            if (!File.Exists(DirectoryLog))
            {
                File.WriteAllText(DirectoryLog, LogTextFileInput);
            }
            return $"successfully log saved: {DirectoryLog}";
        }

        #endregion Methods
    }
}