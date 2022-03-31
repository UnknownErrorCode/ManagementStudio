using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class ClientForm : Form
    {
        #region Constructors

        public ClientForm()
        {
            InitializeComponent();
            Controls.Add(ClientDataStorage.Log.Logger);
            ClientDataStorage.ClientCore.OnDataReceived += OnReceiveAllData;
            ClientDataStorage.ClientCore.OnAllowedPluginReceived += OnAllowedPluginReceived;
        }

        #endregion Constructors

        #region Properties

        private bool Pk2Initialized => ClientDataStorage.Client.Media.MediaPk2.Initialized && ClientDataStorage.Client.Map.Reader.Initialized;

        #endregion Properties

        #region Methods

        private void ClickLoadPlugin(object sender, EventArgs e)
        {
            ToolStripItem itm = (ToolStripItem)sender;

            // ServerFrameworkRes.Network.Security.Packet pack = ClientDataStorage.Network.ClientPacketFormat.RequestPluginDataTables(itm.Text);
            //
            // ClientDataStorage.ClientCore.Send(pack);
            //
            if (TryLoadPlugin(itm.Text, out TabPage page))
            {
                tabControlPlugins.TabPages.Add(page);
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ClientDataStorage.Log.Logger.WriteLogLine("Loading pk2 ressources...");

            if (!InitializePk2Files().Result)
            {
                ClientDataStorage.Log.Logger.WriteLogLine("Failed initialize pk2 ressources!");
            }
        }

        private async Task<bool> InitializePk2Files()
        {
            if (!await ClientDataStorage.Client.Media.InitializeMediaAsync())
            {
                return false;
            }

            if (!await ClientDataStorage.Client.Map.InitializeMapAsync())
            {
                return false;
            }

            if (!await ClientDataStorage.Client.DataPack.InitializeDataAsync())
            {
                return false;
            }

            return ClientDataStorage.Client.Media.MediaPk2.Initialized && ClientDataStorage.Client.Map.Reader.Initialized;
        }

        private void OnAllowedPluginReceived()
        {
            Invoke(new Action(() =>
            {
                foreach (string pluginName in ClientDataStorage.ClientMemory.AllowedPlugin)
                {
                    loadPluginsToolStripMenuItem.DropDownItems.Add(pluginName);
                    loadPluginsToolStripMenuItem.DropDownItems[loadPluginsToolStripMenuItem.DropDownItems.Count - 1].Click += ClickLoadPlugin;
                }
                loadPluginsToolStripMenuItem.Enabled = true;
            }));
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            ClientDataStorage.ClientMemory.LoggedIn = false;
            Program.StaticLoginForm.Close();
            GC.Collect(5);
        }

        private void OnReceiveAllData()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { loadPluginsToolStripMenuItem.Enabled = true; }));
            }
            else
            {
                loadPluginsToolStripMenuItem.Enabled = true;
            }
        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm(Program.MainConfig))
            {
                form.InitializeSettings();
                form.ShowDialog();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClientDataStorage.Log.Logger.Visible)
            {
                ClientDataStorage.Log.Logger.Show();
            }
        }

        private bool TryLoadPlugin(string text, out TabPage tabPage)
        {
            tabPage = new TabPage(text);
            if (ClientDataStorage.ClientMemory.AllowedPlugin.Contains(text))
            {
                var p = Path.Combine("Plugins", text);
                Assembly plugin = Assembly.LoadFrom(p);
                string typeName = text.Replace(".dll", "Control");
                if (plugin.DefinedTypes.Any(typ => typ.Name == typeName))
                {
                    Type dll = plugin.DefinedTypes.Single(typ => typ.Name == typeName);
                    UserControl controlal = (UserControl)Activator.CreateInstance(dll);
                    controlal.Dock = DockStyle.Fill;
                    tabPage.Controls.Add(controlal);

                    ClientDataStorage.ClientMemory.UsedPlugins.Add(text);
                    return true;
                }
            }
            return false;
        }

        #endregion Methods
    }
}