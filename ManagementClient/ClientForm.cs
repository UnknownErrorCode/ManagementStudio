using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class ClientForm : Form
    {
        #region Constructors

        public ClientForm()
        {
            InitializeComponent();
            Controls.Add(ServerFrameworkRes.Log.Logger);
            ClientFrameworkRes.ClientCore.OnDataReceived += OnReceiveAllData;
            ClientFrameworkRes.ClientCore.OnAllowedPluginReceived += OnAllowedPluginReceived;
        }

        #endregion Constructors

        #region Methods

        private void ClickLoadPlugin(object sender, EventArgs e)
        {
            ToolStripItem itm = (ToolStripItem)sender;

            if (TryLoadPlugin(itm.Text, out TabPage page))
                tabControlPlugins.TabPages.Add(page);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ServerFrameworkRes.Log.Logger.WriteLogLine("Loading pk2 ressources...");

            if (!PackFile.PackFileManager.InitializePackFiles(ClientFrameworkRes.Config.StaticConfig.ClientPath))
                ServerFrameworkRes.Log.Logger.WriteLogLine("Failed initialize pk2 ressources!");
        }

        private void OnAllowedPluginReceived()
        {
            Invoke(new Action(() =>
            {
                foreach (string pluginName in ClientFrameworkRes.ClientMemory.AllowedPlugin)
                {
                    loadPluginsToolStripMenuItem.DropDownItems.Add(pluginName);
                    loadPluginsToolStripMenuItem.DropDownItems[loadPluginsToolStripMenuItem.DropDownItems.Count - 1].Click += ClickLoadPlugin;
                }
                loadPluginsToolStripMenuItem.Enabled = true;
            }));
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            ClientFrameworkRes.ClientMemory.LoggedIn = false;
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
            if (!ServerFrameworkRes.Log.Logger.Visible)
            {
                ServerFrameworkRes.Log.Logger.Show();
            }
        }

        private bool TryLoadPlugin(string text, out TabPage tabPage)
        {
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