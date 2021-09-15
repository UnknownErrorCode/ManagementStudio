using ClientDataStorage.Client.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor.MapRessources
{
    public interface IMapControl
    {

        void Render();
        void Draw(mFile meshFile, bool newwLoad);
        void LoadGL(object sender, EventArgs arg);
    }
}
