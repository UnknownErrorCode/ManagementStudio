
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopEditor));
            this.vSroSmallButton4 = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSmallButton3 = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSmallButton2 = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroButtonList1 = new ServerFrameworkRes.BasicControls.vSroButtonList();
            this.vSroSmallButton1 = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSizableWindow1 = new ServerFrameworkRes.BasicControls.vSroSizableWindow();
            this.SuspendLayout();
            // 
            // vSroSmallButton4
            // 
            this.vSroSmallButton4.Enabled = false;
            this.vSroSmallButton4.Location = new System.Drawing.Point(249, 129);
            this.vSroSmallButton4.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton4.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton4.Name = "vSroSmallButton4";
            this.vSroSmallButton4.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton4.TabIndex = 9;
            this.vSroSmallButton4.vSroSmallButtonName = "Edit Price";
            // 
            // vSroSmallButton3
            // 
            this.vSroSmallButton3.Location = new System.Drawing.Point(249, 99);
            this.vSroSmallButton3.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton3.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton3.Name = "vSroSmallButton3";
            this.vSroSmallButton3.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton3.TabIndex = 8;
            this.vSroSmallButton3.vSroSmallButtonName = "Add Price";
            this.vSroSmallButton3.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.vSroSmallButton3_vSroClickEvent);
            // 
            // vSroSmallButton2
            // 
            this.vSroSmallButton2.Location = new System.Drawing.Point(249, 69);
            this.vSroSmallButton2.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton2.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton2.Name = "vSroSmallButton2";
            this.vSroSmallButton2.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton2.TabIndex = 7;
            this.vSroSmallButton2.vSroSmallButtonName = "Delete Price";
            this.vSroSmallButton2.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.vSroSmallButton2_vSroClickEvent);
            // 
            // vSroButtonList1
            // 
            this.vSroButtonList1.AutoScroll = true;
            this.vSroButtonList1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroButtonList1.BackgroundImage")));
            this.vSroButtonList1.Location = new System.Drawing.Point(23, 69);
            this.vSroButtonList1.MaximumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.MinimumSize = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.Name = "vSroButtonList1";
            this.vSroButtonList1.Size = new System.Drawing.Size(220, 400);
            this.vSroButtonList1.TabIndex = 6;
            // 
            // vSroSmallButton1
            // 
            this.vSroSmallButton1.Location = new System.Drawing.Point(23, 39);
            this.vSroSmallButton1.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.Name = "vSroSmallButton1";
            this.vSroSmallButton1.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.TabIndex = 4;
            this.vSroSmallButton1.vSroSmallButtonName = "Display Price";
            this.vSroSmallButton1.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.DisplayPrice);
            // 
            // vSroSizableWindow1
            // 
            this.vSroSizableWindow1.BackColor = System.Drawing.Color.Black;
            this.vSroSizableWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vSroSizableWindow1.Location = new System.Drawing.Point(0, 0);
            this.vSroSizableWindow1.Name = "vSroSizableWindow1";
            this.vSroSizableWindow1.Size = new System.Drawing.Size(538, 489);
            this.vSroSizableWindow1.TabIndex = 5;
            this.vSroSizableWindow1.Title = "Shop Good editor";
            // 
            // ShopEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 489);
            this.Controls.Add(this.vSroSmallButton4);
            this.Controls.Add(this.vSroSmallButton3);
            this.Controls.Add(this.vSroSmallButton2);
            this.Controls.Add(this.vSroButtonList1);
            this.Controls.Add(this.vSroSmallButton1);
            this.Controls.Add(this.vSroSizableWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShopEditor";
            this.Text = "ShopEditor";
            this.ResumeLayout(false);

        }

        #endregion
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButton1;
        private ServerFrameworkRes.BasicControls.vSroSizableWindow vSroSizableWindow1;
        private ServerFrameworkRes.BasicControls.vSroButtonList vSroButtonList1;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButton2;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButton3;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButton4;
    }
}