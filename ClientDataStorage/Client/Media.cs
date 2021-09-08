using Structs.Pk2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public static class Media 
    {
        public static Pk2.Pk2Reader MediaPk2 { get; set; }

        public static Textdata.TextUISystem StaticTextuiSystem { get; set; }


        public static void InitializeMedia()
        {
            MediaPk2 = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Media.pk2");
            StaticTextuiSystem = new Textdata.TextUISystem();

        }
    }
}
