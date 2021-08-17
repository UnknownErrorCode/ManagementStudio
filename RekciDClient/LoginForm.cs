using ServerFrameworkRes.BasicControls;
using System;
using RekciDClient.Network;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RekciDClient
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
            this.vSroInputBox1.ValueText = Program.MainConfig.ToolUser();
            this.vSroInputBox2.ValueText = Program.MainConfig.ToolUserPassword();
            this.vSroCheckBox1.ChangeStatus(Program.MainConfig.ShowPwInText());
            vSroCheckBox1.vSroCheckChange += VSroCheckBox1_vSroCheckChange;
        }

        /// <summary>
        /// Initialize Click Event with password box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VSroCheckBox1_vSroCheckChange(object sender, EventArgs e)
        {
            Program.MainConfig.ConfigEditor.IniWriteValue("ToolClient", "ShowPW", vSroCheckBox1.vSroCheck.ToString());
            this.vSroInputBox2.vSroUseSystemPasswordChar = Program.MainConfig.ShowPwInText() ? false : true;
        }

        /// <summary>
        /// Start authentification to server with account informations
        /// </summary>
        private void vSroSmallButtonLogin_vSroClickEvent()
        {
            if (vSroInputBox1.ValueText.Length == 0)
            { vSroMessageBox.Show("Please type in your username!", "Invalid username"); return; }
            else
                ClientMemory.LatestAccountName = vSroInputBox1.ValueText;



            if (vSroInputBox2.ValueText.Length == 0)
            { vSroMessageBox.Show("Please type in your password!", "Invalid password"); return; }
            else
                ClientMemory.LatestPassword = vSroInputBox2.ValueText;

            this.vSroSmallButtonLogin.Enabled = false;

            Thread startThread = new Thread(Connect);
            startThread.Start();

        }

        private void ClientTool_Load(object sender, EventArgs e)
        {
            ClientMemory.Authorized = false;
        }


        private void Connect()
        {
            if (ClientCore.Connected)
                return;

            var connected = ClientCore.Start().GetAwaiter().GetResult();
            if (connected)
            {
                vSroMessageBox.Show("The connection to server has been established.\nAccount authentification started...", "Connection established");
                if (ClientMemory.Authorized)
                {
                    Application.Run(new ClientForm());
                    this.Close();
                }
            }
            else
            {
                vSroMessageBox.Show("The connection to server failed", "Connection failed");
                this.vSroSmallButtonLogin.Invoke(new Action(() => { this.vSroSmallButtonLogin.Enabled = true; }));
            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (ClientMemory.Authorized != null)
                if (!ClientMemory.Authorized)
                    ClientCore.Disconnect();
        }
    }
}
