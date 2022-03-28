namespace Dashboard
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
            this.vSroButtonList1 = new ServerFrameworkRes.BasicControls.vSroButtonList();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainerDashboardText = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTopic = new System.Windows.Forms.Label();
            this.richTextBoxShowTopicText = new System.Windows.Forms.RichTextBox();
            this.vSroSmallButtonSave = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSmallButtonCancel = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.editShownTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteShownTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCheckDashboard = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDashboardText)).BeginInit();
            this.splitContainerDashboardText.Panel1.SuspendLayout();
            this.splitContainerDashboardText.Panel2.SuspendLayout();
            this.splitContainerDashboardText.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vSroButtonList1);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerDashboardText);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 0;
            // 
            // vSroButtonList1
            // 
            this.vSroButtonList1.AutoScroll = true;
            this.vSroButtonList1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroButtonList1.BackgroundImage")));
            this.vSroButtonList1.Location = new System.Drawing.Point(3, 47);
            this.vSroButtonList1.MaximumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.MinimumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.Name = "vSroButtonList1";
            this.vSroButtonList1.Size = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.TabIndex = 1;
            this.vSroButtonList1.OnIndCh += new System.EventHandler(this.vSroButtonList1_OnIndCh);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.SystemColors.Window;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(242, 450);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.OnIdexChange);
            // 
            // splitContainerDashboardText
            // 
            this.splitContainerDashboardText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerDashboardText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDashboardText.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDashboardText.Name = "splitContainerDashboardText";
            // 
            // splitContainerDashboardText.Panel1
            // 
            this.splitContainerDashboardText.Panel1.Controls.Add(this.panel2);
            this.splitContainerDashboardText.Panel1.Controls.Add(this.richTextBoxShowTopicText);
            // 
            // splitContainerDashboardText.Panel2
            // 
            this.splitContainerDashboardText.Panel2.Controls.Add(this.vSroSmallButtonSave);
            this.splitContainerDashboardText.Panel2.Controls.Add(this.vSroSmallButtonCancel);
            this.splitContainerDashboardText.Size = new System.Drawing.Size(554, 428);
            this.splitContainerDashboardText.SplitterDistance = 382;
            this.splitContainerDashboardText.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.labelAuthor);
            this.panel2.Controls.Add(this.labelTopic);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.MaximumSize = new System.Drawing.Size(376, 384);
            this.panel2.MinimumSize = new System.Drawing.Size(376, 384);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 384);
            this.panel2.TabIndex = 3;
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
            // richTextBoxShowTopicText
            // 
            this.richTextBoxShowTopicText.BackColor = System.Drawing.Color.Black;
            this.richTextBoxShowTopicText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxShowTopicText.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxShowTopicText.Name = "richTextBoxShowTopicText";
            this.richTextBoxShowTopicText.ReadOnly = true;
            this.richTextBoxShowTopicText.Size = new System.Drawing.Size(378, 424);
            this.richTextBoxShowTopicText.TabIndex = 0;
            this.richTextBoxShowTopicText.Text = "";
            this.richTextBoxShowTopicText.TextChanged += new System.EventHandler(this.richTextBoxShowTopicText_TextChanged);
            // 
            // vSroSmallButtonSave
            // 
            this.vSroSmallButtonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.vSroSmallButtonSave.Location = new System.Drawing.Point(0, 376);
            this.vSroSmallButtonSave.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonSave.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonSave.Name = "vSroSmallButtonSave";
            this.vSroSmallButtonSave.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonSave.TabIndex = 3;
            this.vSroSmallButtonSave.vSroSmallButtonName = "Save";
            // 
            // vSroSmallButtonCancel
            // 
            this.vSroSmallButtonCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.vSroSmallButtonCancel.Location = new System.Drawing.Point(0, 400);
            this.vSroSmallButtonCancel.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonCancel.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonCancel.Name = "vSroSmallButtonCancel";
            this.vSroSmallButtonCancel.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonCancel.TabIndex = 2;
            this.vSroSmallButtonCancel.vSroSmallButtonName = "Cancel";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(554, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
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
            this.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerDashboardText.Panel1.ResumeLayout(false);
            this.splitContainerDashboardText.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDashboardText)).EndInit();
            this.splitContainerDashboardText.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainerDashboardText;
        private System.Windows.Forms.RichTextBox richTextBoxShowTopicText;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonSave;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonCancel;
        private System.Windows.Forms.Timer timerCheckDashboard;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem editShownTopicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteShownTopicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTopicToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTopic;
        private ServerFrameworkRes.BasicControls.vSroButtonList vSroButtonList1;
    }
}
