﻿using ClientDataStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class SettingsForm : Form
    {

        private readonly Config ReadOnlyCfg;
        public SettingsForm(Config config = null)
        {
            ReadOnlyCfg = config;
            InitializeComponent();
        }


        public bool InitializeSettings()
        {
            vSroInputBox1.ValueText = ReadOnlyCfg.ToolServerIP;
            vSroInputBox2.ValueText = ReadOnlyCfg.ToolServerPort.ToString();
            vSroInputBox3.ValueText = ReadOnlyCfg.ToolServerVersion.ToString();
            vSroInputBox4.ValueText = ReadOnlyCfg.PToolUser;
            vSroInputBox5.ValueText = ReadOnlyCfg.PToolUserPassword;
            vSroInputBox6.ValueText = ReadOnlyCfg.ClientPath;
            vSroInputBox7.ValueText = ReadOnlyCfg.ClientExtracted;

            vSroCheckBox1.vSroCheck = ReadOnlyCfg.ShowPwInText;

            return true;
        }

        private void OnShowPasswordCheckChange(object sender, EventArgs e)
        => vSroInputBox5.ShowPWCharakter(!vSroCheckBox1.vSroCheck);

        private void OnLoadSettings()
            => this.InitializeSettings();


        private void OnSaveSettings()
        {
            if (!ReadOnlyCfg.ToolServerIP.Equals(vSroInputBox1.ValueText))
                ReadOnlyCfg.ToolServerIP = vSroInputBox1.ValueText;

            ReadOnlyCfg.ToolServerPort = int.Parse(vSroInputBox2.ValueText);
            ReadOnlyCfg.ToolServerVersion = int.Parse(vSroInputBox3.ValueText);
            ReadOnlyCfg.PToolUser = vSroInputBox4.ValueText;
            ReadOnlyCfg.PToolUserPassword = vSroInputBox5.ValueText;
            ReadOnlyCfg.ClientPath = vSroInputBox6.ValueText;
            ReadOnlyCfg.ClientExtracted = vSroInputBox7.ValueText;
        }
    }
}