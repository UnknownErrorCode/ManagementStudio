using ClientDataStorage.Database;
using Structs.Database;
using System.Data;
using System.Linq;

namespace Editors.Spawn
{
    public class SingleSpawn
    {
        public Tab_RefNest Nest { get; private set; }
        public Tab_RefTactics Tactics;
        public Tab_RefHive Hive;
        public RefObjCommon ObjCommon;
        public RefObjChar ObjChar;

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

            if (SRO_VT_SHARD.dbo.Tables["Tab_RefHive"].Rows.OfType<DataRow>().Any(row => row.Field<int>("dwHiveID").Equals(Nest.dwHiveID)))
            {
                Hive = new Tab_RefHive(SRO_VT_SHARD.dbo.Tables["Tab_RefHive"].Rows.OfType<DataRow>().Single(row => row.Field<int>("dwHiveID").Equals(Nest.dwHiveID)).ItemArray);
            }

            if (SRO_VT_SHARD.dbo.Tables["Tab_RefTactics"].Rows.OfType<DataRow>().Any(row => row.Field<int>("dwTacticsID").Equals(Nest.dwTacticsID)))
            {
                Tactics = new Tab_RefTactics(SRO_VT_SHARD.dbo.Tables["Tab_RefTactics"].Rows.OfType<DataRow>().Single(row => row.Field<int>("dwTacticsID").Equals(Nest.dwTacticsID)).ItemArray);


                if (SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Any(row => row.Field<int>("ID").Equals(Tactics.dwObjID)))
                {
                    ObjCommon = new RefObjCommon(SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Single(row => row.Field<int>("ID").Equals(Tactics.dwObjID)).ItemArray);


                    if (SRO_VT_SHARD.dbo.Tables["_RefObjChar"].Rows.OfType<DataRow>().Any(row => row.Field<int>("ID").Equals(ObjCommon.Link)))
                    {
                        ObjChar = new RefObjChar(SRO_VT_SHARD.dbo.Tables["_RefObjChar"].Rows.OfType<DataRow>().Single(row => row.Field<int>("ID").Equals(ObjCommon.Link)).ItemArray);

                    }
                }
            }

            /*
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
                        ObjChar = SRO_VT_SHARD._RefObjChar[ObjCommon.Link];
                    }
                }
            }
            */
        }
    }
}
