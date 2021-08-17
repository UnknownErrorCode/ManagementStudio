namespace ServerFrameworkRes.Ressources
{
    partial class ArchitectureBody
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchitectureBody));
            this.pictureBoxCertification = new System.Windows.Forms.PictureBox();
            this.pictureBoxWaitForStart = new System.Windows.Forms.PictureBox();
            this.pictureBoxActive = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCertification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaitForStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActive)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCertification
            // 
            this.pictureBoxCertification.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCertification.BackgroundImage")));
            this.pictureBoxCertification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCertification.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCertification.ErrorImage")));
            this.pictureBoxCertification.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCertification.InitialImage")));
            this.pictureBoxCertification.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCertification.Name = "pictureBoxCertification";
            this.pictureBoxCertification.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxCertification.TabIndex = 0;
            this.pictureBoxCertification.TabStop = false;
            this.pictureBoxCertification.Visible = false;
            this.pictureBoxCertification.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseDown);
            this.pictureBoxCertification.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseMove);
            // 
            // pictureBoxWaitForStart
            // 
            this.pictureBoxWaitForStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxWaitForStart.BackgroundImage")));
            this.pictureBoxWaitForStart.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxWaitForStart.ErrorImage")));
            this.pictureBoxWaitForStart.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxWaitForStart.InitialImage")));
            this.pictureBoxWaitForStart.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWaitForStart.Name = "pictureBoxWaitForStart";
            this.pictureBoxWaitForStart.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxWaitForStart.TabIndex = 1;
            this.pictureBoxWaitForStart.TabStop = false;
            this.pictureBoxWaitForStart.Visible = false;
            this.pictureBoxWaitForStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseDown);
            this.pictureBoxWaitForStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseMove);
            // 
            // pictureBoxActive
            // 
            this.pictureBoxActive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxActive.BackgroundImage")));
            this.pictureBoxActive.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxActive.ErrorImage")));
            this.pictureBoxActive.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxActive.InitialImage")));
            this.pictureBoxActive.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxActive.Name = "pictureBoxActive";
            this.pictureBoxActive.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxActive.TabIndex = 2;
            this.pictureBoxActive.TabStop = false;
            this.pictureBoxActive.Visible = false;
            this.pictureBoxActive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseDown);
            this.pictureBoxActive.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseMove);
            // 
            // ArchitectureBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.pictureBoxActive);
            this.Controls.Add(this.pictureBoxWaitForStart);
            this.Controls.Add(this.pictureBoxCertification);
            this.Name = "ArchitectureBody";
            this.Size = new System.Drawing.Size(32, 32);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ArchitectureBody_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCertification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaitForStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxActive;
        public System.Windows.Forms.PictureBox pictureBoxCertification;
        public System.Windows.Forms.PictureBox pictureBoxWaitForStart;
    }
}
