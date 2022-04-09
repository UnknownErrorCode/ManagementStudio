using ClientFrameworkRes.Database.SRProperties;
using PluginFramework.Database;
using Structs.Database;

namespace WorldMapSpawnEditor.MapGraphics
{
    public class NestSpawnProperty
    {
        public PTabRefNest Nest;
        public PTab_RefHive Hive;
        public P_RefObjChar ObjChar;
        public P_RefObjCommon ObjCommon;
        public PTab_RefTactics Tactics;

        public NestSpawnProperty(TabRefNest nest)
        {
            Nest = new PTabRefNest(nest);
            Initialize();
        }

        /// <summary>
        /// Gets the required informations from Tab_RefNest struct. Pulls all informations boxed from the stored Data.
        /// </summary>
        private void Initialize()
        {
            if (SRO_VT_SHARD.Tab_RefHive.ContainsKey(Nest.dwHiveID))
                Hive = new PTab_RefHive(SRO_VT_SHARD.Tab_RefHive[Nest.dwHiveID]);

            if (SRO_VT_SHARD.Tab_RefTactics.ContainsKey(Nest.dwTacticsID))
            {
                Tactics = new PTab_RefTactics(SRO_VT_SHARD.Tab_RefTactics[Nest.dwTacticsID]);

                if (SRO_VT_SHARD._RefObjCommon.ContainsKey(Tactics.dwObjID))
                {
                    ObjCommon = new P_RefObjCommon(SRO_VT_SHARD._RefObjCommon[Tactics.dwObjID]);

                    if (SRO_VT_SHARD._RefObjChar.ContainsKey(ObjCommon.Link))
                    {
                        ObjChar = new P_RefObjChar(SRO_VT_SHARD._RefObjChar[ObjCommon.Link]);
                    }
                }
            }
        }
    }
}