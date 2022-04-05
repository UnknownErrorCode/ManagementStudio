using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class ClientForm : Form
    {
        private bool ReceivedDataTable = false, ReceivedPluginNames = false;

        /// <summary>
        /// The ´main form that consists of all plugindata and the basic requirement ressources.
        /// <br> Pk2 initialization</br>
        /// <br>Data pool and network connection manager</br>
        /// <br>Parent of plugin *.dll</br>
        /// </summary>
        public ClientForm()
        {
            InitializeComponent();
            Controls.Add(ServerFrameworkRes.Log.Logger);
            ClientFrameworkRes.ClientCore.OnDataReceived += OnReceiveAllData;
            ClientFrameworkRes.ClientCore.OnAllowedPluginReceived += OnAllowedPluginReceived;
        }

        private bool Initialized => PackFile.PackFileManager.Initialized && ReceivedPluginNames;



        #region Methods

        private void ClickLoadPlugin(object sender, EventArgs e)
        {
            ToolStripItem itm = (ToolStripItem)sender;

            if (!TryLoadPlugin(itm.Text, out TabPage page))
                return;

            tabControlPlugins.TabPages.RemoveByKey(itm.Text);
            tabControlPlugins.TabPages.Add(page);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.loading, "Loading pk2 ressources...");
            System.Threading.Tasks.Task.Run(() => OnPackFileInitialized());
        }

        private void OnPackFileInitialized()
        {
            if (!PackFile.PackFileManager.InitializePackFiles(ClientFrameworkRes.Config.StaticConfig.ClientPath))
                ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.fatal, "Failed initialize pk2 ressources!");
            else
                ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.success, $"Initialized Client.pk2 data.");

            if (Initialized)
            {
                Invoke(new Action(() =>
                {
                    loadPluginsToolStripMenuItem.Enabled = true;
                }));
            }
        }

        /// <summary>
        /// When receiving all Plugin Names the Client is allowed to load
        /// </summary>
        private void OnAllowedPluginReceived()
        {
            Invoke(new Action(() =>
            {
                foreach (string pluginName in ClientFrameworkRes.ClientMemory.AllowedPlugin)
                {
                    loadPluginsToolStripMenuItem.DropDownItems.Add(pluginName);
                    loadPluginsToolStripMenuItem.DropDownItems[loadPluginsToolStripMenuItem.DropDownItems.Count - 1].Click += ClickLoadPlugin;
                }
                ReceivedPluginNames = true;
                if (Initialized)
                {
                    loadPluginsToolStripMenuItem.Enabled = true;
                }
            }));
            ServerFrameworkRes.Log.Logger.WriteLogLine($"Allowed [{ClientFrameworkRes.ClientMemory.AllowedPlugin.Length}] *.dll libraries");
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            ClientFrameworkRes.ClientMemory.LoggedIn = false;
            Program.StaticLoginForm.Close();
            GC.Collect(5);
        }

        /// <summary>
        /// To avoid pooling wrong DataTable or illegal data into the memory.
        /// </summary>
        private void OnReceiveAllData() => ReceivedDataTable = true;

        /// <summary>
        /// Opens the <see cref="SettingsForm"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm(Program.MainConfig))
            {
                form.InitializeSettings();
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Show and hide the Logger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showToolStripMenuItem_Click(object sender, EventArgs e) => ServerFrameworkRes.Log.Logger.Visible = !ServerFrameworkRes.Log.Logger.Visible;

        /// <summary>
        /// Try load a Plugin into the Control
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tabPage"></param>
        /// <returns></returns>
        private bool TryLoadPlugin(string text, out TabPage tabPage)
        {
            if (ClientFrameworkRes.ClientMemory.UsedPlugins.Contains(text))
                ClientFrameworkRes.ClientMemory.UsedPlugins.Remove(text);

            tabPage = new TabPage(text);
            if (ClientFrameworkRes.ClientMemory.AllowedPlugin.Contains(text))
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

                    ClientFrameworkRes.ClientMemory.UsedPlugins.Add(text);
                    return true;
                }
            }
            return false;
        }

        #endregion Methods
    }
}