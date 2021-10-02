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
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStripRegionClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCreateSpawn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCoordinateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dViewer)).BeginInit();
            this.splitContainer2dViewer.Panel2.SuspendLayout();
            this.splitContainer2dViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
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
            // splitContainer2dViewer.Panel2
            // 
            this.splitContainer2dViewer.Panel2.Controls.Add(this.trackBarZoom);
            this.splitContainer2dViewer.Panel2.Controls.Add(this.listView1);
            this.splitContainer2dViewer.Size = new System.Drawing.Size(786, 418);
            this.splitContainer2dViewer.SplitterDistance = 523;
            this.splitContainer2dViewer.TabIndex = 1;
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarZoom.LargeChange = 1;
            this.trackBarZoom.Location = new System.Drawing.Point(0, 153);
            this.trackBarZoom.Maximum = 50;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(255, 45);
            this.trackBarZoom.TabIndex = 1;
            this.trackBarZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarZoom.Scroll += new System.EventHandler(this.ZoomChange);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Location = new System.Drawing.Point(0, 198);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(255, 216);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.OnIndexChanged);
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
            this.splitContainer2dViewer.Panel2.ResumeLayout(false);
            this.splitContainer2dViewer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dViewer)).EndInit();
            this.splitContainer2dViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.contextMenuStripRegionClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WorldMap2dPanel worldMap2dPanel1;
        private System.Windows.Forms.SplitContainer splitContainer2dViewer;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRegionClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateSpawn;
        private System.Windows.Forms.ToolStripMenuItem saveCoordinateToolStripMenuItem;
    }
}
