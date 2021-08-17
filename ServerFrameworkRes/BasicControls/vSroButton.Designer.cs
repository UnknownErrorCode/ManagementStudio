namespace ServerFrameworkRes.BasicControls
{
    partial class vSroButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vSroButton));
            this.imageListButton = new System.Windows.Forms.ImageList(this.components);
            this.RealButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageListButton
            // 
            this.imageListButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListButton.ImageStream")));
            this.imageListButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListButton.Images.SetKeyName(0, "button_europe_focus.PNG");
            this.imageListButton.Images.SetKeyName(1, "button_europe_press.PNG");
            this.imageListButton.Images.SetKeyName(2, "button_europe.PNG");
            // 
            // RealButton
            // 
            this.RealButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RealButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RealButton.Font = new System.Drawing.Font("SilkRoad", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealButton.ImageIndex = 0;
            this.RealButton.ImageList = this.imageListButton;
            this.RealButton.Location = new System.Drawing.Point(0, 0);
            this.RealButton.Name = "RealButton";
            this.RealButton.Size = new System.Drawing.Size(92, 40);
            this.RealButton.TabIndex = 0;
            this.RealButton.UseVisualStyleBackColor = true;
            this.RealButton.Leave += new System.EventHandler(this.button1_Leave);
            this.RealButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.RealButton.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.RealButton.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.RealButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // vSroButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RealButton);
            this.MaximumSize = new System.Drawing.Size(92, 40);
            this.MinimumSize = new System.Drawing.Size(92, 40);
            this.Name = "vSroButton";
            this.Size = new System.Drawing.Size(92, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListButton;
        public System.Windows.Forms.Button RealButton;
    }
}
