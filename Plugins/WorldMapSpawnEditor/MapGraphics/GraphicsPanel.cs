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

namespace WorldMapSpawnEditor.MapGraphics
{
    internal sealed class GraphicsPanel : Panel
    {
        #region Properties

        /// <summary>
        /// Indicates weather the tooltip should be shown or not.
        /// </summary>
        internal bool HasToolTip { get; set; } = false;

        internal bool OpenEditorOnClick { get; set; } = false;


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
        /// Unique tooltip used for anyting that requires a Tip to display to avoid creating duplicate tooltips.
        /// </summary>
        ToolTip tip = new ToolTip();

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point MouseDownPoint = new Point(0, 0);

        /// <summary>
        /// The start Position for Drawing.
        /// </summary>
        private Point MovingPoint = new Point(0, 0);

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point MouseSroRegioDownPoint = new Point(0, 0);

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap.
        /// </summary>
        Dictionary<Point, RegionGraphic> AllRegionGraphics = new Dictionary<Point, RegionGraphic>();

        internal Dictionary<int, Monster> AllMonsters = new Dictionary<int, Monster>();
        internal Dictionary<int, UniqueMonster> AllUniqueMonsters = new Dictionary<int, UniqueMonster>();
        internal Dictionary<int, Npc> AllNpcs = new Dictionary<int, Npc>();


        #region Spawn Bitmap Images
        private Bitmap NpcImage;
        private Bitmap MonsterImage;
        private Bitmap UMonsterImage;
        #endregion

        #region Spawn Bitmap Image Paths
        private readonly string NpcIconPath = "Media\\interface\\minimap\\mm_sign_npc.ddj";
        private readonly string MonsterIconPath = "Media\\interface\\minimap\\mm_sign_monster.ddj";
        private readonly string UMonsterIconPath = "Media\\interface\\minimap\\mm_sign_unique.ddj";
        #endregion
        #endregion

        internal GraphicsPanel()
            => InitializeComponents();


        /// <summary>
        /// Initializes all required components for the WorldMap viewer
        /// </summary>
        private void InitializeComponents()
        {
            //this.AutoSize = true;
            //this.AutoScroll = true;
            this.Initialized = false;
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;

            this.Paint += GraphicsPanel_Paint;
            this.MouseUp += GraphicsPanel_MouseUp;
            this.MouseDown += GraphicsPanel_MouseDown;
            this.MouseWheel += GraphicsPanel_MouseWheel;
            this.MouseMove += GraphicsPanel_MouseMove;

            InitializeSpawnImage(NpcIconPath, 8, out NpcImage);
            InitializeSpawnImage(MonsterIconPath, 8, out MonsterImage);
            InitializeSpawnImage(UMonsterIconPath, 8, out UMonsterImage);



            Task.Run(() => InitializeWorldGraphics());
            Task.Run(() => InitializeSpawnGraphics());
        }

        /// <summary>
        /// On Mouse Move it calculates the neccesary informations from each spawn below the cursor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            var rangeXCoordPanel = Enumerable.Range((int)e.X - 8, 16);
            var rangeYCoordPanel = Enumerable.Range((int)e.Y - 8, 16);

