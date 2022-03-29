using System.Collections.Generic;
using System.IO;

namespace StudioServer.Worker
{
    public static class DataStorage
    {
        private static Dictionary<string, StoredData> AllDataInStorage;

        internal static string[] AllFilesAsArray()
        {
            List<string> stringList = new List<string>();
            foreach (StoredData item in AllDataInStorage.Values)
            {
                stringList.Add(item.FileTitle);
            }
            return stringList.ToArray();
        }
        internal static int DataCount => AllDataInStorage.Count;
        internal static string DataStoragePath => Path.Combine(Directory.GetCurrentDirectory(), "DataStorage");
        /// <summary>
        /// Creates the Environment for the DataStorage
        /// </summary>
        public static void CreateEnvironment()
        {
            AllDataInStorage = new Dictionary<string, StoredData>();
            if (!File.Exists(DataStoragePath))
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, $"Initialized Environment for DataStorage at: {DataStoragePath}");
                Directory.CreateDirectory(DataStoragePath);
            }
            foreach (string item in Directory.GetFiles(DataStoragePath, "*.7z", SearchOption.TopDirectoryOnly))
            {
                AllDataInStorage.Add(item, new StoredData(item));
            }
            foreach (string item in Directory.GetFiles(DataStoragePath, "*.zip", SearchOption.TopDirectoryOnly))
            {
                AllDataInStorage.Add(item, new StoredData(item));
            }
            foreach (string item in Directory.GetFiles(DataStoragePath, "*.rar", SearchOption.TopDirectoryOnly))
            {
                AllDataInStorage.Add(item, new StoredData(item));
            }
            StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, $"Initialized {DataCount} files from {DataStoragePath}");
        }


        internal static bool Contains(string file)
        {
            return AllDataInStorage.ContainsKey(Path.Combine(DataStoragePath, file));
        }

        internal static StoredData GetData(string file)
        {
            if (Contains(file))
            {
                return AllDataInStorage[Path.Combine(DataStoragePath, file)];
            }
            return new StoredData();
        }
        internal struct StoredData
        {
            readonly byte[] dataAsArray;
            public string FileTitle;
            internal StoredData(string path)
            {
                dataAsArray = File.Exists(path) ? File.ReadAllBytes(path) : new byte[0];
                FileTitle = Path.GetFileName(path);
            }
        }
    }



}
