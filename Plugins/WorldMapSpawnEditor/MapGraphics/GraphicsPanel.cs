using ClientDataStorage.Client.Files;
using Editors.Spawn;
using Editors.Teleport;
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

        /// <summary>
        /// Weather the Spawn Editor should be open on click.
        /// </summary>
        internal bool OpenEditorOnClick { get; set; } = false;

        internal bool ShowNpc { get; set; } = false;
        internal bool ShowPlayer { get; set; } = false;
        internal bool ShowMonster { get; set; } = false;
        internal bool ShowTeleport { get; set; } = false;
        internal bool ShowUniqueMonster { get; set; } = false;

        internal bool ShowDbRegions { get; set; } = true;
        internal bool ShowUnassignedRegions { get; set; } = true;




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
        /// String builder for tooltip text help.
        /// </summary>
        StringBuilder StrBuilder = new StringBuilder();

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point MouseDownPoint = new Point(0, 0);

        /// <summary>
        /// The start Position for Drawing.
        /// </summary>
        private Point MovingPoint = new Point(0, 0);

        /// <summary>
        /// Delta position from last MouseDown and MouseUp. This is required to calculate the MovePoint for swiping
        /// </summary>
        private Point Delta = new Point(0, 0);

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point MouseSroRegioDownPoint = new Point(0, 0);

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap existing in the DB.
        /// </summary>
        Dictionary<Point, RegionGraphic> AllRegionGraphics = new Dictionary<Point, RegionGraphic>();

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap that does not existing in the DB but -m file is aviable.
        /// </summary>
        Dictionary<Point, RegionGraphic> AllUnusedRegionGraphics = new Dictionary<Point, RegionGraphic>();

        internal Dictionary<int, Monster> AllMonsters = new Dictionary<int, Monster>();
        internal Dictionary<int, UniqueMonster> AllUniqueMonsters = new Dictionary<int, UniqueMonster>();
        internal Dictionary<int, Npc> AllNpcs = new Dictionary<int, Npc>();
        internal Dictionary<int, IChar> AllPlayer = new Dictionary<int, IChar>();
        internal Dictionary<int, Teleport> AllTeleports = new Dictionary<int, Teleport>();
        internal Dictionary<string, NewPosition> NewPosDic = new Dictionary<string, NewPosition>();


        #region Spawn Bitmap Images
        private Bitmap NpcImage;
        private Bitmap PlayerImage;
        private Bitmap MonsterImage;
        private Bitmap UMonsterImage;
        private Bitmap TeleportImage;
        private Bitmap OwnPointImage;

        #endregion

        #region Spawn Bitmap Image Paths
        private readonly string NpcIconPath = "Media\\interface\\minimap\\mm_sign_npc.ddj";
        private readonly string PlayerIconPath = "Media\\interface\\minimap\\mm_sign_otherplayer.ddj";
        private readonly string MonsterIconPath = "Media\\interface\\minimap\\mm_sign_monster.ddj";
        private readonly string UMonsterIconPath = "Media\\interface\\minimap\\mm_sign_unique.ddj";
        private readonly string TeleportIconPath = "Media\\interface\\worldmap\\map\\xy_gate.ddj";
        private readonly string OwnPointIconPath = "Media\\interface\\minimap\\mm_sign_animal.ddj";
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
            InitializeSpawnImage(PlayerIconPath, 8, out PlayerImage);
            InitializeSpawnImage(MonsterIconPath, 8, out MonsterImage);
            InitializeSpawnImage(UMonsterIconPath, 8, out UMonsterImage);
            InitializeSpawnImage(TeleportIconPath, 16, out TeleportImage);
            InitializeSpawnImage(OwnPointIconPath, 8, out OwnPointImage);



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

            if (HasToolTip)
            {
                var rangeXCoordPanel = Enumerable.Range((int)e.X - 8, 16);
                var rangeYCoordPanel = Enumerable.Range((int)e.Y - 8, 16);

                StrBuilder.Clear();
                if (ShowMonster)
                    foreach (var mob in AllMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                        StrBuilder.AppendLine(mob.Value.Spawn.ObjCommon.CodeName128);
                if (ShowNpc)
                    foreach (var npc in AllNpcs.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ((int)Math.Round(ch.Value.Spawn.Nest.fLocalPosX / (1920f / PictureSize), 0))) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ((int)Math.Round((ch.Value.Spawn.Nest.fLocalPosZ / (1920f / PictureSize)) * -1)))))
                        StrBuilder.AppendLine(npc.Value.Spawn.ObjCommon.CodeName128);

                if (ShowUniqueMonster)
                    foreach (var umob in AllUniqueMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                        StrBuilder.AppendLine(umob.Value.Spawn.ObjCommon.CodeName128);
                if (ShowPlayer)
                    foreach (var player in ClientDataStorage.Database.SRO_VT_SHARD._Char.Where(ch => rangeXCoordPanel.Contains((((ch.Value.LatestRegion % 256) * PictureSize + MovingPoint.X) + ((int)Math.Round(ch.Value.PosX / (1920f / PictureSize), 0)))) && rangeYCoordPanel.Contains((((((ch.Value.LatestRegion / 256) * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ((int)Math.Round((ch.Value.PosZ / (1920f / PictureSize)) * -1)))))
                        StrBuilder.AppendLine(player.Value.CharName16);


                tip.Show(StrBuilder.ToString(), Parent, e.X + 20, e.Y + 2, 5000);

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
            AllNpcs = new Dictionary<int, Npc>();
            AllMonsters = new Dictionary<int, Monster>();
            AllUniqueMonsters = new Dictionary<int, UniqueMonster>();
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

            foreach (var teleport in ClientDataStorage.Database.SRO_VT_SHARD._RefTeleport.Values)
            {
                if (teleport.AssocRefObjID > 0)
                {
                    var tele = new Teleport(new SingleTeleport(teleport));
                    AllTeleports.Add(tele.TeleportData.Teleport.ID, tele);
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
                Delta.X = e.Location.X - MouseDownPoint.X; Delta.Y = e.Location.Y - MouseDownPoint.Y;
                MovingPoint.X += Delta.X;
                MovingPoint.Y += Delta.Y;

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


                float fRegX = ((MouseSroRegioDownPoint.X) * PictureSize + (MovingPoint.X - e.X)) * -1;
                float RegX = (float)Math.Round(fRegX * (1920f / PictureSize), 0);

                int fRegX2 = ((MouseSroRegioDownPoint.X) * PictureSize + (MovingPoint.X - e.X)) * -1;
                int RegX2 = (int)Math.Round(fRegX * (1920f / PictureSize), 0);

                float fRegY = ((128 * PictureSize) + (MovingPoint.Y - e.Y)) - ((MouseSroRegioDownPoint.Y) * PictureSize);
                float RegY = (float)Math.Round(fRegY * (1920f / PictureSize));

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
                        if (ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"/warp {regionID} {RegX} {Z} {RegY}\n\nX:{MouseSroRegioDownPoint.X}\nY:{MouseSroRegioDownPoint.Y}", "Add new Position?"))
                        {
                            string str = ServerFrameworkRes.BasicControls.vSroMessageBox.GetInput("Enter the Name of your Point inside the InputBox.", "Add new location", "Pos Name:");
                            NewPosDic.Add(str, new NewPosition() { RegionID = (short)regionID, Position = new System.Numerics.Vector3(RegX, RegY, Z) });
                            this.Invalidate();
                        }
                }
                else
                    ServerFrameworkRes.BasicControls.vSroMessageBox.Show($"/warp {regionID} {RegX} 0 {RegY}\n\nFailed to get Z coordinate\nUse Charakter Position to get hight.\n\nX:{MouseSroRegioDownPoint.X}\nY:{MouseSroRegioDownPoint.Y}");



                var rangeXCoordPanel = Enumerable.Range((int)e.X - 6, 12);
                var rangeYCoordPanel = Enumerable.Range((int)e.Y - 6, 12);

                foreach (var npc in AllNpcs.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    if (OpenEditorOnClick && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {npc.Value.Spawn.ObjCommon.CodeName128}", "SpawnEditor"))
                        using (SpawnEditor Editor = new SpawnEditor(npc.Value.Spawn))
                            Editor.ShowDialog();
                }
                foreach (var mob in AllMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    if (OpenEditorOnClick && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {mob.Value.Spawn.ObjCommon.CodeName128}", "SpawnEditor"))
                    {
                        using (SpawnEditor Editor = new SpawnEditor(mob.Value.Spawn))
                            Editor.ShowDialog();
                    }
                }
                foreach (var umob in AllUniqueMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + MovingPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ch.Value.Location.Y)))
                {
                    if (OpenEditorOnClick && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {umob.Value.Spawn.ObjCommon.CodeName128}", "SpawnEditor"))
                        using (SpawnEditor Editor = new SpawnEditor(umob.Value.Spawn))
                            Editor.ShowDialog();
                }
            }
        }

        Point regionPoint = new Point(0, 0);
        Point panelPoint = new Point(0, 0);
        /// <summary>
        /// When the panel gets repainted it after invalidate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_Paint(object sender, PaintEventArgs e)
        {

           var xRange = Enumerable.Range(-this.PictureSize, this.Width + PictureSize);
            var yRange = Enumerable.Range(-this.PictureSize, this.Height + PictureSize);

            for (int x = 0; x < 256; x++)
            {
                regionPoint.X = x;
                panelPoint.X = ((x * PictureSize)) + MovingPoint.X;

                for (int z = 0; z < 128; z++)
                {
                    regionPoint.Y = z;
                    panelPoint.Y = ((((z * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) - PictureSize;


                    if (xRange.Contains(panelPoint.X) && yRange.Contains(panelPoint.Y))
                    {
                        if (AllRegionGraphics.TryGetValue(regionPoint, out RegionGraphic region) && this.ShowDbRegions)
                            e.Graphics.DrawImage(region.RegionLayer, panelPoint.X, panelPoint.Y, PictureSize, PictureSize);
                        else if (AllUnusedRegionGraphics.TryGetValue(regionPoint, out RegionGraphic unassignedregion) && this.ShowUnassignedRegions)
                            e.Graphics.DrawImage(unassignedregion.RegionLayer, panelPoint.X, panelPoint.Y, PictureSize, PictureSize);
                        else
                        {
                            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(panelPoint, new Size(PictureSize, PictureSize)));
                            if (this.PictureSize > 128)
                                e.Graphics.DrawString($"X: {regionPoint.X} Z: {regionPoint.Y} \n", this.Font, Brushes.AliceBlue, panelPoint);
                        }
                    }
                }
            }
            if (Initialized)
            {
                if (ShowNpc)
                    foreach (var npc in AllNpcs)
                    {
                        e.Graphics.DrawImage(NpcImage, (npc.Value.X * PictureSize + MovingPoint.X) + (int)Math.Round(npc.Value.Spawn.Nest.fLocalPosX / (1920f / PictureSize), 0), ((((npc.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + (int)Math.Round((npc.Value.Spawn.Nest.fLocalPosZ / (1920f / PictureSize)) * -1), NpcImage.Width, NpcImage.Height);
                    }
                if (ShowMonster)
                    foreach (var mob in AllMonsters)
                    {
                        mob.Value.UpdateISpawn(PictureSize);
                        var spawnLocationX = (mob.Value.X * PictureSize + MovingPoint.X) + mob.Value.Location.X;
                        var spawnLocationY = ((((mob.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + mob.Value.Location.Y;
                        e.Graphics.DrawImage(MonsterImage, spawnLocationX - MonsterImage.Width / 2, spawnLocationY - MonsterImage.Width / 2, MonsterImage.Width, MonsterImage.Height);
                        e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nRadius / (1920 / PictureSize));
                        e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize), mob.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize));
                    }
                if (ShowUniqueMonster)
                    foreach (var unique in AllUniqueMonsters)
                    {
                        unique.Value.UpdateISpawn(PictureSize);
                        var spawnLocationX = (unique.Value.X * PictureSize + MovingPoint.X) + unique.Value.Location.X;
                        var spawnLocationY = ((((unique.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + unique.Value.Location.Y;
                        e.Graphics.DrawImage(UMonsterImage, spawnLocationX - UMonsterImage.Width / 2, spawnLocationY - UMonsterImage.Width / 2, UMonsterImage.Width, UMonsterImage.Height);
                        e.Graphics.DrawEllipse(Pens.Green, spawnLocationX - ((unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize)) / 2), unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize), unique.Value.Spawn.Nest.nRadius / (1920 / PictureSize));
                        e.Graphics.DrawEllipse(Pens.Yellow, spawnLocationX - ((unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize)) / 2), unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize), unique.Value.Spawn.Nest.nGenerateRadius / (1920 / PictureSize));
                    }

                foreach (var item in NewPosDic)
                {
                    e.Graphics.DrawImage(OwnPointImage, new PointF((Convert.ToSingle((item.Value.RegionID % 256) * PictureSize + MovingPoint.X)) + (item.Value.Position.X / (1920f / PictureSize)), Convert.ToSingle(((((item.Value.RegionID / 256) * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + ((item.Value.Position.Y / (1920f / PictureSize)) * -1)));
                }

                if (ShowTeleport)
                    foreach (var teleport in AllTeleports.Values)
                    {
                        e.Graphics.DrawImage(TeleportImage, (teleport.X * PictureSize + MovingPoint.X) + (int)Math.Round(teleport.Location.X / (1920f / PictureSize), 0), ((((teleport.Y * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + (int)Math.Round((teleport.Location.Y / (1920f / PictureSize)) * -1), TeleportImage.Width, TeleportImage.Height);
                    }
                if (ShowPlayer)
                    foreach (var item in ClientDataStorage.Database.SRO_VT_SHARD._Char.Values)
                    {
                        e.Graphics.DrawImage(PlayerImage, ((item.LatestRegion % 256) * PictureSize + MovingPoint.X) + (int)Math.Round(item.PosX / (1920f / PictureSize), 0), (((((item.LatestRegion / 256) * PictureSize) - (128 * PictureSize)) * -1) + MovingPoint.Y) + (int)Math.Round((item.PosZ / (1920f / PictureSize)) * -1), PlayerImage.Width, PlayerImage.Height);
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
            MovingPoint.X = e.Delta < 0 ? MovingPoint.X + MouseSroRegioDownPoint.X * 6 : MovingPoint.X - MouseSroRegioDownPoint.X * 6;
            MovingPoint.Y = e.Delta < 0 ? MovingPoint.Y + MouseSroRegioDownPoint.Y * 6 : MovingPoint.Y - MouseSroRegioDownPoint.Y * 6;

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
            Point point = new Point(0, 0);
            foreach (DataRow item in allRegions)
            {
                var rGraphic = new RegionGraphic(item.Field<short>("wRegionID"));
                if (rGraphic.RegionLayer != null)
                {
                    point.X = rGraphic.X;
                    point.Y = rGraphic.Z;
                    AllRegionGraphics.Add(point, rGraphic);
                }
                else
                {
                    //Missing Minimap
                }
            }

            Point p = new Point(0, 0);
            for (int i = 0; i < 255; i++)
            {
                for (int i2 = 0; i2 < 255; i2++)
                {
                    p.X = i; p.Y = i2;

                    var str = $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{i}x{i2}.JPG";
                    if (System.IO.File.Exists(str))
                    {
                        if (!AllRegionGraphics.ContainsKey(p))
                        {
                            var rID = Convert.ToInt32($"{i2.ToString("X")}{i.ToString("X")}", 16);
                            AllUnusedRegionGraphics.Add(p, new RegionGraphic((short)rID));
                        }
                    }
                }
            }
        }
    }
}
