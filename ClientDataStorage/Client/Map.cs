using ClientDataStorage.Client.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client
{
    public class Map
    {
        public static Pk2.Pk2Reader MapPk2 { get; set; }

        public static List<o2File> Allo2Files = new List<o2File>();
        public static List<mFile> AllmFiles = new List<mFile>();
        public static Tile2dIFOFile Tile2d_ifo;
        public static Dictionary<int, DDSImage> TileTextureDictionary = new Dictionary<int, DDSImage>();

        public static void Initialize()
        {
            MapPk2 = new Pk2.Pk2Reader($"{Config.StaticConfig.ClientPath}\\Map.pk2");

            Tile2d_ifo = new Tile2dIFOFile();
            for (int i = 0; i < Tile2d_ifo.TexturePaths.Length; i++)
            {
               
                var file = MapPk2.GetFileByDirectory($"Map\\tile2d\\{Tile2d_ifo.TexturePaths[i]}");
                var array = MapPk2.GetByteArrayByFile(file);
                DDSImage img = new DDSImage(array, true) ;
                TileTextureDictionary.Add(i, img);
            }
          // for (int i = 0; i < 255; i++)
          // {
          //     string xName = $"{i}";
          //
          //     foreach (var folder in MapPk2.Pk2File.subfolders)
          //     {
          //         if (folder.name == xName)
          //             foreach (var file in folder.files)
          //             {
          //                 if (file.name.EndsWith(".o2"))
          //                     Allo2Files.Add(new o2File(file));
          //                 else if (file.name.EndsWith(".m"))
          //                     AllmFiles.Add(new mFile(file));
          //             }
          //     }
          // }
        }
    }
}
