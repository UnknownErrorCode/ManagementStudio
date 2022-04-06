
namespace FileEditor._2dt
{
    partial class File2dtEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(File2dtEditor));
            this.toolStripMainLeft = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen2dt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonViewSelected2dt = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProperty = new System.Windows.Forms.TabPage();
            this.splitContainer2dt = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPageViewer = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStripButtonLoadResinfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainLeft.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dt)).BeginInit();
            this.splitContainer2dt.Panel1.SuspendLayout();
            this.splitContainer2dt.SuspendLayout();
            this.tabPageViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMainLeft
            // 
            this.toolStripMainLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripMainLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen2dt,
            this.toolStripButtonViewSelected2dt,
            this.toolStripButtonLoadResinfo});
            this.toolStripMainLeft.Location = new System.Drawing.Point(0, 0);
            this.toolStripMainLeft.Name = "toolStripMainLeft";
            this.toolStripMainLeft.Size = new System.Drawing.Size(33, 372);
            this.toolStripMainLeft.TabIndex = 5;
            this.toolStripMainLeft.Text = "toolStrip1";
            // 
            // toolStripButtonOpen2dt
            // 
            this.toolStripButtonOpen2dt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen2dt.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen2dt.Image")));
            this.toolStripButtonOpen2dt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOpen2dt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen2dt.Name = "toolStripButtonOpen2dt";
            this.toolStripButtonOpen2dt.Size = new System.Drawing.Size(30, 32);
            this.toolStripButtonOpen2dt.Text = "Open 2dt";
            this.toolStripButtonOpen2dt.ToolTipText = "Open a 2dt file.";
            this.toolStripButtonOpen2dt.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonViewSelected2dt
            // 
            this.toolStripButtonViewSelected2dt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonViewSelected2dt.Enabled = false;
            this.toolStripButtonViewSelected2dt.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonViewSelected2dt.Image")));
            this.toolStripButtonViewSelected2dt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewSelected2dt.Name = "toolStripButtonViewSelected2dt";
            this.toolStripButtonViewSelected2dt.Size = new System.Drawing.Size(30, 20);
            this.toolStripButtonViewSelected2dt.Text = "Open 2dt view";
            this.toolStripButtonViewSelected2dt.ToolTipText = "View opened 2dt file.";
            this.toolStripButtonViewSelected2dt.Click += new System.EventHandler(this.toolStripButtonViewSelected2dt_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProperty);
            this.tabControl1.Controls.Add(this.tabPageViewer);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(33, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 372);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageProperty
            // 
            this.tabPageProperty.Controls.Add(this.splitContainer2dt);
            this.tabPageProperty.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperty.Name = "tabPageProperty";
            this.tabPageProperty.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperty.Size = new System.Drawing.Size(729, 346);
            this.tabPageProperty.TabIndex = 0;
            this.tabPageProperty.Text = "Properties";
            this.tabPageProperty.UseVisualStyleBackColor = true;
            // 
            // splitContainer2dt
            // 
            this.splitContainer2dt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2dt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2dt.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2dt.Name = "splitContainer2dt";
            // 
            // splitContainer2dt.Panel1
            // 
            this.splitContainer2dt.Panel1.Controls.Add(this.propertyGrid1);
            // 
            // splitContainer2dt.Panel2
            // 
            this.splitContainer2dt.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2dt_Panel2_Paint);
            this.splitContainer2dt.Size = new System.Drawing.Size(723, 340);
            this.splitContainer2dt.SplitterDistance = 240;
            this.splitContainer2dt.TabIndex = 5;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.CategorySplitterColor = System.Drawing.SystemColors.ControlDarkDark;
            this.propertyGrid1.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid1.HelpBackColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGrid1.HelpForeColor = System.Drawing.Color.Black;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(236, 131);
            this.propertyGrid1.TabIndex = 3;
            this.propertyGrid1.ViewBackColor = System.Drawing.Color.DimGray;
            this.propertyGrid1.ViewForeColor = System.Drawing.Color.Black;
            // 
            // tabPageViewer
            // 
            this.tabPageViewer.Controls.Add(this.listView1);
            this.tabPageViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewer.Name = "tabPageViewer";
            this.tabPageViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViewer.Size = new System.Drawing.Size(729, 346);
            this.tabPageViewer.TabIndex = 1;
            this.tabPageViewer.Text = "View";
            this.tabPageViewer.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(272, 228);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // toolStripButtonLoadResinfo
            // 
            this.toolStripButtonLoadResinfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadResinfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadResinfo.Image")));
            this.toolStripButtonLoadResinfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadResinfo.Name = "toolStripButtonLoadResinfo";
            this.toolStripButtonLoadResinfo.Size = new System.Drawing.Size(30, 20);
            this.toolStripButtonLoadResinfo.Text = "LoadResinfo";
            this.toolStripButtonLoadResinfo.Click += new System.EventHandler(this.toolStripButtonLoadResinfo_Click);
            // 
            // File2dtEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStripMainLeft);
            this.Name = "File2dtEditor";
            this.Size = new System.Drawing.Size(770, 372);
            this.Load += new System.EventHandler(this.Loading);
            this.toolStripMainLeft.ResumeLayout(false);
            this.toolStripMainLeft.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageProperty.ResumeLayout(false);
            this.splitContainer2dt.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2dt)).EndInit();
            this.splitContainer2dt.ResumeLayout(false);
            this.tabPageViewer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMainLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen2dt;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewSelected2dt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProperty;
        private System.Windows.Forms.SplitContainer splitContainer2dt;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabPageViewer;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadResinfo;
    }
}
