using BinaryFiles.PackFile;
using PackFile.Utility;
using System.Collections.Generic;

namespace PackFile
{
    public static class MediaPack
    {
        #region Fields

        /// <summary>
        /// Contains all necessary ddj images.
        /// </summary>
        public static Dictionary<string, DDJImage> DDJFiles = new Dictionary<string, DDJImage>();

        /// <summary>
        /// Main static Pk2 reader
        /// </summary>
        public static Pk2Reader Reader;
        internal static bool Initialized => Reader.Initialized;


        #endregion Fields

        #region Methods

        /// <summary>
        /// Initialize Media syncronous.
        /// </summary>
        internal static bool Initialize(string clientPath)
        {
            Reader = new Pk2Reader($"{clientPath}\\Media.pk2");
            return Reader.Initialized;
        }


        public static bool GetSkillEffect(out Media.Textdata.SkillEffect skillEffect) => Media.ServerDependencies.GetSkillEffect(out skillEffect);
        public static bool GetTextDataName(out Media.Textdata.TextDataName textDataName) => Media.ServerDependencies.GetTextDataName(out textDataName);
        public static bool GetTextUISystem(out Media.Textdata.TextUISystem textUISystem) => Media.ServerDependencies.GetTextUISystem(out textUISystem);
        public static bool GetWorldmap_Mapinfo(out Media.Textdata.Worldmap_Mapinfo worldmap_Mapinfo) => Media.ServerDependencies.GetWorldmap_Mapinfo(out worldmap_Mapinfo);

        #endregion Methods
    }
}