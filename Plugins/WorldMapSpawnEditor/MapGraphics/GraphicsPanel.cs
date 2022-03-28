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

        internal bool ShowDbRegions { get; set; } = false;
        internal bool ShowUnassignedRegions { get; set; } = false;
        internal bool ShowNestGenRadius { get; set; } = false;
        internal bool ShowNestRadius { get; set; } = false;

        internal Point ViewPoint { get => ZeroLocationPoint; set => ZeroLocationPoint = value; }
        internal int RegionPixelSize { get => PictureSize; set => PictureSize = value; }


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
        private Point MouseDownPoint = Point.Empty;

        /// <summary>
        /// Delta position from last MouseDown and MouseUp. This is required to calculate the MovePoint for swiping
        /// </summary>
        private Point Delta = Point.Empty;

        /// <summary>
        /// The start Position for Drawing.
        /// </summary>
        private Point ZeroLocationPoint = Point.Empty;

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point MouseSroRegioDownPoint = Point.Empty;

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap existing in the DB.
        /// </summary>
        Dictionary<Point, RegionGraphic> AllRegionGraphics = new Dictionary<Point, RegionGraphic>();

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap that does not existing in the DB but -m file is aviable.
        /// </summary>
        Dictionary<Point, RegionGraphic> AllUnusedRegionGraphics = new Dictionary<Point, RegionGraphic>();

      //  private readonly Dictionary<int, Monster> AllMonsters = new Dictionary<int, Monster>();
      //  private readonly Dictionary<int, UniqueMonster> AllUniqueMonsters = new Dictionary<int, UniqueMonster>();
      //  private readonly Dictionary<int, Npc> AllNpcs = new Dictionary<int, Npc>();
        private readonly Dictionary<int, IChar> AllPlayer = new Dictionary<int, IChar>();
        private readonly Dictionary<int, Teleport> AllTeleports = new Dictionary<int, Teleport>();
        private readonly Dictionary<string, NewPosition> NewPosDic = new Dictionary<string, NewPosition>();

       private readonly List<Spawn> Spawns = new List<Spawn>();

        #region Spawn Bitmap Images
        private Bitmap NpcImage;
        private Bitmap PlayerImage;
        private Bitmap MonsterImage;
        private Bitmap UMonsterImage;
        private Bitmap TeleportImage;
        private Bitmap OwnPointImage;

        #endregion

        #region Spawn Bitmap Image Paths
        private const string NpcIconPath = "Media\\interface\\minimap\\mm_sign_npc.ddj";
        private const string PlayerIconPath = "Media\\interface\\minimap\\mm_sign_otherplayer.ddj";
        private const string MonsterIconPath = "Media\\interface\\minimap\\mm_sign_monster.ddj";
        private const string UMonsterIconPath = "Media\\interface\\minimap\\mm_sign_unique.ddj";
        private const string TeleportIconPath = "Media\\interface\\worldmap\\map\\xy_gate.ddj";
        private const string OwnPointIconPath = "Media\\interface\\minimap\\mm_sign_animal.ddj";
        #endregion
        #endregion

        internal GraphicsPanel()
            => InitializeComponents();


        /// <summary>
        /// Initializes all required components for the WorldMap viewer
        /// </summary>
        private void InitializeComponents()
        {

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
                foreach (var spawn in Spawns.Where(spwn =>
                rangeXCoordPanel.Contains((spwn.RegionID.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(spwn.xLocation / (1920f / PictureSize), 0))
                && rangeYCoordPanel.Contains(((((spwn.RegionID.Z * PictureSize )- (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((spwn.yLocation / (1920f / PictureSize)) * -1))))
                {
                    switch (spawn.spawnType)
                    {
                        case SpawnType.None:
                            break;
                        case SpawnType.Monster when ShowMonster:
                            StrBuilder.AppendLine($"NestID: {spawn.ID}");
                            break;
                        case SpawnType.Npc when ShowNpc:
                            StrBuilder.AppendLine($"NestID: {spawn.ID}");
                            break;
                        case SpawnType.Unique when ShowUniqueMonster:
                            StrBuilder.AppendLine($"NestID: {spawn.ID}");
                            break;
                        case SpawnType.Teleport when ShowTeleport:
                            StrBuilder.AppendLine($"Teleport: {spawn.ID}");
                            break;
                        case SpawnType.Player when ShowPlayer:
                            StrBuilder.AppendLine($"CharID: {spawn.ID}");
                            break;
                        default:
                            break;
                    }
                }

                // if (ShowMonster)
                //     foreach (var mob in AllMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + ZeroLocationPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + ch.Value.Location.Y)))
                //         StrBuilder.AppendLine(mob.Value.Spawn.ObjCommon.CodeName128);
               // if (ShowNpc)
               //     foreach (var npc in AllNpcs.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + ZeroLocationPoint.X) + ((int)Math.Round(ch.Value.Spawn.Nest.fLocalPosX / (1920f / PictureSize), 0))) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + ((int)Math.Round((ch.Value.Spawn.Nest.fLocalPosZ / (1920f / PictureSize)) * -1)))))
               //         StrBuilder.AppendLine(npc.Value.Spawn.ObjCommon.CodeName128);
               //
               // if (ShowUniqueMonster)
               //     foreach (var umob in AllUniqueMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + ZeroLocationPoint.X) + ch.Value.Location.X) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + ch.Value.Location.Y)))
               //         StrBuilder.AppendLine(umob.Value.Spawn.ObjCommon.CodeName128);
               // if (ShowPlayer)
               //     foreach (var player in ClientDataStorage.Database.SRO_VT_SHARD._Char.Where(ch => rangeXCoordPanel.Contains((((ch.Value.LatestRegion % 256) * PictureSize + ZeroLocationPoint.X) + ((int)Math.Round(ch.Value.PosX / (1920f / PictureSize), 0)))) && rangeYCoordPanel.Contains((((((ch.Value.LatestRegion / 256) * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + ((int)Math.Round((ch.Value.PosZ / (1920f / PictureSize)) * -1)))))
               //         StrBuilder.AppendLine(player.Value.CharName16);

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

        public enum SpawnType : byte
        {
            None = 0xFF,
            Monster = 0x00,
            Npc = 0x01,
            Unique = 0x02,
            Teleport = 0x03,
            Player = 0x04
        }
        /// <summary>
        /// Defines weather the spawn is a monster, npc or smthing else...
        /// </summary>
        private void InitializeSpawnGraphics()
        {
          //  AllNpcs.Clear();
          //  AllMonsters.Clear();
          //  AllUniqueMonsters.Clear();
            Spawns.Clear();
            foreach (var nest in ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest)
            {
                var singleSpawn = new SingleSpawn(nest.Value);

                if (GetSpawnType(singleSpawn, out SpawnType type))
                {
                    var spawn = new Spawn(nest.Key, nest.Value.nRegionDBID, nest.Value.fLocalPosX, nest.Value.fLocalPosZ, nest.Value.fLocalPosY, type, nest.Value.nRadius, nest.Value.nGenerateRadius);
                    
                    Spawns.Add(spawn);
                 //  switch (type)
                 //  {
                 //      case SpawnType.Monster:
                 //          AllMonsters.Add(singleSpawn.Nest.dwNestID, new Monster(singleSpawn));
                 //          break;
                 //      case SpawnType.Npc:
                 //          AllNpcs.Add(singleSpawn.Nest.dwNestID, new Npc(singleSpawn));
                 //          break;
                 //      case SpawnType.Unique:
                 //          AllUniqueMonsters.Add(singleSpawn.Nest.dwNestID, new UniqueMonster(singleSpawn));
                 //          break;
                 //      case SpawnType.Teleport:
                 //          break;
                 //      default:
                 //          break;
                 //  }
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

        private bool GetSpawnType(SingleSpawn singleSpawn, out SpawnType type)
        {
            type = SpawnType.None;

            if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 1 && singleSpawn.ObjCommon.TypeID4 == 1 && singleSpawn.ObjCommon.Rarity != Rarity.MonsterUnique && singleSpawn.ObjCommon.Rarity != Rarity.MonsterUniqueNoMsg)
            { type = SpawnType.Monster; return true; }
            else if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 1 && singleSpawn.ObjCommon.TypeID4 == 1 && (singleSpawn.ObjCommon.Rarity == Rarity.MonsterUnique || singleSpawn.ObjCommon.Rarity == Rarity.MonsterUniqueNoMsg))
            { type = SpawnType.Unique; return true; }
            else if (singleSpawn.ObjCommon.TypeID1 == 1 && singleSpawn.ObjCommon.TypeID2 == 2 && singleSpawn.ObjCommon.TypeID3 == 2 && singleSpawn.ObjCommon.TypeID4 == 0)
            { type = SpawnType.Npc; return true; }

            return false;
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
                ZeroLocationPoint.X += Delta.X;
                ZeroLocationPoint.Y += Delta.Y;

                if (ZeroLocationPoint.X > 0)
                    ZeroLocationPoint.X = 0;

                if (ZeroLocationPoint.Y > 0)
                    ZeroLocationPoint.Y = 0;

                if (ZeroLocationPoint.X < -PictureSize * 256 + this.Width)
                    ZeroLocationPoint.X = -PictureSize * 256 + this.Width;

                if (ZeroLocationPoint.Y < -PictureSize * 128 + this.Height)
                    ZeroLocationPoint.Y = -PictureSize * 128 + this.Height;

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
                MouseSroRegioDownPoint.X = ((ZeroLocationPoint.X - e.X) / PictureSize) * -1;
                MouseSroRegioDownPoint.Y = ((ZeroLocationPoint.Y - e.Y) / PictureSize) + 127;

                var strx = MouseSroRegioDownPoint.X.ToString("X");
                var stry = MouseSroRegioDownPoint.Y.ToString("X");
                var strin = $"{stry}{strx}";

                var regionID = Convert.ToInt32(strin, 16);

                float fRegX = ((MouseSroRegioDownPoint.X) * PictureSize + (ZeroLocationPoint.X - e.X)) * -1;
                float RegX = (float)Math.Round(fRegX * (1920f / PictureSize), 0);

                int fRegX2 = ((MouseSroRegioDownPoint.X) * PictureSize + (ZeroLocationPoint.X - e.X)) * -1;
                int RegX2 = (int)Math.Round(fRegX * (1920f / PictureSize), 0);

                float fRegY = ((128 * PictureSize) + (ZeroLocationPoint.Y - e.Y)) - ((MouseSroRegioDownPoint.Y) * PictureSize);
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

                // TODO: Reimplement the SpawnEditor on Click
            // if (this.ShowNpc)
            //     foreach (var npc in AllNpcs.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(ch.Value.Spawn.Nest.fLocalPosX / (1920f / PictureSize), 0)) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((ch.Value.Spawn.Nest.fLocalPosZ / (1920f / PictureSize)) * -1))))
            //     {
            //         if (OpenEditorOnClick && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {npc.Value.Spawn.ObjCommon.CodeName128}", "SpawnEditor"))
            //             using (SpawnEditor Editor = new SpawnEditor(npc.Value.Spawn))
            //                 Editor.ShowDialog();
            //     }
            // if (this.ShowMonster)
            //     foreach (var mob in AllMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(ch.Value.Spawn.Nest.fLocalPosX / (1920f / PictureSize), 0)) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((ch.Value.Spawn.Nest.fLocalPosZ / (1920f / PictureSize)) * -1))))
            //     {
            //         if (OpenEditorOnClick && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {mob.Value.Spawn.ObjCommon.CodeName128}", "SpawnEditor"))
            //         {
            //             using (SpawnEditor Editor = new SpawnEditor(mob.Value.Spawn))
            //                 Editor.ShowDialog();
            //         }
            //     }
            // if (this.ShowUniqueMonster)
            //     foreach (var umob in AllUniqueMonsters.Where(ch => rangeXCoordPanel.Contains((ch.Value.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(ch.Value.Spawn.Nest.fLocalPosX / (1920f / PictureSize), 0)) && rangeYCoordPanel.Contains(((((ch.Value.Y * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + ch.Value.Location.Y)))
            //     {
            //         if (OpenEditorOnClick && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {umob.Value.Spawn.ObjCommon.CodeName128}", "SpawnEditor"))
            //             using (SpawnEditor Editor = new SpawnEditor(umob.Value.Spawn))
            //                 Editor.ShowDialog();
            //     }
            }
        }

        Point regionPoint = Point.Empty;
        Point panelPoint = Point.Empty;
        Rectangle drawRec = Rectangle.Empty;
        Size drawSize = Size.Empty;
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
                panelPoint.X = ((x * PictureSize)) + ZeroLocationPoint.X;

                for (int z = 0; z < 128; z++)
                {
                    regionPoint.Y = z;
                    panelPoint.Y = ((((z * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) - PictureSize;


                    if (xRange.Contains(panelPoint.X) && yRange.Contains(panelPoint.Y))
                    {
                        if (AllRegionGraphics.TryGetValue(regionPoint, out RegionGraphic region) && this.ShowDbRegions)
                            e.Graphics.DrawImage(region.RegionLayer, panelPoint.X, panelPoint.Y, PictureSize, PictureSize);
                        else if (AllUnusedRegionGraphics.TryGetValue(regionPoint, out RegionGraphic unassignedregion) && this.ShowUnassignedRegions)
                            e.Graphics.DrawImage(unassignedregion.RegionLayer, panelPoint.X, panelPoint.Y, PictureSize, PictureSize);
                        else
                        {
                            drawSize.Width = PictureSize;
                            drawSize.Height = PictureSize;
                            drawRec.Location = panelPoint;
                            drawRec.Size = drawSize;
                            e.Graphics.DrawRectangle(Pens.Red, drawRec);
                            if (this.PictureSize > 128)
                                TextRenderer.DrawText(e.Graphics, $"X: {regionPoint.X} Z: {regionPoint.Y} \n", this.Font, panelPoint, Color.AliceBlue);
                            //e.Graphics.DrawString($"X: {regionPoint.X} Z: {regionPoint.Y} \n", this.Font, Brushes.AliceBlue, panelPoint);
                        }
                    }
                }
            }
            if (Initialized)
            {
                foreach (var spawn in Spawns)
                {
                    switch (spawn.spawnType)
                    {
                        case SpawnType.None:
                            break;
                        case SpawnType.Monster when ShowMonster:
                            var spawnLocationX = (spawn.RegionID.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(spawn.xLocation / (1920f / PictureSize), 0);//+ mob.Value.Location.X;
                            var spawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((spawn.yLocation/ (1920f / PictureSize)) * -1);// mob.Value.Location.Y;
                            e.Graphics.DrawImage(MonsterImage, spawnLocationX - MonsterImage.Width / 2, spawnLocationY - MonsterImage.Width / 2, MonsterImage.Width, MonsterImage.Height);

                            if (this.ShowNestGenRadius)
                                e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), spawn.nGenerateRadius / (1920 / PictureSize), spawn.nGenerateRadius / (1920 / PictureSize));

                            if (this.ShowNestRadius)
                                e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((spawn.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((spawn.nRadius / (1920 / PictureSize)) / 2), spawn.nRadius / (1920 / PictureSize), spawn.nRadius / (1920 / PictureSize));
                            break;
                        case SpawnType.Npc when ShowNpc:
                            e.Graphics.DrawImage(NpcImage, (spawn.RegionID.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(spawn.xLocation / (1920f / PictureSize), 0) - (NpcImage.Width / 2), ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((spawn.yLocation / (1920f / PictureSize)) * -1) - (NpcImage.Width / 2), NpcImage.Width, NpcImage.Height);
                            break;
                        case SpawnType.Unique when ShowUniqueMonster:
                            var uspawnLocationX = (spawn.RegionID.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(spawn.xLocation / (1920f / PictureSize), 0) - (MonsterImage.Width / 2);
                            var uspawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((spawn.yLocation / (1920f / PictureSize)) * -1) - (MonsterImage.Width / 2);
                            e.Graphics.DrawImage(UMonsterImage, uspawnLocationX - UMonsterImage.Width / 2, uspawnLocationY - UMonsterImage.Width / 2, UMonsterImage.Width, UMonsterImage.Height);

                            if (this.ShowNestRadius)
                                e.Graphics.DrawEllipse(Pens.Green, uspawnLocationX - ((spawn.nRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((spawn.nRadius / (1920 / PictureSize)) / 2), spawn.nRadius / (1920 / PictureSize), spawn.nRadius / (1920 / PictureSize));

                            if (this.ShowNestGenRadius)
                                e.Graphics.DrawEllipse(Pens.Yellow, uspawnLocationX - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), spawn.nGenerateRadius / (1920 / PictureSize), spawn.nGenerateRadius / (1920 / PictureSize));
                            break;
                        case SpawnType.Teleport:
                            break;
                        case SpawnType.Player:
                            break;
                        default:
                            break;
                    }
                }
             

                foreach (var item in NewPosDic)
                {
                    e.Graphics.DrawImage(OwnPointImage, new PointF((Convert.ToSingle((item.Value.RegionID % 256) * PictureSize + ZeroLocationPoint.X)) + (item.Value.Position.X / (1920f / PictureSize)), Convert.ToSingle(((((item.Value.RegionID / 256) * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + ((item.Value.Position.Y / (1920f / PictureSize)) * -1)));
                }

                if (ShowTeleport)
                    foreach (var teleport in AllTeleports.Values)
                    {
                        e.Graphics.DrawImage(TeleportImage, (teleport.X * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(teleport.Location.X / (1920f / PictureSize), 0), ((((teleport.Y * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((teleport.Location.Y / (1920f / PictureSize)) * -1), TeleportImage.Width, TeleportImage.Height);
                    }
                if (ShowPlayer)
                    foreach (var item in ClientDataStorage.Database.SRO_VT_SHARD._Char.Values)
                    {
                        e.Graphics.DrawImage(PlayerImage, ((item.LatestRegion % 256) * PictureSize + ZeroLocationPoint.X) + (int)Math.Round(item.PosX / (1920f / PictureSize), 0), (((((item.LatestRegion / 256) * PictureSize) - (128 * PictureSize)) * -1) + ZeroLocationPoint.Y) + (int)Math.Round((item.PosZ / (1920f / PictureSize)) * -1), PlayerImage.Width, PlayerImage.Height);
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
            if (e.Delta < 0 && PictureSize < 10)
                return;
            else if (e.Delta > 0 && PictureSize > 900)
                return;

            MouseSroRegioDownPoint.X = ((ZeroLocationPoint.X - e.X) / PictureSize) * -1;
            MouseSroRegioDownPoint.Y = ((ZeroLocationPoint.Y - e.Y) / PictureSize) * -1;

            PictureSize = e.Delta < 0 ? PictureSize - 10 : PictureSize + 10;
            ZeroLocationPoint.X = e.Delta < 0 ? ZeroLocationPoint.X + MouseSroRegioDownPoint.X * 10 : ZeroLocationPoint.X - MouseSroRegioDownPoint.X * 10;
            ZeroLocationPoint.Y = e.Delta < 0 ? ZeroLocationPoint.Y + MouseSroRegioDownPoint.Y * 10 : ZeroLocationPoint.Y - MouseSroRegioDownPoint.Y * 10;

            if (ZeroLocationPoint.X > 0)
                ZeroLocationPoint.X = 0;

            if (ZeroLocationPoint.Y > 0)
                ZeroLocationPoint.Y = 0;


            if (ZeroLocationPoint.X < -PictureSize * 256 + this.Width)
                ZeroLocationPoint.X = -PictureSize * 256 + this.Width;

            if (ZeroLocationPoint.Y < -PictureSize * 128 + this.Height)
                ZeroLocationPoint.Y = -PictureSize * 128 + this.Height;


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
                    point.X = rGraphic.RegionID.X;
                    point.Y = rGraphic.RegionID.Z;
                    AllRegionGraphics.Add(point, rGraphic);
                }
                else
                {
                    //Missing Minimap
                }
            }

            //Add images which are not present inside the database
            Point p = new Point(0, 0);
            for (int i = 0; i < 255; i++)
            {
                for (int i2 = 0; i2 < 255; i2++)
                {
                    p.X = i; p.Y = i2;

                    var str = $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{i}x{i2}.JPG";
                    if (System.IO.File.Exists(str) && !AllRegionGraphics.ContainsKey(p))
                    {
                        var rID = Convert.ToInt32($"{i2.ToString("X")}{i.ToString("X")}", 16);
                        var regLayer = new RegionGraphic((short)rID);
                        if (regLayer.RegionLayer != null)
                            AllUnusedRegionGraphics.Add(p, regLayer);
                    }
                }
            }
        }
    }
}
