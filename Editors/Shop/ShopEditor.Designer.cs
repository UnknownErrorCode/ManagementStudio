
namespace Editors.Shop
{
    partial class ShopEditor
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid4 = new System.Windows.Forms.PropertyGrid();
            this.vSroSmallButton1 = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(12, 33);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(226, 189);
            this.propertyGrid1.TabIndex = 0;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.HelpVisible = false;
            this.propertyGrid2.Location = new System.Drawing.Point(247, 33);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(226, 189);
            this.propertyGrid2.TabIndex = 1;
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.HelpVisible = false;
            this.propertyGrid3.Location = new System.Drawing.Point(12, 249);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(226, 189);
            this.propertyGrid3.TabIndex = 2;
            // 
            // propertyGrid4
            // 
            this.propertyGrid4.HelpVisible = false;
            this.propertyGrid4.Location = new System.Drawing.Point(247, 249);
            this.propertyGrid4.Name = "propertyGrid4";
            this.propertyGrid4.Size = new System.Drawing.Size(226, 189);
            this.propertyGrid4.TabIndex = 3;
            // 
            // vSroSmallButton1
            // 
            this.vSroSmallButton1.Location = new System.Drawing.Point(513, 37);
            this.vSroSmallButton1.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.Name = "vSroSmallButton1";
            this.vSroSmallButton1.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.TabIndex = 4;
            this.vSroSmallButton1.vSroSmallButtonName = "Display Price";
            this.vSroSmallButton1.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.DisplayPrice);
            // 
            // ShopEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vSroSmallButton1);
            this.Controls.Add(this.propertyGrid4);
            this.Controls.Add(this.propertyGrid3);
            this.Controls.Add(this.propertyGrid2);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "ShopEditor";
            this.Text = "ShopEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.PropertyGrid propertyGrid3;
        private System.Windows.Forms.PropertyGrid propertyGrid4;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButton1;
    }
}