
namespace Editors.Teleport
{
    partial class TeleportEditor
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
            this.propertyGridRefTeleport = new System.Windows.Forms.PropertyGrid();
            this.propertyGridRefTeleLink = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // propertyGridRefTeleport
            // 
            this.propertyGridRefTeleport.HelpVisible = false;
            this.propertyGridRefTeleport.Location = new System.Drawing.Point(12, 39);
            this.propertyGridRefTeleport.Name = "propertyGridRefTeleport";
            this.propertyGridRefTeleport.Size = new System.Drawing.Size(221, 214);
            this.propertyGridRefTeleport.TabIndex = 0;
            // 
            // propertyGridRefTeleLink
            // 
            this.propertyGridRefTeleLink.HelpVisible = false;
            this.propertyGridRefTeleLink.Location = new System.Drawing.Point(259, 39);
            this.propertyGridRefTeleLink.Name = "propertyGridRefTeleLink";
            this.propertyGridRefTeleLink.Size = new System.Drawing.Size(221, 214);
            this.propertyGridRefTeleLink.TabIndex = 1;
            // 
            // TeleportEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 320);
            this.Controls.Add(this.propertyGridRefTeleLink);
            this.Controls.Add(this.propertyGridRefTeleport);
            this.Name = "TeleportEditor";
            this.Text = "TeleportEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGridRefTeleport;
        private System.Windows.Forms.PropertyGrid propertyGridRefTeleLink;
    }
}