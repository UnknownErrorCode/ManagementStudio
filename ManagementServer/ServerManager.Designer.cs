﻿
namespace ManagementServer
{
    partial class ServerManager
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gCCollectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gen1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gen2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gen3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelOnlineUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.patchManagerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.gCCollectToolStripMenuItem,
            this.refreshSecurityToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            // 
            // gCCollectToolStripMenuItem
            // 
            this.gCCollectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gen1ToolStripMenuItem,
            this.gen2ToolStripMenuItem,
            this.gen3ToolStripMenuItem});
            this.gCCollectToolStripMenuItem.Name = "gCCollectToolStripMenuItem";
            this.gCCollectToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.gCCollectToolStripMenuItem.Text = "GC Collect";
            // 
            // gen1ToolStripMenuItem
            // 
            this.gen1ToolStripMenuItem.Name = "gen1ToolStripMenuItem";
            this.gen1ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.gen1ToolStripMenuItem.Text = "Gen 1";
            this.gen1ToolStripMenuItem.Click += new System.EventHandler(this.gen1ToolStripMenuItem_Click);
            // 
            // gen2ToolStripMenuItem
            // 
            this.gen2ToolStripMenuItem.Name = "gen2ToolStripMenuItem";
            this.gen2ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.gen2ToolStripMenuItem.Text = "Gen 2";
            this.gen2ToolStripMenuItem.Click += new System.EventHandler(this.gen2ToolStripMenuItem_Click);
            // 
            // gen3ToolStripMenuItem
            // 
            this.gen3ToolStripMenuItem.Name = "gen3ToolStripMenuItem";
            this.gen3ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.gen3ToolStripMenuItem.Text = "Gen 3";
            this.gen3ToolStripMenuItem.Click += new System.EventHandler(this.gen3ToolStripMenuItem_Click);
            // 
            // refreshSecurityToolStripMenuItem
            // 
            this.refreshSecurityToolStripMenuItem.Name = "refreshSecurityToolStripMenuItem";
            this.refreshSecurityToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.refreshSecurityToolStripMenuItem.Text = "Refresh Security";
            this.refreshSecurityToolStripMenuItem.Click += new System.EventHandler(this.refreshSecurityToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sqlConnectionToolStripMenuItem,
            this.serverConnectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editToolStripMenuItem.Text = "Settings";
            // 
            // sqlConnectionToolStripMenuItem
            // 
            this.sqlConnectionToolStripMenuItem.Name = "sqlConnectionToolStripMenuItem";
            this.sqlConnectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sqlConnectionToolStripMenuItem.Text = "Sql Connection";
            this.sqlConnectionToolStripMenuItem.Click += new System.EventHandler(this.sqlConnectionToolStripMenuItem_Click);
            // 
            // serverConnectionToolStripMenuItem
            // 
            this.serverConnectionToolStripMenuItem.Name = "serverConnectionToolStripMenuItem";
            this.serverConnectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serverConnectionToolStripMenuItem.Text = "Server Connection";
            this.serverConnectionToolStripMenuItem.Click += new System.EventHandler(this.serverConnectionToolStripMenuItem_Click);
            // 
            // patchManagerToolStripMenuItem
            // 
            this.patchManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.patchManagerToolStripMenuItem.Name = "patchManagerToolStripMenuItem";
            this.patchManagerToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.patchManagerToolStripMenuItem.Text = "Patch Manager";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelOnlineUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(692, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelOnlineUser
            // 
            this.toolStripStatusLabelOnlineUser.Name = "toolStripStatusLabelOnlineUser";
            this.toolStripStatusLabelOnlineUser.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(436, 382);
            this.dataGridView1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(692, 386);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // ServerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 432);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerManager";
            this.Text = "Server Manager by RekciD 2021";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverConnectionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOnlineUser;
        private System.Windows.Forms.ToolStripMenuItem patchManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gCCollectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gen1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gen2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gen3ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem refreshSecurityToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

