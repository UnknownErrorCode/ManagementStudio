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
        public static RichTextBox LogBox;
        internal static LauncherClient MainClient;
        internal static Config.InitializeConfig LConfig;

        public Launcher()
        {
            InitializeComponent();
            LogBox = this.richTextBoxLog;
            LConfig = new Config.InitializeConfig();
            MainClient = new LauncherClient();
            vSroInputBoxHost.ValueText = LConfig.HostIP;
            vSroInputBoxPort.ValueText = LConfig.HostPort.ToString();
            this.vSroSizableWindow1.Title = $"vSro Studio Launcher v.{LConfig.Version}";

            WriteLine("Connecting to server... Please wait!");
            Thread connect = new Thread(TryConnect);
            connect.Start();
        }

        public static void WriteStaticLine(string msg)
        {
            if (LogBox.InvokeRequired)
            {
                LogBox.Invoke(new Action(() =>
                {
                    LogBox.AppendText($"{msg}\n");
                    LogBox.ScrollToCaret();
                }));
            }
            else
            {
                LogBox.AppendText($"{msg}\n");
                LogBox.ScrollToCaret();
            }
        }
        public void WriteLine(string msg)
        {
            if (richTextBoxLog.InvokeRequired)
            {
                this.richTextBoxLog.Invoke(new Action(() =>
                {
                    this.richTextBoxLog.AppendText($"{msg}\n");
                    this.richTextBoxLog.ScrollToCaret();
                }));
            }
            else
            {
                this.richTextBoxLog.AppendText($"{msg}\n");
                this.richTextBoxLog.ScrollToCaret();
            }
        }
        private void TryConnect()
        {
            try
            {
                if (MainClient.Connect())
                    WriteLine("Successfully connected to Server!");
                else
                    WriteLine($"Failed to connect to Server!");
            }
            catch (Exception ex)
            {
                WriteLine($"Failed to connect to Server! {ex.Message}"); 
            }
        }
    }
}
