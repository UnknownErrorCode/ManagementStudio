using ServerFrameworkRes.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            InitializeLogger();
            InitializePk2Files();
            
            ClientDataStorage.Log.Logger.WriteLogLine("Successfully initialized!");
        }

        private void InitializeLogger()
            => this.Controls.Add(ClientDataStorage.Log.Logger);

        private void InitializePk2Files()
        {
            ClientDataStorage.Client.Media.InitializeMediaAsync();
            ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load Media.pk2!");

            ClientDataStorage.Client.Map.InitializeMapAsync();
            ClientDataStorage.Log.Logger.WriteLogLine($"Successfully load Map.Pk2!");

        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            ClientMemory.LoggedIn = false;
            Program.StaticLoginForm.Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
        }

        private void loadPluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string pluginPath in Directory.GetFiles("Plugins\\"))
            {
                if (pluginPath.Contains(".dll")  && ClientMemory.AllowedPlugin.Contains(pluginPath.Remove(0, 8)))
                {
                    Assembly plugin = Assembly.LoadFrom(pluginPath);
                    TabPage tabPage = new TabPage(pluginPath.Remove(0, 8));
                    string typeName = pluginPath.Remove(0, 8).Replace(".dll", "Control");
                    if (plugin.DefinedTypes.Any(typ => typ.Name == typeName))
                    {
                        Type dll = plugin.DefinedTypes.Single(typ => typ.Name == typeName);
                        UserControl controlal = (UserControl)Activator.CreateInstance(dll, Network.ClientCore.CInterface.cData);
                        controlal.Dock = DockStyle.Fill;
                        tabPage.Controls.Add(controlal);
                        tabControlPlugins.TabPages.Add(tabPage);
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
    }
}
