using ClientDataStorage.Client.Files;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public static class Media
    {
        #region Public Fields

        /// <summary>
        /// Contains all necessary ddj images.
        /// </summary>
        public static Dictionary<string, DDJImage> DDJFiles = new Dictionary<string, DDJImage>();

        #endregion Public Fields

        #region Public Properties

        /// <summary>
        /// Main static Pk2 reader
        /// </summary>
        public static Pk2.Pk2Reader MediaPk2 { get; set; }

        /// <summary>
        /// Skilleffect from Media.pk2
        /// </summary>
        public static Textdata.SkillEffect SkillEffect { get; set; }

        /// <summary>
        /// TextUISystem from Media.pk2
        /// </summary>
        public static Textdata.TextUISystem StaticTextuiSystem { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Initialize Media syncronous.
        /// </summary>
        public static bool InitializeMedia()
        {
            MediaPk2 = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Media.pk2");

            if (Media.MediaPk2.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\textuisystem.txt", out byte[] file))
            {
                StaticTextuiSystem = new Textdata.TextUISystem(file);
            }

            SkillEffect = new Textdata.SkillEffect();

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

        #endregion Public Methods
    }
}