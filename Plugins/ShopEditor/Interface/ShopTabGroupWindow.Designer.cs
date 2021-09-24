
namespace ShopEditor.Interface
{
    partial class ShopTabGroupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopTabGroupWindow));
            this.labelShopTabGroup = new System.Windows.Forms.Label();
            this.vSroCloseButton1 = new ServerFrameworkRes.BasicControls.vSroCloseButton();
            this.SuspendLayout();
            // 
            // labelShopTabGroup
            // 
            this.labelShopTabGroup.AutoSize = true;
            this.labelShopTabGroup.BackColor = System.Drawing.Color.Transparent;
            this.labelShopTabGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShopTabGroup.Location = new System.Drawing.Point(20, 11);
            this.labelShopTabGroup.Name = "labelShopTabGroup";
            this.labelShopTabGroup.Size = new System.Drawing.Size(101, 16);
            this.labelShopTabGroup.TabIndex = 0;
            this.labelShopTabGroup.Text = "<Shop name>";
            // 
            // vSroCloseButton1
            // 
            this.vSroCloseButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroCloseButton1.BackgroundImage")));
            this.vSroCloseButton1.Location = new System.Drawing.Point(226, 10);
            this.vSroCloseButton1.Name = "vSroCloseButton1";
            this.vSroCloseButton1.Size = new System.Drawing.Size(15, 15);
            this.vSroCloseButton1.TabIndex = 1;
            // 
            // ShopTabGroupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(252, 370);
            this.Controls.Add(this.vSroCloseButton1);
            this.Controls.Add(this.labelShopTabGroup);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(218)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(252, 370);
            this.MinimumSize = new System.Drawing.Size(252, 370);
            this.Name = "ShopTabGroupWindow";
            this.Text = "ShopTabGroupWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShopTabGroup;
        private ServerFrameworkRes.BasicControls.vSroCloseButton vSroCloseButton1;
    }
}