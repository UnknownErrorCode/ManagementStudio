namespace ManagementFramework.BasicControls
{
    partial class vSroListButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vSroListButton));
            this.imageListSingleButton = new System.Windows.Forms.ImageList(this.components);
            this.labelButtonName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageListSingleButton
            // 
            this.imageListSingleButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSingleButton.ImageStream")));
            this.imageListSingleButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSingleButton.Images.SetKeyName(0, "SingleOnlineUser.png");
            this.imageListSingleButton.Images.SetKeyName(1, "SingleOnlineUser_focus.png");
            this.imageListSingleButton.Images.SetKeyName(2, "SingleOnlineUser_Press.png");
            // 
            // labelButtonName
            // 
            this.labelButtonName.BackColor = System.Drawing.Color.Transparent;
            this.labelButtonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButtonName.ForeColor = System.Drawing.Color.White;
            this.labelButtonName.Location = new System.Drawing.Point(6, 3);
            this.labelButtonName.Name = "labelButtonName";
            this.labelButtonName.Size = new System.Drawing.Size(197, 19);
            this.labelButtonName.TabIndex = 1;
            this.labelButtonName.Text = "UserName";
            this.labelButtonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelButtonName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroListButton_MouseDown);
            this.labelButtonName.MouseEnter += new System.EventHandler(this.labelEnter);
            this.labelButtonName.MouseLeave += new System.EventHandler(this.labelleave);
            this.labelButtonName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vSroListButton_MouseUp);
            // 
            // vSroListButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.labelButtonName);
            this.MaximumSize = new System.Drawing.Size(206, 26);
            this.MinimumSize = new System.Drawing.Size(206, 26);
            this.Name = "vSroListButton";
            this.Size = new System.Drawing.Size(463, 58);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroListButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vSroListButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label labelButtonName;
        public System.Windows.Forms.ImageList imageListSingleButton;
    }
}
