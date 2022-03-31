using BinaryFiles.PackFile;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public static class Media
    {
        #region Fields

        /// <summary>
        /// Contains all necessary ddj images.
        /// </summary>
        public static Dictionary<string, DDJImage> DDJFiles = new Dictionary<string, DDJImage>();

        /// <summary>
        /// Main static Pk2 reader
        /// </summary>
        public static Pk2.Pk2Reader MediaPk2;

        public static ServerDependencies Server_Dep = new ServerDependencies();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Initialize Media syncronous.
        /// </summary>
        public static bool InitializeMedia()
        {
            MediaPk2 = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Media.pk2");
            if (!Server_Dep.Initialize())
                return false;

            Log.Logger.MessageStack.Push(MediaPk2.Initialized ? "Successfully load Media.pk2..." : "Cannot find Media.pk2...");

            return MediaPk2.Initialized;
        }

        /// <summary>
        /// Initialize Media asyncronous.
        /// </summary>
        public static async Task<bool> InitializeMediaAsync()
        {
            return Task.Run(() => InitializeMedia()).Result;
        }

        #endregion Methods
    }
}