using ServerFrameworkRes.Network.ServerStructs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFrameworkRes.Ressources
{
    public partial class LogGridView : UserControl
    {
        #region Fields

        public Stack<string> MessageStack = new Stack<string>();
        //private delegate void WriteLogMsg(string msg, LogLevel level = LogLevel.notify);
        #endregion Fields

        #region Constructors

        public LogGridView()
        {
            InitializeComponent();
            Dock = DockStyle.Bottom;
        }

        #endregion Constructors

        #region Properties

        public ModuleType TypeOfModuleLog { get; set; }

        private ReportLog Reporter => new ReportLog(TypeOfModuleLog);

        #endregion Properties

        #region Methods

      
        public void WriteLogLine(Exception message, string sender)
        {
            WriteLogLine(LogLevel.fatal, $"{sender}: {message.Message}");
        }

        public void WriteLogLine( string message, LogLevel Level = LogLevel.notify)
        {
            WriteLogLine(Level, message);
        }
        public void WriteLogLine(LogLevel Level, string message)
        {
            string[] LogArray = new string[3]
            {
                $"{Level}",
                message,
                DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss fff ")
            };
            using (DataGridViewRow r = new DataGridViewRow())
            {
                r.Height = 15;

                r.CreateCells(dataGridView1);
                r.SetValues(LogArray);

                switch (Level)
                {
                    case LogLevel.fatal:
                        r.DefaultCellStyle.ForeColor = Color.Red;
                        break;
                    case LogLevel.notify:
                        r.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case LogLevel.warning:
                        r.DefaultCellStyle.ForeColor = Color.OrangeRed;
                        break;
                    case LogLevel.loading:
                        r.DefaultCellStyle.ForeColor = Color.Orange;
                        break;
                    case LogLevel.success:
                        r.DefaultCellStyle.ForeColor = Color.Green;
                        break;
                    case LogLevel.sql:
                        r.DefaultCellStyle.ForeColor = Color.DarkViolet;
                        break;
                    default:
                        break;
                }


                dataGridView1?.Invoke(new Action(() => { dataGridView1.Rows.Add(r); dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1; }));
            }

            dataGridView1?.Invoke(new Action(() => { dataGridView1.ClearSelection(); }));
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripPlayLog.Show(this, e.Location);
            }
        }

        private void LogGridView_Load(object sender, EventArgs e)
        {
            //Task.Run(() => LogMsgThread());
        }

        private void LogMsgThread()
        {
            WriteLogLine(LogLevel.notify, "Runtime logThread started!");
            while (true)
            {
                if (MessageStack.Count > 0)
                {
                    WriteLogLine(LogLevel.notify, MessageStack.Pop());
                }
                System.Threading.Thread.Sleep(100);
            }
        }

        private void saveClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteLogLine(Reporter.SaveReportLog(dataGridView1));
            dataGridView1.Rows.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteLogLine(Reporter.SaveReportLog(dataGridView1));
        }

        #endregion Methods
    }
}