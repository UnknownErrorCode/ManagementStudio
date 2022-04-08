using System;
using System.Windows.Forms;

namespace ManagementClient
{
    internal static class Program
    {
        #region Fields

        internal static PluginFramework.Config MainConfig = new PluginFramework.Config();
        internal static ClientForm StaticClientForm;
        internal static LoginForm StaticLoginForm;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Main entry point for the application!
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StaticLoginForm = new LoginForm();
            StaticClientForm = new ClientForm();
            Application.Run(StaticLoginForm);
        }

        #endregion Methods
    }
}