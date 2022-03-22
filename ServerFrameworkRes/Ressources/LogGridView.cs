using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerFrameworkRes.Network.ServerStructs;

namespace ServerFrameworkRes.Ressources
{
    public partial class LogGridView : UserControl
    {
        public Stack<string> MessageStack = new Stack<string>();

        private ReportLog Reporter { get => new ReportLog(TypeOfModuleLog); }
        public ModuleType TypeOfModuleLog { get; set; }
        public LogGridView()
        {
            InitializeComponent();
            Dock = DockStyle.Bottom;
        }

        public void WriteLogLine(string message)
        {
            WriteLogLine(LogLevel.notify, message);
        }

        public void WriteLogLine(LogLevel Level, string message)
        {
            var LogArray = new string[3]
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
                        r.DefaultCellStyle.ForeColor = Color.RoyalBlue;
                        break;
                    case LogLevel.warning:
                        r.DefaultCellStyle.ForeColor = Color.OrangeRed;
                        break;
                    default:
                        r.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                }

                // dataGridView1.Rows.Add(r);
                dataGridView1.Invoke(new Action(() => { dataGridView1.Rows.Add(r); }));
                // dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Invoke(new Action(() => { dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1; }));
            }
            
            // dataGridView1.ClearSelection();
            dataGridView1.Invoke(new Action(() => { dataGridView1.ClearSelection(); }));
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripPlayLog.Show(this, e.Location);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteLogLine(Reporter.SaveReportLog(dataGridView1));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveClearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WriteLogLine(Reporter.SaveReportLog(dataGridView1));
            dataGridView1.Rows.Clear();
        }

        private void LogGridView_Load(object sender, EventArgs e)
        {
            Task.Run(() => LogMsgThread());
        }

        private void LogMsgThread()
        {
            this.WriteLogLine(LogLevel.notify, "Runtime logThread started!");
            while (true)
            {
                if (MessageStack.Count > 0)
                {
                    this.WriteLogLine(LogLevel.notify, MessageStack.Pop());
                }
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
