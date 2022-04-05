
namespace ManagementClient
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlPlugins = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPluginsToolStripMenuItem,
            this.openSettingsToolStripMenuItem,
            this.logToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadPluginsToolStripMenuItem
            // 
            this.loadPluginsToolStripMenuItem.Enabled = false;
            this.loadPluginsToolStripMenuItem.Name = "loadPluginsToolStripMenuItem";
            this.loadPluginsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadPluginsToolStripMenuItem.Text = "Load Plugins";
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openSettingsToolStripMenuItem.Text = "Open Settings";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.openSettingsToolStripMenuItem_Click);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            // 
            // tabControlPlugins
            // 
            this.tabControlPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPlugins.Location = new System.Drawing.Point(0, 24);
            this.tabControlPlugins.Name = "tabControlPlugins";
            this.tabControlPlugins.SelectedIndex = 0;
            this.tabControlPlugins.Size = new System.Drawing.Size(964, 607);
            this.tabControlPlugins.TabIndex = 1;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(964, 631);
            this.Controls.Add(this.tabControlPlugins);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.Text = "vSro Studio Client V.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlPlugins;
        internal System.Windows.Forms.ToolStripMenuItem loadPluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
    }
}