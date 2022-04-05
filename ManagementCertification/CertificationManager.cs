using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Ressources;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ManagementCertification
{
    public partial class CertificationManager : Form
    {
        internal static LogGridView Logger = new LogGridView() { Dock = DockStyle.Bottom };
        internal static AsyncServer Server;
        internal static Utility.Settings settings = new Utility.Settings();
        private bool Ticker = false;
        private byte[] buffer;
        private Thread t, t2;

        public CertificationManager()
        {
            InitializeComponent();
            Controls.Add(Logger);

            t = new Thread(DiagnosticThread);
            t2 = new Thread(StartServer);
            t2.Start();
        }

        private void DiagnosticThread()
        {
            while (Ticker)
            {
                Invoke(new Action(() => Text = $"Connected user: {LizenceMemory.OnlineUser}"));

                Thread.Sleep(500);
            }
            Logger.WriteLogLine("Status: Diagnostic thread aborted!");
        }

        private void CertificationManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
            t2.Abort();
        }

        private void StartServer()
        {
            try
            {
                if (!settings.InitializeSettings(out string msg))
                {
                    Logger.WriteLogLine(LogLevel.fatal, msg);
                    return;
                }
                Logger.WriteLogLine(LogLevel.success, msg);

                if (!Utility.SQL.ConnectionSuccess)
                    return;

                if (!LizenceSecurityManager.TryRefreshSecurityManager())
                    return;

                int i = Utility.SQL.LogoutEveryone();
                if (i > 0)
                    Logger.WriteLogLine(LogLevel.warning, $"Disconnected {i} active user. do something against it!!");

                Server = new AsyncServer();
                Server.Accept(settings.IP, settings.Port, 5, new LizenceServerInterface(), buffer);

                Ticker = true;
                t.Start();
                Logger.WriteLogLine(LogLevel.success, "Status: vSro-Studio-CertServer started!");

                while (Ticker)
                {
                    Server.Tick();
                    Thread.Sleep(1);
                }
                t.Abort();
                t2.Abort();
            }
            catch (Exception ex)
            {
                //Logger?.WriteLogLine(LogLevel.fatal, $"Status: vSro-Studio-Server failed to start... Exception: {ex.Message}");
                Ticker = false;
            }
        }
    }
}