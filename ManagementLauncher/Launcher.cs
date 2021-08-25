using ManagementLauncher.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementLauncher
{
    public partial class Launcher : Form
    {
        internal static LauncherClient MainClient;
        internal static Config.InitializeConfig LConfig;

        public Launcher()
        {
            InitializeComponent();
            LConfig = new Config.InitializeConfig();
            MainClient = new LauncherClient();
            vSroInputBoxHost.ValueText = LConfig.HostIP;
            vSroInputBoxPort.ValueText = LConfig.HostPort.ToString();

            this.logGridView1.WriteLogLine("Connecting to server... Please wait!");
            Thread connect = new Thread(TryConnect);
            connect.Start();
        }

        private void TryConnect()
        {
            try
            {
                if (MainClient.Connect())
                    this.logGridView1.Invoke(new Action(() => { this.logGridView1.WriteLogLine("Successfully connected to Server!"); }));
                else
                    this.logGridView1.Invoke(new Action(() => { this.logGridView1.WriteLogLine($"Failed to connect to Server!"); }));
            }
            catch (Exception ex)
            {
                this.logGridView1.Invoke(new Action(() => { this.logGridView1.WriteLogLine($"Failed to connect to Server! {ex.Message}"); }));
            }
        }
    }
}
