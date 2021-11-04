using ServerFrameworkRes.BasicControls;
using System;
using ManagementClient.Network;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;

namespace ManagementClient
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomnComponent();
        }
        /// <summary>
        /// Initialize vSroInterface Component properties
        /// </summary>
        private void InitializeCustomnComponent()
        {
            this.vSroInputBox1.ValueText = Program.MainConfig.PToolUser;
            this.vSroInputBox2.ValueText = Program.MainConfig.PToolUserPassword;
            this.vSroCheckBox1.ChangeStatus(Program.MainConfig.ShowPwInText);
            this.vSroCheckBoxSaveLogin.ChangeStatus(Program.MainConfig.ToolSaveUserData);
            vSroCheckBox1.vSroCheckChange += VSroCheckBox1_vSroCheckChange;
            vSroCheckBoxSaveLogin.vSroCheckChange += OnCheckChangeSaveUserData;
        }

        private void OnCheckChangeSaveUserData(object sender, EventArgs e)
        {
            Program.MainConfig.ConfigEditor.IniWriteValue("ToolClient", "SaveUserData", vSroCheckBoxSaveLogin.vSroCheck.ToString());
        }

        /// <summary>
        /// Initialize Click Event with password box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VSroCheckBox1_vSroCheckChange(object sender, EventArgs e)
        {
            Program.MainConfig.ConfigEditor.IniWriteValue("ToolClient", "ShowPW", vSroCheckBox1.vSroCheck.ToString());
            this.vSroInputBox2.vSroUseSystemPasswordChar = Program.MainConfig.ShowPwInText ? false : true;
        }

        /// <summary>
        /// Start authentification to server with account informations
        /// </summary>
        private void vSroSmallButtonLogin_vSroClickEvent()
        {
            if (vSroInputBox1.ValueText.Length == 0)
            { vSroMessageBox.Show("Please type in your username!", "Invalid username"); return; }

            if (vSroInputBox2.ValueText.Length == 0)
            { vSroMessageBox.Show("Please type in your password!", "Invalid password"); return; }


            Program.MainConfig.PToolUser = vSroInputBox1.ValueText;
            Program.MainConfig.PToolUserPassword = vSroInputBox2.ValueText;
            Packet requestLogin = new Packet(0x1000);
            requestLogin.WriteAscii(vSroInputBox1.ValueText);
            requestLogin.WriteAscii(Utility.MD5Generator.MD5String(vSroInputBox2.ValueText));
            ClientCore.Send(requestLogin);

        }

        private void ClientTool_Load(object sender, EventArgs e)
        {
            this.vSroSizableWindow1.Title = "Offline";
            Thread startThread = new Thread(Connect);
            startThread.Start();
        }


        private void Connect()
        {
            if (ClientCore.Connected)
                return;

            var connected = ClientCore.Start().GetAwaiter().GetResult();
            if (connected)
                this.vSroSmallButtonLogin.Invoke(new Action(() => { this.vSroSmallButtonLogin.Enabled = true; }));
            else
            {
                vSroMessageBox.Show("The connection to server failed", "Connection failed");
                this.vSroSmallButtonLogin.Invoke(new Action(() => { this.vSroSmallButtonLogin.Enabled = false; }));
            }
            Invoke(new Action(() => this.vSroSizableWindow1.Title = connected ? "Online" : "Offline"));
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (!ClientMemory.LoggedIn)
                ClientCore.Disconnect();
          
        }
        internal void OnHide()
        {
            Program.StaticClientForm.Show();
            this.Visible = false;
        }

        private void vSroInputBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar =='\n')
            {
                vSroSmallButtonLogin_vSroClickEvent();
            }
        }
    }
}
