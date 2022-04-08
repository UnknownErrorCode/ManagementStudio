namespace PluginFramework.BasicControls
{
    partial class vSroCloseButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vSroCloseButton));
            this.imageListCloseButton = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageListCloseButton
            // 
            this.imageListCloseButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCloseButton.ImageStream")));
            this.imageListCloseButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCloseButton.Images.SetKeyName(0, "Close_Button.png");
            this.imageListCloseButton.Images.SetKeyName(1, "CloseButton_Focus.png");
            this.imageListCloseButton.Images.SetKeyName(2, "Close_Button_Press.png");
            // 
            // vSroCloseButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Name = "vSroCloseButton";
            this.Size = new System.Drawing.Size(15, 15);
            this.Click += new System.EventHandler(this.vSroCloseButton_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroCloseButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.vSroCloseButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.vSroCloseButton_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListCloseButton;
    }
}
