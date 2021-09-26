using Structs.Database;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer
{
    abstract class RegionSpawn : PictureBox
    {
        /// <summary>
        /// Region Identifier.
        /// </summary>
        private short RegionID { get; set; }

        /// <summary>
        /// List of all Monster Controls.
        /// </summary>
        internal List<Monster> MonsterOnRegion = new List<Monster>();

        /// <summary>
        /// List of all UniqueMonster Controls.
        /// </summary>
        internal List<UniqueMonster> UniqueMonsterOnRegion = new List<UniqueMonster>();

        /// <summary>
        /// List of all Npc Controls.
        /// </summary>
        internal List<Npc> NpcOnRegion = new List<Npc>();

        /// <summary>
        /// Contains all Controls that are required to display on the Map
        /// </summary>
        /// <param name="regID"></param>
        internal RegionSpawn(short regID)
        {
            RegionID = regID;
            InitializeSpawns();
        }

        /// <summary>
        /// Initialize Spawns on the Region.
        /// </summary>
        private void InitializeSpawns()
        {
            if (ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["Tab_RefNest"].Rows.OfType<DataRow>().Any(row => row.Field<short>("nRegionDBID") == RegionID))
            {
                var nestsOnRegion = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["Tab_RefNest"].Rows.OfType<DataRow>().Where(row => row.Field<short>("nRegionDBID") == RegionID).ToArray();

                var SpawnsOnRegion = new List<SingleSpawn>(nestsOnRegion.Length);

                for (int i = 0; i < nestsOnRegion.Length; i++)
                    SpawnsOnRegion.Add(new SingleSpawn(new Tab_RefNest(nestsOnRegion[i].ItemArray)));

                if (GenerateSpawns(SpawnsOnRegion, out MonsterOnRegion, out UniqueMonsterOnRegion, out NpcOnRegion))
                {
                    if (this.InvokeRequired)
                    {
                        this.SuspendLayout();

                        if (MonsterOnRegion.Count > 0)
                            Invoke((MethodInvoker)delegate
                            {
                                this.Controls.AddRange(MonsterOnRegion.ToArray());
                            });

                        if (UniqueMonsterOnRegion.Count > 0)
                            Invoke((MethodInvoker)delegate
                            {
                                this.Controls.AddRange(UniqueMonsterOnRegion.ToArray());
                            });

                        if (NpcOnRegion.Count > 0)
                            Invoke((MethodInvoker)delegate
                            {
                                this.Controls.AddRange(NpcOnRegion.ToArray());
                            });

                        this.ResumeLayout();
                        return;
                    }

                    this.SuspendLayout();

                    if (MonsterOnRegion.Count > 0)
                        this.Controls.AddRange(MonsterOnRegion.ToArray());


                    if (UniqueMonsterOnRegion.Count > 0)
                        this.Controls.AddRange(UniqueMonsterOnRegion.ToArray());
                    if (NpcOnRegion.Count > 0)
                        this.Controls.AddRange(NpcOnRegion.ToArray());

                    this.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// Generates all Controls on the RegionID.
        /// </summary>
        /// <param name="SpawnsOnRegion"></param>
        /// <param name="monsterOnRegion"></param>
        /// <param name="uniqueMonsterOnRegion"></param>
        /// <param name="npcOnRegion"></param>
        /// <returns>bool Weather it succeed or fail to generate the Controls.</returns>
        private bool GenerateSpawns(List<SingleSpawn> SpawnsOnRegion, out List<Monster> monsterOnRegion, out List<UniqueMonster> uniqueMonsterOnRegion, out List<Npc> npcOnRegion)
        {
            monsterOnRegion = new List<Monster>(); uniqueMonsterOnRegion = new List<UniqueMonster>(); npcOnRegion = new List<Npc>();

            if (SpawnsOnRegion.Count <= 0)
                return false;

            foreach (SingleSpawn spawn in SpawnsOnRegion.Where(mob => mob.ObjCommon.TypeID1 == 1 && mob.ObjCommon.TypeID2 == 2 && mob.ObjCommon.TypeID3 == 1 && mob.ObjCommon.TypeID4 == 1 && mob.ObjCommon.Rarity != Rarity.Unique))
                MonsterOnRegion.Add(new Monster(spawn));
            foreach (SingleSpawn spawn in SpawnsOnRegion.Where(unique => unique.ObjCommon.TypeID1 == 1 && unique.ObjCommon.TypeID2 == 2 && unique.ObjCommon.TypeID3 == 1 && unique.ObjCommon.TypeID4 == 1 && unique.ObjCommon.Rarity == Rarity.Unique))
                UniqueMonsterOnRegion.Add(new UniqueMonster(spawn));
            foreach (SingleSpawn spawn in SpawnsOnRegion.Where(npc => npc.ObjCommon.TypeID1 == 1 && npc.ObjCommon.TypeID2 == 2 && npc.ObjCommon.TypeID3 == 2 && npc.ObjCommon.TypeID4 == 0))
                NpcOnRegion.Add(new Npc(spawn));

            return true;
        }
    }
}
