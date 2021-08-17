namespace StudioServer
{
    partial class StudioServer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.ServerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ServerLog = new ServerFrameworkRes.Ressources.LogGridView();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.architecturePanel2 = new ServerFrameworkRes.Ressources.Architecture.ArchitecturePanel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSQLConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ServerChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerChart
            // 
            this.ServerChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(24)))));
            this.ServerChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(166)))), ((int)(((byte)(108)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(24)))));
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(166)))), ((int)(((byte)(104)))));
            chartArea2.Name = "ChartArea1";
            this.ServerChart.ChartAreas.Add(chartArea2);
            this.ServerChart.Dock = System.Windows.Forms.DockStyle.Top;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(24)))));
            legend2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(166)))), ((int)(((byte)(106)))));
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend2.Name = "Legend1";
            this.ServerChart.Legends.Add(legend2);
            this.ServerChart.Location = new System.Drawing.Point(0, 24);
            this.ServerChart.Name = "ServerChart";
            this.ServerChart.Size = new System.Drawing.Size(584, 150);
            this.ServerChart.TabIndex = 9;
            this.ServerChart.Text = "chart1";
            // 
            // ServerLog
            // 
            this.ServerLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ServerLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ServerLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerLog.Location = new System.Drawing.Point(0, 311);
            this.ServerLog.Name = "ServerLog";
            this.ServerLog.Size = new System.Drawing.Size(584, 150);
            this.ServerLog.TabIndex = 10;
            this.ServerLog.TypeOfModuleLog = ServerFrameworkRes.Network.ServerStructs.ModuleType.None;
            // 
            // splitter3
            // 
            this.splitter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(0, 304);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(584, 7);
            this.splitter3.TabIndex = 11;
            this.splitter3.TabStop = false;
            // 
            // architecturePanel2
            // 
            this.architecturePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.architecturePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.architecturePanel2.Location = new System.Drawing.Point(0, 156);
            this.architecturePanel2.Name = "architecturePanel2";
            this.architecturePanel2.Size = new System.Drawing.Size(584, 148);
            this.architecturePanel2.TabIndex = 12;
            // 
            // splitter4
            // 
            this.splitter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 149);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(584, 7);
            this.splitter4.TabIndex = 13;
            this.splitter4.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.managerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServerToolStripMenuItem,
            this.testSQLConnectionToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // startServerToolStripMenuItem
            // 
            this.startServerToolStripMenuItem.Name = "startServerToolStripMenuItem";
            this.startServerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.startServerToolStripMenuItem.Text = "Start Server";
            this.startServerToolStripMenuItem.Click += new System.EventHandler(this.startServerToolStripMenuItem_Click);
            // 
            // testSQLConnectionToolStripMenuItem
            // 
            this.testSQLConnectionToolStripMenuItem.Name = "testSQLConnectionToolStripMenuItem";
            this.testSQLConnectionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.testSQLConnectionToolStripMenuItem.Text = "Test SQL Connection";
            this.testSQLConnectionToolStripMenuItem.Click += new System.EventHandler(this.testSQLConnectionToolStripMenuItem_Click);
            // 
            // managerToolStripMenuItem
            // 
            this.managerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patchManagerToolStripMenuItem});
            this.managerToolStripMenuItem.Name = "managerToolStripMenuItem";
            this.managerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.managerToolStripMenuItem.Text = "Manager";
            // 
            // patchManagerToolStripMenuItem
            // 
            this.patchManagerToolStripMenuItem.Name = "patchManagerToolStripMenuItem";
            this.patchManagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patchManagerToolStripMenuItem.Text = "PatchManager";
            this.patchManagerToolStripMenuItem.Click += new System.EventHandler(this.patchManagerToolStripMenuItem_Click);
            // 
            // StudioServer
            // 
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.architecturePanel2);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.ServerLog);
            this.Controls.Add(this.ServerChart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StudioServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudioServer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ServerChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ServerFrameworkRes.Ressources.LogGridView logGridView1;
        private System.Windows.Forms.Splitter splitter1;
        private ServerFrameworkRes.Ressources.Architecture.ArchitecturePanel architecturePanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart CertificationChart;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ServerChart;
        public ServerFrameworkRes.Ressources.LogGridView ServerLog;
        private System.Windows.Forms.Splitter splitter3;
        private ServerFrameworkRes.Ressources.Architecture.ArchitecturePanel architecturePanel2;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testSQLConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchManagerToolStripMenuItem;
    }
}

