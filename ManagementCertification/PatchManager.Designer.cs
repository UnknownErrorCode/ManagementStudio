
namespace ManagementCertification
{
    partial class PatchManager
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
            this.dataGridViewPatchHistory = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileSize = new System.Windows.Forms.Label();
            this.FileCount = new System.Windows.Forms.Label();
            this.buttonCancelPatch = new System.Windows.Forms.Button();
            this.buttonPatchShownFiles = new System.Windows.Forms.Button();
            this.buttonPreparePatch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatchHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPatchHistory
            // 
            this.dataGridViewPatchHistory.AllowUserToAddRows = false;
            this.dataGridViewPatchHistory.AllowUserToDeleteRows = false;
            this.dataGridViewPatchHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatchHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewPatchHistory.Location = new System.Drawing.Point(0, 273);
            this.dataGridViewPatchHistory.Name = "dataGridViewPatchHistory";
            this.dataGridViewPatchHistory.ReadOnly = true;
            this.dataGridViewPatchHistory.Size = new System.Drawing.Size(800, 177);
            this.dataGridViewPatchHistory.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FileSize);
            this.groupBox1.Controls.Add(this.FileCount);
            this.groupBox1.Location = new System.Drawing.Point(10, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 89);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patch Information";
            // 
            // FileSize
            // 
            this.FileSize.AutoSize = true;
            this.FileSize.Location = new System.Drawing.Point(6, 46);
            this.FileSize.Name = "FileSize";
            this.FileSize.Size = new System.Drawing.Size(57, 13);
            this.FileSize.TabIndex = 1;
            this.FileSize.Text = "patch Size";
            // 
            // FileCount
            // 
            this.FileCount.AutoSize = true;
            this.FileCount.Location = new System.Drawing.Point(6, 23);
            this.FileCount.Name = "FileCount";
            this.FileCount.Size = new System.Drawing.Size(54, 13);
            this.FileCount.TabIndex = 0;
            this.FileCount.Text = "File Count";
            // 
            // buttonCancelPatch
            // 
            this.buttonCancelPatch.Enabled = false;
            this.buttonCancelPatch.Location = new System.Drawing.Point(285, 75);
            this.buttonCancelPatch.Name = "buttonCancelPatch";
            this.buttonCancelPatch.Size = new System.Drawing.Size(120, 27);
            this.buttonCancelPatch.TabIndex = 13;
            this.buttonCancelPatch.Text = "Cancel Patch";
            this.buttonCancelPatch.UseVisualStyleBackColor = true;
            this.buttonCancelPatch.Click += new System.EventHandler(this.buttonCancelPatch_Click);
            // 
            // buttonPatchShownFiles
            // 
            this.buttonPatchShownFiles.Enabled = false;
            this.buttonPatchShownFiles.Location = new System.Drawing.Point(285, 108);
            this.buttonPatchShownFiles.Name = "buttonPatchShownFiles";
            this.buttonPatchShownFiles.Size = new System.Drawing.Size(120, 27);
            this.buttonPatchShownFiles.TabIndex = 12;
            this.buttonPatchShownFiles.Text = "Patch shown Files";
            this.buttonPatchShownFiles.UseVisualStyleBackColor = true;
            this.buttonPatchShownFiles.Click += new System.EventHandler(this.buttonPatchShownFiles_Click);
            // 
            // buttonPreparePatch
            // 
            this.buttonPreparePatch.Location = new System.Drawing.Point(285, 42);
            this.buttonPreparePatch.Name = "buttonPreparePatch";
            this.buttonPreparePatch.Size = new System.Drawing.Size(120, 27);
            this.buttonPreparePatch.TabIndex = 11;
            this.buttonPreparePatch.Text = "Prepare Patch";
            this.buttonPreparePatch.UseVisualStyleBackColor = true;
            this.buttonPreparePatch.Click += new System.EventHandler(this.buttonPreparePatch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Next patch:";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(410, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(390, 273);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // PatchManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancelPatch);
            this.Controls.Add(this.buttonPatchShownFiles);
            this.Controls.Add(this.buttonPreparePatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridViewPatchHistory);
            this.Name = "PatchManager";
            this.Text = "PatchManager";
            this.Load += new System.EventHandler(this.PatchManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatchHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPatchHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label FileSize;
        private System.Windows.Forms.Label FileCount;
        private System.Windows.Forms.Button buttonCancelPatch;
        private System.Windows.Forms.Button buttonPatchShownFiles;
        private System.Windows.Forms.Button buttonPreparePatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
    }
}