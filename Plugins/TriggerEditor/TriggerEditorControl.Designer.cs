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
            this.vSroButtonList1 = new ServerFrameworkRes.BasicControls.vSroButtonList();
            this.treeViewGameWorlds = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageTriggerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTriggerViewer);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            // 
            // treeViewGameWorlds
            // 
            this.treeViewGameWorlds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewGameWorlds.Location = new System.Drawing.Point(0, 0);
            this.treeViewGameWorlds.Name = "treeViewGameWorlds";
            this.treeViewGameWorlds.Size = new System.Drawing.Size(217, 485);
            this.treeViewGameWorlds.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(845, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTriggerViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ServerFrameworkRes.BasicControls.vSroButtonList vSroButtonList1;
        private System.Windows.Forms.TreeView treeViewGameWorlds;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
