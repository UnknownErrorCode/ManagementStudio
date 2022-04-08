namespace PluginFramework.BasicControls
{
    partial class vSroSizableWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vSroSizableWindow));
            this.panelMainTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vSroCloseButton1 = new PluginFramework.BasicControls.vSroCloseButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelMainBottom = new System.Windows.Forms.Panel();
            this.panelRightBottom = new System.Windows.Forms.Panel();
            this.panelMiddleBottom = new System.Windows.Forms.Panel();
            this.panelLeftBottom = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelMainTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.panel2);
            this.panelMainTop.Controls.Add(this.panel3);
            this.panelMainTop.Controls.Add(this.panel4);
            this.panelMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainTop.Location = new System.Drawing.Point(0, 0);
            this.panelMainTop.Name = "panelMainTop";
            this.panelMainTop.Size = new System.Drawing.Size(520, 68);
            this.panelMainTop.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.vSroCloseButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(480, 0);
            this.panel2.MaximumSize = new System.Drawing.Size(40, 68);
            this.panel2.MinimumSize = new System.Drawing.Size(40, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(40, 68);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseUp);
            // 
            // vSroCloseButton1
            // 
            this.vSroCloseButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vSroCloseButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroCloseButton1.BackgroundImage")));
            this.vSroCloseButton1.Location = new System.Drawing.Point(12, 10);
            this.vSroCloseButton1.Name = "vSroCloseButton1";
            this.vSroCloseButton1.Size = new System.Drawing.Size(16, 17);
            this.vSroCloseButton1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(40, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 68);
            this.panel3.TabIndex = 2;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.MaximumSize = new System.Drawing.Size(40, 68);
            this.panel4.MinimumSize = new System.Drawing.Size(40, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(40, 68);
            this.panel4.TabIndex = 1;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseMove);
            this.panel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseUp);
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.Controls.Add(this.panelRightBottom);
            this.panelMainBottom.Controls.Add(this.panelMiddleBottom);
            this.panelMainBottom.Controls.Add(this.panelLeftBottom);
            this.panelMainBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMainBottom.Location = new System.Drawing.Point(0, 306);
            this.panelMainBottom.Name = "panelMainBottom";
            this.panelMainBottom.Size = new System.Drawing.Size(520, 48);
            this.panelMainBottom.TabIndex = 6;
            // 
            // panelRightBottom
            // 
            this.panelRightBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelRightBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelRightBottom.BackgroundImage")));
            this.panelRightBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightBottom.Location = new System.Drawing.Point(480, 0);
            this.panelRightBottom.MaximumSize = new System.Drawing.Size(40, 48);
            this.panelRightBottom.MinimumSize = new System.Drawing.Size(40, 48);
            this.panelRightBottom.Name = "panelRightBottom";
            this.panelRightBottom.Size = new System.Drawing.Size(40, 48);
            this.panelRightBottom.TabIndex = 2;
            // 
            // panelMiddleBottom
            // 
            this.panelMiddleBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMiddleBottom.BackgroundImage")));
            this.panelMiddleBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddleBottom.Location = new System.Drawing.Point(40, 0);
            this.panelMiddleBottom.Name = "panelMiddleBottom";
            this.panelMiddleBottom.Size = new System.Drawing.Size(480, 48);
            this.panelMiddleBottom.TabIndex = 2;
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelLeftBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeftBottom.BackgroundImage")));
            this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 0);
            this.panelLeftBottom.MaximumSize = new System.Drawing.Size(40, 48);
            this.panelLeftBottom.MinimumSize = new System.Drawing.Size(40, 48);
            this.panelLeftBottom.Name = "panelLeftBottom";
            this.panelLeftBottom.Size = new System.Drawing.Size(40, 48);
            this.panelLeftBottom.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 68);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(40, 238);
            this.panel5.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(480, 68);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(40, 238);
            this.panel6.TabIndex = 8;
            // 
            // vSroSizableWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panelMainBottom);
            this.Controls.Add(this.panelMainTop);
            this.Name = "vSroSizableWindow";
            this.Size = new System.Drawing.Size(520, 354);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vSroSizableWindow_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vSroSizableWindow_MouseUp);
            this.panelMainTop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainTop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelMainBottom;
        private System.Windows.Forms.Panel panelRightBottom;
        private System.Windows.Forms.Panel panelMiddleBottom;
        private System.Windows.Forms.Panel panelLeftBottom;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private vSroCloseButton vSroCloseButton1;
    }
}
