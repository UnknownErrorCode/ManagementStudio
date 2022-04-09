namespace ManagementFramework.BasicControls
{
    partial class vSroCheckBox
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vSroCheckBox));
            this.buttonCheckBox = new System.Windows.Forms.Button();
            this.imageListCheckBox = new System.Windows.Forms.ImageList(this.components);
            this.labelCheckBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCheckBox
            // 
            this.buttonCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCheckBox.ForeColor = System.Drawing.Color.Transparent;
            this.buttonCheckBox.ImageIndex = 0;
            this.buttonCheckBox.ImageList = this.imageListCheckBox;
            this.buttonCheckBox.Location = new System.Drawing.Point(0, 0);
            this.buttonCheckBox.Name = "buttonCheckBox";
            this.buttonCheckBox.Size = new System.Drawing.Size(16, 16);
            this.buttonCheckBox.TabIndex = 0;
            this.buttonCheckBox.UseVisualStyleBackColor = true;
            this.buttonCheckBox.Click += new System.EventHandler(this.buttonCheckBox_Click);
            // 
            // imageListCheckBox
            // 
            this.imageListCheckBox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCheckBox.ImageStream")));
            this.imageListCheckBox.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCheckBox.Images.SetKeyName(0, "unchecked.PNG");
            this.imageListCheckBox.Images.SetKeyName(1, "checked.PNG");
            // 
            // labelCheckBox
            // 
            this.labelCheckBox.AutoSize = true;
            this.labelCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.labelCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckBox.Location = new System.Drawing.Point(16, 0);
            this.labelCheckBox.Name = "labelCheckBox";
            this.labelCheckBox.Size = new System.Drawing.Size(0, 20);
            this.labelCheckBox.TabIndex = 1;
            // 
            // vSroCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelCheckBox);
            this.Controls.Add(this.buttonCheckBox);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(16, 16);
            this.Name = "vSroCheckBox";
            this.Size = new System.Drawing.Size(16, 16);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageListCheckBox;
        private System.Windows.Forms.Label labelCheckBox;
        public System.Windows.Forms.Button buttonCheckBox;
    }
}
