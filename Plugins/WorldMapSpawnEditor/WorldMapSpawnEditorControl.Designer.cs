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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldMapSpawnEditorControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageWorld = new System.Windows.Forms.TabPage();
            this.splitContainer2dViewer = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButtonEditSpawn = new System.Windows.Forms.ToolStripDropDownButton();
            this.spawnEditorOnClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonMapGuide = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonReload = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonView = new System.Windows.Forms.ToolStripDropDownButton();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unassignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBRegionsWithoutDdjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monsterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noMsgUniqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teleportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.nestNGenRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nestNRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.spawnInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.showStructuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPageWorld.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dViewer)).BeginInit();
            this.splitContainer2dViewer.Panel2.SuspendLayout();
            this.splitContainer2dViewer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageWorld);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageWorld
            // 
            this.tabPageWorld.Controls.Add(this.splitContainer2dViewer);
            this.tabPageWorld.Location = new System.Drawing.Point(4, 22);
            this.tabPageWorld.Name = "tabPageWorld";
            this.tabPageWorld.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorld.Size = new System.Drawing.Size(792, 424);
            this.tabPageWorld.TabIndex = 0;
            this.tabPageWorld.Text = "WorldSpawn";
            this.tabPageWorld.UseVisualStyleBackColor = true;
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
            // 
            // splitContainer2dViewer.Panel2
            // 
            this.splitContainer2dViewer.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer2dViewer.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer2dViewer.Panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer2dViewer.Size = new System.Drawing.Size(786, 418);
            this.splitContainer2dViewer.SplitterDistance = 723;
            this.splitContainer2dViewer.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonEditSpawn,
            this.toolStripDropDownButtonMapGuide,
            this.toolStripDropDownButtonReload,
            this.toolStripDropDownButtonView});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(55, 414);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButtonEditSpawn
            // 
            this.toolStripDropDownButtonEditSpawn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonEditSpawn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spawnEditorOnClickToolStripMenuItem});
            this.toolStripDropDownButtonEditSpawn.Enabled = false;
            this.toolStripDropDownButtonEditSpawn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonEditSpawn.Image")));
            this.toolStripDropDownButtonEditSpawn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonEditSpawn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonEditSpawn.Name = "toolStripDropDownButtonEditSpawn";
            this.toolStripDropDownButtonEditSpawn.Size = new System.Drawing.Size(53, 32);
            this.toolStripDropDownButtonEditSpawn.Text = "toolStripDropDownButton1";
            // 
            // spawnEditorOnClickToolStripMenuItem
            // 
            this.spawnEditorOnClickToolStripMenuItem.CheckOnClick = true;
            this.spawnEditorOnClickToolStripMenuItem.Name = "spawnEditorOnClickToolStripMenuItem";
            this.spawnEditorOnClickToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.spawnEditorOnClickToolStripMenuItem.Text = "EditMode";
            this.spawnEditorOnClickToolStripMenuItem.Click += new System.EventHandler(this.showSpawnEditorOnClickToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonMapGuide
            // 
            this.toolStripDropDownButtonMapGuide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonMapGuide.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonMapGuide.Image")));
            this.toolStripDropDownButtonMapGuide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonMapGuide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonMapGuide.Name = "toolStripDropDownButtonMapGuide";
            this.toolStripDropDownButtonMapGuide.Size = new System.Drawing.Size(53, 44);
            this.toolStripDropDownButtonMapGuide.Text = "toolStripDropDownButton2";
            this.toolStripDropDownButtonMapGuide.ToolTipText = "Open Map Guide";
            this.toolStripDropDownButtonMapGuide.Click += new System.EventHandler(this.mapGuideToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonReload
            // 
            this.toolStripDropDownButtonReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDownButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonReload.Enabled = false;
            this.toolStripDropDownButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonReload.Image")));
            this.toolStripDropDownButtonReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonReload.Name = "toolStripDropDownButtonReload";
            this.toolStripDropDownButtonReload.Size = new System.Drawing.Size(53, 44);
            this.toolStripDropDownButtonReload.Text = "Refresh";
            this.toolStripDropDownButtonReload.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripDropDownButtonView
            // 
            this.toolStripDropDownButtonView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.toolStripDropDownButtonView.Enabled = false;
            this.toolStripDropDownButtonView.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonView.Image")));
            this.toolStripDropDownButtonView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonView.Name = "toolStripDropDownButtonView";
            this.toolStripDropDownButtonView.Size = new System.Drawing.Size(53, 44);
            this.toolStripDropDownButtonView.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButtonView.ToolTipText = "View";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem,
            this.regionToolStripMenuItem,
            this.monsterToolStripMenuItem,
            this.nPCToolStripMenuItem,
            this.teleportToolStripMenuItem,
            this.toolStripSeparator1,
            this.nestNGenRadiusToolStripMenuItem,
            this.nestNRadiusToolStripMenuItem,
            this.toolStripSeparator2,
            this.spawnInformationToolStripMenuItem,
            this.showStructuresToolStripMenuItem});
            this.showToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showToolStripMenuItem.Image")));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.CheckOnClick = true;
            this.playerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("playerToolStripMenuItem.Image")));
            this.playerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playerToolStripMenuItem.Text = "Player";
            this.playerToolStripMenuItem.Click += new System.EventHandler(this.showPlayerToolStripMenuItem_Click);
            // 
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignedToolStripMenuItem,
            this.unassignedToolStripMenuItem,
            this.dBRegionsWithoutDdjToolStripMenuItem,
            this.meshBlocksToolStripMenuItem,
            this.meshCellsToolStripMenuItem});
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.regionToolStripMenuItem.Text = "Region";
            // 
            // assignedToolStripMenuItem
            // 
            this.assignedToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.assignedToolStripMenuItem.Checked = true;
            this.assignedToolStripMenuItem.CheckOnClick = true;
            this.assignedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.assignedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("assignedToolStripMenuItem.Image")));
            this.assignedToolStripMenuItem.Name = "assignedToolStripMenuItem";
            this.assignedToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.assignedToolStripMenuItem.Text = "Assigned";
            this.assignedToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.assignedToolStripMenuItem.Click += new System.EventHandler(this.showAssignedRegionsToolStripMenuItem_Click);
            // 
            // unassignedToolStripMenuItem
            // 
            this.unassignedToolStripMenuItem.CheckOnClick = true;
            this.unassignedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("unassignedToolStripMenuItem.Image")));
            this.unassignedToolStripMenuItem.Name = "unassignedToolStripMenuItem";
            this.unassignedToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.unassignedToolStripMenuItem.Text = "Unassigned";
            this.unassignedToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.unassignedToolStripMenuItem.Click += new System.EventHandler(this.showUnassignedRegionsToolStripMenuItem_Click);
            // 
            // dBRegionsWithoutDdjToolStripMenuItem
            // 
            this.dBRegionsWithoutDdjToolStripMenuItem.CheckOnClick = true;
            this.dBRegionsWithoutDdjToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dBRegionsWithoutDdjToolStripMenuItem.Image")));
            this.dBRegionsWithoutDdjToolStripMenuItem.Name = "dBRegionsWithoutDdjToolStripMenuItem";
            this.dBRegionsWithoutDdjToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.dBRegionsWithoutDdjToolStripMenuItem.Text = "DB regions without ddj";
            this.dBRegionsWithoutDdjToolStripMenuItem.Click += new System.EventHandler(this.showDBRegionsWithoutDdjToolStripMenuItem_Click);
            // 
            // meshBlocksToolStripMenuItem
            // 
            this.meshBlocksToolStripMenuItem.CheckOnClick = true;
            this.meshBlocksToolStripMenuItem.Name = "meshBlocksToolStripMenuItem";
            this.meshBlocksToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.meshBlocksToolStripMenuItem.Text = "MeshBlocks";
            this.meshBlocksToolStripMenuItem.Click += new System.EventHandler(this.meshBlocksToolStripMenuItem_Click);
            // 
            // meshCellsToolStripMenuItem
            // 
            this.meshCellsToolStripMenuItem.CheckOnClick = true;
            this.meshCellsToolStripMenuItem.Name = "meshCellsToolStripMenuItem";
            this.meshCellsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.meshCellsToolStripMenuItem.Text = "MeshCells";
            // 
            // monsterToolStripMenuItem
            // 
            this.monsterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commonToolStripMenuItem,
            this.uniqueToolStripMenuItem,
            this.noMsgUniqueToolStripMenuItem});
            this.monsterToolStripMenuItem.Name = "monsterToolStripMenuItem";
            this.monsterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.monsterToolStripMenuItem.Text = "Monster";
            // 
            // commonToolStripMenuItem
            // 
            this.commonToolStripMenuItem.CheckOnClick = true;
            this.commonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("commonToolStripMenuItem.Image")));
            this.commonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.commonToolStripMenuItem.Name = "commonToolStripMenuItem";
            this.commonToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.commonToolStripMenuItem.Text = "Common";
            this.commonToolStripMenuItem.Click += new System.EventHandler(this.showCommonToolStripMenuItem_Click);
            // 
            // uniqueToolStripMenuItem
            // 
            this.uniqueToolStripMenuItem.CheckOnClick = true;
            this.uniqueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uniqueToolStripMenuItem.Image")));
            this.uniqueToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.uniqueToolStripMenuItem.Name = "uniqueToolStripMenuItem";
            this.uniqueToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.uniqueToolStripMenuItem.Text = "Unique";
            this.uniqueToolStripMenuItem.Click += new System.EventHandler(this.showUniqueToolStripMenuItem_Click);
            // 
            // noMsgUniqueToolStripMenuItem
            // 
            this.noMsgUniqueToolStripMenuItem.CheckOnClick = true;
            this.noMsgUniqueToolStripMenuItem.Name = "noMsgUniqueToolStripMenuItem";
            this.noMsgUniqueToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.noMsgUniqueToolStripMenuItem.Text = "No Msg Unique";
            // 
            // nPCToolStripMenuItem
            // 
            this.nPCToolStripMenuItem.CheckOnClick = true;
            this.nPCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nPCToolStripMenuItem.Image")));
            this.nPCToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nPCToolStripMenuItem.Name = "nPCToolStripMenuItem";
            this.nPCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nPCToolStripMenuItem.Text = "NPC";
            this.nPCToolStripMenuItem.Click += new System.EventHandler(this.showNPCToolStripMenuItem_Click);
            // 
            // teleportToolStripMenuItem
            // 
            this.teleportToolStripMenuItem.CheckOnClick = true;
            this.teleportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("teleportToolStripMenuItem.Image")));
            this.teleportToolStripMenuItem.Name = "teleportToolStripMenuItem";
            this.teleportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.teleportToolStripMenuItem.Text = "Teleport";
            this.teleportToolStripMenuItem.Click += new System.EventHandler(this.showTeleportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // nestNGenRadiusToolStripMenuItem
            // 
            this.nestNGenRadiusToolStripMenuItem.BackColor = System.Drawing.Color.Lime;
            this.nestNGenRadiusToolStripMenuItem.CheckOnClick = true;
            this.nestNGenRadiusToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.nestNGenRadiusToolStripMenuItem.Name = "nestNGenRadiusToolStripMenuItem";
            this.nestNGenRadiusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nestNGenRadiusToolStripMenuItem.Text = "Nest nGenRadius";
            this.nestNGenRadiusToolStripMenuItem.Click += new System.EventHandler(this.showNestNGenRadiusToolStripMenuItem_Click);
            // 
            // nestNRadiusToolStripMenuItem
            // 
            this.nestNRadiusToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.nestNRadiusToolStripMenuItem.CheckOnClick = true;
            this.nestNRadiusToolStripMenuItem.Name = "nestNRadiusToolStripMenuItem";
            this.nestNRadiusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nestNRadiusToolStripMenuItem.Text = "Nest nRadius";
            this.nestNRadiusToolStripMenuItem.Click += new System.EventHandler(this.showNestNRadiusToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // spawnInformationToolStripMenuItem
            // 
            this.spawnInformationToolStripMenuItem.CheckOnClick = true;
            this.spawnInformationToolStripMenuItem.Name = "spawnInformationToolStripMenuItem";
            this.spawnInformationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spawnInformationToolStripMenuItem.Text = "Spawn information";
            this.spawnInformationToolStripMenuItem.Click += new System.EventHandler(this.showSpawnInformationToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.continentToolStripMenuItem,
            this.dungeonToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // continentToolStripMenuItem
            // 
            this.continentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("continentToolStripMenuItem.Image")));
            this.continentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.continentToolStripMenuItem.Name = "continentToolStripMenuItem";
            this.continentToolStripMenuItem.Size = new System.Drawing.Size(147, 42);
            this.continentToolStripMenuItem.Text = "Continent";
            // 
            // dungeonToolStripMenuItem
            // 
            this.dungeonToolStripMenuItem.Name = "dungeonToolStripMenuItem";
            this.dungeonToolStripMenuItem.Size = new System.Drawing.Size(147, 42);
            this.dungeonToolStripMenuItem.Text = "Dungeon";
            this.dungeonToolStripMenuItem.Click += new System.EventHandler(this.dungeonToolStripMenuItem_Click);
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
            // showStructuresToolStripMenuItem
            // 
            this.showStructuresToolStripMenuItem.Name = "showStructuresToolStripMenuItem";
            this.showStructuresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showStructuresToolStripMenuItem.Text = "Show Structures";
            this.showStructuresToolStripMenuItem.Click += new System.EventHandler(this.showStructuresToolStripMenuItem_Click);
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
            this.tabPageWorld.ResumeLayout(false);
            this.splitContainer2dViewer.Panel2.ResumeLayout(false);
            this.splitContainer2dViewer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dViewer)).EndInit();
            this.splitContainer2dViewer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageWorld;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2dViewer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonEditSpawn;
        private System.Windows.Forms.ToolStripMenuItem spawnEditorOnClickToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonMapGuide;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonReload;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonView;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unassignedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBRegionsWithoutDdjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meshBlocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meshCellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monsterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noMsgUniqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teleportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem nestNGenRadiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nestNRadiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem spawnInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStructuresToolStripMenuItem;
    }
}
