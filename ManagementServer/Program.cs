using System;
using System.Windows.Forms;

namespace ManagementServer
{
    internal static class Program
    {
        #region Private Methods

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerManager());
        }

        #endregion Private Methods
    }
}