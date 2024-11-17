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
            this.tabPageategory = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeViewTriggerViewer = new System.Windows.Forms.TreeView();
            this.contextMenuStripTriggerEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListTriggerEditor = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabPageTriggerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStripTriggerEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer3.Size = new System.Drawing.Size(839, 489);
            this.splitContainer3.SplitterDistance = 560;
            this.splitContainer3.TabIndex = 1;
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
            this.treeViewTriggerViewer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTriggerViewer_NodeMouseClick);
            // 
            // contextMenuStripTriggerEditor
            // 
            this.contextMenuStripTriggerEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.unlinkToolStripMenuItem,
            this.linkToolStripMenuItem,
            this.addToolStripMenuItem});
            this.contextMenuStripTriggerEditor.Name = "contextMenuStripTriggerEditor";
            this.contextMenuStripTriggerEditor.Size = new System.Drawing.Size(109, 92);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // unlinkToolStripMenuItem
            // 
            this.unlinkToolStripMenuItem.Name = "unlinkToolStripMenuItem";
            this.unlinkToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.unlinkToolStripMenuItem.Text = "Unlink";
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            this.linkToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.linkToolStripMenuItem.Text = "Link";
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
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(275, 489);
            this.propertyGrid1.TabIndex = 0;
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.addToolStripMenuItem.Text = "Add";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPageategory.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStripTriggerEditor.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem unlinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}
