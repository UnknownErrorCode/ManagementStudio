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

        public ClientForm()
        {
            InitializeComponent();
            ClientDataStorage.Network.ClientCore.OnDataReceived += OnReceiveAllData;
            this.Controls.Add(ClientDataStorage.Log.Logger);
        }

        private async Task<bool> InitializePk2Files()
        {
            if (!await ClientDataStorage.Client.Media.InitializeMediaAsync())
                return false;

            if (!await ClientDataStorage.Client.Map.InitializeMapAsync())
                return false;

            return ClientDataStorage.Client.Media.MediaPk2.Initialized && ClientDataStorage.Client.Map.MapPk2.Initialized;
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
                Invoke(new Action(() => { loadPluginsToolStripMenuItem.Enabled = true; }));
            else
                loadPluginsToolStripMenuItem.Enabled = true;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ClientDataStorage.Log.Logger.WriteLogLine("Successfully initialized Logger!");

            ClientDataStorage.Log.Logger.WriteLogLine("Loading pk2 ressources...");
            if (!InitializePk2Files().Result)
                ClientDataStorage.Log.Logger.WriteLogLine("Failed initialize pk2 ressources!");
        }

        private void loadPluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!ClientDataStorage.Client.Media.MediaPk2.Initialized)
                return;

            if (!ClientDataStorage.Client.Map.MapPk2.Initialized)
                return;
            ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load Media.pk2!");
            ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load Map.Pk2!");
            

            foreach (string pluginPath in Directory.GetFiles("Plugins\\"))
            {
                if (pluginPath.Contains(".dll") && ClientDataStorage.ClientMemory.AllowedPlugin.Contains(pluginPath.Remove(0, 8)))
                {
                    Assembly plugin = Assembly.LoadFrom(pluginPath);
                    TabPage tabPage = new TabPage(pluginPath.Remove(0, 8));
                    string typeName = pluginPath.Remove(0, 8).Replace(".dll", "Control");
                    if (plugin.DefinedTypes.Any(typ => typ.Name == typeName))
                    {
                        Type dll = plugin.DefinedTypes.Single(typ => typ.Name == typeName);
                        UserControl controlal = (UserControl)Activator.CreateInstance(dll);
                        controlal.Dock = DockStyle.Fill;
                        tabPage.Controls.Add(controlal);
                        tabControlPlugins.TabPages.Add(tabPage);
                        ClientDataStorage.ClientMemory.UsedPlugins.Add(pluginPath.Remove(0, 8));
                    }
                }
            }

            this.loadPluginsToolStripMenuItem.Checked = true;
            this.loadPluginsToolStripMenuItem.Enabled = false;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClientDataStorage.Log.Logger.Visible)
                ClientDataStorage.Log.Logger.Show();
        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm(Program.MainConfig))
            {
                form.InitializeSettings();
                form.ShowDialog();
            }
        }
    }
}
