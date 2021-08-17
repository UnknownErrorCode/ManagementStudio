using ServerFrameworkRes.Network.ServerStructs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFrameworkRes.Ressources
{
    public class ReportLog
    {


        public virtual ModuleType ModuleReportLog { get => ModuleReportLog; set => ModuleName = value.ToString(); }



        private const string Name = "ReportLog";
        private protected string DirectoryLogFolder { get => Path.Combine(Directory.GetCurrentDirectory(), Name); }
        private protected string DirectoryLog { get => Path.Combine(DirectoryLogFolder, LogTxtName); }
        private string ModuleName { get; set; }
        private string LogTxtName { get => $"ReportLog_[{ModuleName}][{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}].txt";  set => LogTxtName = value; }

        public ReportLog(ModuleType module)
        {
            ModuleReportLog = module;
        }
        public  string SaveReportLog(DataGridView dataGridView)
        {
            string[] LogText = dataGridView.Rows.OfType<DataGridViewRow>().Select(k => $"{k.Cells[0].Value}\t{k.Cells[1].Value}\t{k.Cells[2].Value}").ToArray();
            string LogTextFileInput = "";
            foreach (var item in LogText)
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
    }
}
