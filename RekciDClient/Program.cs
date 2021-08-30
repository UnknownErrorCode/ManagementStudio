using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementClient
{
    static class Program
    {
        internal static ClientDataStorage.Config MainConfig = new ClientDataStorage.Config();
        internal static LoginForm StaticLoginForm;
        internal static ClientForm StaticClientForm;

        /// <summary>
        /// Main entry point for the application!
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StaticLoginForm = new LoginForm();
            StaticClientForm = new ClientForm();
            Application.Run(StaticLoginForm);
        }
    }
}