            if (HasToolTip)
            {
                foreach (var npc in AllNpcs.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                    tip.Show(npc.Value.Spawn.ObjCommon.CodeName128, Parent, e.X + 20, e.Y + 2, 5000);

                foreach (var mob in AllMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                    tip.Show(mob.Value.Spawn.ObjCommon.CodeName128, Parent, e.X + 20, e.Y + 2, 5000);

                foreach (var umob in AllUniqueMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                    tip.Show(umob.Value.Spawn.ObjCommon.CodeName128, Parent, e.X + 20, e.Y + 2, 5000);
            }

        }

        /// <summary>
        /// Initializes all Spawn Images to the Panel.
        /// </summary>
        /// <param name="pk2PathString"></param>
        /// <param name="ImageSize"></param>
        /// <param name="image"></param>
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

        /// <summary>
        /// Defines weather the spawn is a monster, npc or smthing else...
        /// </summary>
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

        /// <summary>
        /// On mouse up. Required for moving the view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Location != MouseDownPoint && e.Button == MouseButtons.Left)
            {

                var delta = new Point(e.Location.X - MouseDownPoint.X, e.Location.Y - MouseDownPoint.Y);
                MovingPoint.X += delta.X;
                MovingPoint.Y += delta.Y;

                if (MovingPoint.X > 0)
                    MovingPoint.X = 0;

                if (MovingPoint.Y > 0)
                    MovingPoint.Y = 0;


                if (MovingPoint.X < -PictureSize * 256 + this.Width)
                    MovingPoint.X = -PictureSize * 256 + this.Width;

                if (MovingPoint.Y < -PictureSize * 128 + this.Height)
                    MovingPoint.Y  = -PictureSize * 128 + this.Height;

                this.Invalidate();
            }
        }

        /// <summary>
        /// On mouse down. Required for releasing the view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownPoint = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                MouseSroRegioDownPoint.X = ((MovingPoint.X - e.X) / PictureSize) * -1;
                MouseSroRegioDownPoint.Y = ((MovingPoint.Y - e.Y) / PictureSize) + 127;

                var strx = MouseSroRegioDownPoint.X.ToString("X");
                var stry = MouseSroRegioDownPoint.Y.ToString("X");
                var strin = $"{stry}{strx}";

                var regionID = Convert.ToInt32(strin, 16);


                float fRegX = ((MouseSroRegioDownPoint.X + 1) * PictureSize + (MovingPoint.X - e.X) - PictureSize) * -1;
                float RegX = fRegX * (1920 / PictureSize);

                float fRegY = ((128 * PictureSize) + (MovingPoint.Y - e.Y)) - ((MouseSroRegioDownPoint.Y) * PictureSize);
                float RegY = fRegY * (1920 / PictureSize);

                if (!ClientDataStorage.Client.Map.AllmFiles.ContainsKey(MouseSroRegioDownPoint))
                {
                    if (ClientDataStorage.Client.Map.MapPk2.GetByteArrayByDirectory($"Map\\{MouseSroRegioDownPoint.Y}\\{MouseSroRegioDownPoint.X}.m", out byte[] mFile))
                    {
                        var mfi = new mFile(mFile, (byte)MouseSroRegioDownPoint.X, (byte)MouseSroRegioDownPoint.Y);
                        ClientDataStorage.Client.Map.AllmFiles.Add(MouseSroRegioDownPoint, mfi);
                    }
                }
                if (ClientDataStorage.Client.Map.AllmFiles.ContainsKey(MouseSroRegioDownPoint))
                {
                    if (ClientDataStorage.Client.Map.AllmFiles[MouseSroRegioDownPoint].GetHightByfPoint(RegX, RegY, out float Z))
                        ServerFrameworkRes.BasicControls.vSroMessageBox.Show($"/warp {regionID} {RegX} {Z} {RegY}\n\nX:{MouseSroRegioDownPoint.X}\nY:{MouseSroRegioDownPoint.Y}");
                    else
                        ServerFrameworkRes.BasicControls.vSroMessageBox.Show($"/warp {regionID} {RegX} 0 {RegY}\nFailed to get Z coordinate\nX:{MouseSroRegioDownPoint.X}\nY:{MouseSroRegioDownPoint.Y}");

                }


                var rangeXCoordPanel = Enumerable.Range((int)e.X - 8, 16);
                var rangeYCoordPanel = Enumerable.Range((int)e.Y - 8, 16);

                foreach (var npc in AllNpcs.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    ClientDataStorage.Log.Logger.WriteLogLine($"Catched NPC:[{npc.Value.Spawn.ObjCommon.CodeName128}]");


                    if (OpenEditorOnClick)
                        using (SpawnEditor Editor = new SpawnEditor(npc.Value.Spawn))
                            Editor.Show();
                }
                foreach (var mob in AllMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    ClientDataStorage.Log.Logger.WriteLogLine($"Catched Monster:[{mob.Value.Spawn.ObjCommon.CodeName128}]");
                    if (OpenEditorOnClick)
                        using (SpawnEditor Editor = new SpawnEditor(mob.Value.Spawn))
                            Editor.Show();
                }
                foreach (var umob in AllUniqueMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    ClientDataStorage.Log.Logger.WriteLogLine($"Catched Unique:[{umob.Value.Spawn.ObjCommon.CodeName128}]");
                    if (OpenEditorOnClick)
                        using (SpawnEditor Editor = new SpawnEditor(umob.Value.Spawn))
                            Editor.Show();
                }
            }
        }

        /// <summary>
        /// When the panel gets repainted it after invalidate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    panelPoint.Y = ((((z * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) - PictureSize;// + ((LastViewPoint.Y / PictureSize) * (OldPicSize - PictureSize));

                    if (AllRegionGraphics.TryGetValue(regionPoint, out RegionGraphic region))
                        e.Graphics.DrawImage(region.RegionLayer, panelPoint.X, panelPoint.Y, PictureSize, PictureSize);
                    else
                        e.Graphics.DrawRectangle(Pens.Red, new Rectangle(panelPoint, new Size(PictureSize, PictureSize)));
                }
            }
            if (Initialized)
            {
                foreach (var npc in AllNpcs)
                {

                    npc.Value.UpdateISpawn(PictureSize);
                    e.Graphics.DrawImage(NpcImage, (npc.Value.X * PictureSize + MovingPoint.X) + (int)Math.Round(npc.Value.Spawn.Nest.fLocalPosX / (1920f / PictureSize), 0), ((((npc.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + (int)Math.Round((npc.Value.Spawn.Nest.fLocalPosZ / (1920f / PictureSize)) * -1), NpcImage.Width, NpcImage.Height);
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
                    e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize));
                    e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize));
                }
            }

        }

        /// <summary>
        /// on scroll for zoom. TODO: keep position on scroll to Mouse Cursor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && PictureSize < 6)
                return;
            else if (e.Delta > 0 && PictureSize > 900)
                return;

            MouseSroRegioDownPoint.X = ((MovingPoint.X - e.X) / PictureSize) * -1;
            MouseSroRegioDownPoint.Y = ((MovingPoint.Y - e.Y) / PictureSize) * -1;

            PictureSize = e.Delta < 0 ? PictureSize - 6 : PictureSize + 6;
            // MovingPoint.X = e.Delta < 0 ? MovingPoint.X - MouseSroRegioDownPoint.X * 6 : MovingPoint.X + MouseSroRegioDownPoint.X * 6;
            // MovingPoint.Y = e.Delta < 0 ? MovingPoint.Y + MouseSroRegioDownPoint.Y * 6 : MovingPoint.Y - MouseSroRegioDownPoint.Y * 6;
            if (MovingPoint.X > 0)
                MovingPoint.X = 0;

            if (MovingPoint.Y > 0)
                MovingPoint.Y = 0;


            if (MovingPoint.X < -PictureSize * 256 + this.Width)
                MovingPoint.X = -PictureSize * 256 + this.Width;

            if (MovingPoint.Y < -PictureSize * 128 + this.Height)
                MovingPoint.Y = -PictureSize * 128 + this.Height;


            this.Invalidate();
        }

        /// <summary>
        /// Initialize the entired _RefRegion map into the application for faster loadup.
        /// </summary>
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
