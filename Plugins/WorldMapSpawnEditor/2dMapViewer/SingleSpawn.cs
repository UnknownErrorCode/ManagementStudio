using ClientDataStorage.Database;
using Structs.Database;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor._2dMapViewer
{
    public class SingleSpawn
    {
        public Tab_RefNest Nest { get; private set; }
        public Tab_RefHive Hive { get; set; }// { get => SRO_VT_SHARD.dbo.Tables["Tab_RefHive"].Rows.OfType<DataRow>().Any(hive => hive.Field<int>("dwHiveID") == Nest.dwHiveID) ? new Tab_RefHive(SRO_VT_SHARD.dbo.Tables["Tab_RefHive"].Rows.OfType<DataRow>().Single(hive => hive.Field<int>("dwHiveID") == Nest.dwHiveID).ItemArray) : new Tab_RefHive(); set => this.Hive =value; }
        public Tab_RefTactics Tactics { get; set; } //{ get => SRO_VT_SHARD.dbo.Tables["Tab_RefTactics"].Rows.OfType<DataRow>().Any(tactic => tactic.Field<int>("dwTacticsID") == Nest.dwTacticsID) ? new Tab_RefTactics(SRO_VT_SHARD.dbo.Tables["Tab_RefTactics"].Rows.OfType<DataRow>().Single(tactic => tactic.Field<int>("dwTacticsID") == Nest.dwTacticsID).ItemArray) : new Tab_RefTactics(); }
        public RefObjCommon ObjCommon { get; set; } // { get => new RefObjCommon(SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Single(common => common.Field<int>("ID") == Tactics.dwObjID).ItemArray); }
        public RefObjChar ObjChar { get; set; }  //{ get => new RefObjChar(SRO_VT_SHARD.dbo.Tables["_RefObjChar"].Rows.OfType<DataRow>().Single(ochar => ochar.Field<int>("ID") == ObjCommon.Link).ItemArray); }

        public SingleSpawn(Tab_RefNest nest)
        {
            Nest = nest;

            InitializeThis();
        }


        private void InitializeThis()
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
