using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public static class DataPack
    {
        #region Fields

        /// <summary>
        /// Consists of all .dof file paths the GameServer/ShardManager requires to load.
        /// </summary>
        public static Textdata.DungeonInfo DungeonInfo;

        /// <summary>
        /// The Main abstract Pk2 reader.
        /// </summary>
        public static Pk2.Pk2Reader Reader;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Initialize the Data.pk2 syncronous.
        /// </summary>
        public static bool Initialize()
        {
            Reader = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Data.pk2");

            if (!Reader.Initialized)
                return false;

            if (!Reader.GetByteArrayByDirectory("Data\\dungeon\\dungeoninfo.txt", out byte[] dungeoninfo_txt))
                return false;

            DungeonInfo = new Textdata.DungeonInfo(dungeoninfo_txt);
            Log.Logger.MessageStack.Push($"Successfully load {DungeonInfo.Count} dungeoninfo entities");

            Log.Logger.MessageStack.Push(Reader.Initialized ? "Successfully load Data.pk2..." : "Cannot find Data.pk2...");

            return Reader.Initialized;
        }

        /// <summary>
        /// Initialize the Data.pk2 file async.
        /// </summary>
        public static async Task<bool> InitializeDataAsync()
        {
            return Task.Run(() => Initialize()).Result;
        }

        #endregion Methods
    }
}