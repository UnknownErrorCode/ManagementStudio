using System.Collections.Generic;
using System.IO;

namespace StudioServer.Worker
{
    public static class DataStorage
    {
        #region Private Fields

        private static Dictionary<string, StoredData> AllDataInStorage;

        #endregion Private Fields

        #region Internal Properties

        internal static int DataCount => AllDataInStorage.Count;

        internal static string DataStoragePath => Path.Combine(Directory.GetCurrentDirectory(), "DataStorage");

        #endregion Internal Properties

        #region Public Methods

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

        #endregion Public Methods

        #region Internal Methods

        internal static string[] AllFilesAsArray()
        {
            List<string> stringList = new List<string>();
            foreach (StoredData item in AllDataInStorage.Values)
            {
                stringList.Add(item.FileTitle);
            }
            return stringList.ToArray();
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

        #endregion Internal Methods

        #region Internal Structs

        internal struct StoredData
        {
            #region Public Fields

            public string FileTitle;

            #endregion Public Fields

            #region Private Fields

            private readonly byte[] dataAsArray;

            #endregion Private Fields

            #region Internal Constructors

            internal StoredData(string path)
            {
                dataAsArray = File.Exists(path) ? File.ReadAllBytes(path) : new byte[0];
                FileTitle = Path.GetFileName(path);
            }

            #endregion Internal Constructors
        }

        #endregion Internal Structs
    }
}