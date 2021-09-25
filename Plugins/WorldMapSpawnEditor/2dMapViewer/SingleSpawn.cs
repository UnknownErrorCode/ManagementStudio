using ClientDataStorage.Database;
using Structs.Database;
using System.Data;
using System.Linq;

namespace WorldMapSpawnEditor._2dMapViewer
{
    class SingleSpawn
    {
       internal Tab_RefNest Nest { get; set; }
       internal Tab_RefHive Hive { get; set; }
       internal Tab_RefTactics Tactics { get; set; }
       internal RefObjCommon ObjCommon { get; set; }
       internal RefObjChar ObjChar { get; set; }

        internal SingleSpawn(Tab_RefNest nest)
        {
            Nest = nest;
            if (SRO_VT_SHARD.dbo.Tables["Tab_RefHive"].Rows.OfType<DataRow>().Any(hive => hive.Field<int>("dwHiveID") == Nest.dwHiveID))
                Hive = new Tab_RefHive(SRO_VT_SHARD.dbo.Tables["Tab_RefHive"].Rows.OfType<DataRow>().Single(hive => hive.Field<int>("dwHiveID") == Nest.dwHiveID).ItemArray);

            if(SRO_VT_SHARD.dbo.Tables["Tab_RefTactics"].Rows.OfType<DataRow>().Any(tactic => tactic.Field<int>("dwTacticsID") == Nest.dwTacticsID))
            {
                Tactics = new Tab_RefTactics(SRO_VT_SHARD.dbo.Tables["Tab_RefTactics"].Rows.OfType<DataRow>().Single(tactic => tactic.Field<int>("dwTacticsID") == Nest.dwTacticsID).ItemArray);

                ObjCommon = new RefObjCommon(SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Single(common => common.Field<int>("ID") == Tactics.dwObjID).ItemArray);
                ObjChar = new RefObjChar(SRO_VT_SHARD.dbo.Tables["_RefObjChar"].Rows.OfType<DataRow>().Single(ochar => ochar.Field<int>("ID") == ObjCommon.Link).ItemArray);
            }
        }
    }
}
