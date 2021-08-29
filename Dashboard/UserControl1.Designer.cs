namespace Dashboard
{
    partial class Dashboard
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainerDashboardText = new System.Windows.Forms.SplitContainer();
            this.richTextBoxShowTopicText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEditTopicText = new System.Windows.Forms.RichTextBox();
            this.vSroSmallButtonSave = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSmallButtonCancel = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTopic = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelAdTopic = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDashboardText)).BeginInit();
            this.splitContainerDashboardText.Panel1.SuspendLayout();
            this.splitContainerDashboardText.Panel2.SuspendLayout();
            this.splitContainerDashboardText.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerDashboardText);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(160, 450);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            this.splitContainerDashboardText.Panel1.Controls.Add(this.richTextBoxShowTopicText);
            // 
            // splitContainerDashboardText.Panel2
            // 
            this.splitContainerDashboardText.Panel2.Controls.Add(this.richTextBoxEditTopicText);
            this.splitContainerDashboardText.Panel2.Controls.Add(this.vSroSmallButtonSave);
            this.splitContainerDashboardText.Panel2.Controls.Add(this.vSroSmallButtonCancel);
            this.splitContainerDashboardText.Panel2.Controls.Add(this.labelTitle);
            this.splitContainerDashboardText.Panel2.Controls.Add(this.textBoxTopic);
            this.splitContainerDashboardText.Size = new System.Drawing.Size(636, 428);
            this.splitContainerDashboardText.SplitterDistance = 307;
            this.splitContainerDashboardText.TabIndex = 1;
            // 
            // richTextBoxShowTopicText
            // 
            this.richTextBoxShowTopicText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxShowTopicText.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxShowTopicText.Name = "richTextBoxShowTopicText";
            this.richTextBoxShowTopicText.Size = new System.Drawing.Size(303, 424);
            this.richTextBoxShowTopicText.TabIndex = 0;
            this.richTextBoxShowTopicText.Text = "";
            // 
            // richTextBoxEditTopicText
            // 
            this.richTextBoxEditTopicText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxEditTopicText.Location = new System.Drawing.Point(3, 29);
            this.richTextBoxEditTopicText.Name = "richTextBoxEditTopicText";
            this.richTextBoxEditTopicText.Size = new System.Drawing.Size(315, 362);
            this.richTextBoxEditTopicText.TabIndex = 4;
            this.richTextBoxEditTopicText.Text = "";
            // 
            // vSroSmallButtonSave
            // 
            this.vSroSmallButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vSroSmallButtonSave.Location = new System.Drawing.Point(156, 397);
            this.vSroSmallButtonSave.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonSave.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonSave.Name = "vSroSmallButtonSave";
            this.vSroSmallButtonSave.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonSave.TabIndex = 3;
            this.vSroSmallButtonSave.vSroSmallButtonName = "Save";
            this.vSroSmallButtonSave.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.SaveTopic);
            // 
            // vSroSmallButtonCancel
            // 
            this.vSroSmallButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vSroSmallButtonCancel.Location = new System.Drawing.Point(-2, 397);
            this.vSroSmallButtonCancel.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonCancel.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonCancel.Name = "vSroSmallButtonCancel";
            this.vSroSmallButtonCancel.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonCancel.TabIndex = 2;
            this.vSroSmallButtonCancel.vSroSmallButtonName = "Cancel";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(19, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 13);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Title:";
            // 
            // textBoxTopic
            // 
            this.textBoxTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTopic.Location = new System.Drawing.Point(51, 3);
            this.textBoxTopic.Name = "textBoxTopic";
            this.textBoxTopic.Size = new System.Drawing.Size(267, 20);
            this.textBoxTopic.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelAdTopic});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(636, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelAdTopic
            // 
            this.toolStripStatusLabelAdTopic.Name = "toolStripStatusLabelAdTopic";
            this.toolStripStatusLabelAdTopic.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabelAdTopic.Text = "Add new Topic";
            this.toolStripStatusLabelAdTopic.Click += new System.EventHandler(this.toolStripStatusLabelAdTopic_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerDashboardText.Panel1.ResumeLayout(false);
            this.splitContainerDashboardText.Panel2.ResumeLayout(false);
            this.splitContainerDashboardText.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDashboardText)).EndInit();
            this.splitContainerDashboardText.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAdTopic;
        private System.Windows.Forms.SplitContainer splitContainerDashboardText;
        private System.Windows.Forms.RichTextBox richTextBoxShowTopicText;
        private System.Windows.Forms.RichTextBox richTextBoxEditTopicText;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonSave;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonCancel;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTopic;
    }
}
