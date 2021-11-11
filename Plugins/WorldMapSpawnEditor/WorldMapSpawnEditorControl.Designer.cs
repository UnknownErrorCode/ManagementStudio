namespace WorldMapSpawnEditor
{
    partial class WorldMapSpawnEditorControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2dViewer = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarLoadSpawns = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelSpawnsLoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStripRegionClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCreateSpawn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCoordinateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vSroCheckBox1 = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBox2 = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dViewer)).BeginInit();
            this.splitContainer2dViewer.Panel1.SuspendLayout();
            this.splitContainer2dViewer.Panel2.SuspendLayout();
            this.splitContainer2dViewer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripRegionClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2dViewer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2dViewer
            // 
            this.splitContainer2dViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2dViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2dViewer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2dViewer.Name = "splitContainer2dViewer";
            // 
            // splitContainer2dViewer.Panel1
            // 
            this.splitContainer2dViewer.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer2dViewer.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer2dViewer.Panel2
            // 
            this.splitContainer2dViewer.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBox2);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBox1);
            this.splitContainer2dViewer.Panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer2dViewer.Size = new System.Drawing.Size(786, 418);
            this.splitContainer2dViewer.SplitterDistance = 523;
            this.splitContainer2dViewer.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarLoadSpawns,
            this.toolStripStatusLabelSpawnsLoad});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(519, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBarLoadSpawns
            // 
            this.toolStripProgressBarLoadSpawns.Name = "toolStripProgressBarLoadSpawns";
            this.toolStripProgressBarLoadSpawns.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelSpawnsLoad
            // 
            this.toolStripStatusLabelSpawnsLoad.Name = "toolStripStatusLabelSpawnsLoad";
            this.toolStripStatusLabelSpawnsLoad.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelSpawnsLoad.Text = "toolStripStatusLabel1";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripRegionClick
            // 
            this.contextMenuStripRegionClick.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.contextMenuStripRegionClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateSpawn,
            this.saveCoordinateToolStripMenuItem});
            this.contextMenuStripRegionClick.Name = "contextMenuStripRegionClick";
            this.contextMenuStripRegionClick.Size = new System.Drawing.Size(161, 48);
            // 
            // toolStripMenuItemCreateSpawn
            // 
            this.toolStripMenuItemCreateSpawn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStripMenuItemCreateSpawn.Name = "toolStripMenuItemCreateSpawn";
            this.toolStripMenuItemCreateSpawn.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemCreateSpawn.Text = "Create spawn";
            // 
            // saveCoordinateToolStripMenuItem
            // 
            this.saveCoordinateToolStripMenuItem.Name = "saveCoordinateToolStripMenuItem";
            this.saveCoordinateToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveCoordinateToolStripMenuItem.Text = "Save Coordinate";
            // 
            // vSroCheckBox1
            // 
            this.vSroCheckBox1.AutoSize = true;
            this.vSroCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBox1.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBox1.Location = new System.Drawing.Point(15, 22);
            this.vSroCheckBox1.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBox1.Name = "vSroCheckBox1";
            this.vSroCheckBox1.Size = new System.Drawing.Size(124, 16);
            this.vSroCheckBox1.TabIndex = 0;
            this.vSroCheckBox1.vSroCheck = false;
            this.vSroCheckBox1.vSroCheckBoxName = "Show Tool Tip";
            this.vSroCheckBox1.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBox1_vSroCheckChange);
            // 
            // vSroCheckBox2
            // 
            this.vSroCheckBox2.AutoSize = true;
            this.vSroCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBox2.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBox2.Location = new System.Drawing.Point(15, 44);
            this.vSroCheckBox2.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBox2.Name = "vSroCheckBox2";
            this.vSroCheckBox2.Size = new System.Drawing.Size(124, 16);
            this.vSroCheckBox2.TabIndex = 1;
            this.vSroCheckBox2.vSroCheck = false;
            this.vSroCheckBox2.vSroCheckBoxName = "Show Tool Tip";
            this.vSroCheckBox2.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBox2_vSroCheckChange);
            // 
            // WorldMapSpawnEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "WorldMapSpawnEditorControl";
            this.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2dViewer.Panel1.ResumeLayout(false);
            this.splitContainer2dViewer.Panel1.PerformLayout();
            this.splitContainer2dViewer.Panel2.ResumeLayout(false);
            this.splitContainer2dViewer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dViewer)).EndInit();
            this.splitContainer2dViewer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripRegionClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2dViewer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRegionClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateSpawn;
        private System.Windows.Forms.ToolStripMenuItem saveCoordinateToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpawnsLoad;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBarLoadSpawns;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBox1;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBox2;
    }
}
