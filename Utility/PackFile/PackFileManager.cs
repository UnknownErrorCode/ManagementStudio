namespace PackFile
{
    public static class PackFileManager
    {
        public static bool Initialized => MediaPack.Initialized && MapPack.Initialized && DataPack.Initialized;

        public static bool InitializePackFiles(string clientPath)
        {

            if (!MediaPack.Initialize(clientPath))
                return false;
            if (!MapPack.Initialize(clientPath))
                return false;
            if (!DataPack.Initialize(clientPath))
                return false;

            return MediaPack.Initialized && MapPack.Initialized && DataPack.Initialized;

        }
    }
}