namespace ShopEditor
{
    partial class ShopEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopEditorControl));
            this.listViewAllNpcs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.talkWindow1 = new ShopEditor.TalkWindow();
            this.vSroSmallButtonLoadShops = new PluginFramework.BasicControls.vSroSmallButton();
            this.SuspendLayout();
            // 
            // listViewAllNpcs
            // 
            this.listViewAllNpcs.BackColor = System.Drawing.Color.Black;
            this.listViewAllNpcs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewAllNpcs.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewAllNpcs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewAllNpcs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(218)))), ((int)(((byte)(164)))));
            this.listViewAllNpcs.HideSelection = false;
            this.listViewAllNpcs.Location = new System.Drawing.Point(0, 0);
            this.listViewAllNpcs.MultiSelect = false;
            this.listViewAllNpcs.Name = "listViewAllNpcs";
            this.listViewAllNpcs.Size = new System.Drawing.Size(240, 450);
            this.listViewAllNpcs.TabIndex = 1;
            this.listViewAllNpcs.UseCompatibleStateImageBehavior = false;
            this.listViewAllNpcs.View = System.Windows.Forms.View.Details;
            this.listViewAllNpcs.SelectedIndexChanged += new System.EventHandler(this.listViewAllNpcs_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "All Shops";
            this.columnHeader1.Width = 235;
            // 
            // talkWindow1
            // 
            this.talkWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("talkWindow1.BackgroundImage")));
            this.talkWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.talkWindow1.Dock = System.Windows.Forms.DockStyle.Left;
            this.talkWindow1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.talkWindow1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(218)))), ((int)(((byte)(164)))));
            this.talkWindow1.Location = new System.Drawing.Point(240, 0);
            this.talkWindow1.MaximumSize = new System.Drawing.Size(387, 450);
            this.talkWindow1.MinimumSize = new System.Drawing.Size(387, 450);
            this.talkWindow1.Name = "talkWindow1";
            this.talkWindow1.Size = new System.Drawing.Size(387, 450);
            this.talkWindow1.TabIndex = 2;
            // 
            // vSroSmallButtonLoadShops
            // 
            this.vSroSmallButtonLoadShops.Location = new System.Drawing.Point(633, 3);
            this.vSroSmallButtonLoadShops.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLoadShops.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLoadShops.Name = "vSroSmallButtonLoadShops";
            this.vSroSmallButtonLoadShops.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLoadShops.TabIndex = 3;
            this.vSroSmallButtonLoadShops.vSroSmallButtonName = "Load Shops";
            // 
            // ShopEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.vSroSmallButtonLoadShops);
            this.Controls.Add(this.talkWindow1);
            this.Controls.Add(this.listViewAllNpcs);
            this.Name = "ShopEditorControl";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private TalkWindow talkWindow1;
        private System.Windows.Forms.ListView listViewAllNpcs;
        private PluginFramework.BasicControls.vSroSmallButton vSroSmallButtonLoadShops;
    }
}
