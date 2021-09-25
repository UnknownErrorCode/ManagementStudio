using ClientDataStorage.Client.Files;
using Structs.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer
{
    class RegionSpawn
    {
        private short RegionID { get; set; }

        internal List<Monster> MonsterOnRegion = new List<Monster>();
        internal List<UniqueMonster> UniqueMonsterOnRegion = new List<UniqueMonster>();
        internal List<Npc> NpcOnRegion = new List<Npc>();

        internal RegionSpawn(short regID)
        {
            RegionID = regID;
            InitializeSpawns();
        }

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
                }
            }
        }

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


    abstract class ISpawn : Panel
    {
        public SingleSpawn Spawn { get; }
         public string ImgPath { get; set; }

        public ISpawn(SingleSpawn spawn, int size, string mediaPath)
        {
            Spawn = spawn;
            ImgPath = mediaPath;
            this.DoubleBuffered = true;
            this.Size = new Size(12, 12);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Location = new Point((int)Math.Round(spawn.Nest.fLocalPosX / 7.5f,0)-6 , (int) Math.Round((spawn.Nest.fLocalPosZ / 7.5f - 256 )* -1) -6);
            DrawBackgroundImage();
        }

        private void DrawBackgroundImage()
        {
            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey(ImgPath))
            {
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory(ImgPath, out byte[] file))
                {
                    DDJImage DDJFile = new DDJImage(file);
                    DDSImage DDSFile = new DDSImage(file, true);

                    this.BackgroundImage = DDJFile.BitmapImage;
                    return;
                }
            }
            this.BackColor = Color.Orange;
        }
    }


    class Monster : ISpawn
    {
        internal Monster(SingleSpawn spawn) : base(spawn, 8, "Media\\interface\\minimap\\mm_sign_monster.ddj")
        {
            this.Click += Monster_Click;
            ToolTip tip = new ToolTip() { InitialDelay = 100, AutoPopDelay = 0, ReshowDelay = 100 };
            tip.SetToolTip(this, spawn.ObjCommon.CodeName128);
        }

        private void Monster_Click(object sender, EventArgs e)
        {
            
        }
    }


    class UniqueMonster : ISpawn
    {
        internal UniqueMonster(SingleSpawn spawn) : base(spawn, 12, "Media\\interface\\minimap\\mm_sign_unique.ddj")
        {
            this.Click += UniqueMonster_Click; ;
        }

        private void UniqueMonster_Click(object sender, EventArgs e)
        {
        }
    }

    class Npc : ISpawn
    {

        internal Npc(SingleSpawn spawn) : base(spawn, 8, "Media\\interface\\minimap\\mm_sign_npc.ddj")
        {
            this.Click += Npc_Click; ;
        }

        private void Npc_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
    class Teleport
    {

    }
}
