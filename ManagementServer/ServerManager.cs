using ManagementServer.Network;
using ServerFrameworkRes.Ressources;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ManagementServer
{
    public partial class ServerManager : Form
    {
        #region Fields

        internal static LogGridView Logger = new LogGridView() { Dock = DockStyle.Bottom };
        internal static Utility.Settings settings = new Utility.Settings();
        internal Thread diagnosticThread;
        internal Thread serverCodeTickThread;
        public ServerManager()
        {
            InitializeComponent();
            Controls.Add(Logger);

            if (!LizenceCore.CanStart)
            {
                MessageBox.Show("Woops. please contact Rekcuz...");
                return;
            }
            diagnosticThread = new Thread(DiagnosticThread);
            serverCodeTickThread = new Thread(ServerCore.TickThread);
        }


        #endregion Fields



        #region Properties

        private byte[] buffer { get; set; }

        #endregion Properties

        #region Methods

        private void DiagnosticThread()
        {
            int counter = 0;
            while (ServerCore.IsConnected)
            {
                Invoke(new Action(() => toolStripStatusLabelOnlineUser.Text = $"Connected user: {ServerMemory.OnlineUser}"));
                Thread.Sleep(100);
                counter++;
                if (counter > 1000)
                {
                    GC.Collect(2);
                    counter = 0;
                }
            }
            Logger.WriteLogLine("Status: Diagnostic thread aborted!");
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = !ServerCore.IsConnected;
            stopToolStripMenuItem.Enabled = ServerCore.IsConnected;
        }

        private void gen1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect(1);
        }

        private void gen2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect(2);
        }

        private void gen3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect(3);
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ServerCore.IsConnected)
            {
                Logger.WriteLogLine("please establish a Server connection first!");
                return;
            }
            using (PatchManager patchManager = new PatchManager())
            {
                patchManager.ShowDialog();
            }
        }

        private void StartServer()
        {
            try
            {
                if (!Utility.SQL.ConnectionSuccess)
                    return;

                if (!PluginSecurityManager.IsRefreshed)
                    return;

                if (Utility.SQL.LogoutEveryone(out int i))
                    ServerManager.Logger.WriteLogLine(LogLevel.warning, $"Disconnected {i} active user. do something against it!!");

                dataGridView1.DataSource = PluginSecurityManager._ToolPluginDataAccessDataTable;
                ServerCore.Listen(settings.IP, settings.Port, 5, new ServerInterface(), buffer);

                Logger.WriteLogLine(LogLevel.success, "Status: vSro-Studio-Server started!");

                serverCodeTickThread.Start();
                diagnosticThread.Start();
            }
            catch (Exception ex)
            {
                //Logger?.WriteLogLine(LogLevel.fatal, $"Status: vSro-Studio-Server failed to start... Exception: {ex.Message}");
                diagnosticThread.Abort();
                serverCodeTickThread.Abort();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteLogLine(LogLevel.loading, "Starting...");
            // Thread thread = new Thread(StartServer);
            // thread.Start();
            StartServer();
        }

        private void StopServer()
        {
            if (!ServerCore.IsConnected && !LizenceCore.IsConnected)
                return;

            // Ticker = false;
            diagnosticThread.Abort();
            serverCodeTickThread.Abort();
            ServerCore.Stop();
            LizenceCore.Disconnect();
            Logger.WriteLogLine(LogLevel.warning, "Status: vSro-Studio-Server stopped!");
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void vSroSmallButtonRefreshSec_vSroClickEvent()
        {
        }

        #endregion Methods

        private void refreshSecurityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var flag = PluginSecurityManager.IsRefreshed;
            dataGridView1.DataSource = PluginSecurityManager._ToolPluginDataAccessDataTable;
            Logger.WriteLogLine(flag ? LogLevel.loading : LogLevel.fatal, flag ? $"Refreshed security groups" : "Failed to refresh groups...");
        }
    }
}