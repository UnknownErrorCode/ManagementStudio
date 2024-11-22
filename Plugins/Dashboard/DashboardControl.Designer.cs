﻿namespace Dashboard
{
    partial class DashboardControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTopic = new System.Windows.Forms.Label();
            this.vSroButtonList1 = new PluginFramework.BasicControls.vSroButtonList();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.editShownTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteShownTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.vSroButtonListOnlineUser = new PluginFramework.BasicControls.vSroButtonList();
            this.timerCheckDashboard = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.vSroButtonList1);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel2.Controls.Add(this.vSroButtonListOnlineUser);
            this.splitContainer1.Size = new System.Drawing.Size(833, 450);
            this.splitContainer1.SplitterDistance = 603;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.labelAuthor);
            this.panel2.Controls.Add(this.labelTopic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(220, 0);
            this.panel2.MaximumSize = new System.Drawing.Size(376, 384);
            this.panel2.MinimumSize = new System.Drawing.Size(376, 384);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 384);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.labelText);
            this.panel3.Location = new System.Drawing.Point(12, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 312);
            this.panel3.TabIndex = 3;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.ForeColor = System.Drawing.Color.Black;
            this.labelText.Location = new System.Drawing.Point(3, 0);
            this.labelText.MaximumSize = new System.Drawing.Size(325, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(146, 16);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Please select a Topic!";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthor.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(18, 4);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(52, 13);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Author: ";
            // 
            // labelTopic
            // 
            this.labelTopic.AutoSize = true;
            this.labelTopic.BackColor = System.Drawing.Color.Transparent;
            this.labelTopic.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopic.ForeColor = System.Drawing.Color.Black;
            this.labelTopic.Location = new System.Drawing.Point(29, 26);
            this.labelTopic.MaximumSize = new System.Drawing.Size(327, 327);
            this.labelTopic.Name = "labelTopic";
            this.labelTopic.Size = new System.Drawing.Size(172, 19);
            this.labelTopic.TabIndex = 1;
            this.labelTopic.Text = "Please select a Topic!";
            // 
            // vSroButtonList1
            // 
            this.vSroButtonList1.AutoScroll = true;
            this.vSroButtonList1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroButtonList1.BackgroundImage")));
            this.vSroButtonList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vSroButtonList1.Location = new System.Drawing.Point(0, 0);
            this.vSroButtonList1.MaximumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.MinimumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.Name = "vSroButtonList1";
            this.vSroButtonList1.Size = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.TabIndex = 6;
            this.vSroButtonList1.OnIndCh += new System.EventHandler(this.vSroButtonListDashboard_OnIndCh);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(603, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editShownTopicToolStripMenuItem,
            this.deleteShownTopicToolStripMenuItem,
            this.addNewTopicToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // editShownTopicToolStripMenuItem
            // 
            this.editShownTopicToolStripMenuItem.Name = "editShownTopicToolStripMenuItem";
            this.editShownTopicToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editShownTopicToolStripMenuItem.Text = "Edit shown topic";
            this.editShownTopicToolStripMenuItem.Click += new System.EventHandler(this.editShownTopicToolStripMenuItem_Click);
            // 
            // deleteShownTopicToolStripMenuItem
            // 
            this.deleteShownTopicToolStripMenuItem.Name = "deleteShownTopicToolStripMenuItem";
            this.deleteShownTopicToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.deleteShownTopicToolStripMenuItem.Text = "Delete shown topic";
            this.deleteShownTopicToolStripMenuItem.Click += new System.EventHandler(this.deleteShownTopicToolStripMenuItem_Click);
            // 
            // addNewTopicToolStripMenuItem
            // 
            this.addNewTopicToolStripMenuItem.Name = "addNewTopicToolStripMenuItem";
            this.addNewTopicToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.addNewTopicToolStripMenuItem.Text = "Add new topic";
            this.addNewTopicToolStripMenuItem.Click += new System.EventHandler(this.addNewTopicToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.SystemColors.Window;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(603, 450);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // vSroButtonListOnlineUser
            // 
            this.vSroButtonListOnlineUser.AutoScroll = true;
            this.vSroButtonListOnlineUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroButtonListOnlineUser.BackgroundImage")));
            this.vSroButtonListOnlineUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.vSroButtonListOnlineUser.Location = new System.Drawing.Point(0, 0);
            this.vSroButtonListOnlineUser.MaximumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonListOnlineUser.MinimumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonListOnlineUser.Name = "vSroButtonListOnlineUser";
            this.vSroButtonListOnlineUser.Size = new System.Drawing.Size(220, 400);
            this.vSroButtonListOnlineUser.TabIndex = 0;
            // 
            // timerCheckDashboard
            // 
            this.timerCheckDashboard.Interval = 1000;
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(833, 450);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timerCheckDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTopic;
        private PluginFramework.BasicControls.vSroButtonList vSroButtonList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem editShownTopicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteShownTopicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTopicToolStripMenuItem;
        private PluginFramework.BasicControls.vSroButtonList vSroButtonListOnlineUser;
    }
}
