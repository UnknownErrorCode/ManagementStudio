using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using ServerFrameworkRes.Ressources;
using ServerFrameworkRes.Ressources.ServerBody;
using StudioServer.Patch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace StudioServer
{
    public partial class StudioServer : Form
    {
        #region Public Fields

        public static Config.Settings settings = new Config.Settings();
        public static LogGridView StaticCertificationGrid;

        #endregion Public Fields

        #region Private Fields

        private readonly ServerData ServerData = new ServerData() { UserIP = settings.IP, AccountName = "vSroStudioServer" };
        private readonly bool Ticker = true;

        #endregion Private Fields

        #region Public Constructors

        public StudioServer()
        {
            InitializeComponent();
            StaticCertificationGrid = ServerLog;
            Text = $"Studio Server Version {settings.Version}";
            SingleBody = new ArchitectureBody(ServerData, new Point(20, 20));
            architecturePanel2.Controls.Add(SingleBody);

            SingleBody.BackgroundImage = SingleBody.ServerBodyImages[ServerBodyState.Cert];
            foreach (object item in ServerTimer.OnBegin())
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(LogLevel.notify, (string)item);
            }
            Worker.DataStorage.CreateEnvironment();
        }

        #endregion Public Constructors

        #region Private Properties

        private static AsyncServer AsyncronousNetwork { get; set; }
        private byte[] buffer { get; set; }
        private ArchitectureBody SingleBody { get; set; }

        #endregion Private Properties

        #region Private Methods

        private void patchClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Patch.PatchProces.Exaggurate();
        }

        private void patchManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatchManager manager = new PatchManager();
            manager.Show();
        }

        private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int offs = SQL.ExecuteQuery("UPDATE _ToolUser SET Active = 0 where Active = 1", StudioServer.settings.DBDev);
            ServerMembory.SendUpdateSuccessNoticeToAll($"Kicked {offs} online users! Closed for maintenance!", "StudioServer");
            LogLevel level = LogLevel.warning;

            KeyValuePair<string, bool> Initialize = settings.InitializeSettings;
            if (Initialize.Value)
            {
                level = LogLevel.notify;
                StaticCertificationGrid.WriteLogLine(level, Initialize.Key);
                Initialize = SQL.TestSqlConnection();
            }
            else
            {
                level = LogLevel.fatal;
                StaticCertificationGrid.WriteLogLine(level, Initialize.Key);
            }

            if (Initialize.Value)
            {
                level = LogLevel.notify;
                Thread t = new Thread(vood); t.Start();
                StaticCertificationGrid.WriteLogLine(level, Initialize.Key);
            }
            else
            {
                level = LogLevel.fatal;
                StaticCertificationGrid.WriteLogLine(level, Initialize.Key);
            }
        }

        private void StudioServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            int offs = SQL.ExecuteQuery("UPDATE _ToolUser SET Active = 0 where Active = 1", StudioServer.settings.DBDev);
            ServerMembory.SendUpdateSuccessNoticeToAll($"Kicked {offs} online users! Closed for maintenance!", "StudioServer");
            Process.GetCurrentProcess().CloseMainWindow();
            Process.GetProcessesByName("StudioServer").ToList().ForEach(process => process.Kill());
        }

        private void testSQLConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, bool> kpv = SQL.TestSqlConnection();
            StudioServer.StaticCertificationGrid.WriteLogLine(kpv.Value ? kpv.Key : "Failed to login to the Server");
        }

        private void vood()
        {
            try
            {
                IPEndPoint ServerEndPoint = new IPEndPoint(IPAddress.Parse(StudioServer.settings.IP), StudioServer.settings.Port);

                AsyncronousNetwork = new AsyncServer();

                ServerInterface certificationServerInterface = new ServerInterface();

                AsyncronousNetwork.Accept(ServerEndPoint.Address.ToString(), ServerEndPoint.Port, 5, certificationServerInterface, buffer);

                SingleBody.BackgroundImage = SingleBody.ServerBodyImages[ServerBodyState.Blue];
                StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("Status: vSro-Studio-Server started on {0}:{1}", ServerEndPoint.Address.ToString(), ServerEndPoint.Port.ToString()));

                while (Ticker)
                {
                    AsyncronousNetwork.Tick();
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(String.Format("Status: vSro-Studio-Server failed to start... Exception: {0}", ex.Message));
            }
        }

        #endregion Private Methods
    }
}