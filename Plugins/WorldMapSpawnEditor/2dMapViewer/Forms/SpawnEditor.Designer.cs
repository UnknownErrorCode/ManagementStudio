
namespace WorldMapSpawnEditor._2dMapViewer.Forms
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
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(3, 23);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid1.TabIndex = 0;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Location = new System.Drawing.Point(197, 23);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid2.TabIndex = 1;
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Location = new System.Drawing.Point(391, 23);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid3.TabIndex = 2;
            // 
            // propertyGrid4
            // 
            this.propertyGrid4.Location = new System.Drawing.Point(585, 23);
            this.propertyGrid4.Name = "propertyGrid4";
            this.propertyGrid4.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid4.TabIndex = 3;
            // 
            // propertyGrid5
            // 
            this.propertyGrid5.Location = new System.Drawing.Point(779, 23);
            this.propertyGrid5.Name = "propertyGrid5";
            this.propertyGrid5.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid5.TabIndex = 4;
            // 
            // SpawnEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 450);
            this.Controls.Add(this.propertyGrid5);
            this.Controls.Add(this.propertyGrid4);
            this.Controls.Add(this.propertyGrid3);
            this.Controls.Add(this.propertyGrid2);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "SpawnEditor";
            this.Text = "SpawnEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.PropertyGrid propertyGrid3;
        private System.Windows.Forms.PropertyGrid propertyGrid4;
        private System.Windows.Forms.PropertyGrid propertyGrid5;
    }
}