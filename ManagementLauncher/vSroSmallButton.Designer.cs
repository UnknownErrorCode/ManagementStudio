namespace ManagementLauncher
{
    partial class vSroSmallButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vSroSmallButton));
            this.buttonvSroSmall = new System.Windows.Forms.Button();
            this.ButtonImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // buttonvSroSmall
            // 
            this.buttonvSroSmall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonvSroSmall.Font = new System.Drawing.Font("SilkRoad", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonvSroSmall.ForeColor = System.Drawing.Color.White;
            this.buttonvSroSmall.ImageIndex = 0;
            this.buttonvSroSmall.ImageList = this.ButtonImageList;
            this.buttonvSroSmall.Location = new System.Drawing.Point(0, 0);
            this.buttonvSroSmall.MaximumSize = new System.Drawing.Size(152, 24);
            this.buttonvSroSmall.MinimumSize = new System.Drawing.Size(152, 24);
            this.buttonvSroSmall.Name = "buttonvSroSmall";
            this.buttonvSroSmall.Size = new System.Drawing.Size(152, 24);
            this.buttonvSroSmall.TabIndex = 1;
            this.buttonvSroSmall.Text = "Empty";
            this.buttonvSroSmall.UseVisualStyleBackColor = true;
            this.buttonvSroSmall.Leave += new System.EventHandler(this.OpenSettings_Leave);
            this.buttonvSroSmall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenSettings_MouseDown);
            this.buttonvSroSmall.MouseEnter += new System.EventHandler(this.OpenSettings_MouseEnter);
            this.buttonvSroSmall.MouseLeave += new System.EventHandler(this.OpenSettings_MouseLeave);
            this.buttonvSroSmall.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenSettings_MouseUp);
            // 
            // ButtonImageList
            // 
            this.ButtonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImageList.ImageStream")));
            this.ButtonImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonImageList.Images.SetKeyName(0, "sys_button.PNG");
            this.ButtonImageList.Images.SetKeyName(1, "sys_button_focus.PNG");
            this.ButtonImageList.Images.SetKeyName(2, "sys_button_press.PNG");
            // 
            // vSroSmallButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonvSroSmall);
            this.MaximumSize = new System.Drawing.Size(152, 24);
            this.MinimumSize = new System.Drawing.Size(152, 24);
            this.Name = "vSroSmallButton";
            this.Size = new System.Drawing.Size(152, 24);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList ButtonImageList;
        public System.Windows.Forms.Button buttonvSroSmall;
    }
}
