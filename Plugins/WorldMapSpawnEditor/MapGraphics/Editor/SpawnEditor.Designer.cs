
namespace WorldMapSpawnEditor.MapGraphics
{
    partial class SpawnEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid4 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid5 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonShowUpdateNest = new System.Windows.Forms.Button();
            this.buttonSelectHive = new System.Windows.Forms.Button();
            this.buttonShowUpdateHive = new System.Windows.Forms.Button();
            this.buttonSelectTactics = new System.Windows.Forms.Button();
            this.buttonShowUpdateTactics = new System.Windows.Forms.Button();
            this.buttonselectcommon = new System.Windows.Forms.Button();
            this.buttonShowUpdateCommon = new System.Windows.Forms.Button();
            this.buttonShowUpdateChar = new System.Windows.Forms.Button();
            this.buttonSelectNewPosition = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagehive = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPagetactics = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabPagecommon = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabPageChar = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabPagehive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPagetactics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPagecommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPageChar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(3, 23);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeNestValue);
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(336, 364);
            this.propertyGrid2.TabIndex = 3;
            this.propertyGrid2.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeHive);
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid3.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(336, 364);
            this.propertyGrid3.TabIndex = 6;
            this.propertyGrid3.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeTacticsValue);
            // 
            // propertyGrid4
            // 
            this.propertyGrid4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid4.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid4.Name = "propertyGrid4";
            this.propertyGrid4.Size = new System.Drawing.Size(336, 364);
            this.propertyGrid4.TabIndex = 9;
            this.propertyGrid4.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeObjCommonValue);
            // 
            // propertyGrid5
            // 
            this.propertyGrid5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid5.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid5.Name = "propertyGrid5";
            this.propertyGrid5.Size = new System.Drawing.Size(336, 364);
            this.propertyGrid5.TabIndex = 12;
            this.propertyGrid5.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeObjChar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tab_RefNest";
            // 
            // buttonShowUpdateNest
            // 
            this.buttonShowUpdateNest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowUpdateNest.Location = new System.Drawing.Point(3, 371);
            this.buttonShowUpdateNest.Name = "buttonShowUpdateNest";
            this.buttonShowUpdateNest.Size = new System.Drawing.Size(91, 23);
            this.buttonShowUpdateNest.TabIndex = 1;
            this.buttonShowUpdateNest.Text = "Show Update";
            this.buttonShowUpdateNest.UseVisualStyleBackColor = true;
            this.buttonShowUpdateNest.Click += new System.EventHandler(this.ShowNestUpdate);
            // 
            // buttonSelectHive
            // 
            this.buttonSelectHive.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSelectHive.Location = new System.Drawing.Point(245, 0);
            this.buttonSelectHive.Name = "buttonSelectHive";
            this.buttonSelectHive.Size = new System.Drawing.Size(91, 25);
            this.buttonSelectHive.TabIndex = 5;
            this.buttonSelectHive.Text = "Select Hive";
            this.buttonSelectHive.UseVisualStyleBackColor = true;
            this.buttonSelectHive.Click += new System.EventHandler(this.buttonSelectHive_Click);
            // 
            // buttonShowUpdateHive
            // 
            this.buttonShowUpdateHive.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonShowUpdateHive.Location = new System.Drawing.Point(0, 0);
            this.buttonShowUpdateHive.Name = "buttonShowUpdateHive";
            this.buttonShowUpdateHive.Size = new System.Drawing.Size(91, 25);
            this.buttonShowUpdateHive.TabIndex = 4;
            this.buttonShowUpdateHive.Text = "Show Update";
            this.buttonShowUpdateHive.UseVisualStyleBackColor = true;
            this.buttonShowUpdateHive.Click += new System.EventHandler(this.ShowUpdateHive);
            // 
            // buttonSelectTactics
            // 
            this.buttonSelectTactics.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSelectTactics.Location = new System.Drawing.Point(245, 0);
            this.buttonSelectTactics.Name = "buttonSelectTactics";
            this.buttonSelectTactics.Size = new System.Drawing.Size(91, 25);
            this.buttonSelectTactics.TabIndex = 8;
            this.buttonSelectTactics.Text = "Select tactics";
            this.buttonSelectTactics.UseVisualStyleBackColor = true;
            this.buttonSelectTactics.Click += new System.EventHandler(this.buttonSelectTactics_Click);
            // 
            // buttonShowUpdateTactics
            // 
            this.buttonShowUpdateTactics.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonShowUpdateTactics.Location = new System.Drawing.Point(0, 0);
            this.buttonShowUpdateTactics.Name = "buttonShowUpdateTactics";
            this.buttonShowUpdateTactics.Size = new System.Drawing.Size(91, 25);
            this.buttonShowUpdateTactics.TabIndex = 7;
            this.buttonShowUpdateTactics.Text = "Show Update";
            this.buttonShowUpdateTactics.UseVisualStyleBackColor = true;
            this.buttonShowUpdateTactics.Click += new System.EventHandler(this.ShowUpdateTactics);
            // 
            // buttonselectcommon
            // 
            this.buttonselectcommon.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonselectcommon.Location = new System.Drawing.Point(245, 0);
            this.buttonselectcommon.Name = "buttonselectcommon";
            this.buttonselectcommon.Size = new System.Drawing.Size(91, 25);
            this.buttonselectcommon.TabIndex = 11;
            this.buttonselectcommon.Text = "Select dwObjID";
            this.buttonselectcommon.UseVisualStyleBackColor = true;
            this.buttonselectcommon.Click += new System.EventHandler(this.buttonselectcommon_Click);
            // 
            // buttonShowUpdateCommon
            // 
            this.buttonShowUpdateCommon.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonShowUpdateCommon.Location = new System.Drawing.Point(0, 0);
            this.buttonShowUpdateCommon.Name = "buttonShowUpdateCommon";
            this.buttonShowUpdateCommon.Size = new System.Drawing.Size(91, 25);
            this.buttonShowUpdateCommon.TabIndex = 10;
            this.buttonShowUpdateCommon.Text = "Show Update";
            this.buttonShowUpdateCommon.UseVisualStyleBackColor = true;
            this.buttonShowUpdateCommon.Click += new System.EventHandler(this.ShowUpdateCommon);
            // 
            // buttonShowUpdateChar
            // 
            this.buttonShowUpdateChar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowUpdateChar.Location = new System.Drawing.Point(0, 0);
            this.buttonShowUpdateChar.Name = "buttonShowUpdateChar";
            this.buttonShowUpdateChar.Size = new System.Drawing.Size(336, 25);
            this.buttonShowUpdateChar.TabIndex = 13;
            this.buttonShowUpdateChar.Text = "Show Update";
            this.buttonShowUpdateChar.UseVisualStyleBackColor = true;
            this.buttonShowUpdateChar.Click += new System.EventHandler(this.ShowUpdateChar);
            // 
            // buttonSelectNewPosition
            // 
            this.buttonSelectNewPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectNewPosition.Location = new System.Drawing.Point(100, 371);
            this.buttonSelectNewPosition.Name = "buttonSelectNewPosition";
            this.buttonSelectNewPosition.Size = new System.Drawing.Size(91, 23);
            this.buttonSelectNewPosition.TabIndex = 20;
            this.buttonSelectNewPosition.Text = "Select Position";
            this.buttonSelectNewPosition.UseVisualStyleBackColor = true;
            this.buttonSelectNewPosition.Click += new System.EventHandler(this.buttonSelectNewPosition_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagehive);
            this.tabControl1.Controls.Add(this.tabPagetactics);
            this.tabControl1.Controls.Add(this.tabPagecommon);
            this.tabControl1.Controls.Add(this.tabPageChar);
            this.tabControl1.Location = new System.Drawing.Point(214, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(354, 433);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPagehive
            // 
            this.tabPagehive.Controls.Add(this.splitContainer1);
            this.tabPagehive.Location = new System.Drawing.Point(4, 22);
            this.tabPagehive.Name = "tabPagehive";
            this.tabPagehive.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagehive.Size = new System.Drawing.Size(346, 407);
            this.tabPagehive.TabIndex = 0;
            this.tabPagehive.Text = "Tab_RefHive";
            this.tabPagehive.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propertyGrid2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonShowUpdateHive);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSelectHive);
            this.splitContainer1.Size = new System.Drawing.Size(340, 401);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabPagetactics
            // 
            this.tabPagetactics.Controls.Add(this.splitContainer2);
            this.tabPagetactics.Location = new System.Drawing.Point(4, 22);
            this.tabPagetactics.Name = "tabPagetactics";
            this.tabPagetactics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagetactics.Size = new System.Drawing.Size(346, 407);
            this.tabPagetactics.TabIndex = 1;
            this.tabPagetactics.Text = "Tab_RefTactics";
            this.tabPagetactics.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.propertyGrid3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonSelectTactics);
            this.splitContainer2.Panel2.Controls.Add(this.buttonShowUpdateTactics);
            this.splitContainer2.Size = new System.Drawing.Size(340, 401);
            this.splitContainer2.SplitterDistance = 368;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabPagecommon
            // 
            this.tabPagecommon.Controls.Add(this.splitContainer3);
            this.tabPagecommon.Location = new System.Drawing.Point(4, 22);
            this.tabPagecommon.Name = "tabPagecommon";
            this.tabPagecommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagecommon.Size = new System.Drawing.Size(346, 407);
            this.tabPagecommon.TabIndex = 2;
            this.tabPagecommon.Text = "RefObjCommon";
            this.tabPagecommon.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.propertyGrid4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.buttonselectcommon);
            this.splitContainer3.Panel2.Controls.Add(this.buttonShowUpdateCommon);
            this.splitContainer3.Size = new System.Drawing.Size(340, 401);
            this.splitContainer3.SplitterDistance = 368;
            this.splitContainer3.TabIndex = 1;
            // 
            // tabPageChar
            // 
            this.tabPageChar.Controls.Add(this.splitContainer4);
            this.tabPageChar.Location = new System.Drawing.Point(4, 22);
            this.tabPageChar.Name = "tabPageChar";
            this.tabPageChar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChar.Size = new System.Drawing.Size(346, 407);
            this.tabPageChar.TabIndex = 3;
            this.tabPageChar.Text = "_RefObjChar";
            this.tabPageChar.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.propertyGrid5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.buttonShowUpdateChar);
            this.splitContainer4.Size = new System.Drawing.Size(340, 401);
            this.splitContainer4.SplitterDistance = 368;
            this.splitContainer4.TabIndex = 1;
            // 
            // SpawnEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonSelectNewPosition);
            this.Controls.Add(this.buttonShowUpdateNest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "SpawnEditor";
            this.Text = "SpawnEditor";
            this.Load += new System.EventHandler(this.SpawnEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPagehive.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPagetactics.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPagecommon.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabPageChar.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.PropertyGrid propertyGrid3;
        private System.Windows.Forms.PropertyGrid propertyGrid4;
        private System.Windows.Forms.PropertyGrid propertyGrid5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonShowUpdateNest;
        private System.Windows.Forms.Button buttonSelectHive;
        private System.Windows.Forms.Button buttonShowUpdateHive;
        private System.Windows.Forms.Button buttonSelectTactics;
        private System.Windows.Forms.Button buttonShowUpdateTactics;
        private System.Windows.Forms.Button buttonselectcommon;
        private System.Windows.Forms.Button buttonShowUpdateCommon;
        private System.Windows.Forms.Button buttonShowUpdateChar;
        private System.Windows.Forms.Button buttonSelectNewPosition;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagehive;
        private System.Windows.Forms.TabPage tabPagetactics;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabPage tabPagecommon;
        private System.Windows.Forms.TabPage tabPageChar;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}