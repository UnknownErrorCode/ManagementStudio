using PluginFramework.Database;
using Structs.Database;

namespace WorldMapSpawnEditor.MapGraphics
{
    public class NestSpawnProperty
    {
        public TabRefNest Nest;
        public Tab_RefHive Hive;
        public RefObjChar ObjChar;
        public RefObjCommon ObjCommon;
        public Tab_RefTactics Tactics;

        public NestSpawnProperty(TabRefNest nest)
        {
            Nest = nest;
            Initialize();
        }

        /// <summary>
        /// Gets the required informations from Tab_RefNest struct. Pulls all informations boxed from the stored Data.
        /// </summary>
        private void Initialize()
        {
            if (SRO_VT_SHARD.Tab_RefHive.ContainsKey(Nest.DwHiveID))
                Hive = SRO_VT_SHARD.Tab_RefHive[Nest.DwHiveID];

            if (SRO_VT_SHARD.Tab_RefTactics.ContainsKey(Nest.DwTacticsID))
            {
                Tactics = SRO_VT_SHARD.Tab_RefTactics[Nest.DwTacticsID];

                if (SRO_VT_SHARD._RefObjCommon.ContainsKey(Tactics.DwObjID))
                {
                    ObjCommon = SRO_VT_SHARD._RefObjCommon[Tactics.DwObjID];

                    if (SRO_VT_SHARD._RefObjChar.ContainsKey(ObjCommon.Link))
                    {
                        ObjChar = SRO_VT_SHARD._RefObjChar[ObjCommon.Link];
                    }
                }
            }
        }
    }
}