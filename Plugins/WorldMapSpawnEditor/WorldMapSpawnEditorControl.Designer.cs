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
            this.vSroCheckBoxShowTeleports = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroSmallButtonLoad = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroCheckBoxUnAsReg = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxReg = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxShowPlayer = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxShowNpc = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxShowuMob = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxShowMob = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxOpenSpawnEditor = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxShowToolTip = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStripRegionClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCreateSpawn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCoordinateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vSroCheckBoxShowNestGenRadius = new ServerFrameworkRes.BasicControls.vSroCheckBox();
            this.vSroCheckBoxShowNestRadius = new ServerFrameworkRes.BasicControls.vSroCheckBox();
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
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowNestRadius);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowNestGenRadius);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowTeleports);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroSmallButtonLoad);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxUnAsReg);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxReg);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowPlayer);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowNpc);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowuMob);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowMob);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxOpenSpawnEditor);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.vSroCheckBoxShowToolTip);
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
            // vSroCheckBoxShowTeleports
            // 
            this.vSroCheckBoxShowTeleports.AutoSize = true;
            this.vSroCheckBoxShowTeleports.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowTeleports.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowTeleports.Location = new System.Drawing.Point(16, 178);
            this.vSroCheckBoxShowTeleports.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowTeleports.Name = "vSroCheckBoxShowTeleports";
            this.vSroCheckBoxShowTeleports.Size = new System.Drawing.Size(127, 16);
            this.vSroCheckBoxShowTeleports.TabIndex = 6;
            this.vSroCheckBoxShowTeleports.vSroCheck = false;
            this.vSroCheckBoxShowTeleports.vSroCheckBoxName = "Show Teleport";
            this.vSroCheckBoxShowTeleports.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxShowTeleports_vSroCheckChange);
            // 
            // vSroSmallButtonLoad
            // 
            this.vSroSmallButtonLoad.Location = new System.Drawing.Point(16, 346);
            this.vSroSmallButtonLoad.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLoad.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLoad.Name = "vSroSmallButtonLoad";
            this.vSroSmallButtonLoad.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLoad.TabIndex = 8;
            this.vSroSmallButtonLoad.vSroSmallButtonName = "Load Data";
            this.vSroSmallButtonLoad.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.vSroSmallButtonLoad_vSroClickEvent);
            // 
            // vSroCheckBoxUnAsReg
            // 
            this.vSroCheckBoxUnAsReg.AutoSize = true;
            this.vSroCheckBoxUnAsReg.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxUnAsReg.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxUnAsReg.Location = new System.Drawing.Point(15, 230);
            this.vSroCheckBoxUnAsReg.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxUnAsReg.Name = "vSroCheckBoxUnAsReg";
            this.vSroCheckBoxUnAsReg.Size = new System.Drawing.Size(217, 16);
            this.vSroCheckBoxUnAsReg.TabIndex = 8;
            this.vSroCheckBoxUnAsReg.vSroCheck = false;
            this.vSroCheckBoxUnAsReg.vSroCheckBoxName = "Show Unassigned Regions";
            this.vSroCheckBoxUnAsReg.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxUnAsReg_vSroCheckChange);
            // 
            // vSroCheckBoxReg
            // 
            this.vSroCheckBoxReg.AutoSize = true;
            this.vSroCheckBoxReg.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxReg.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxReg.Location = new System.Drawing.Point(15, 208);
            this.vSroCheckBoxReg.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxReg.Name = "vSroCheckBoxReg";
            this.vSroCheckBoxReg.Size = new System.Drawing.Size(153, 16);
            this.vSroCheckBoxReg.TabIndex = 7;
            this.vSroCheckBoxReg.vSroCheck = false;
            this.vSroCheckBoxReg.vSroCheckBoxName = "Show Db Regions";
            this.vSroCheckBoxReg.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxReg_vSroCheckChange);
            // 
            // vSroCheckBoxShowPlayer
            // 
            this.vSroCheckBoxShowPlayer.AutoSize = true;
            this.vSroCheckBoxShowPlayer.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowPlayer.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowPlayer.Location = new System.Drawing.Point(15, 156);
            this.vSroCheckBoxShowPlayer.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowPlayer.Name = "vSroCheckBoxShowPlayer";
            this.vSroCheckBoxShowPlayer.Size = new System.Drawing.Size(124, 16);
            this.vSroCheckBoxShowPlayer.TabIndex = 5;
            this.vSroCheckBoxShowPlayer.vSroCheck = false;
            this.vSroCheckBoxShowPlayer.vSroCheckBoxName = "Show Player";
            this.vSroCheckBoxShowPlayer.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxShowPlayer_vSroCheckChange);
            // 
            // vSroCheckBoxShowNpc
            // 
            this.vSroCheckBoxShowNpc.AutoSize = true;
            this.vSroCheckBoxShowNpc.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowNpc.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowNpc.Location = new System.Drawing.Point(15, 134);
            this.vSroCheckBoxShowNpc.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowNpc.Name = "vSroCheckBoxShowNpc";
            this.vSroCheckBoxShowNpc.Size = new System.Drawing.Size(124, 16);
            this.vSroCheckBoxShowNpc.TabIndex = 4;
            this.vSroCheckBoxShowNpc.vSroCheck = false;
            this.vSroCheckBoxShowNpc.vSroCheckBoxName = "Show Npcs";
            this.vSroCheckBoxShowNpc.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxShowNpc_vSroCheckChange);
            // 
            // vSroCheckBoxShowuMob
            // 
            this.vSroCheckBoxShowuMob.AutoSize = true;
            this.vSroCheckBoxShowuMob.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowuMob.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowuMob.Location = new System.Drawing.Point(15, 112);
            this.vSroCheckBoxShowuMob.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowuMob.Name = "vSroCheckBoxShowuMob";
            this.vSroCheckBoxShowuMob.Size = new System.Drawing.Size(182, 16);
            this.vSroCheckBoxShowuMob.TabIndex = 3;
            this.vSroCheckBoxShowuMob.vSroCheck = false;
            this.vSroCheckBoxShowuMob.vSroCheckBoxName = "Show Unique Monster";
            this.vSroCheckBoxShowuMob.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxShowuMob_vSroCheckChange);
            // 
            // vSroCheckBoxShowMob
            // 
            this.vSroCheckBoxShowMob.AutoSize = true;
            this.vSroCheckBoxShowMob.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowMob.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowMob.Location = new System.Drawing.Point(15, 90);
            this.vSroCheckBoxShowMob.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowMob.Name = "vSroCheckBoxShowMob";
            this.vSroCheckBoxShowMob.Size = new System.Drawing.Size(127, 16);
            this.vSroCheckBoxShowMob.TabIndex = 2;
            this.vSroCheckBoxShowMob.vSroCheck = false;
            this.vSroCheckBoxShowMob.vSroCheckBoxName = "Show Monster";
            this.vSroCheckBoxShowMob.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxShowMob_vSroCheckChange);
            // 
            // vSroCheckBoxOpenSpawnEditor
            // 
            this.vSroCheckBoxOpenSpawnEditor.AutoSize = true;
            this.vSroCheckBoxOpenSpawnEditor.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxOpenSpawnEditor.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxOpenSpawnEditor.Location = new System.Drawing.Point(15, 44);
            this.vSroCheckBoxOpenSpawnEditor.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxOpenSpawnEditor.Name = "vSroCheckBoxOpenSpawnEditor";
            this.vSroCheckBoxOpenSpawnEditor.Size = new System.Drawing.Size(222, 16);
            this.vSroCheckBoxOpenSpawnEditor.TabIndex = 1;
            this.vSroCheckBoxOpenSpawnEditor.vSroCheck = false;
            this.vSroCheckBoxOpenSpawnEditor.vSroCheckBoxName = "Open Spawn Editor on Click";
            this.vSroCheckBoxOpenSpawnEditor.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBox2_vSroCheckChange);
            // 
            // vSroCheckBoxShowToolTip
            // 
            this.vSroCheckBoxShowToolTip.AutoSize = true;
            this.vSroCheckBoxShowToolTip.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowToolTip.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowToolTip.Location = new System.Drawing.Point(15, 22);
            this.vSroCheckBoxShowToolTip.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowToolTip.Name = "vSroCheckBoxShowToolTip";
            this.vSroCheckBoxShowToolTip.Size = new System.Drawing.Size(124, 16);
            this.vSroCheckBoxShowToolTip.TabIndex = 0;
            this.vSroCheckBoxShowToolTip.vSroCheck = false;
            this.vSroCheckBoxShowToolTip.vSroCheckBoxName = "Show Tool Tip";
            this.vSroCheckBoxShowToolTip.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBox1_vSroCheckChange);
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
            // vSroCheckBoxShowNestGenRadius
            // 
            this.vSroCheckBoxShowNestGenRadius.AutoSize = true;
            this.vSroCheckBoxShowNestGenRadius.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowNestGenRadius.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowNestGenRadius.Location = new System.Drawing.Point(15, 252);
            this.vSroCheckBoxShowNestGenRadius.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowNestGenRadius.Name = "vSroCheckBoxShowNestGenRadius";
            this.vSroCheckBoxShowNestGenRadius.Size = new System.Drawing.Size(228, 16);
            this.vSroCheckBoxShowNestGenRadius.TabIndex = 9;
            this.vSroCheckBoxShowNestGenRadius.vSroCheck = false;
            this.vSroCheckBoxShowNestGenRadius.vSroCheckBoxName = "Show Nest Generate Radius";
            this.vSroCheckBoxShowNestGenRadius.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxShowNestGenRadius_vSroCheckChange);
            // 
            // vSroCheckBoxShowNestRadius
            // 
            this.vSroCheckBoxShowNestRadius.AutoSize = true;
            this.vSroCheckBoxShowNestRadius.BackColor = System.Drawing.Color.Transparent;
            this.vSroCheckBoxShowNestRadius.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxShowNestRadius.Location = new System.Drawing.Point(15, 274);
            this.vSroCheckBoxShowNestRadius.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxShowNestRadius.Name = "vSroCheckBoxShowNestRadius";
            this.vSroCheckBoxShowNestRadius.Size = new System.Drawing.Size(228, 16);
            this.vSroCheckBoxShowNestRadius.TabIndex = 10;
            this.vSroCheckBoxShowNestRadius.vSroCheck = false;
            this.vSroCheckBoxShowNestRadius.vSroCheckBoxName = "Show Nest Radius";
            this.vSroCheckBoxShowNestRadius.vSroCheckChange += new ServerFrameworkRes.BasicControls.vSroCheckBox.vSroCheckChanger(this.vSroCheckBoxShowNestRadius_vSroCheckChange);
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
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowToolTip;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxOpenSpawnEditor;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowNpc;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowuMob;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowMob;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowPlayer;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxUnAsReg;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxReg;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonLoad;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowTeleports;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowNestRadius;
        private ServerFrameworkRes.BasicControls.vSroCheckBox vSroCheckBoxShowNestGenRadius;
    }
}
