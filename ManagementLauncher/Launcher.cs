﻿using ManagementLauncher.Network;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ManagementLauncher
{
    public partial class Launcher : Form
    {
        public static RichTextBox LogBox;
        internal static LauncherClient MainClient;
        internal static Config.InitializeConfig LConfig;
        public static Launcher StaticLauncher;

        public Launcher()
        {
            InitializeComponent();
            LogBox = richTextBoxLog;
            LConfig = new Config.InitializeConfig();
            MainClient = new LauncherClient();
            vSroInputBoxHost.ValueText = LConfig.HostIP;
            vSroInputBoxPort.ValueText = LConfig.HostPort.ToString();
            vSroSizableWindow1.Title = $"vSro Studio Launcher v.{LConfig.Version}";

            StaticLauncher = this;
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
                richTextBoxLog.Invoke(new Action(() =>
                {
                    richTextBoxLog.AppendText($"{msg}\n");
                    richTextBoxLog.ScrollToCaret();
                }));
            }
            else
            {
                richTextBoxLog.AppendText($"{msg}\n");
                richTextBoxLog.ScrollToCaret();
            }
        }
        private void TryConnect()
        {
            try
            {
                if (MainClient.Connect())
                {
                    WriteLine("Successfully connected to Server!");
                }
                else
                {
                    WriteLine($"Failed to connect to Server!");
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Failed to connect to Server! {ex.Message}");
            }
        }

        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainClient.TickerThread.Abort();
        }
    }
}
