using System.Threading;

namespace ManagementLauncher.Network
{
    class LauncherClient
    {
        public Thread TickerThread;
        internal LauncherInterface LInterface { get; set; }
        internal static LauncherData LData { get; set; }
        internal AsyncClient.AsyncClient LClient;

        internal LauncherClient()
        {
            LData = new LauncherData();
            LInterface = new LauncherInterface();
            LClient = new AsyncClient.AsyncClient();
            TickerThread = new Thread(TickLoop);
        }

        internal bool Connect()
        {
            if (LData == null)
            {
                return false;
            }

            if (LData.m_connected)
            {
                return true;
            }

            LClient.Connect(Launcher.LConfig.HostIP, Launcher.LConfig.HostPort, LInterface, LData);

            for (int i = 0; i < 5000; i++)
            {
                if (LData.m_connected)
                {
                    break;
                }

                Thread.Sleep(1);
            }

            if (LData.m_connected)
            {
                TickerThread.Start();
            }

            return LData.m_connected;
        }

        private void TickLoop()
        {
            while (LData.m_connected)
            {
                LClient.Tick();
                Thread.Sleep(1);
            }
        }
    }
}
