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
            Controls.Add(ClientDataStorage.Log.Logger);
            ClientDataStorage.ClientCore.OnDataReceived += OnReceiveAllData;
            ClientDataStorage.ClientCore.OnAllowedPluginReceived += OnAllowedPluginReceived;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ClientDataStorage.Log.Logger.WriteLogLine("Loading pk2 ressources...");

            if (!InitializePk2Files().Result)
            {
                ClientDataStorage.Log.Logger.WriteLogLine("Failed initialize pk2 ressources!");
            }
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

        private void ClickLoadPlugin(object sender, EventArgs e)
        {
            ToolStripItem itm = (ToolStripItem)sender;

            ServerFrameworkRes.Network.Security.Packet pack = ClientDataStorage.Network.ClientPacketFormat.RequestPluginDataTables(itm.Text);

            ClientDataStorage.ClientCore.Send(pack);

            if (TryLoadPlugin(itm.Text, out TabPage page))
            {
                tabControlPlugins.TabPages.Add(page);
            }
        }

        private bool TryLoadPlugin(string text, out TabPage tabPage)
        {
            tabPage = new TabPage(text);
            if (ClientDataStorage.ClientMemory.AllowedPlugin.Contains(text))
            {
                Assembly plugin = Assembly.LoadFrom(Path.Combine("Plugins", text));
                string typeName = text.Replace(".dll", "Control");
                if (plugin.DefinedTypes.Any(typ => typ.Name == typeName))
                {
                    Type dll = plugin.DefinedTypes.Single(typ => typ.Name == typeName);
                    UserControl controlal = (UserControl)Activator.CreateInstance(dll, tabPage);
                    controlal.Dock = DockStyle.Fill;
                    // tabPage.Controls.Add(controlal);

                    ClientDataStorage.ClientMemory.UsedPlugins.Add(text);
                    return true;
                }
            }
            return false;
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
            {
                Invoke(new Action(() => { loadPluginsToolStripMenuItem.Enabled = true; }));
            }
            else
            {
                loadPluginsToolStripMenuItem.Enabled = true;
            }
        }

        private bool Pk2Initialized => ClientDataStorage.Client.Media.MediaPk2.Initialized && ClientDataStorage.Client.Map.MapPk2.Initialized;

        private void loadPluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Pk2Initialized)
            {
                return;
            }

            //ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load Media.pk2!");
            //ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load Map.Pk2!");

            foreach (string pluginPath in Directory.GetFiles("Plugins\\").Where(path => path.EndsWith(".dll") && ClientDataStorage.ClientMemory.AllowedPlugin.Contains(path.Remove(0, 8))))
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

            loadPluginsToolStripMenuItem.Checked = true;
            loadPluginsToolStripMenuItem.Enabled = false;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClientDataStorage.Log.Logger.Visible)
            {
                ClientDataStorage.Log.Logger.Show();
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
    }
}