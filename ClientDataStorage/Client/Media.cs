using ClientDataStorage.Client.Files;
using Structs.Pk2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public static class Media
    {
        /// <summary>
        /// Main static Pk2 reader
        /// </summary>
        public static Pk2.Pk2Reader MediaPk2 { get; set; }

        /// <summary>
        /// TextUISystem from Media.pk2
        /// </summary>
        public static Textdata.TextUISystem StaticTextuiSystem { get; set; }

        /// <summary>
        /// Contains all necessary ddj images.
        /// </summary>
        public static Dictionary<string, DDJImage> DDJFiles = new Dictionary<string, DDJImage>();

        /// <summary>
        /// Initialize Media syncronous.
        /// </summary>
        public static void InitializeMedia()
        {
            MediaPk2 = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Media.pk2");

            if (Media.MediaPk2.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\textuisystem.txt", out byte[] file))
                StaticTextuiSystem = new Textdata.TextUISystem(file);
        }

        /// <summary>
        /// Initialize Media asyncronous.
        /// </summary>
        public static async void InitializeMediaAsync()
          => await Task.Run(() => InitializeMedia());
    }
}
