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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTriggerViewer = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewGameWorlds = new System.Windows.Forms.TreeView();
            this.splitContainerTriggerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerCategory = new System.Windows.Forms.SplitContainer();
            this.splitContainerBindCategory = new System.Windows.Forms.SplitContainer();
            this.treeViewCategory = new System.Windows.Forms.TreeView();
            this.propertyGridTCategory = new System.Windows.Forms.PropertyGrid();
            this.splitContainerTriggerCategoryBindTrigger = new System.Windows.Forms.SplitContainer();
            this.tabPageategory = new System.Windows.Forms.TabPage();
            this.treeViewTrigger = new System.Windows.Forms.TreeView();
            this.propertyGridTrigger = new System.Windows.Forms.PropertyGrid();
            this.treeViewTriggerViewer = new System.Windows.Forms.TreeView();
            this.splitContainerEventCondi = new System.Windows.Forms.SplitContainer();
            this.propertyGridTriggerEvent = new System.Windows.Forms.PropertyGrid();
            this.tabControl1.SuspendLayout();
            this.tabPageTriggerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTriggerMain)).BeginInit();
            this.splitContainerTriggerMain.Panel1.SuspendLayout();
            this.splitContainerTriggerMain.Panel2.SuspendLayout();
            this.splitContainerTriggerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCategory)).BeginInit();
            this.splitContainerCategory.Panel1.SuspendLayout();
            this.splitContainerCategory.Panel2.SuspendLayout();
            this.splitContainerCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBindCategory)).BeginInit();
            this.splitContainerBindCategory.Panel1.SuspendLayout();
            this.splitContainerBindCategory.Panel2.SuspendLayout();
            this.splitContainerBindCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTriggerCategoryBindTrigger)).BeginInit();
            this.splitContainerTriggerCategoryBindTrigger.Panel1.SuspendLayout();
            this.splitContainerTriggerCategoryBindTrigger.Panel2.SuspendLayout();
            this.splitContainerTriggerCategoryBindTrigger.SuspendLayout();
            this.tabPageategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEventCondi)).BeginInit();
            this.splitContainerEventCondi.Panel1.SuspendLayout();
            this.splitContainerEventCondi.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerTriggerMain);
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
            // splitContainerTriggerMain
            // 
            this.splitContainerTriggerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTriggerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTriggerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTriggerMain.Name = "splitContainerTriggerMain";
            // 
            // splitContainerTriggerMain.Panel1
            // 
            this.splitContainerTriggerMain.Panel1.Controls.Add(this.splitContainerCategory);
            // 
            // splitContainerTriggerMain.Panel2
            // 
            this.splitContainerTriggerMain.Panel2.Controls.Add(this.splitContainerEventCondi);
            this.splitContainerTriggerMain.Size = new System.Drawing.Size(614, 489);
            this.splitContainerTriggerMain.SplitterDistance = 297;
            this.splitContainerTriggerMain.TabIndex = 2;
            // 
            // splitContainerCategory
            // 
            this.splitContainerCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCategory.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCategory.Name = "splitContainerCategory";
            // 
            // splitContainerCategory.Panel1
            // 
            this.splitContainerCategory.Panel1.Controls.Add(this.splitContainerBindCategory);
            // 
            // splitContainerCategory.Panel2
            // 
            this.splitContainerCategory.Panel2.Controls.Add(this.splitContainerTriggerCategoryBindTrigger);
            this.splitContainerCategory.Size = new System.Drawing.Size(297, 489);
            this.splitContainerCategory.SplitterDistance = 162;
            this.splitContainerCategory.TabIndex = 0;
            // 
            // splitContainerBindCategory
            // 
            this.splitContainerBindCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBindCategory.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBindCategory.Name = "splitContainerBindCategory";
            this.splitContainerBindCategory.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBindCategory.Panel1
            // 
            this.splitContainerBindCategory.Panel1.Controls.Add(this.treeViewCategory);
            // 
            // splitContainerBindCategory.Panel2
            // 
            this.splitContainerBindCategory.Panel2.Controls.Add(this.propertyGridTCategory);
            this.splitContainerBindCategory.Size = new System.Drawing.Size(158, 485);
            this.splitContainerBindCategory.SplitterDistance = 158;
            this.splitContainerBindCategory.TabIndex = 0;
            // 
            // treeViewCategory
            // 
            this.treeViewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCategory.Location = new System.Drawing.Point(0, 0);
            this.treeViewCategory.Name = "treeViewCategory";
            this.treeViewCategory.Size = new System.Drawing.Size(158, 158);
            this.treeViewCategory.TabIndex = 1;
            this.treeViewCategory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCategory_AfterSelect);
            this.treeViewCategory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCategory_NodeMouseClick);
            // 
            // propertyGridTCategory
            // 
            this.propertyGridTCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridTCategory.HelpVisible = false;
            this.propertyGridTCategory.Location = new System.Drawing.Point(0, 0);
            this.propertyGridTCategory.Name = "propertyGridTCategory";
            this.propertyGridTCategory.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridTCategory.Size = new System.Drawing.Size(158, 323);
            this.propertyGridTCategory.TabIndex = 0;
            // 
            // splitContainerTriggerCategoryBindTrigger
            // 
            this.splitContainerTriggerCategoryBindTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTriggerCategoryBindTrigger.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTriggerCategoryBindTrigger.Name = "splitContainerTriggerCategoryBindTrigger";
            this.splitContainerTriggerCategoryBindTrigger.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTriggerCategoryBindTrigger.Panel1
            // 
            this.splitContainerTriggerCategoryBindTrigger.Panel1.Controls.Add(this.treeViewTrigger);
            // 
            // splitContainerTriggerCategoryBindTrigger.Panel2
            // 
            this.splitContainerTriggerCategoryBindTrigger.Panel2.Controls.Add(this.propertyGridTrigger);
            this.splitContainerTriggerCategoryBindTrigger.Size = new System.Drawing.Size(127, 485);
            this.splitContainerTriggerCategoryBindTrigger.SplitterDistance = 160;
            this.splitContainerTriggerCategoryBindTrigger.TabIndex = 0;
            // 
            // tabPageategory
            // 
            this.tabPageategory.Controls.Add(this.treeViewTriggerViewer);
            this.tabPageategory.Location = new System.Drawing.Point(4, 22);
            this.tabPageategory.Name = "tabPageategory";
            this.tabPageategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageategory.Size = new System.Drawing.Size(845, 495);
            this.tabPageategory.TabIndex = 1;
            this.tabPageategory.Text = "TriggerCategory";
            this.tabPageategory.UseVisualStyleBackColor = true;
            // 
            // treeViewTrigger
            // 
            this.treeViewTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTrigger.Location = new System.Drawing.Point(0, 0);
            this.treeViewTrigger.Name = "treeViewTrigger";
            this.treeViewTrigger.Size = new System.Drawing.Size(127, 160);
            this.treeViewTrigger.TabIndex = 0;
            this.treeViewTrigger.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTrigger_AfterSelect);
            // 
            // propertyGridTrigger
            // 
            this.propertyGridTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridTrigger.HelpVisible = false;
            this.propertyGridTrigger.Location = new System.Drawing.Point(0, 0);
            this.propertyGridTrigger.Name = "propertyGridTrigger";
            this.propertyGridTrigger.Size = new System.Drawing.Size(127, 321);
            this.propertyGridTrigger.TabIndex = 0;
            // 
            // treeViewTriggerViewer
            // 
            this.treeViewTriggerViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTriggerViewer.Location = new System.Drawing.Point(3, 3);
            this.treeViewTriggerViewer.Name = "treeViewTriggerViewer";
            this.treeViewTriggerViewer.Size = new System.Drawing.Size(839, 489);
            this.treeViewTriggerViewer.TabIndex = 0;
            this.treeViewTriggerViewer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTriggerViewer_AfterSelect);
            // 
            // splitContainerEventCondi
            // 
            this.splitContainerEventCondi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerEventCondi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEventCondi.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEventCondi.Name = "splitContainerEventCondi";
            // 
            // splitContainerEventCondi.Panel1
            // 
            this.splitContainerEventCondi.Panel1.Controls.Add(this.propertyGridTriggerEvent);
            this.splitContainerEventCondi.Size = new System.Drawing.Size(313, 489);
            this.splitContainerEventCondi.SplitterDistance = 151;
            this.splitContainerEventCondi.TabIndex = 0;
            // 
            // propertyGridTriggerEvent
            // 
            this.propertyGridTriggerEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridTriggerEvent.HelpVisible = false;
            this.propertyGridTriggerEvent.Location = new System.Drawing.Point(0, 0);
            this.propertyGridTriggerEvent.Name = "propertyGridTriggerEvent";
            this.propertyGridTriggerEvent.Size = new System.Drawing.Size(147, 130);
            this.propertyGridTriggerEvent.TabIndex = 0;
            this.propertyGridTriggerEvent.ToolbarVisible = false;
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
            this.splitContainerTriggerMain.Panel1.ResumeLayout(false);
            this.splitContainerTriggerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTriggerMain)).EndInit();
            this.splitContainerTriggerMain.ResumeLayout(false);
            this.splitContainerCategory.Panel1.ResumeLayout(false);
            this.splitContainerCategory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCategory)).EndInit();
            this.splitContainerCategory.ResumeLayout(false);
            this.splitContainerBindCategory.Panel1.ResumeLayout(false);
            this.splitContainerBindCategory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBindCategory)).EndInit();
            this.splitContainerBindCategory.ResumeLayout(false);
            this.splitContainerTriggerCategoryBindTrigger.Panel1.ResumeLayout(false);
            this.splitContainerTriggerCategoryBindTrigger.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTriggerCategoryBindTrigger)).EndInit();
            this.splitContainerTriggerCategoryBindTrigger.ResumeLayout(false);
            this.tabPageategory.ResumeLayout(false);
            this.splitContainerEventCondi.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEventCondi)).EndInit();
            this.splitContainerEventCondi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTriggerViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewGameWorlds;
        private System.Windows.Forms.TabPage tabPageategory;
        private System.Windows.Forms.PropertyGrid propertyGridTCategory;
        private System.Windows.Forms.TreeView treeViewCategory;
        private System.Windows.Forms.SplitContainer splitContainerTriggerMain;
        private System.Windows.Forms.SplitContainer splitContainerCategory;
        private System.Windows.Forms.SplitContainer splitContainerBindCategory;
        private System.Windows.Forms.SplitContainer splitContainerTriggerCategoryBindTrigger;
        private System.Windows.Forms.TreeView treeViewTrigger;
        private System.Windows.Forms.PropertyGrid propertyGridTrigger;
        private System.Windows.Forms.TreeView treeViewTriggerViewer;
        private System.Windows.Forms.SplitContainer splitContainerEventCondi;
        private System.Windows.Forms.PropertyGrid propertyGridTriggerEvent;
    }
}
