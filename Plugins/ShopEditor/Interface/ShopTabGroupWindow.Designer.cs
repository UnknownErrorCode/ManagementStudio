
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
            this.vSroCloseButton1 = new PluginFramework.BasicControls.vSroCloseButton();
            this.labelPageIndex = new System.Windows.Forms.Label();
            this.panelCurrentPage = new System.Windows.Forms.Panel();
            this.panelNextPage = new System.Windows.Forms.Panel();
            this.panelPrePage = new System.Windows.Forms.Panel();
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
            // labelPageIndex
            // 
            this.labelPageIndex.AutoSize = true;
            this.labelPageIndex.BackColor = System.Drawing.Color.Transparent;
            this.labelPageIndex.Location = new System.Drawing.Point(118, 255);
            this.labelPageIndex.Name = "labelPageIndex";
            this.labelPageIndex.Size = new System.Drawing.Size(13, 13);
            this.labelPageIndex.TabIndex = 2;
            this.labelPageIndex.Text = "0";
            // 
            // panelCurrentPage
            // 
            this.panelCurrentPage.BackColor = System.Drawing.Color.Transparent;
            this.panelCurrentPage.Location = new System.Drawing.Point(15, 66);
            this.panelCurrentPage.Name = "panelCurrentPage";
            this.panelCurrentPage.Size = new System.Drawing.Size(218, 182);
            this.panelCurrentPage.TabIndex = 3;
            // 
            // panelNextPage
            // 
            this.panelNextPage.BackColor = System.Drawing.Color.Transparent;
            this.panelNextPage.Location = new System.Drawing.Point(135, 254);
            this.panelNextPage.Name = "panelNextPage";
            this.panelNextPage.Size = new System.Drawing.Size(15, 15);
            this.panelNextPage.TabIndex = 4;
            this.panelNextPage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowNextPage);
            // 
            // panelPrePage
            // 
            this.panelPrePage.BackColor = System.Drawing.Color.Transparent;
            this.panelPrePage.Location = new System.Drawing.Point(101, 254);
            this.panelPrePage.Name = "panelPrePage";
            this.panelPrePage.Size = new System.Drawing.Size(15, 15);
            this.panelPrePage.TabIndex = 5;
            this.panelPrePage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowPreviousPage);
            // 
            // ShopTabGroupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(252, 370);
            this.Controls.Add(this.panelPrePage);
            this.Controls.Add(this.panelNextPage);
            this.Controls.Add(this.panelCurrentPage);
            this.Controls.Add(this.labelPageIndex);
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
        private PluginFramework.BasicControls.vSroCloseButton vSroCloseButton1;
        private System.Windows.Forms.Label labelPageIndex;
        private System.Windows.Forms.Panel panelCurrentPage;
        private System.Windows.Forms.Panel panelNextPage;
        private System.Windows.Forms.Panel panelPrePage;
    }
}