using ClientDataStorage.Pk2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor
{
    class Pk2Ressources
    {
        internal Pk2Class MediaPk2 { get; set; }
        internal Pk2Class MapPk2 { get; set; }
        private protected string ClientPath { get; set; }
        private protected string MediaPath { get => Path.Combine(ClientPath, "Media.pk2"); }
        private protected string MapPath { get => Path.Combine(ClientPath, "Map.pk2"); }

        internal Pk2Ressources(string clientPath)
        {
            ClientPath = clientPath;
            MediaPk2 = new Pk2Class(MediaPath);
            MapPk2 = new Pk2Class(MapPath);
        }
    }
}
