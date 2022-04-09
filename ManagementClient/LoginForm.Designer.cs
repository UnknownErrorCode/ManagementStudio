
namespace ManagementClient
{
    partial class LoginForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.vSroCheckBox1 = new PluginFramework.BasicControls.vSroCheckBox();
            this.vSroSmallButtonLogin = new PluginFramework.BasicControls.vSroSmallButton();
            this.vSroInputBox2 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroInputBox1 = new PluginFramework.BasicControls.vSroInputBox();
            this.vSroSizableWindow1 = new PluginFramework.BasicControls.vSroSizableWindow();
            this.vSroCheckBoxSaveLogin = new PluginFramework.BasicControls.vSroCheckBox();
            this.SuspendLayout();
            // 
            // vSroCheckBox1
            // 
            this.vSroCheckBox1.AutoSize = true;
            this.vSroCheckBox1.BackColor = System.Drawing.Color.Black;
            this.vSroCheckBox1.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBox1.Location = new System.Drawing.Point(40, 133);
            this.vSroCheckBox1.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBox1.Name = "vSroCheckBox1";
            this.vSroCheckBox1.Size = new System.Drawing.Size(137, 16);
            this.vSroCheckBox1.TabIndex = 5;
            this.vSroCheckBox1.vSroCheck = false;
            this.vSroCheckBox1.vSroCheckBoxName = "Show password";
            // 
            // vSroSmallButtonLogin
            // 
            this.vSroSmallButtonLogin.Location = new System.Drawing.Point(75, 202);
            this.vSroSmallButtonLogin.MaximumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLogin.MinimumSize = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLogin.Name = "vSroSmallButtonLogin";
            this.vSroSmallButtonLogin.Size = new System.Drawing.Size(152, 24);
            this.vSroSmallButtonLogin.TabIndex = 4;
            this.vSroSmallButtonLogin.vSroSmallButtonName = "Login";
            this.vSroSmallButtonLogin.vSroClickEvent += new PluginFramework.BasicControls.vSroSmallButton.vSroClick(this.vSroSmallButtonLogin_vSroClickEvent);
            // 
            // vSroInputBox2
            // 
            this.vSroInputBox2.AutoSize = true;
            this.vSroInputBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox2.BackgroundImage")));
            this.vSroInputBox2.Location = new System.Drawing.Point(40, 87);
            this.vSroInputBox2.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox2.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox2.Name = "vSroInputBox2";
            this.vSroInputBox2.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox2.TabIndex = 3;
            this.vSroInputBox2.TitleText = "Password:";
            this.vSroInputBox2.ValueText = "";
            this.vSroInputBox2.vSroUseSystemPasswordChar = true;
            this.vSroInputBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vSroInputBox2_KeyPress);
            // 
            // vSroInputBox1
            // 
            this.vSroInputBox1.AutoSize = true;
            this.vSroInputBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vSroInputBox1.BackgroundImage")));
            this.vSroInputBox1.Location = new System.Drawing.Point(40, 41);
            this.vSroInputBox1.MaximumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox1.MinimumSize = new System.Drawing.Size(250, 40);
            this.vSroInputBox1.Name = "vSroInputBox1";
            this.vSroInputBox1.Size = new System.Drawing.Size(250, 40);
            this.vSroInputBox1.TabIndex = 2;
            this.vSroInputBox1.TitleText = "Username:";
            this.vSroInputBox1.ValueText = "";
            this.vSroInputBox1.vSroUseSystemPasswordChar = false;
            // 
            // vSroSizableWindow1
            // 
            this.vSroSizableWindow1.BackColor = System.Drawing.Color.Black;
            this.vSroSizableWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vSroSizableWindow1.Location = new System.Drawing.Point(0, 0);
            this.vSroSizableWindow1.Name = "vSroSizableWindow1";
            this.vSroSizableWindow1.Size = new System.Drawing.Size(325, 238);
            this.vSroSizableWindow1.TabIndex = 0;
            this.vSroSizableWindow1.Title = "RekciD Tool Client";
            // 
            // vSroCheckBoxSaveLogin
            // 
            this.vSroCheckBoxSaveLogin.AutoSize = true;
            this.vSroCheckBoxSaveLogin.BackColor = System.Drawing.Color.Black;
            this.vSroCheckBoxSaveLogin.ForeColor = System.Drawing.Color.White;
            this.vSroCheckBoxSaveLogin.Location = new System.Drawing.Point(40, 155);
            this.vSroCheckBoxSaveLogin.MinimumSize = new System.Drawing.Size(16, 16);
            this.vSroCheckBoxSaveLogin.Name = "vSroCheckBoxSaveLogin";
            this.vSroCheckBoxSaveLogin.Size = new System.Drawing.Size(191, 16);
            this.vSroCheckBoxSaveLogin.TabIndex = 6;
            this.vSroCheckBoxSaveLogin.vSroCheck = false;
            this.vSroCheckBoxSaveLogin.vSroCheckBoxName = "Save user data on login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 238);
            this.Controls.Add(this.vSroCheckBoxSaveLogin);
            this.Controls.Add(this.vSroCheckBox1);
            this.Controls.Add(this.vSroSmallButtonLogin);
            this.Controls.Add(this.vSroInputBox2);
            this.Controls.Add(this.vSroInputBox1);
            this.Controls.Add(this.vSroSizableWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.ClientTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PluginFramework.BasicControls.vSroSizableWindow vSroSizableWindow1;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox1;
        private PluginFramework.BasicControls.vSroInputBox vSroInputBox2;
        private PluginFramework.BasicControls.vSroSmallButton vSroSmallButtonLogin;
        private PluginFramework.BasicControls.vSroCheckBox vSroCheckBox1;
        private PluginFramework.BasicControls.vSroCheckBox vSroCheckBoxSaveLogin;
    }
}

