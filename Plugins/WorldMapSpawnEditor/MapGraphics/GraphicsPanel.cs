using ClientDataStorage.Client.Files;
using Editors.Spawn;
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
        #region Properties
        /// <summary>
        /// Defines weather the MapViewer is initialized successfully or not.
        /// </summary>
        internal bool Initialized { get; private set; }

        /// <summary>
        /// Defines the Pixel Size Width and Heigth from a single Region.
        /// </summary>
        private int PictureSize { get; set; } = 256;
        #endregion

        #region Fields

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point MouseDownPoint = new Point(0, 0);

        /// <summary>
        /// The start Position for Drawing.
        /// </summary>
        private Point MovingPoint = new Point(0, 0);

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap.
        /// </summary>
        Dictionary<Point, RegionGraphic> AllRegionGraphics = new Dictionary<Point, RegionGraphic>();

        internal Dictionary<int, Monster> AllMonsters = new Dictionary<int, Monster>();
        internal Dictionary<int, UniqueMonster> AllUniqueMonsters = new Dictionary<int, UniqueMonster>();
        internal Dictionary<int, Npc> AllNpcs = new Dictionary<int, Npc>();


        private protected Bitmap NpcImage;
        private protected Bitmap MonsterImage;
        private protected Bitmap UMonsterImage;

        private protected readonly string NpcIconPath = "Media\\interface\\minimap\\mm_sign_npc.ddj";
        private protected readonly string MonsterIconPath = "Media\\interface\\minimap\\mm_sign_monster.ddj";
        private protected readonly string UMonsterIconPath = "Media\\interface\\minimap\\mm_sign_unique.ddj";

        #endregion

        internal GraphicsPanel()
            => InitializeComponents();



        private void InitializeComponents()
        {
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Initialized = false;
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;

            this.Paint += GraphicsPanel_Paint;
            this.MouseUp += GraphicsPanel_MouseUp;
            this.MouseDown += GraphicsPanel_MouseDown;
            this.MouseWheel += GraphicsPanel_MouseWheel;

            InitializeSpawnImage(NpcIconPath, 8, out NpcImage);
            InitializeSpawnImage(MonsterIconPath, 8, out MonsterImage);
            InitializeSpawnImage(UMonsterIconPath, 8, out UMonsterImage);



            Task.Run(() => InitializeWorldGraphics());
            Task.Run(() => InitializeSpawnGraphics());
        }
        private void InitializeSpawnImage(string pk2PathString, int ImageSize, out Bitmap image)
        {
            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey(pk2PathString))
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory(pk2PathString, out byte[] file))
                {
                    DDJImage DDJFile = new DDJImage(file);
                    ClientDataStorage.Client.Media.DDJFiles.Add(pk2PathString, DDJFile);
                }

            image = ClientDataStorage.Client.Media.DDJFiles[pk2PathString].BitmapImage;
        }

        private void InitializeSpawnGraphics()
        {
            foreach (var nest in ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest)
            {
                var singleSpawn = new SingleSpawn(nest.Value);

                if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 1 && singleSpawn.ObjCommon.TypeID4 == 1 && singleSpawn.ObjCommon.Rarity != Rarity.Unique && singleSpawn.ObjCommon.Rarity != Rarity.UniqueNoMsg)
                {
                    var Mob = new Monster(singleSpawn);
                    AllMonsters.Add(Mob.Spawn.Nest.dwNestID, Mob);
                    continue;
                }
                if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 1 && singleSpawn.ObjCommon.TypeID4 == 1 && (singleSpawn.ObjCommon.Rarity == Rarity.Unique || singleSpawn.ObjCommon.Rarity == Rarity.UniqueNoMsg))
                {
                    var umob = new UniqueMonster(singleSpawn);
                    AllUniqueMonsters.Add(umob.Spawn.Nest.dwNestID, umob);

                    continue;
                }
                if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 2 && singleSpawn.ObjCommon.TypeID4 == 0)
                {
                    var npc = new Npc(singleSpawn);
                    AllNpcs.Add(npc.Spawn.Nest.dwNestID, npc);

                    continue;
                }
            }
            Initialized = true;
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
            else if (e.Button == MouseButtons.Right)
            {
                var regionX = ((MovingPoint.X - e.X) / PictureSize) * -1;
                var regionY = ((MovingPoint.Y - e.Y) / PictureSize) + 128;

                var tregionX = ((float)(MovingPoint.X - e.X) / PictureSize) * -1;
                var tregionY = ((float)(MovingPoint.Y - e.Y) / PictureSize) + 128;

                var spawnPanelLocation = e.X + (MovingPoint.X * -1);

                var rangeXCoordPanel = Enumerable.Range((int)e.X - 4, 8);
                var rangeYCoordPanel = Enumerable.Range((int)e.Y - 4, 8);

                foreach (var npc in AllNpcs.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    ClientDataStorage.Log.Logger.WriteLogLine($"Catched NPC:[{npc.Value.Spawn.ObjCommon.CodeName128}]");
                }
                foreach (var mob in AllMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    ClientDataStorage.Log.Logger.WriteLogLine($"Catched Monster:[{mob.Value.Spawn.ObjCommon.CodeName128}]");

                }
                foreach (var umob in AllUniqueMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    ClientDataStorage.Log.Logger.WriteLogLine($"Catched Unique:[{umob.Value.Spawn.ObjCommon.CodeName128}]");
                }
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
                        e.Graphics.DrawRectangle(Pens.Red, new Rectangle(panelPoint, new Size(PictureSize, PictureSize)));
                        //e.Graphics.DrawString($"{x}x{z}",SystemFonts.DefaultFont,Brushes.Red, new Rectangle(panelPoint, new Size(PictureSize, PictureSize)));
                    }
                }
            }
            if (Initialized)
            {
                foreach (var npc in AllNpcs)
                {
                    npc.Value.UpdateISpawn(PictureSize);
                    e.Graphics.DrawImage(NpcImage, (npc.Value.X * PictureSize + MovingPoint.X) + npc.Value.Location.X, ((((npc.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + npc.Value.Location.Y, NpcImage.Width, NpcImage.Height);
                }
                foreach (var unique in AllUniqueMonsters)
                {
                    unique.Value.UpdateISpawn(PictureSize);
                    var spawnLocationX = (unique.Value.X * PictureSize + MovingPoint.X) + unique.Value.Location.X;
                    var spawnLocationY = ((((unique.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + unique.Value.Location.Y;
                    e.Graphics.DrawImage(UMonsterImage, spawnLocationX - UMonsterImage.Width / 2, spawnLocationY - UMonsterImage.Width / 2, UMonsterImage.Width, UMonsterImage.Height);
                    e.Graphics.DrawEllipse(Pens.Green, spawnLocationX - ((unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize), unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize));
                    e.Graphics.DrawEllipse(Pens.Yellow, spawnLocationX - ((unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize), unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize));
                }
                foreach (var mob in AllMonsters)
                {
                    mob.Value.UpdateISpawn(PictureSize);
                    var spawnLocationX = (mob.Value.X * PictureSize + MovingPoint.X) + mob.Value.Location.X;
                    var spawnLocationY = ((((mob.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + mob.Value.Location.Y;
                    e.Graphics.DrawImage(MonsterImage, spawnLocationX - MonsterImage.Width / 2, spawnLocationY - MonsterImage.Width / 2, MonsterImage.Width, MonsterImage.Height);
                    // e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize));
                    // e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize));
                }
            }

        }
        // int OldPicSize = 256;


        private void GraphicsPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && PictureSize < 6)
                return;
            else if (e.Delta > 0 && PictureSize > 900)
                return;

            PictureSize = e.Delta < 0 ? PictureSize - 6 : PictureSize + 6;

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
