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
     
        private protected string ClientPath { get; set; }

        internal Pk2Ressources(string clientPath)
        {
            ClientPath = clientPath;
          
        }
    }
}
