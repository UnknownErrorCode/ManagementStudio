
namespace WorldMapSpawnEditor.MapGuide
{
    partial class MapGuideForm
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
            this.vSroSizableWindow1 = new PluginFramework.BasicControls.vSroSizableWindow();
            this.SuspendLayout();
            // 
            // vSroSizableWindow1
            // 
            this.vSroSizableWindow1.BackColor = System.Drawing.Color.Black;
            this.vSroSizableWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vSroSizableWindow1.Location = new System.Drawing.Point(0, 0);
            this.vSroSizableWindow1.Name = "vSroSizableWindow1";
            this.vSroSizableWindow1.Size = new System.Drawing.Size(800, 450);
            this.vSroSizableWindow1.TabIndex = 0;
            this.vSroSizableWindow1.Title = "label1";
            // 
            // MapGuideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vSroSizableWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapGuideForm";
            this.Text = "MapGuideForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapGuideForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private PluginFramework.BasicControls.vSroSizableWindow vSroSizableWindow1;
    }
}