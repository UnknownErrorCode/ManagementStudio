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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriggerEditorControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTriggerViewer = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vSroButtonList1 = new PluginFramework.BasicControls.vSroButtonList();
            this.treeViewGameWorlds = new System.Windows.Forms.TreeView();
            this.treeViewCategory = new System.Windows.Forms.TreeView();
            this.propertyGridTCategory = new System.Windows.Forms.PropertyGrid();
            this.tabPageategory = new System.Windows.Forms.TabPage();
            this.splitContainerTriggerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerCategory = new System.Windows.Forms.SplitContainer();
            this.splitContainerBindCategory = new System.Windows.Forms.SplitContainer();
            this.splitContainerTriggerCategoryBindTrigger = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabPageTriggerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTriggerMain)).BeginInit();
            this.splitContainerTriggerMain.Panel1.SuspendLayout();
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
            this.splitContainerTriggerCategoryBindTrigger.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.vSroButtonList1);
            this.splitContainer1.Panel1.Controls.Add(this.treeViewGameWorlds);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerTriggerMain);
            this.splitContainer1.Size = new System.Drawing.Size(839, 489);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 1;
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
            this.vSroButtonList1.TabIndex = 1;
            this.vSroButtonList1.OnIndCh += new System.EventHandler(this.vSroButtonList1_OnIndCh);
            // 
            // treeViewGameWorlds
            // 
            this.treeViewGameWorlds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewGameWorlds.Location = new System.Drawing.Point(0, 0);
            this.treeViewGameWorlds.Name = "treeViewGameWorlds";
            this.treeViewGameWorlds.Size = new System.Drawing.Size(217, 485);
            this.treeViewGameWorlds.TabIndex = 0;
            // 
            // treeViewCategory
            // 
            this.treeViewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCategory.Location = new System.Drawing.Point(0, 0);
            this.treeViewCategory.Name = "treeViewCategory";
            this.treeViewCategory.Size = new System.Drawing.Size(149, 132);
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
            this.propertyGridTCategory.Size = new System.Drawing.Size(149, 269);
            this.propertyGridTCategory.TabIndex = 0;
            // 
            // tabPageategory
            // 
            this.tabPageategory.Location = new System.Drawing.Point(4, 22);
            this.tabPageategory.Name = "tabPageategory";
            this.tabPageategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageategory.Size = new System.Drawing.Size(845, 495);
            this.tabPageategory.TabIndex = 1;
            this.tabPageategory.Text = "TriggerCategory";
            this.tabPageategory.UseVisualStyleBackColor = true;
            // 
            // splitContainerTriggerMain
            // 
            this.splitContainerTriggerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTriggerMain.Location = new System.Drawing.Point(3, 25);
            this.splitContainerTriggerMain.Name = "splitContainerTriggerMain";
            // 
            // splitContainerTriggerMain.Panel1
            // 
            this.splitContainerTriggerMain.Panel1.Controls.Add(this.splitContainerCategory);
            this.splitContainerTriggerMain.Size = new System.Drawing.Size(572, 409);
            this.splitContainerTriggerMain.SplitterDistance = 277;
            this.splitContainerTriggerMain.TabIndex = 2;
            // 
            // splitContainerCategory
            // 
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
            this.splitContainerCategory.Size = new System.Drawing.Size(273, 405);
            this.splitContainerCategory.SplitterDistance = 149;
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
            this.splitContainerBindCategory.Size = new System.Drawing.Size(149, 405);
            this.splitContainerBindCategory.SplitterDistance = 132;
            this.splitContainerBindCategory.TabIndex = 0;
            // 
            // splitContainerTriggerCategoryBindTrigger
            // 
            this.splitContainerTriggerCategoryBindTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTriggerCategoryBindTrigger.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTriggerCategoryBindTrigger.Name = "splitContainerTriggerCategoryBindTrigger";
            this.splitContainerTriggerCategoryBindTrigger.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerTriggerCategoryBindTrigger.Size = new System.Drawing.Size(120, 405);
            this.splitContainerTriggerCategoryBindTrigger.SplitterDistance = 166;
            this.splitContainerTriggerCategoryBindTrigger.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTriggerCategoryBindTrigger)).EndInit();
            this.splitContainerTriggerCategoryBindTrigger.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTriggerViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PluginFramework.BasicControls.vSroButtonList vSroButtonList1;
        private System.Windows.Forms.TreeView treeViewGameWorlds;
        private System.Windows.Forms.TabPage tabPageategory;
        private System.Windows.Forms.PropertyGrid propertyGridTCategory;
        private System.Windows.Forms.TreeView treeViewCategory;
        private System.Windows.Forms.SplitContainer splitContainerTriggerMain;
        private System.Windows.Forms.SplitContainer splitContainerCategory;
        private System.Windows.Forms.SplitContainer splitContainerBindCategory;
        private System.Windows.Forms.SplitContainer splitContainerTriggerCategoryBindTrigger;
    }
}
