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
        internal static LogGridView Logger = new LogGridView() { Dock = DockStyle.Bottom};
        public ClientForm()
        {
            InitializeComponent();
            this.Controls.Add(Logger);
            Logger.WriteLogLine("Successfully initialized!");
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
            ClientMemory.AllowedPlugin = new string[1] {"Dashboard.dll" };
            foreach (string pluginPath in Directory.GetFiles("Plugins\\"))
            {
                if (pluginPath.Contains(".dll")  && ClientMemory.AllowedPlugin.Contains(pluginPath.Remove(0, 8)))
                {
                    Assembly plugin = Assembly.LoadFrom(pluginPath);
                    TabPage tabPage = new TabPage(pluginPath.Remove(0, 8));
                    string typeName = pluginPath.Remove(0, 8).Replace(".dll", "");
                    Type dll = plugin.DefinedTypes.Single(typ => typ.Name == typeName);
                    UserControl controlal = (UserControl)Activator.CreateInstance(dll, Network.ClientCore.CInterface.cData);
                    controlal.Dock = DockStyle.Fill;
                    tabPage.Controls.Add(controlal);
                    tabControl1.TabPages.Add(tabPage);
                }
            }

            this.loadPluginsToolStripMenuItem.Checked = true;
            this.loadPluginsToolStripMenuItem.Enabled = false;
        }
    }
}
