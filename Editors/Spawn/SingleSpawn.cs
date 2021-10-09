using ClientDataStorage.Database;
using Structs.Database;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Editors.Spawn
{
    public class SingleSpawn
    {
        public Tab_RefNest Nest { get; private set; }
        public Tab_RefTactics Tactics { get; set; } 
        public Tab_RefHive Hive { get; set; }
        public RefObjCommon ObjCommon { get; set; } 
        public RefObjChar ObjChar { get; set; }  

        public SingleSpawn(Tab_RefNest nest)
        {
            Nest = nest;
            Initialize();
        }

        /// <summary>
        /// Gets the required informations from Tab_RefNest struct. Pulls all informations boxed from the stored Data. 
        /// </summary>
        private void Initialize()
        {
            if (SRO_VT_SHARD.Tab_RefHive.ContainsKey(Nest.dwHiveID))
                Hive = SRO_VT_SHARD.Tab_RefHive[Nest.dwHiveID];

            if (SRO_VT_SHARD.Tab_RefTactics.ContainsKey(Nest.dwTacticsID))
            {
                Tactics = SRO_VT_SHARD.Tab_RefTactics[Nest.dwTacticsID];

                if (SRO_VT_SHARD._RefObjCommon.ContainsKey(Tactics.dwObjID))
                {
                    ObjCommon = SRO_VT_SHARD._RefObjCommon[Tactics.dwObjID];
                    if (SRO_VT_SHARD._RefObjCommon.ContainsKey(ObjCommon.Link))
                    {
                        ObjChar = SRO_VT_SHARD._RefObjChar[ObjCommon.Link];
                    }
                }
            }
        }
    }
}
