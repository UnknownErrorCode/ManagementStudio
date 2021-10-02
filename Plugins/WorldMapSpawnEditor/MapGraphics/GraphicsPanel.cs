using Structs.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldMapSpawnEditor._2dMapViewer;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal sealed class GraphicsPanel : Panel
    {

        private int PictureSize = 256;

        private Point LastViewPoint = new Point(0, 0);
        private Point MouseDownPoint = new Point(0, 0);
        private Point MovingPoint = new Point(0, 0);

        Dictionary<Point, RegionGraphic> AllRegionGraphics = new Dictionary<Point, RegionGraphic>();

        Dictionary<int, ISpawn> AllSpawns = new Dictionary<int, ISpawn>();
        Dictionary<int, Monster> AllMonsters = new Dictionary<int, Monster>();
        Dictionary<int, UniqueMonster> AllUniqueMonsters = new Dictionary<int, UniqueMonster>();
        Dictionary<int, Npc> AllNpcs = new Dictionary<int, Npc>();

        internal GraphicsPanel()
        {
            DoubleBuffered = true;
            InitializeWorldGraphics();
            Task.Run( () => InitializeSpawns());
            this.Dock = DockStyle.Fill;
            this.Paint += GraphicsPanel_Paint;
            this.MouseWheel += GraphicsPanel_MouseWheel;
            this.MouseDown += GraphicsPanel_MouseDown;
            this.MouseUp += GraphicsPanel_MouseUp;
            this.AutoScroll = true;
            this.AutoSize = true;

        }

        private void InitializeSpawns()
        {

            var nestsOnRegion = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["Tab_RefNest"].Rows.OfType<DataRow>().ToArray();

            var SpawnsOnRegion = new Dictionary<int, SingleSpawn>(nestsOnRegion.Length);
            var array = new SingleSpawn[nestsOnRegion.Length];
            for (int i = 0; i < nestsOnRegion.Length; i++)
            {
                var singleSpawn = new SingleSpawn(new Tab_RefNest(nestsOnRegion[i].ItemArray));
                if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 1 && singleSpawn.ObjCommon.TypeID4 == 1 && singleSpawn.ObjCommon.Rarity != Rarity.Unique)
                {
                    var mob = new Monster(new SingleSpawn(new Tab_RefNest(nestsOnRegion[i].ItemArray)));
                    AllMonsters.Add(AllMonsters.Count, mob);
                    //AllSpawns.Add(mob.Spawn.Nest.dwNestID, mob);
                    continue;
                }
                if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 1 && singleSpawn.ObjCommon.TypeID4 == 1 && singleSpawn.ObjCommon.Rarity == Rarity.Unique)
                {
                    var umob = new UniqueMonster(new SingleSpawn(new Tab_RefNest(nestsOnRegion[i].ItemArray)));
                    AllUniqueMonsters.Add(AllUniqueMonsters.Count, umob);
                    //AllSpawns.Add(umob.Spawn.Nest.dwNestID, umob);

                    continue;
                }
                if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 2 && singleSpawn.ObjCommon.TypeID4 == 0 )
                {
                    var npc = new Npc(new SingleSpawn(new Tab_RefNest(nestsOnRegion[i].ItemArray)));
                    AllNpcs.Add(AllNpcs.Count, npc);
                    //AllSpawns.Add(npc.Spawn.Nest.dwNestID, npc);

                    continue;
                }
            }

           //foreach (SingleSpawn spawn in array.Where(mob => mob.ObjCommon.TypeID1 == 1 && mob.ObjCommon.TypeID2 == 2 && mob.ObjCommon.TypeID3 == 1 && mob.ObjCommon.TypeID4 == 1 && mob.ObjCommon.Rarity != Rarity.Unique))
           //{
           //    var mob = new Monster(spawn);
           //    AllMonsters.Add(AllMonsters.Count, mob);
           //}
           //foreach (SingleSpawn spawn in array.Where(unique => unique.ObjCommon.TypeID1 == 1 && unique.ObjCommon.TypeID2 == 2 && unique.ObjCommon.TypeID3 == 1 && unique.ObjCommon.TypeID4 == 1 && unique.ObjCommon.Rarity == Rarity.Unique))
           //{
           //    var umob = new UniqueMonster(spawn);
           //    AllUniqueMonsters.Add(AllUniqueMonsters.Count, umob);
           //}
           //foreach (SingleSpawn spawn in array.Where(npc => npc.ObjCommon.TypeID1 == 1 && npc.ObjCommon.TypeID2 == 2 && npc.ObjCommon.TypeID3 == 2 && npc.ObjCommon.TypeID4 == 0))
           //{
           //    var npc = new Npc(spawn);
           //    AllNpcs.Add(AllNpcs.Count, npc);
           //}
        }



        private void GraphicsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Location != MouseDownPoint && e.Button == MouseButtons.Left)
            {
                var delta = new Point(e.Location.X - MouseDownPoint.X, e.Location.Y - MouseDownPoint.Y);
                MovingPoint.X += delta.X;
                MovingPoint.Y += delta.Y;


                this.Invalidate();
            }
        }

        private void GraphicsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownPoint = e.Location;
            }
        }

        private void GraphicsPanel_Paint(object sender, PaintEventArgs e)
        {


            var regionPoint = new Point(0, 0);
            var panelPoint = new Point(0, 0);
            for (int x = 0; x < 256; x++)
            {
                regionPoint.X = x;
                panelPoint.X = ((x * PictureSize)) + MovingPoint.X; // + ((LastViewPoint.X / PictureSize) * (LastViewPoint.X /OldPicSize));

                for (int z = 0; z < 128; z++)
                {
                    regionPoint.Y = z;
                    panelPoint.Y = (((z * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y;// + ((LastViewPoint.Y / PictureSize) * (OldPicSize - PictureSize));

                    if (AllRegionGraphics.TryGetValue(regionPoint, out RegionGraphic region))
                    {
                        e.Graphics.DrawImage(region.RegionLayer, panelPoint.X, panelPoint.Y, PictureSize, PictureSize);
                    }
                    else
                    {
                       // e.Graphics.DrawRectangle(Pens.Red, new Rectangle(panelPoint, new Size(PictureSize, PictureSize)));
                        //e.Graphics.DrawString($"{x}x{z}",SystemFonts.DefaultFont,Brushes.Red, new Rectangle(panelPoint, new Size(PictureSize, PictureSize)));
                    }
                }
            }
            foreach (var npc in AllNpcs)
            {
                npc.Value.UpdateISpawn(PictureSize);
                e.Graphics.DrawImage(npc.Value.Texture,( npc.Value.X *PictureSize + MovingPoint.X) + npc.Value.Location.X, ((((npc.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) +npc.Value.Location.Y, npc.Value.Texture.Width, npc.Value.Texture.Height);
            }
            foreach (var unique in AllUniqueMonsters)
            {
                unique.Value.UpdateISpawn(PictureSize);
                var spawnLocationX = (unique.Value.X * PictureSize + MovingPoint.X) + unique.Value.Location.X;
                var spawnLocationY = ((((unique.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + unique.Value.Location.Y;
                e.Graphics.DrawImage(unique.Value.Texture, spawnLocationX, spawnLocationY, unique.Value.Texture.Width, unique.Value.Texture.Height);
                e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize), unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize));
                e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize));
            }
            foreach (var mob in AllMonsters)
            {
                mob.Value.UpdateISpawn(PictureSize);
                var spawnLocationX = (mob.Value.X * PictureSize + MovingPoint.X) + mob.Value.Location.X;
                var spawnLocationY = ((((mob.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + mob.Value.Location.Y;
                e.Graphics.DrawImage(mob.Value.Texture, spawnLocationX, spawnLocationY, mob.Value.Texture.Width, mob.Value.Texture.Height);
                e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize));
                e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize));
            }
        }
        int OldPicSize = 256;
        private bool dragged;

        private void GraphicsPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            LastViewPoint.X = MovingPoint.X - e.Location.X;/// PictureSize; //- (this.Width/2);
            LastViewPoint.Y = MovingPoint.Y - e.Location.Y;//;/ PictureSize  - this.Height  / PictureSize);

            if (e.Delta < 0 && PictureSize < 5)
                return;
            else if (e.Delta > 0 && PictureSize > 300)
                return;
            OldPicSize = PictureSize;
            PictureSize = e.Delta < 0 ? PictureSize - 2 : PictureSize + 2;

            this.Invalidate();
        }



        private void InitializeWorldGraphics()
        {
            var allRegions = ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["_RefRegion"].Rows;

            foreach (DataRow item in allRegions)
            {
                var rGraphic = new RegionGraphic(item.Field<short>("wRegionID"));
                if (rGraphic.RegionLayer != null)
                {
                    AllRegionGraphics.Add(new Point(rGraphic.X, rGraphic.Z), rGraphic);
                }
            }
        }
    }
}
