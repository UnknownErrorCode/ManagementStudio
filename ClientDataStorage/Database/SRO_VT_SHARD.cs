using Structs.Database;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Database
{
    public static class SRO_VT_SHARD 
    {
        public static DataSet dbo = new DataSet("SRO_VT_SHARD");

        public static ConcurrentDictionary<int, RefObjChar> _RefObjChar;
        public static ConcurrentDictionary<int, RefObjCommon> _RefObjCommon;
        public static ConcurrentDictionary<int, Tab_RefHive> Tab_RefHive;
        public static ConcurrentDictionary<int, Tab_RefNest> Tab_RefNest;
        public static ConcurrentDictionary<int, Tab_RefTactics> Tab_RefTactics;


        public static void InitializeDBShard()
        {
            InitializeRefObjChars();
            InitializeTab_RefNest();
            InitializeRefObjCommon();
            InitializeTab_RefHivet();
            InitializeTab_RefTactics();
        }


        static void InitializeRefObjChars()
        {
            _RefObjChar = new ConcurrentDictionary<int, RefObjChar>();

            for (int i = 0; i < dbo.Tables["_RefObjChar"].Rows.Count; i++)
                _RefObjChar.TryAdd(dbo.Tables["_RefObjChar"].Rows[i].Field<int>("ID"), new RefObjChar(dbo.Tables["_RefObjChar"].Rows[i].ItemArray));
        }

        static void InitializeRefObjCommon()
        {
            _RefObjCommon = new ConcurrentDictionary<int, RefObjCommon>();

            for (int i = 0; i < dbo.Tables["_RefObjCommon"].Rows.Count; i++)
                _RefObjCommon.TryAdd(dbo.Tables["_RefObjCommon"].Rows[i].Field<int>("ID"), new RefObjCommon(dbo.Tables["_RefObjCommon"].Rows[i].ItemArray));
        }

        static void InitializeTab_RefTactics()
        {
            Tab_RefTactics = new ConcurrentDictionary<int, Tab_RefTactics>();

            for (int i = 0; i < dbo.Tables["Tab_RefTactics"].Rows.Count; i++)
                Tab_RefTactics.TryAdd(dbo.Tables["Tab_RefTactics"].Rows[i].Field<int>("dwTacticsID"), new Tab_RefTactics(dbo.Tables["Tab_RefTactics"].Rows[i].ItemArray));
        }
        static void InitializeTab_RefNest()
        {
            Tab_RefNest = new ConcurrentDictionary<int, Tab_RefNest>();

            for (int i = 0; i < dbo.Tables["Tab_RefNest"].Rows.Count; i++)
                Tab_RefNest.TryAdd(dbo.Tables["Tab_RefNest"].Rows[i].Field<int>("dwNestID"), new Tab_RefNest(dbo.Tables["Tab_RefNest"].Rows[i].ItemArray));
        }
        static void InitializeTab_RefHivet()
        {
            Tab_RefHive = new ConcurrentDictionary<int, Tab_RefHive>();

            for (int i = 0; i < dbo.Tables["Tab_RefHive"].Rows.Count; i++)
                Tab_RefHive.TryAdd(dbo.Tables["Tab_RefHive"].Rows[i].Field<int>("dwHiveID"), new Tab_RefHive(dbo.Tables["Tab_RefHive"].Rows[i].ItemArray));
        }

    }
}
