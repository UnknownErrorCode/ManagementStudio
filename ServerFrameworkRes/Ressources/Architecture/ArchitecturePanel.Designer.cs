namespace ServerFrameworkRes.Ressources.Architecture
{
    partial class ArchitecturePanel
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.showArchitectureTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCertificationFromCertificationManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showArchitectureTreeToolStripMenuItem,
            this.loadCertificationFromCertificationManagerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(313, 70);
            // 
            // showArchitectureTreeToolStripMenuItem
            // 
            this.showArchitectureTreeToolStripMenuItem.Name = "showArchitectureTreeToolStripMenuItem";
            this.showArchitectureTreeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showArchitectureTreeToolStripMenuItem.Text = "Show Architecture Tree";
            this.showArchitectureTreeToolStripMenuItem.Click += new System.EventHandler(this.showArchitectureTreeToolStripMenuItem_Click);
            // 
            // loadCertificationFromCertificationManagerToolStripMenuItem
            // 
            this.loadCertificationFromCertificationManagerToolStripMenuItem.Name = "loadCertificationFromCertificationManagerToolStripMenuItem";
            this.loadCertificationFromCertificationManagerToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.loadCertificationFromCertificationManagerToolStripMenuItem.Text = "Load Certification from CertificationManager";
            this.loadCertificationFromCertificationManagerToolStripMenuItem.Click += new System.EventHandler(this.loadCertificationFromCertificationManagerToolStripMenuItem_Click);
            // 
            // ArchitecturePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "ArchitecturePanel";
            this.Size = new System.Drawing.Size(500, 200);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showArchitectureTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCertificationFromCertificationManagerToolStripMenuItem;
    }
}
