using System.IO;

namespace PackFile
{
    public static class PackFileManager
    {
        private const string WorldMapGuidePath = "Media\\interface\\worldmap\\map";
        private const string ResInfoPath = "Media\\resinfo";
        private static string clientPath;
        public static bool Initialized => MediaPack.Initialized && MapPack.Initialized && DataPack.Initialized;

        public static bool InitializePackFiles(string _clientPath)
        {
            clientPath = _clientPath;
            if (!MediaPack.Initialize(_clientPath))
                return false;
            if (!MapPack.Initialize(_clientPath))
                return false;
            if (!DataPack.Initialize(_clientPath))
                return false;

            return MediaPack.Initialized && MapPack.Initialized && DataPack.Initialized;
        }

        public static bool ExtractIfInterfaces()
        {
            if (!MediaPack.Initialized)
            {
                return false; ;
            }
            if (!MediaPack.Reader.GetFilesInFolder(ResInfoPath, out Pk2File[] files))
            {
                return false;
            }
            foreach (var file in files)
            {
                try
                {
                    if (!file.name.ToLower().EndsWith(".txt") || !MediaPack.Reader.GetByteArrayByFile(file, out byte[] rawddjFile))
                    {
                        continue;
                    }

                    var picDirPath = Path.Combine(clientPath, ResInfoPath);
                    Directory.CreateDirectory(picDirPath);
                    using (MemoryStream stream = new MemoryStream(rawddjFile))
                    {
                        using (var fs = File.Create(Path.Combine(picDirPath, file.name), (int)stream.Length, FileOptions.Asynchronous))
                        {
                            fs.Write(rawddjFile, 0, (int)stream.Length);
                            fs.Close();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ExtractRegionIcons()
        {
            if (MediaPack.Initialized)
            {
                if (MediaPack.Reader.GetFilesInFolder(WorldMapGuidePath, out Pk2File[] files))
                {
                    foreach (var file in files)
                    {
                        if (file.name.ToLower().EndsWith(".ddj") && MediaPack.Reader.GetByteArrayByDirectory($"{WorldMapGuidePath}\\{file.name}", out byte[] rawddjFile))
                        {
                            try
                            {
                                var picDirPath = Path.Combine(clientPath, WorldMapGuidePath);
                                Directory.CreateDirectory(picDirPath);
                                using (MemoryStream stream = new MemoryStream(rawddjFile))
                                {
                                    using (var fs = File.Create(Path.Combine(picDirPath, file.name.ToLower().Replace(".ddj", ".dds")), (int)stream.Length - 20, FileOptions.Asynchronous))
                                    {
                                        fs.Write(rawddjFile, 20, (int)stream.Length - 20);
                                        fs.Close();
                                    }
                                }
                            }
                            catch (System.Exception)
                            {
                            }
                            //}
                        }
                    }
                }
            }

            return true;
        }
    }
}