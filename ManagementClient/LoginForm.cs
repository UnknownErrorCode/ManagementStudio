using PluginFramework;
using PluginFramework.BasicControls;
using ManagementFramework.Network.Security;
using Structs.Tool;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class LoginForm : Form
    {
        #region Constructors

        /// <summary>
        /// Interface to login.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomnComponent();
        }

        #endregion Constructors

        #region Methods

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
                arg1.AccountName = status.UserName;
                Program.StaticLoginForm.Invoke(new Action(() => Program.StaticLoginForm.OnHide()));
                ClientCore.Send(new Packet(PacketID.Client.RequestAllowedPlugins));
            }
            else
                vSroMessageBox.Show($"Login failed! \n{status.Notification}");

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
                return;

            if (ClientCore.Start())
                vSroSmallButtonLogin.Invoke(new Action(() => { vSroSmallButtonLogin.Enabled = true; }));
            else
            {
                vSroMessageBox.Show("The connection to server failed", "Connection failed");
                vSroSmallButtonLogin.Invoke(new Action(() => { vSroSmallButtonLogin.Enabled = false; }));
            }
            Invoke(new Action(() => vSroSizableWindow1.Title = ClientCore.Connected ? "Online" : "Offline"));
        }

        /// <summary>
        /// Initialize vSroInterface Component properties
        /// </summary>
        private void InitializeCustomnComponent()
        {
            vSroInputBox1.ValueText = Program.MainConfig.PToolUser;
            vSroInputBox2.ValueText = Program.MainConfig.PToolUserPassword;
            vSroCheckBox1.ChangeStatus(Program.MainConfig.ShowPwInText);
            vSroCheckBoxSaveLogin.ChangeStatus(Program.MainConfig.ToolSaveUserDataOnLogin);
            vSroCheckBox1.vSroCheckChange += VSroCheckBox1_vSroCheckChange;
            vSroCheckBoxSaveLogin.vSroCheckChange += OnCheckChangeSaveUserData;
            ClientCore.AddEntry(ManagementFramework.Network.Security.PacketID.Server.LoginStatusResponse, LoginStatus);
        }

        private void OnCheckChangeSaveUserData(object sender, EventArgs e)
        {
            Program.MainConfig.ConfigEditor.IniWriteValue("ToolClient", "SaveUserData", vSroCheckBoxSaveLogin.vSroCheck.ToString());
        }

        /// <summary>
        /// Disconnects the <see cref="ClientCore"/> Thread on exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, FormClosingEventArgs e) => ClientCore.Disconnect();

        /// <summary>
        /// Hides the static login form.
        /// </summary>
        private void OnHide()
        {
            Program.StaticClientForm.Show();
            Visible = false;
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

        /// <summary>
        /// Start authentification to server with account informations
        /// </summary>
        private void vSroSmallButtonLogin_vSroClickEvent()
        {
            if (vSroInputBox1.ValueText.Length == 0)
            { vSroMessageBox.Show("Please type in your username!", "Invalid username"); return; }

            if (vSroInputBox2.ValueText.Length == 0)
            { vSroMessageBox.Show("Please type in your password!", "Invalid password"); return; }

            if (Program.MainConfig.ToolSaveUserDataOnLogin)
            {
                Program.MainConfig.PToolUser = vSroInputBox1.ValueText;
                Program.MainConfig.PToolUserPassword = vSroInputBox2.ValueText;
            }

            ClientCore.Send(PacketFormat.LoginRequest(vSroInputBox1.ValueText, vSroInputBox2.ValueText));
        }

        #endregion Methods
    }
}