
namespace ShopEditor
{
    partial class TalkWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalkWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelNpcNoticeMessage = new System.Windows.Forms.Label();
            this.labelNpcName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(30, 62);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelNpcNoticeMessage);
            this.splitContainer1.Size = new System.Drawing.Size(314, 362);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelNpcNoticeMessage
            // 
            this.labelNpcNoticeMessage.AutoSize = true;
            this.labelNpcNoticeMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNpcNoticeMessage.Location = new System.Drawing.Point(14, 13);
            this.labelNpcNoticeMessage.Name = "labelNpcNoticeMessage";
            this.labelNpcNoticeMessage.Size = new System.Drawing.Size(138, 13);
            this.labelNpcNoticeMessage.TabIndex = 0;
            this.labelNpcNoticeMessage.Text = "<NPC notice message>";
            // 
            // labelNpcName
            // 
            this.labelNpcName.AutoSize = true;
            this.labelNpcName.BackColor = System.Drawing.Color.Transparent;
            this.labelNpcName.Location = new System.Drawing.Point(27, 11);
            this.labelNpcName.Name = "labelNpcName";
            this.labelNpcName.Size = new System.Drawing.Size(81, 13);
            this.labelNpcName.TabIndex = 1;
            this.labelNpcName.Text = "<NPC Name>";
            // 
            // TalkWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.labelNpcName);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(218)))), ((int)(((byte)(164)))));
            this.MaximumSize = new System.Drawing.Size(387, 450);
            this.MinimumSize = new System.Drawing.Size(387, 450);
            this.Name = "TalkWindow";
            this.Size = new System.Drawing.Size(387, 450);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelNpcNoticeMessage;
        private System.Windows.Forms.Label labelNpcName;
    }
}
