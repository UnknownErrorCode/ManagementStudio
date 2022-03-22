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
    public static class SRO_VT_SHARD //<T> where T : struct
    {
        public static DataSet dbo = new DataSet("SRO_VT_SHARD");

        public static ConcurrentDictionary<int, IChar> _Char;
        public static ConcurrentDictionary<int, RefObjChar> _RefObjChar;
        public static ConcurrentDictionary<int, RefObjCommon> _RefObjCommon;
        public static ConcurrentDictionary<int, Tab_RefHive> Tab_RefHive;
        public static ConcurrentDictionary<int, Tab_RefNest> Tab_RefNest;
        public static ConcurrentDictionary<int, Tab_RefTactics> Tab_RefTactics;
        public static ConcurrentDictionary<int, RefSkill> _RefSkill;
        public static ConcurrentDictionary<int, RefSkillGroup> _RefSkillGroup;
        public static ConcurrentDictionary<int, RefSkillMastery> _RefSkillMastery;
        public static ConcurrentDictionary<int, RefTeleport> _RefTeleport;
        public static List<RefTeleLink> _RefTeleLink;

        public static ConcurrentDictionary<int, Structs.Database.RefGame_World> _RefGame_World;
        public static ConcurrentDictionary<int, Structs.Database.RefGameWorldBindTriggerCategory> _RefGameWorldBindTriggerCategory;
        public static ConcurrentDictionary<int, Structs.Database.RefTriggerCategory> _RefTriggerCategory;
        public static ConcurrentDictionary<int, Structs.Database.RefTriggerCategoryBindTrigger> _RefTriggerCategoryBindTrigger;
        public static ConcurrentDictionary<int, Structs.Database.RefTrigger> _RefTrigger;

        public static void InitializeDBShard()
        {
            InitializeChars();
            InitializeRefObjChars();
            InitializeRefObjCommon();
            InitializeRefSkill();
            //InitializeRefSkillGroup();
            //InitializeRefSkillMastery();
            Initialize_RefTeleport();
            Initialize_RefTeleLink();
            InitializeTab_RefHive();
            InitializeTab_RefNest();
            InitializeTab_RefTactics();
            InitializeRefGame_World();
            InitializeRefGameWorldBindTriggerCategory();
            InitializeRefTriggerCategory();
            InitializeRefTriggerCategoryBindTrigger();
            InitializeRefTrigger();


        }

        private static void InitializeRefTrigger()
        {
            var table = dbo.Tables["_RefTrigger"];
            _RefTrigger = new ConcurrentDictionary<int, RefTrigger>(2, table.Rows.Count);

            for (int i = 0; i < table.Rows.Count; i++)
                _RefTrigger.TryAdd(table.Rows[i].Field<int>("ID"), new RefTrigger(table.Rows[i].ItemArray));
        }

        private static void InitializeRefTriggerCategoryBindTrigger()
        {
            var table = dbo.Tables["_RefTriggerCategoryBindTrigger"];
            _RefTriggerCategoryBindTrigger = new ConcurrentDictionary<int, RefTriggerCategoryBindTrigger>(2, table.Rows.Count);

            for (int i = 0; i < table.Rows.Count; i++)
                _RefTriggerCategoryBindTrigger.TryAdd(table.Rows[i].Field<int>("ID"), new RefTriggerCategoryBindTrigger(table.Rows[i].ItemArray));
        }

        private static void InitializeRefTriggerCategory()
        {
            var table = dbo.Tables["_RefTriggerCategory"];
            _RefTriggerCategory = new ConcurrentDictionary<int, RefTriggerCategory>(2, table.Rows.Count);

            for (int i = 0; i < table.Rows.Count; i++)
                _RefTriggerCategory.TryAdd(table.Rows[i].Field<int>("ID"), new RefTriggerCategory(table.Rows[i].ItemArray));
        }

        private static void InitializeRefGameWorldBindTriggerCategory()
        {
            _RefGameWorldBindTriggerCategory = new ConcurrentDictionary<int, RefGameWorldBindTriggerCategory>(2, dbo.Tables["_RefGameWorldBindTriggerCategory"].Rows.Count);

            for (int i = 0; i < dbo.Tables["_RefGameWorldBindTriggerCategory"].Rows.Count; i++)
                _RefGameWorldBindTriggerCategory.TryAdd(dbo.Tables["_RefGameWorldBindTriggerCategory"].Rows[i].Field<int>("ID"), new RefGameWorldBindTriggerCategory(dbo.Tables["_RefGameWorldBindTriggerCategory"].Rows[i].ItemArray));
        }

        private static void InitializeRefGame_World() 
        {
            _RefGame_World = new ConcurrentDictionary<int, RefGame_World>(2, dbo.Tables["_RefGame_World"].Rows.Count);

            for (int i = 0; i < dbo.Tables["_RefGame_World"].Rows.Count; i++)
                _RefGame_World.TryAdd(dbo.Tables["_RefGame_World"].Rows[i].Field<int>("ID"), new RefGame_World(dbo.Tables["_RefGame_World"].Rows[i].ItemArray));
        }

        private static void InitializeChars()
        {
            _Char = new ConcurrentDictionary<int, IChar>(2, dbo.Tables["_Char"].Rows.Count);
            for (int i = 0; i < dbo.Tables["_Char"].Rows.Count; i++)
                _Char.TryAdd(dbo.Tables["_Char"].Rows[i].Field<int>("CharID"), new IChar(dbo.Tables["_Char"].Rows[i].ItemArray));
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

        private static void InitializeRefSkill()
        {
            _RefSkill = new ConcurrentDictionary<int, RefSkill>();

            for (int i = 0; i < dbo.Tables["_RefSkill"].Rows.Count; i++)
                _RefSkill.TryAdd(dbo.Tables["_RefSkill"].Rows[i].Field<int>("ID"), new RefSkill(dbo.Tables["_RefSkill"].Rows[i].ItemArray));
        }

        private static void InitializeRefSkillGroup()
        {
            _RefSkillGroup = new ConcurrentDictionary<int, RefSkillGroup>();

            for (int i = 0; i < dbo.Tables["_RefSkillGroup"].Rows.Count; i++)
                _RefSkillGroup.TryAdd(dbo.Tables["_RefSkillGroup"].Rows[i].Field<int>("ID"), new RefSkillGroup(dbo.Tables["_RefSkillGroup"].Rows[i].ItemArray));
        }

        private static void InitializeRefSkillMastery()
        {
            _RefSkillMastery = new ConcurrentDictionary<int, RefSkillMastery>();

            for (int i = 0; i < dbo.Tables["_RefSkillMastery"].Rows.Count; i++)
                _RefSkillMastery.TryAdd(dbo.Tables["_RefSkillMastery"].Rows[i].Field<int>("ID"), new RefSkillMastery(dbo.Tables["_RefSkillMastery"].Rows[i].ItemArray));
        }

        static void Initialize_RefTeleLink()
        {
            try
            {
                _RefTeleLink = new List<RefTeleLink>(dbo.Tables["_RefTeleLink"].Rows.Count);

                for (int i = 0; i < dbo.Tables["_RefTeleLink"].Rows.Count; i++)
                    _RefTeleLink.Add(new RefTeleLink(dbo.Tables["_RefTeleLink"].Rows[i].ItemArray));

            }
            catch (Exception w)
            {

            }
        }

        static void Initialize_RefTeleport()
        {
            _RefTeleport = new ConcurrentDictionary<int, RefTeleport>();

            for (int i = 0; i < dbo.Tables["_RefTeleport"].Rows.Count; i++)
                _RefTeleport.TryAdd(dbo.Tables["_RefTeleport"].Rows[i].Field<int>("ID"), new RefTeleport(dbo.Tables["_RefTeleport"].Rows[i].ItemArray));
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
        static void InitializeTab_RefHive()
        {
            Tab_RefHive = new ConcurrentDictionary<int, Tab_RefHive>();

            for (int i = 0; i < dbo.Tables["Tab_RefHive"].Rows.Count; i++)
                Tab_RefHive.TryAdd(dbo.Tables["Tab_RefHive"].Rows[i].Field<int>("dwHiveID"), new Tab_RefHive(dbo.Tables["Tab_RefHive"].Rows[i].ItemArray));
        }


    }
}
