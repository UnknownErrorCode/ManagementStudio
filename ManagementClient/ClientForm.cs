﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ManagementClient
{
    public partial class ClientForm : Form
    {
        /// <summary>
        /// The ´main form that consists of all plugindata and the basic requirement ressources.
        /// <br> Pk2 initialization</br>
        /// <br>Data pool and network connection manager</br>
        /// <br>Parent of plugin *.dll</br>
        /// </summary>
        public ClientForm()
        {
            InitializeComponent();
            Controls.Add(ManagementFramework.Log.Logger);
            PluginFramework.ClientCore.OnAllowedPluginReceived += OnAllowedPluginReceived;
        }

        /// <summary>
        /// User loads a plugin <see cref="TabPage"/> into the <see cref="ClientForm"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickLoadPlugin(object sender, EventArgs e)
        {
            ToolStripItem itm = (ToolStripItem)sender;

            if (!TryLoadPlugin(itm.Text, out TabPage page))
                return;

            loadPluginsToolStripMenuItem.DropDownItems.Remove(itm);
            tabControlPlugins.TabPages.Add(page);
        }

        /// <summary>
        /// Initializes the pk2 data.
        /// </summary>
        private void InitializePackFile()
        {
            ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.loading, "Loading pk2 ressources...");

            if (!PackFile.PackFileManager.InitializePackFiles(PluginFramework.Config.StaticConfig.ClientPath))
                ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.fatal, "Failed initialize pk2 ressources!");
            else
                ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.success, $"Initialized Client.pk2 data.");

            Invoke(new Action(() =>
            {
                loadPluginsToolStripMenuItem.Enabled = true;
            }));
        }

        /// <summary>
        /// When receiving all Plugin Names the Client is allowed to load
        /// </summary>
        private void OnAllowedPluginReceived()
        {
            Invoke(new Action(() =>
            {
                foreach (string pluginName in PluginFramework.ClientMemory.AllowedPlugin)
                {
                    loadPluginsToolStripMenuItem.DropDownItems.Add(pluginName);
                    loadPluginsToolStripMenuItem.DropDownItems[loadPluginsToolStripMenuItem.DropDownItems.Count - 1].Click += ClickLoadPlugin;
                }
            })); System.Threading.Tasks.Task.Run(() => InitializePackFile());
            ManagementFramework.Log.Logger.WriteLogLine($"Allowed [{PluginFramework.ClientMemory.AllowedPlugin.Length}] *.dll libraries");
        }

        /// <summary>
        /// Dhutdown all processes on exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, FormClosingEventArgs e)
        {
            //ClientFrameworkRes.ClientMemory.LoggedIn = false;
            Program.StaticLoginForm.Close();
            GC.Collect(5);
        }

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
        private void showToolStripMenuItem_Click(object sender, EventArgs e) => ManagementFramework.Log.Logger.Visible = !ManagementFramework.Log.Logger.Visible;

        /// <summary>
        /// Try load a Plugin into the Control
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tabPage"></param>
        /// <returns></returns>
        private bool TryLoadPlugin(string text, out TabPage tabPage)
        {
            tabPage = new TabPage(text);
            if (!PluginFramework.ClientMemory.AllowedPlugin.Contains(text))
            {
                return false;
            }
            Assembly plugin = Assembly.LoadFrom(Path.Combine("Plugins", text));
            string typeName = text.Replace(".dll", "Control");
            if (!plugin.DefinedTypes.Any(typ => typ.Name == typeName))
            {
                return false;
            }
            Type dll = plugin.DefinedTypes.Single(typ => typ.Name == typeName);
            UserControl controlal = (UserControl)Activator.CreateInstance(dll);
            controlal.Dock = DockStyle.Fill;
            tabPage.Controls.Add(controlal);

            return true;
        }
    }
}