namespace TriggerEditor.EditorLayouts
{
    partial class UCAddCategoryToWorld
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
            this.comboBoxAddCategoryToWorld = new System.Windows.Forms.ComboBox();
            this.textBoxAddCategoryComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddCategoryToWorld = new System.Windows.Forms.Button();
            this.labelWorldName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAddCategoryToWorld
            // 
            this.comboBoxAddCategoryToWorld.FormattingEnabled = true;
            this.comboBoxAddCategoryToWorld.Location = new System.Drawing.Point(15, 57);
            this.comboBoxAddCategoryToWorld.Name = "comboBoxAddCategoryToWorld";
            this.comboBoxAddCategoryToWorld.Size = new System.Drawing.Size(184, 21);
            this.comboBoxAddCategoryToWorld.TabIndex = 0;
            this.comboBoxAddCategoryToWorld.Text = "TRI_CATEGORY_";
            this.comboBoxAddCategoryToWorld.TextChanged += new System.EventHandler(this.comboBoxAddCategoryToWorld_TextChanged);
            // 
            // textBoxAddCategoryComment
            // 
            this.textBoxAddCategoryComment.Location = new System.Drawing.Point(15, 97);
            this.textBoxAddCategoryComment.MaxLength = 500;
            this.textBoxAddCategoryComment.Multiline = true;
            this.textBoxAddCategoryComment.Name = "textBoxAddCategoryComment";
            this.textBoxAddCategoryComment.Size = new System.Drawing.Size(184, 65);
            this.textBoxAddCategoryComment.TabIndex = 1;
            this.textBoxAddCategoryComment.TextChanged += new System.EventHandler(this.textBoxAddCategoryComment_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category Comment:";
            // 
            // buttonAddCategoryToWorld
            // 
            this.buttonAddCategoryToWorld.Enabled = false;
            this.buttonAddCategoryToWorld.Location = new System.Drawing.Point(15, 168);
            this.buttonAddCategoryToWorld.Name = "buttonAddCategoryToWorld";
            this.buttonAddCategoryToWorld.Size = new System.Drawing.Size(184, 23);
            this.buttonAddCategoryToWorld.TabIndex = 4;
            this.buttonAddCategoryToWorld.Text = "Add Category to GameWorld: ";
            this.buttonAddCategoryToWorld.UseVisualStyleBackColor = true;
            this.buttonAddCategoryToWorld.Click += new System.EventHandler(this.buttonAddCategoryToWorld_Click);
            // 
            // labelWorldName
            // 
            this.labelWorldName.AutoSize = true;
            this.labelWorldName.Location = new System.Drawing.Point(15, 16);
            this.labelWorldName.Name = "labelWorldName";
            this.labelWorldName.Size = new System.Drawing.Size(73, 13);
            this.labelWorldName.TabIndex = 5;
            this.labelWorldName.Text = "<gameWorld>";
            // 
            // UCAddCategoryToWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelWorldName);
            this.Controls.Add(this.buttonAddCategoryToWorld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddCategoryComment);
            this.Controls.Add(this.comboBoxAddCategoryToWorld);
            this.Name = "UCAddCategoryToWorld";
            this.Size = new System.Drawing.Size(386, 310);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAddCategoryToWorld;
        private System.Windows.Forms.TextBox textBoxAddCategoryComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddCategoryToWorld;
        private System.Windows.Forms.Label labelWorldName;
    }
}
