using ClientFrameworkRes.Database;
using Structs.Database;
using Structs.Tool;

namespace Editors.Spawn
{
    public class SingleSpawn
    {
        #region Public Fields

        public readonly TabRefNest Nest;
        public Tab_RefHive Hive;
        public RefObjChar ObjChar;
        public RefObjCommon ObjCommon;
        public Tab_RefTactics Tactics;

        #endregion Public Fields

        #region Private Fields

        private SpawnType spawnType;

        #endregion Private Fields

        #region Public Constructors

        public SingleSpawn(TabRefNest nest)
        {
            Nest = nest;
            Initialize();
        }

        #endregion Public Constructors

        #region Private Methods

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

                    if (SRO_VT_SHARD._RefObjChar.ContainsKey(ObjCommon.Link))
                    {
                        ObjChar = SRO_VT_SHARD._RefObjChar[ObjCommon.Link]; // "].Rows.OfType<DataRow>().Single(row => row.Field<int>("ID").Equals(ObjCommon.Link)).ItemArray);
                    }
                }
            }
        }

        #endregion Private Methods
    }
}