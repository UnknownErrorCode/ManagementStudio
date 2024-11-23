namespace TriggerEditor
{
    partial class TriggerEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriggerEditorControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTriggerViewer = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewGameWorlds = new System.Windows.Forms.TreeView();
            this.splitContainerEditor = new System.Windows.Forms.SplitContainer();
            this.propertyGridStructEditor = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageategory = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeViewTriggerViewer = new System.Windows.Forms.TreeView();
            this.contextMenuStripTriggerEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListTriggerEditor = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPageTriggerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditor)).BeginInit();
            this.splitContainerEditor.Panel2.SuspendLayout();
            this.splitContainerEditor.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPageategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStripTriggerEditor.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTriggerViewer);
            this.tabControl1.Controls.Add(this.tabPageategory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(853, 521);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTriggerViewer
            // 
            this.tabPageTriggerViewer.Controls.Add(this.splitContainer1);
            this.tabPageTriggerViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageTriggerViewer.Name = "tabPageTriggerViewer";
            this.tabPageTriggerViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTriggerViewer.Size = new System.Drawing.Size(845, 495);
            this.tabPageTriggerViewer.TabIndex = 0;
            this.tabPageTriggerViewer.Text = "GameWorld View";
            this.tabPageTriggerViewer.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewGameWorlds);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerEditor);
            this.splitContainer1.Size = new System.Drawing.Size(839, 489);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeViewGameWorlds
            // 
            this.treeViewGameWorlds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewGameWorlds.HotTracking = true;
            this.treeViewGameWorlds.Location = new System.Drawing.Point(0, 0);
            this.treeViewGameWorlds.Name = "treeViewGameWorlds";
            this.treeViewGameWorlds.Size = new System.Drawing.Size(217, 485);
            this.treeViewGameWorlds.TabIndex = 0;
            this.treeViewGameWorlds.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewGameWorlds_AfterSelect);
            // 
            // splitContainerEditor
            // 
            this.splitContainerEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditor.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEditor.Name = "splitContainerEditor";
            // 
            // splitContainerEditor.Panel2
            // 
            this.splitContainerEditor.Panel2.Controls.Add(this.propertyGridStructEditor);
            this.splitContainerEditor.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainerEditor.Size = new System.Drawing.Size(614, 489);
            this.splitContainerEditor.SplitterDistance = 370;
            this.splitContainerEditor.TabIndex = 0;
            // 
            // propertyGridStructEditor
            // 
            this.propertyGridStructEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridStructEditor.Location = new System.Drawing.Point(0, 24);
            this.propertyGridStructEditor.Name = "propertyGridStructEditor";
            this.propertyGridStructEditor.Size = new System.Drawing.Size(236, 461);
            this.propertyGridStructEditor.TabIndex = 1;
            this.propertyGridStructEditor.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridStructEditor_PropertyValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(236, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // tabPageategory
            // 
            this.tabPageategory.Controls.Add(this.splitContainer3);
            this.tabPageategory.Location = new System.Drawing.Point(4, 22);
            this.tabPageategory.Name = "tabPageategory";
            this.tabPageategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageategory.Size = new System.Drawing.Size(845, 495);
            this.tabPageategory.TabIndex = 1;
            this.tabPageategory.Text = "TriggerCategory";
            this.tabPageategory.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer3.Panel2.Controls.Add(this.menuStrip2);
            this.splitContainer3.Size = new System.Drawing.Size(839, 489);
            this.splitContainer3.SplitterDistance = 560;
            this.splitContainer3.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeViewTriggerViewer);
            this.splitContainer2.Size = new System.Drawing.Size(560, 489);
            this.splitContainer2.SplitterDistance = 262;
            this.splitContainer2.TabIndex = 1;
            // 
            // treeViewTriggerViewer
            // 
            this.treeViewTriggerViewer.ContextMenuStrip = this.contextMenuStripTriggerEditor;
            this.treeViewTriggerViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTriggerViewer.ImageIndex = 0;
            this.treeViewTriggerViewer.ImageList = this.imageListTriggerEditor;
            this.treeViewTriggerViewer.Location = new System.Drawing.Point(0, 0);
            this.treeViewTriggerViewer.Name = "treeViewTriggerViewer";
            this.treeViewTriggerViewer.SelectedImageIndex = 0;
            this.treeViewTriggerViewer.Size = new System.Drawing.Size(262, 489);
            this.treeViewTriggerViewer.TabIndex = 0;
            this.treeViewTriggerViewer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTriggerViewer_AfterSelect);
            // 
            // contextMenuStripTriggerEditor
            // 
            this.contextMenuStripTriggerEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.linkToolStripMenuItem,
            this.addToolStripMenuItem});
            this.contextMenuStripTriggerEditor.Name = "contextMenuStripTriggerEditor";
            this.contextMenuStripTriggerEditor.Size = new System.Drawing.Size(181, 114);
            this.contextMenuStripTriggerEditor.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripTriggerEditor_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.CheckOnClick = true;
            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            this.linkToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.linkToolStripMenuItem.Text = "Show link nodes";
            this.linkToolStripMenuItem.CheckedChanged += new System.EventHandler(this.linkToolStripMenuItem_CheckedChanged);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // imageListTriggerEditor
            // 
            this.imageListTriggerEditor.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTriggerEditor.ImageStream")));
            this.imageListTriggerEditor.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTriggerEditor.Images.SetKeyName(0, "erdkugel.png");
            this.imageListTriggerEditor.Images.SetKeyName(1, "e-book.png");
            this.imageListTriggerEditor.Images.SetKeyName(2, "blitz.png");
            this.imageListTriggerEditor.Images.SetKeyName(3, "trendthema.png");
            this.imageListTriggerEditor.Images.SetKeyName(4, "datentransfer.png");
            this.imageListTriggerEditor.Images.SetKeyName(5, "fallen.png");
            this.imageListTriggerEditor.Images.SetKeyName(6, "fall.png");
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 24);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(275, 465);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(275, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Enabled = false;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // TriggerEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TriggerEditorControl";
            this.Size = new System.Drawing.Size(853, 521);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTriggerViewer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerEditor.Panel2.ResumeLayout(false);
            this.splitContainerEditor.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditor)).EndInit();
            this.splitContainerEditor.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageategory.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStripTriggerEditor.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTriggerViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewGameWorlds;
        private System.Windows.Forms.TabPage tabPageategory;
        private System.Windows.Forms.TreeView treeViewTriggerViewer;
        private System.Windows.Forms.ImageList imageListTriggerEditor;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTriggerEditor;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainerEditor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGridStructEditor;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
    }
}
