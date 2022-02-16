namespace SkillEditor
{
    partial class SkillEditorControl
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMonsterSkills = new System.Windows.Forms.TabPage();
            this.splitContainerMonster = new System.Windows.Forms.SplitContainer();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewMonster = new System.Windows.Forms.DataGridView();
            this.textBoxSearchMonster = new System.Windows.Forms.TextBox();
            this.splitContainerSkillData = new System.Windows.Forms.SplitContainer();
            this.vSroSmallButton1 = new ServerFrameworkRes.BasicControls.vSroSmallButton();
            this.tabPageCharSkills = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPageMonsterSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMonster)).BeginInit();
            this.splitContainerMonster.Panel1.SuspendLayout();
            this.splitContainerMonster.Panel2.SuspendLayout();
            this.splitContainerMonster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSkillData)).BeginInit();
            this.splitContainerSkillData.Panel1.SuspendLayout();
            this.splitContainerSkillData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMonsterSkills);
            this.tabControlMain.Controls.Add(this.tabPageCharSkills);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 450);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageMonsterSkills
            // 
            this.tabPageMonsterSkills.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tabPageMonsterSkills.Controls.Add(this.splitContainerMonster);
            this.tabPageMonsterSkills.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonsterSkills.Name = "tabPageMonsterSkills";
            this.tabPageMonsterSkills.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonsterSkills.Size = new System.Drawing.Size(792, 424);
            this.tabPageMonsterSkills.TabIndex = 0;
            this.tabPageMonsterSkills.Text = "Monster Skills";
            // 
            // splitContainerMonster
            // 
            this.splitContainerMonster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMonster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMonster.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMonster.Name = "splitContainerMonster";
            // 
            // splitContainerMonster.Panel1
            // 
            this.splitContainerMonster.Panel1.Controls.Add(this.buttonSearch);
            this.splitContainerMonster.Panel1.Controls.Add(this.dataGridViewMonster);
            this.splitContainerMonster.Panel1.Controls.Add(this.textBoxSearchMonster);
            this.splitContainerMonster.Panel1MinSize = 220;
            // 
            // splitContainerMonster.Panel2
            // 
            this.splitContainerMonster.Panel2.Controls.Add(this.splitContainerSkillData);
            this.splitContainerMonster.Size = new System.Drawing.Size(786, 418);
            this.splitContainerMonster.SplitterDistance = 623;
            this.splitContainerMonster.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(546, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(73, 20);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.SearchMonster);
            // 
            // dataGridViewMonster
            // 
            this.dataGridViewMonster.AllowUserToAddRows = false;
            this.dataGridViewMonster.AllowUserToDeleteRows = false;
            this.dataGridViewMonster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMonster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMonster.Location = new System.Drawing.Point(0, 26);
            this.dataGridViewMonster.MultiSelect = false;
            this.dataGridViewMonster.Name = "dataGridViewMonster";
            this.dataGridViewMonster.ReadOnly = true;
            this.dataGridViewMonster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMonster.Size = new System.Drawing.Size(619, 392);
            this.dataGridViewMonster.TabIndex = 1;
            this.dataGridViewMonster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnMonsterClick);
            // 
            // textBoxSearchMonster
            // 
            this.textBoxSearchMonster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchMonster.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearchMonster.Name = "textBoxSearchMonster";
            this.textBoxSearchMonster.Size = new System.Drawing.Size(540, 20);
            this.textBoxSearchMonster.TabIndex = 0;
            // 
            // splitContainerSkillData
            // 
            this.splitContainerSkillData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerSkillData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSkillData.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSkillData.Name = "splitContainerSkillData";
            this.splitContainerSkillData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSkillData.Panel1
            // 
            this.splitContainerSkillData.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainerSkillData.Panel1.Controls.Add(this.vSroSmallButton1);
            // 
            // splitContainerSkillData.Panel2
            // 
            this.splitContainerSkillData.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainerSkillData.Size = new System.Drawing.Size(159, 418);
            this.splitContainerSkillData.SplitterDistance = 32;
            this.splitContainerSkillData.TabIndex = 0;
            // 
            // vSroSmallButton1
            // 
            this.vSroSmallButton1.Location = new System.Drawing.Point(1, 1);
            this.vSroSmallButton1.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.Name = "vSroSmallButton1";
            this.vSroSmallButton1.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButton1.TabIndex = 0;
            this.vSroSmallButton1.vSroSmallButtonName = "Load Skill requirements";
            this.vSroSmallButton1.vSroClickEvent += new ServerFrameworkRes.BasicControls.vSroSmallButton.vSroClick(this.vSroSmallButton1_vSroClickEvent);
            // 
            // tabPageCharSkills
            // 
            this.tabPageCharSkills.BackColor = System.Drawing.Color.DimGray;
            this.tabPageCharSkills.Location = new System.Drawing.Point(4, 22);
            this.tabPageCharSkills.Name = "tabPageCharSkills";
            this.tabPageCharSkills.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCharSkills.Size = new System.Drawing.Size(792, 424);
            this.tabPageCharSkills.TabIndex = 1;
            this.tabPageCharSkills.Text = "tabPage2";
            // 
            // SkillEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Name = "SkillEditorControl";
            this.Size = new System.Drawing.Size(800, 450);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMonsterSkills.ResumeLayout(false);
            this.splitContainerMonster.Panel1.ResumeLayout(false);
            this.splitContainerMonster.Panel1.PerformLayout();
            this.splitContainerMonster.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMonster)).EndInit();
            this.splitContainerMonster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonster)).EndInit();
            this.splitContainerSkillData.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSkillData)).EndInit();
            this.splitContainerSkillData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMonsterSkills;
        private System.Windows.Forms.TabPage tabPageCharSkills;
        private System.Windows.Forms.SplitContainer splitContainerMonster;
        private System.Windows.Forms.DataGridView dataGridViewMonster;
        private System.Windows.Forms.TextBox textBoxSearchMonster;
        private System.Windows.Forms.SplitContainer splitContainerSkillData;
        private System.Windows.Forms.Button buttonSearch;
        private ServerFrameworkRes.BasicControls.vSroSmallButton vSroSmallButton1;
    }
}
