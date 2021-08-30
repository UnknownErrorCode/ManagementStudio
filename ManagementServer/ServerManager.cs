using System;
using System.Collections.Generic;
using System.ComponentModel;
using ServerFrameworkRes.Ressources;
using ServerFrameworkRes.Network.AsyncNetwork;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementServer
{
    public partial class ServerManager : Form
    {
        internal static Utility.Settings settings = new Utility.Settings();
        internal static LogGridView Logger = new LogGridView() { Dock = DockStyle.Bottom };
        internal static AsyncServer Server;
        private byte[] buffer { get; set; }
        private bool Ticker = false;
        public ServerManager()
        {
            InitializeComponent();
            this.Controls.Add(Logger);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteLogLine("Starting...");
            Thread thread = new Thread(StartServer);
            thread.Start();
        }

        private void DiagnosticThread()
        {
            while(Ticker)
            {
                this.toolStripStatusLabelOnlineUser.Text = $"Connected user: {ServerMemory.OnlineUser}";
                Thread.Sleep(100);
            }
            Logger.WriteLogLine("Status: Diagnostic thread aborted!");
        }

        private void StartServer()
        {
            try
            {
                if (!Utility.SQL.TestSQLConnection(settings.SQL_ConnectionString))
                    return;
                Utility.SQL.LogoutEveryone();
                Server = new AsyncServer();
                Server.Accept(settings.IP, settings.Port, 5, new ServerInterface(), buffer);

                Ticker = true;
                Logger.WriteLogLine("Status: vSro-Studio-Server started!");

                Thread t =new Thread(DiagnosticThread);
                t.Start();

                while (Ticker)
                {
                    Server.Tick();
                    Thread.Sleep(1);
                }
                t.Abort();
            }
            catch (Exception ex)
            {
                Logger.WriteLogLine($"Status: vSro-Studio-Server failed to start... Exception: {ex.Message}");
                Ticker = false;
            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            if (!Ticker)
                return;
            Logger.WriteLogLine("Status: vSro-Studio-Server stopped!");
            Ticker = false;
            Server.Stop();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = Ticker ? false : true;
            stopToolStripMenuItem.Enabled = Ticker;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Ticker)
            {
                Logger.WriteLogLine("please establish a SQL connection first!");
                return;
            }
            using (var patchManager = new PatchManager())
            {
                patchManager.ShowDialog();
            }
        }
    }
}
