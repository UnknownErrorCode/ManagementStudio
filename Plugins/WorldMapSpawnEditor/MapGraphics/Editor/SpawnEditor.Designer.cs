
namespace WorldMapSpawnEditor.MapGraphics
{
    partial class SpawnEditor
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
            this.propertyGrid5 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonShowUpdateNest = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonShowUpdateHive = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonShowUpdateTactics = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonShowUpdateCommon = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonShowUpdateChar = new System.Windows.Forms.Button();
            this.buttonSelectNewPosition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(3, 23);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeNestValue);
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid2.Location = new System.Drawing.Point(197, 23);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid2.TabIndex = 3;
            this.propertyGrid2.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeHive);
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid3.Location = new System.Drawing.Point(391, 23);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid3.TabIndex = 6;
            this.propertyGrid3.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeTacticsValue);
            // 
            // propertyGrid4
            // 
            this.propertyGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid4.Location = new System.Drawing.Point(585, 23);
            this.propertyGrid4.Name = "propertyGrid4";
            this.propertyGrid4.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid4.TabIndex = 9;
            this.propertyGrid4.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeObjCommonValue);
            // 
            // propertyGrid5
            // 
            this.propertyGrid5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid5.Location = new System.Drawing.Point(779, 23);
            this.propertyGrid5.Name = "propertyGrid5";
            this.propertyGrid5.Size = new System.Drawing.Size(188, 342);
            this.propertyGrid5.TabIndex = 12;
            this.propertyGrid5.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ChangeObjChar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tab_RefNest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tab_RefHive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "_RefObjCommon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tab_RefTactics";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(776, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "_RefObjChar";
            // 
            // buttonShowUpdateNest
            // 
            this.buttonShowUpdateNest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowUpdateNest.Location = new System.Drawing.Point(3, 371);
            this.buttonShowUpdateNest.Name = "buttonShowUpdateNest";
            this.buttonShowUpdateNest.Size = new System.Drawing.Size(91, 23);
            this.buttonShowUpdateNest.TabIndex = 1;
            this.buttonShowUpdateNest.Text = "Show Update";
            this.buttonShowUpdateNest.UseVisualStyleBackColor = true;
            this.buttonShowUpdateNest.Click += new System.EventHandler(this.ShowNestUpdate);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(294, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonShowUpdateHive
            // 
            this.buttonShowUpdateHive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowUpdateHive.Location = new System.Drawing.Point(197, 371);
            this.buttonShowUpdateHive.Name = "buttonShowUpdateHive";
            this.buttonShowUpdateHive.Size = new System.Drawing.Size(91, 23);
            this.buttonShowUpdateHive.TabIndex = 4;
            this.buttonShowUpdateHive.Text = "Show Update";
            this.buttonShowUpdateHive.UseVisualStyleBackColor = true;
            this.buttonShowUpdateHive.Click += new System.EventHandler(this.ShowUpdateHive);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(488, 371);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonShowUpdateTactics
            // 
            this.buttonShowUpdateTactics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowUpdateTactics.Location = new System.Drawing.Point(391, 371);
            this.buttonShowUpdateTactics.Name = "buttonShowUpdateTactics";
            this.buttonShowUpdateTactics.Size = new System.Drawing.Size(91, 23);
            this.buttonShowUpdateTactics.TabIndex = 7;
            this.buttonShowUpdateTactics.Text = "Show Update";
            this.buttonShowUpdateTactics.UseVisualStyleBackColor = true;
            this.buttonShowUpdateTactics.Click += new System.EventHandler(this.ShowUpdateTactics);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Location = new System.Drawing.Point(682, 371);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // buttonShowUpdateCommon
            // 
            this.buttonShowUpdateCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowUpdateCommon.Location = new System.Drawing.Point(585, 371);
            this.buttonShowUpdateCommon.Name = "buttonShowUpdateCommon";
            this.buttonShowUpdateCommon.Size = new System.Drawing.Size(91, 23);
            this.buttonShowUpdateCommon.TabIndex = 10;
            this.buttonShowUpdateCommon.Text = "Show Update";
            this.buttonShowUpdateCommon.UseVisualStyleBackColor = true;
            this.buttonShowUpdateCommon.Click += new System.EventHandler(this.ShowUpdateCommon);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Location = new System.Drawing.Point(876, 371);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(91, 23);
            this.button9.TabIndex = 14;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // buttonShowUpdateChar
            // 
            this.buttonShowUpdateChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowUpdateChar.Location = new System.Drawing.Point(779, 371);
            this.buttonShowUpdateChar.Name = "buttonShowUpdateChar";
            this.buttonShowUpdateChar.Size = new System.Drawing.Size(91, 23);
            this.buttonShowUpdateChar.TabIndex = 13;
            this.buttonShowUpdateChar.Text = "Show Update";
            this.buttonShowUpdateChar.UseVisualStyleBackColor = true;
            this.buttonShowUpdateChar.Click += new System.EventHandler(this.ShowUpdateChar);
            // 
            // buttonSelectNewPosition
            // 
            this.buttonSelectNewPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectNewPosition.Location = new System.Drawing.Point(100, 371);
            this.buttonSelectNewPosition.Name = "buttonSelectNewPosition";
            this.buttonSelectNewPosition.Size = new System.Drawing.Size(91, 23);
            this.buttonSelectNewPosition.TabIndex = 20;
            this.buttonSelectNewPosition.Text = "Select Position";
            this.buttonSelectNewPosition.UseVisualStyleBackColor = true;
            this.buttonSelectNewPosition.Click += new System.EventHandler(this.buttonSelectNewPosition_Click);
            // 
            // SpawnEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 450);
            this.Controls.Add(this.buttonSelectNewPosition);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.buttonShowUpdateChar);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.buttonShowUpdateCommon);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonShowUpdateTactics);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonShowUpdateHive);
            this.Controls.Add(this.buttonShowUpdateNest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyGrid5);
            this.Controls.Add(this.propertyGrid4);
            this.Controls.Add(this.propertyGrid3);
            this.Controls.Add(this.propertyGrid2);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "SpawnEditor";
            this.Text = "SpawnEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.PropertyGrid propertyGrid3;
        private System.Windows.Forms.PropertyGrid propertyGrid4;
        private System.Windows.Forms.PropertyGrid propertyGrid5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonShowUpdateNest;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonShowUpdateHive;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonShowUpdateTactics;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonShowUpdateCommon;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button buttonShowUpdateChar;
        private System.Windows.Forms.Button buttonSelectNewPosition;
    }
}