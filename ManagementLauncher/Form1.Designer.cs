
namespace ManagementLauncher
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.vSroSizableWindow1 = new ServerFrameworkRes.BasicControls.vSroSizableWindow();
            this.vSroSmallButtonPatch = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSmallButtonStart = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSmallButtonClose = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroInputBoxHost = new ServerFrameworkRes.BasicControls.vSroInputBox();
            this.vSroInputBoxPort = new ServerFrameworkRes.BasicControls.vSroInputBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // vSroSizableWindow1
            // 
            this.vSroSizableWindow1.BackColor = System.Drawing.Color.Black;
            this.vSroSizableWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vSroSizableWindow1.Location = new System.Drawing.Point(0, 0);
            this.vSroSizableWindow1.Name = "vSroSizableWindow1";
            this.vSroSizableWindow1.Size = new System.Drawing.Size(500, 450);
            this.vSroSizableWindow1.TabIndex = 1;
            this.vSroSizableWindow1.Title = "vSro Management Launcher";
            // 
            // vSroSmallButtonPatch
            // 
            this.vSroSmallButtonPatch.Location = new System.Drawing.Point(20, 271);
            this.vSroSmallButtonPatch.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonPatch.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonPatch.Name = "vSroSmallButtonPatch";
            this.vSroSmallButtonPatch.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonPatch.TabIndex = 2;
            this.vSroSmallButtonPatch.vSroSmallButtonName = "Patch";
            // 
            // vSroSmallButtonStart
            // 
            this.vSroSmallButtonStart.Enabled = false;
            this.vSroSmallButtonStart.Location = new System.Drawing.Point(178, 271);
            this.vSroSmallButtonStart.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonStart.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonStart.Name = "vSroSmallButtonStart";
            this.vSroSmallButtonStart.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonStart.TabIndex = 3;
            this.vSroSmallButtonStart.vSroSmallButtonName = "Start";
            // 
            // vSroSmallButtonClose
            // 
            this.vSroSmallButtonClose.Location = new System.Drawing.Point(336, 271);
            this.vSroSmallButtonClose.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonClose.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonClose.Name = "vSroSmallButtonClose";
            this.vSroSmallButtonClose.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonClose.TabIndex = 4;
            this.vSroSmallButtonClose.vSroSmallButtonName = "Close";
            // 
            // vSroInputBoxHost
            // 
            this.vSroInputBoxHost.AutoSize = true;
            this.vSroInputBoxHost.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBoxHost.BackgroundImage")));
            this.vSroInputBoxHost.Location = new System.Drawing.Point(20, 61);
            this.vSroInputBoxHost.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBoxHost.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBoxHost.Name = "vSroInputBoxHost";
            this.vSroInputBoxHost.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBoxHost.TabIndex = 5;
            this.vSroInputBoxHost.TitleText = "Host IP:";
            this.vSroInputBoxHost.ValueText = "";
            this.vSroInputBoxHost.vSroUseSystemPasswordChar = false;
            // 
            // vSroInputBoxPort
            // 
            this.vSroInputBoxPort.AutoSize = true;
            this.vSroInputBoxPort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBoxPort.BackgroundImage")));
            this.vSroInputBoxPort.Location = new System.Drawing.Point(20, 107);
            this.vSroInputBoxPort.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBoxPort.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBoxPort.Name = "vSroInputBoxPort";
            this.vSroInputBoxPort.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBoxPort.TabIndex = 6;
            this.vSroInputBoxPort.TitleText = "Host Port:";
            this.vSroInputBoxPort.ValueText = "";
            this.vSroInputBoxPort.vSroUseSystemPasswordChar = false;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.BackColor = System.Drawing.SystemColors.MenuText;
            this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLog.Location = new System.Drawing.Point(38, 301);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(423, 119);
            this.richTextBoxLog.TabIndex = 7;
            this.richTextBoxLog.Text = "";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.vSroInputBoxPort);
            this.Controls.Add(this.vSroInputBoxHost);
            this.Controls.Add(this.vSroSmallButtonClose);
            this.Controls.Add(this.vSroSmallButtonStart);
            this.Controls.Add(this.vSroSmallButtonPatch);
            this.Controls.Add(this.vSroSizableWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Launcher";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ServerFrameworkRes.BasicControls.vSroSizableWindow vSroSizableWindow1;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonPatch;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonStart;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonClose;
        private ServerFrameworkRes.BasicControls.vSroInputBox vSroInputBoxHost;
        private ServerFrameworkRes.BasicControls.vSroInputBox vSroInputBoxPort;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
    }
}

