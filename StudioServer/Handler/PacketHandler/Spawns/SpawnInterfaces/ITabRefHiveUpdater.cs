using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Spawns.SpawnInterfaces
{
    public struct ITabRefHiveUpdater
    {
        public string btKeepMonsterCountType;
        public string dwOverwriteMaxTotalCount;
        public string fMonsterCountPerPC;
        public string dwSpawnSpeedIncreaseRate;
        public string dwMaxIncreaseRate;
        public string btFlag;
        public string GameWorldID;
        public string HatchObjType;
        public string szDescString128;
    }
}
