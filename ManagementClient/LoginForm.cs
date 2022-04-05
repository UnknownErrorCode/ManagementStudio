using ClientFrameworkRes;
using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class LoginForm : Form
    {
        #region Constructors

        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomnComponent();
        }

        #endregion Constructors

        #region Methods

        internal void OnHide()
        {
            Program.StaticClientForm.Show();
            Visible = false;
        }

        /// <summary>
        /// The Login user status consists of either success or fail, resultMessage, Security Group and real AccountName.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>PacketHandlerResult result</returns>
        private static PacketHandlerResult LoginStatus(ServerData arg1, Packet arg2)
        {
            LoginStatus status = arg2.ReadStruct<LoginStatus>();

            if (status.Success)
            {
                ClientMemory.LoggedIn = true;
                arg1.AccountName = status.UserName;
                Program.StaticLoginForm.Invoke(new Action(() => Program.StaticLoginForm.OnHide()));
                var packet = new Packet(PacketID.Client.RequestAllowedPlugins);
                ClientCore.Send(packet);
            }
            else
            {
                vSroMessageBox.Show($"Login failed! \n{status.Notification}");
            }

            return PacketHandlerResult.Block;
        }

        private void ClientTool_Load(object sender, EventArgs e)
        {
            vSroSizableWindow1.Title = "Offline";
            Thread startThread = new Thread(Connect);
            startThread.Start();
        }

        private void Connect()
        {
            if (ClientCore.Connected)
            {
                return;
            }

            bool connected = ClientCore.Start();
            if (connected)
            {
                vSroSmallButtonLogin.Invoke(new Action(() => { vSroSmallButtonLogin.Enabled = true; }));
            }
            else
            {
                vSroMessageBox.Show("The connection to server failed", "Connection failed");
                vSroSmallButtonLogin.Invoke(new Action(() => { vSroSmallButtonLogin.Enabled = false; }));
            }
            Invoke(new Action(() => vSroSizableWindow1.Title = connected ? "Online" : "Offline"));
        }

        /// <summary>
        /// Initialize vSroInterface Component properties
        /// </summary>
        private void InitializeCustomnComponent()
        {
            vSroInputBox1.ValueText = Program.MainConfig.PToolUser;
            vSroInputBox2.ValueText = Program.MainConfig.PToolUserPassword;
            vSroCheckBox1.ChangeStatus(Program.MainConfig.ShowPwInText);
            vSroCheckBoxSaveLogin.ChangeStatus(Program.MainConfig.ToolSaveUserData);
            vSroCheckBox1.vSroCheckChange += VSroCheckBox1_vSroCheckChange;
            vSroCheckBoxSaveLogin.vSroCheckChange += OnCheckChangeSaveUserData;
            ClientCore.AddEntry(PacketID.Server.LoginStatusResponse, LoginStatus);
        }

        private void OnCheckChangeSaveUserData(object sender, EventArgs e)
        {
            Program.MainConfig.ConfigEditor.IniWriteValue("ToolClient", "SaveUserData", vSroCheckBoxSaveLogin.vSroCheck.ToString());
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (!ClientMemory.LoggedIn)
            {
                ClientCore.Disconnect();
            }
        }

        /// <summary>
        /// Initialize Click Event with password box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VSroCheckBox1_vSroCheckChange(object sender, EventArgs e)
        {
            Program.MainConfig.ConfigEditor.IniWriteValue("ToolClient", "ShowPW", vSroCheckBox1.vSroCheck.ToString());
            vSroInputBox2.vSroUseSystemPasswordChar = Program.MainConfig.ShowPwInText ? false : true;
        }

        private void vSroInputBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
            {
                vSroSmallButtonLogin_vSroClickEvent();
            }
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
            Packet requestLogin = new Packet(PacketID.Client.Login);
            requestLogin.WriteAscii(vSroInputBox1.ValueText);
            requestLogin.WriteAscii(ServerFrameworkRes.Utility.MD5Generator.MD5String(vSroInputBox2.ValueText));
            ClientCore.Send(requestLogin);
        }

        #endregion Methods
    }
}