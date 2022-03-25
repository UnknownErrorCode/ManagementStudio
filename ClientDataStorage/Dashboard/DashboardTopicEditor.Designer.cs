
namespace ClientDataStorage.Dashboard
{
    partial class DashboardTopicEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardTopicEditor));
            this.vSroSizableWindow1 = new ServerFrameworkRes.BasicControls.vSroSizableWindow();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTopic = new System.Windows.Forms.Label();
            this.vSroSmallButtonEdit = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.vSroSmallButtonAdd = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelEditAuthor = new System.Windows.Forms.Label();
            this.vSroSmallButtonPreview = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // vSroSizableWindow1
            // 
            this.vSroSizableWindow1.BackColor = System.Drawing.Color.Black;
            this.vSroSizableWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vSroSizableWindow1.Location = new System.Drawing.Point(0, 0);
            this.vSroSizableWindow1.Name = "vSroSizableWindow1";
            this.vSroSizableWindow1.Size = new System.Drawing.Size(810, 469);
            this.vSroSizableWindow1.TabIndex = 0;
            this.vSroSizableWindow1.Title = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.labelAuthor);
            this.panel2.Controls.Add(this.labelTopic);
            this.panel2.Location = new System.Drawing.Point(29, 42);
            this.panel2.MaximumSize = new System.Drawing.Size(376, 384);
            this.panel2.MinimumSize = new System.Drawing.Size(376, 384);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 384);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.labelText);
            this.panel3.Location = new System.Drawing.Point(12, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 312);
            this.panel3.TabIndex = 3;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.ForeColor = System.Drawing.Color.Black;
            this.labelText.Location = new System.Drawing.Point(3, 0);
            this.labelText.MaximumSize = new System.Drawing.Size(325, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(146, 16);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Please select a Topic!";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthor.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(18, 4);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(52, 13);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Author: ";
            // 
            // labelTopic
            // 
            this.labelTopic.AutoSize = true;
            this.labelTopic.BackColor = System.Drawing.Color.Transparent;
            this.labelTopic.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopic.ForeColor = System.Drawing.Color.Black;
            this.labelTopic.Location = new System.Drawing.Point(29, 26);
            this.labelTopic.MaximumSize = new System.Drawing.Size(327, 327);
            this.labelTopic.Name = "labelTopic";
            this.labelTopic.Size = new System.Drawing.Size(172, 19);
            this.labelTopic.TabIndex = 1;
            this.labelTopic.Text = "Please select a Topic!";
            // 
            // vSroSmallButtonEdit
            // 
            this.vSroSmallButtonEdit.Location = new System.Drawing.Point(422, 433);
            this.vSroSmallButtonEdit.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonEdit.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonEdit.Name = "vSroSmallButtonEdit";
            this.vSroSmallButtonEdit.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonEdit.TabIndex = 5;
            this.vSroSmallButtonEdit.vSroSmallButtonName = "Edit";
            this.vSroSmallButtonEdit.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.OnEdit);
            // 
            // vSroSmallButtonAdd
            // 
            this.vSroSmallButtonAdd.Location = new System.Drawing.Point(264, 433);
            this.vSroSmallButtonAdd.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonAdd.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonAdd.Name = "vSroSmallButtonAdd";
            this.vSroSmallButtonAdd.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonAdd.TabIndex = 6;
            this.vSroSmallButtonAdd.vSroSmallButtonName = "Add";
            this.vSroSmallButtonAdd.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.OnAddNew);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, -2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(339, 307);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.labelEditAuthor);
            this.panel1.Location = new System.Drawing.Point(411, 42);
            this.panel1.MaximumSize = new System.Drawing.Size(376, 384);
            this.panel1.MinimumSize = new System.Drawing.Size(376, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 384);
            this.panel1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Location = new System.Drawing.Point(12, 48);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(349, 312);
            this.panel4.TabIndex = 3;
            // 
            // labelEditAuthor
            // 
            this.labelEditAuthor.AutoSize = true;
            this.labelEditAuthor.BackColor = System.Drawing.Color.Transparent;
            this.labelEditAuthor.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditAuthor.Location = new System.Drawing.Point(18, 4);
            this.labelEditAuthor.Name = "labelEditAuthor";
            this.labelEditAuthor.Size = new System.Drawing.Size(52, 13);
            this.labelEditAuthor.TabIndex = 2;
            this.labelEditAuthor.Text = "Author: ";
            // 
            // vSroSmallButtonPreview
            // 
            this.vSroSmallButtonPreview.Location = new System.Drawing.Point(580, 433);
            this.vSroSmallButtonPreview.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonPreview.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonPreview.Name = "vSroSmallButtonPreview";
            this.vSroSmallButtonPreview.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonPreview.TabIndex = 7;
            this.vSroSmallButtonPreview.vSroSmallButtonName = "Preview";
            this.vSroSmallButtonPreview.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.OnPreviewClick);
            // 
            // DashboardTopicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 469);
            this.Controls.Add(this.vSroSmallButtonPreview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vSroSmallButtonAdd);
            this.Controls.Add(this.vSroSmallButtonEdit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.vSroSizableWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardTopicEditor";
            this.Text = "DashboardTopicEditor";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ServerFrameworkRes.BasicControls.vSroSizableWindow vSroSizableWindow1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTopic;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonEdit;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonAdd;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelEditAuthor;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButtonPreview;
    }
}