namespace FileEditor
{
    partial class FileEditorControl
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
            this.vSroSmallButton1 = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // vSroSmallButton1
            // 
            this.vSroSmallButton1.Location = new System.Drawing.Point(365, 339);
            this.vSroSmallButton1.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.Name = "vSroSmallButton1";
            this.vSroSmallButton1.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.TabIndex = 0;
            this.vSroSmallButton1.vSroSmallButtonName = "Empty";
            this.vSroSmallButton1.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.vSroSmallButton1_vSroClickEvent);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(297, 50);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(365, 271);
            this.propertyGrid1.TabIndex = 1;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.vSroSmallButton1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButton1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}
