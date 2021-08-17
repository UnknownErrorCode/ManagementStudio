namespace ServerFrameworkRes.BasicControls
{
    partial class vSroMessageBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vSroMessageBox));
            this.labelTitle = new System.Windows.Forms.Label();
            this.imageListButton = new System.Windows.Forms.ImageList(this.components);
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.vSroButtonYes = new ServerFrameworkRes.BasicControls.vSroButton();
            this.vSroCloseButton1 = new ServerFrameworkRes.BasicControls.vSroCloseButton();
            this.vSroButtonNo = new ServerFrameworkRes.BasicControls.vSroButton();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(12, 368);
            this.labelTitle.MaximumSize = new System.Drawing.Size(363, 277);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(363, 22);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "vSroMessageBox";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageListButton
            // 
            this.imageListButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListButton.ImageStream")));
            this.imageListButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListButton.Images.SetKeyName(0, "button.PNG");
            this.imageListButton.Images.SetKeyName(1, "button_focus.PNG");
            this.imageListButton.Images.SetKeyName(2, "button_press.PNG");
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.BackColor = System.Drawing.Color.Black;
            this.richTextBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMessage.ForeColor = System.Drawing.Color.White;
            this.richTextBoxMessage.Location = new System.Drawing.Point(13, 40);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(361, 276);
            this.richTextBoxMessage.TabIndex = 2;
            this.richTextBoxMessage.Text = "";
            // 
            // vSroButtonYes
            // 
            this.vSroButtonYes.Location = new System.Drawing.Point(90, 322);
            this.vSroButtonYes.MaximumSize = new System.Drawing.Size(92, 40);
            this.vSroButtonYes.MinimumSize = new System.Drawing.Size(92, 40);
            this.vSroButtonYes.Name = "vSroButtonYes";
            this.vSroButtonYes.Size = new System.Drawing.Size(92, 40);
            this.vSroButtonYes.TabIndex = 3;
            // 
            // vSroCloseButton1
            // 
            this.vSroCloseButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroCloseButton1.BackgroundImage")));
            this.vSroCloseButton1.Location = new System.Drawing.Point(362, 9);
            this.vSroCloseButton1.Name = "vSroCloseButton1";
            this.vSroCloseButton1.Size = new System.Drawing.Size(15, 15);
            this.vSroCloseButton1.TabIndex = 4;
            // 
            // vSroButtonNo
            // 
            this.vSroButtonNo.Location = new System.Drawing.Point(188, 322);
            this.vSroButtonNo.MaximumSize = new System.Drawing.Size(92, 40);
            this.vSroButtonNo.MinimumSize = new System.Drawing.Size(92, 40);
            this.vSroButtonNo.Name = "vSroButtonNo";
            this.vSroButtonNo.Size = new System.Drawing.Size(92, 40);
            this.vSroButtonNo.TabIndex = 5;
            // 
            // vSroMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(387, 407);
            this.Controls.Add(this.vSroButtonNo);
            this.Controls.Add(this.vSroCloseButton1);
            this.Controls.Add(this.vSroButtonYes);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "vSroMessageBox";
            this.Text = "MessageBox";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vSroMessageBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vSroMessageBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vSroMessageBox_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ImageList imageListButton;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private ServerFrameworkRes.BasicControls.vSroButton vSroButtonYes;
        private ServerFrameworkRes.BasicControls.vSroCloseButton vSroCloseButton1;
        private ServerFrameworkRes.BasicControls.vSroButton vSroButtonNo;
    }
}