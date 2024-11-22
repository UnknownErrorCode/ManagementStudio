﻿
namespace ManagementClient
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.vSroSmallButton2 = new PluginFramework.BasicControls.vSroSmallButton();
            this.vSroSmallButton1 = new PluginFramework.BasicControls.vSroSmallButton();
            this.vSroInputBox7 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroInputBox6 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroCheckBox1 = new PluginFramework.BasicControls.vSroCheckBox();
            this.vSroInputBox5 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroInputBox4 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroInputBox3 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroInputBox2 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroInputBox1 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroSizableWindow1 = new PluginFramework.BasicControls.vSroSizableWindow();
            this.vSroSmallButtonClientPath = new PluginFramework.BasicControls.vSroSmallButton();
            this.vSroSmallButton4 = new PluginFramework.BasicControls.vSroSmallButton();
            this.SuspendLayout();
            // 
            // vSroSmallButton2
            // 
            this.vSroSmallButton2.Location = new System.Drawing.Point(295, 373);
            this.vSroSmallButton2.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton2.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton2.Name = "vSroSmallButton2";
            this.vSroSmallButton2.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton2.TabIndex = 10;
            this.vSroSmallButton2.vSroSmallButtonName = "Save Settings";
            this.vSroSmallButton2.vSroClickEvent += new PluginFramework.BasicControls.vSroSmallButton.vSroClick(this.OnSaveSettings);
            // 
            // vSroSmallButton1
            // 
            this.vSroSmallButton1.Location = new System.Drawing.Point(137, 373);
            this.vSroSmallButton1.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.Name = "vSroSmallButton1";
            this.vSroSmallButton1.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.TabIndex = 9;
            this.vSroSmallButton1.vSroSmallButtonName = "Load Settings";
            this.vSroSmallButton1.vSroClickEvent += new PluginFramework.BasicControls.vSroSmallButton.vSroClick(this.OnLoadSettings);
            // 
            // vSroInputBox7
            // 
            this.vSroInputBox7.AutoSize = true;
            this.vSroInputBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox7.BackgroundImage")));
            this.vSroInputBox7.Location = new System.Drawing.Point(318, 147);
            this.vSroInputBox7.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox7.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox7.Name = "vSroInputBox7";
            this.vSroInputBox7.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox7.TabIndex = 8;
            this.vSroInputBox7.TitleText = "Ressource:";
            this.vSroInputBox7.ValueText = "";
            this.vSroInputBox7.vSroUseSystemPasswordChar = false;
            // 
            // vSroInputBox6
            // 
            this.vSroInputBox6.AutoSize = true;
            this.vSroInputBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox6.BackgroundImage")));
            this.vSroInputBox6.Location = new System.Drawing.Point(318, 71);
            this.vSroInputBox6.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox6.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox6.Name = "vSroInputBox6";
            this.vSroInputBox6.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox6.TabIndex = 7;
            this.vSroInputBox6.TitleText = "Client Path:";
            this.vSroInputBox6.ValueText = "";
            this.vSroInputBox6.vSroUseSystemPasswordChar = false;
            // 
            // vSroCheckBox1
            // 
            this.vSroCheckBox1.AutoSize = true;
            this.vSroCheckBox1.BackColor = System.Drawing.Color.Black;
            this.vSroCheckBox1.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBox1.Location = new System.Drawing.Point(50, 330);
            this.vSroCheckBox1.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBox1.Name = "vSroCheckBox1";
            this.vSroCheckBox1.Size = new System.Drawing.Size(138, 16);
            this.vSroCheckBox1.TabIndex = 6;
            this.vSroCheckBox1.vSroCheck = false;
            this.vSroCheckBox1.vSroCheckBoxName = "Show Password";
            this.vSroCheckBox1.vSroCheckChange += new PluginFramework.BasicControls.vSroCheckBox.vSroCheckChanger(this.OnShowPasswordCheckChange);
            // 
            // vSroInputBox5
            // 
            this.vSroInputBox5.AutoSize = true;
            this.vSroInputBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox5.BackgroundImage")));
            this.vSroInputBox5.Location = new System.Drawing.Point(39, 275);
            this.vSroInputBox5.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox5.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox5.Name = "vSroInputBox5";
            this.vSroInputBox5.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox5.TabIndex = 5;
            this.vSroInputBox5.TitleText = "Password:";
            this.vSroInputBox5.ValueText = "";
            this.vSroInputBox5.vSroUseSystemPasswordChar = true;
            // 
            // vSroInputBox4
            // 
            this.vSroInputBox4.AutoSize = true;
            this.vSroInputBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox4.BackgroundImage")));
            this.vSroInputBox4.Location = new System.Drawing.Point(39, 229);
            this.vSroInputBox4.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox4.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox4.Name = "vSroInputBox4";
            this.vSroInputBox4.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox4.TabIndex = 4;
            this.vSroInputBox4.TitleText = "User:";
            this.vSroInputBox4.ValueText = "";
            this.vSroInputBox4.vSroUseSystemPasswordChar = false;
            // 
            // vSroInputBox3
            // 
            this.vSroInputBox3.AutoSize = true;
            this.vSroInputBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox3.BackgroundImage")));
            this.vSroInputBox3.Location = new System.Drawing.Point(39, 163);
            this.vSroInputBox3.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox3.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox3.Name = "vSroInputBox3";
            this.vSroInputBox3.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox3.TabIndex = 3;
            this.vSroInputBox3.TitleText = "Version:";
            this.vSroInputBox3.ValueText = "";
            this.vSroInputBox3.vSroUseSystemPasswordChar = false;
            // 
            // vSroInputBox2
            // 
            this.vSroInputBox2.AutoSize = true;
            this.vSroInputBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox2.BackgroundImage")));
            this.vSroInputBox2.Location = new System.Drawing.Point(39, 117);
            this.vSroInputBox2.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox2.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox2.Name = "vSroInputBox2";
            this.vSroInputBox2.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox2.TabIndex = 2;
            this.vSroInputBox2.TitleText = "Host Port:";
            this.vSroInputBox2.ValueText = "";
            this.vSroInputBox2.vSroUseSystemPasswordChar = false;
            // 
            // vSroInputBox1
            // 
            this.vSroInputBox1.AutoSize = true;
            this.vSroInputBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox1.BackgroundImage")));
            this.vSroInputBox1.Location = new System.Drawing.Point(39, 71);
            this.vSroInputBox1.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox1.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox1.Name = "vSroInputBox1";
            this.vSroInputBox1.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox1.TabIndex = 1;
            this.vSroInputBox1.TitleText = "Host IP:";
            this.vSroInputBox1.ValueText = "";
            this.vSroInputBox1.vSroUseSystemPasswordChar = false;
            // 
            // vSroSizableWindow1
            // 
            this.vSroSizableWindow1.BackColor = System.Drawing.Color.Black;
            this.vSroSizableWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vSroSizableWindow1.Location = new System.Drawing.Point(0, 0);
            this.vSroSizableWindow1.Name = "vSroSizableWindow1";
            this.vSroSizableWindow1.Size = new System.Drawing.Size(656, 447);
            this.vSroSizableWindow1.TabIndex = 0;
            this.vSroSizableWindow1.Title = "Settings";
            // 
            // vSroSmallButtonClientPath
            // 
            this.vSroSmallButtonClientPath.Location = new System.Drawing.Point(416, 117);
            this.vSroSmallButtonClientPath.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonClientPath.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonClientPath.Name = "vSroSmallButtonClientPath";
            this.vSroSmallButtonClientPath.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonClientPath.TabIndex = 11;
            this.vSroSmallButtonClientPath.vSroSmallButtonName = "Empty";
            this.vSroSmallButtonClientPath.vSroClickEvent += new PluginFramework.BasicControls.vSroSmallButton.vSroClick(this.vSroSmallButtonClientPath_vSroClickEvent);
            // 
            // vSroSmallButton4
            // 
            this.vSroSmallButton4.Location = new System.Drawing.Point(416, 193);
            this.vSroSmallButton4.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton4.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton4.Name = "vSroSmallButton4";
            this.vSroSmallButton4.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton4.TabIndex = 12;
            this.vSroSmallButton4.vSroSmallButtonName = "Empty";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 447);
            this.Controls.Add(this.vSroSmallButton4);
            this.Controls.Add(this.vSroSmallButtonClientPath);
            this.Controls.Add(this.vSroSmallButton2);
            this.Controls.Add(this.vSroSmallButton1);
            this.Controls.Add(this.vSroInputBox7);
            this.Controls.Add(this.vSroInputBox6);
            this.Controls.Add(this.vSroCheckBox1);
            this.Controls.Add(this.vSroInputBox5);
            this.Controls.Add(this.vSroInputBox4);
            this.Controls.Add(this.vSroInputBox3);
            this.Controls.Add(this.vSroInputBox2);
            this.Controls.Add(this.vSroInputBox1);
            this.Controls.Add(this.vSroSizableWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PluginFramework.BasicControls.vSroSizableWindow vSroSizableWindow1;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox1;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox2;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox3;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox4;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox5;
        private PluginFramework.BasicControls.vSroCheckBox vSroCheckBox1;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox6;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox7;
        private PluginFramework.BasicControls.vSroSmallButton vSroSmallButton1;
        private PluginFramework.BasicControls.vSroSmallButton vSroSmallButton2;
        private PluginFramework.BasicControls.vSroSmallButton vSroSmallButtonClientPath;
        private PluginFramework.BasicControls.vSroSmallButton vSroSmallButton4;
    }
}