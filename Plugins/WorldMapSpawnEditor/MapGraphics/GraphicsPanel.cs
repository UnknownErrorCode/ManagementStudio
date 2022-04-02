using BinaryFiles.PackFile;
using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal sealed class GraphicsPanel : Panel
    {
        #region Fields

        private const string MonsterIconPath = "Media\\interface\\minimap\\mm_sign_monster.ddj";
        private const string NpcIconPath = "Media\\interface\\minimap\\mm_sign_npc.ddj";
        private const string OwnPointIconPath = "Media\\interface\\minimap\\mm_sign_animal.ddj";
        private const string PlayerIconPath = "Media\\interface\\minimap\\mm_sign_otherplayer.ddj";
        private const string TeleportIconPath = "Media\\interface\\worldmap\\map\\xy_gate.ddj";
        private const string UMonsterIconPath = "Media\\interface\\minimap\\mm_sign_unique.ddj";

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap that does not existing in the DB but -m file is aviable.
        /// </summary>
        private readonly Dictionary<Point, RegionGraphic> AllUnusedRegionGraphics = new Dictionary<Point, RegionGraphic>();

        /// <summary>
        /// Holds all <see cref="NewPosition"/> the user creates.
        /// </summary>
        private readonly Dictionary<string, NewPosition> NewPosDic = new Dictionary<string, NewPosition>();

        /// <summary>
        /// String builder for tooltip text help.
        /// </summary>
        private readonly StringBuilder StrBuilder = new StringBuilder();

        /// <summary>
        /// Unique tooltip used for anyting that requires a Tip to display to avoid creating duplicate tooltips.
        /// </summary>
        private readonly ToolTip tip = new ToolTip();

        /// <summary>
        /// Delta position from last MouseDown and MouseUp. This is required to calculate the MovePoint for swiping
        /// </summary>
        private Point Delta = Point.Empty;

        private Rectangle drawRec = Rectangle.Empty;
        private Size drawSize = Size.Empty;
        private Bitmap ImageMonster;
        private Bitmap ImageMonsterUnique;
        private Bitmap ImageNpc;
        private Bitmap ImageOwnPoint;
        private Bitmap ImagePlayer;
        private Bitmap ImageTeleport;

        /// <summary>
        /// Defines weather the MapViewer is initialized successfully or not.
        /// </summary>
        private bool Initialized;

        /// <summary>
        /// Defines the Pixel Size Width and Heigth from a single Region.
        /// </summary>
        private int PictureSize = 256;

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point PointMouseDown = Point.Empty;

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point PointMouseSroRegioDown = Point.Empty;

        private Point PointPanel = Point.Empty;
        private Point PointRegionXY = Point.Empty;

        /// <summary>
        /// The start Position for Drawing.
        /// </summary>
        private Point PointZeroLocation = Point.Empty;

        /// <summary>
        /// Weather the Spawn Editor should be open on click.
        /// </summary>
        private bool showEditorOnClick = false;

        private bool showMonster = false;
        private bool showNestGenRadius = false;
        private bool showNestRadius = false;
        private bool showNpc = false;
        private bool showPlayer = false;
        private bool showRegionDb = true;
        private bool showRegionDBnoDDJ = false;
        private bool showRegionsUnassigned = false;
        private bool showTeleport = false;

        /// <summary>
        /// Indicates weather the tooltip should be shown or not.
        /// </summary>
        private bool showToolTip = true;

        private bool showUniqueMonster = false;
        private CWorld World;
        private CWorldSpawn WorldSpawn;

        #endregion Fields

        #region Constructors

        internal GraphicsPanel()
        {
            InitializeComponents();
        }

        #endregion Constructors

        #region Properties

        public bool ShowRegionDBnoDDJ
        { get => showRegionDBnoDDJ; set { showRegionDBnoDDJ = value; Invalidate(); } }

        internal string[] Continents => World.Continents.Keys.ToArray();

        internal Point PointOfView
        { get => PointZeroLocation; set { PointZeroLocation = value; Invalidate(); } }

        internal int RegionPixelSize
        { get => PictureSize; set { PictureSize = value; Invalidate(); } }

        internal bool ShowEditorOnClick { get => showEditorOnClick; set => showEditorOnClick = value; }

        internal bool ShowMonster
        { get => showMonster; set { showMonster = value; Invalidate(); } }

        internal bool ShowNestGenRadius
        { get => showNestGenRadius; set { showNestGenRadius = value; Invalidate(); } }

        internal bool ShowNestRadius
        { get => showNestRadius; set { showNestRadius = value; Invalidate(); } }

        internal bool ShowNpc
        { get => showNpc; set { showNpc = value; Invalidate(); } }

        internal bool ShowPlayer
        { get => showPlayer; set { showPlayer = value; Invalidate(); } }

        internal bool ShowRegionsDb
        { get => showRegionDb; set { showRegionDb = value; Invalidate(); } }

        internal bool ShowRegionsUnassigned
        { get => showRegionsUnassigned; set { showRegionsUnassigned = value; Invalidate(); } }

        internal bool ShowTeleport
        { get => showTeleport; set { showTeleport = value; Invalidate(); } }

        internal bool ShowToolTip { get => showToolTip; set => showToolTip = value; }

        internal bool ShowUniqueMonster
        { get => showUniqueMonster; set { showUniqueMonster = value; Invalidate(); } }

        #endregion Properties

        #region Methods

        internal bool TryViewContinent(string continentName)
        {
            if (World.GetContinentView(continentName, Width, Height, out Point viewPoint, out int size))
            {
                RegionPixelSize = size;
                PointOfView = viewPoint;
                return true;
            }
            return false;
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
                PointMouseDown = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                PointMouseSroRegioDown.X = ((PointZeroLocation.X - e.X) / PictureSize) * -1;
                PointMouseSroRegioDown.Y = ((PointZeroLocation.Y - e.Y) / PictureSize) + 127;

                string strx = PointMouseSroRegioDown.X.ToString("X");
                string stry = PointMouseSroRegioDown.Y.ToString("X");
                string strin = $"{stry}{strx}";

                short regionID = (short)Convert.ToInt32(strin, 16);

                float fRegX = ((PointMouseSroRegioDown.X) * PictureSize + (PointZeroLocation.X - e.X)) * -1;
                float RegX = (float)Math.Round(fRegX * (1920f / PictureSize), 0);

                int fRegX2 = ((PointMouseSroRegioDown.X) * PictureSize + (PointZeroLocation.X - e.X)) * -1;
                int RegX2 = (int)Math.Round(fRegX * (1920f / PictureSize), 0);

                float fRegY = ((128 * PictureSize) + (PointZeroLocation.Y - e.Y)) - ((PointMouseSroRegioDown.Y) * PictureSize);
                float RegY = (float)Math.Round(fRegY * (1920f / PictureSize));

                if (!PackFile.MapPack.AllmFiles.ContainsKey(regionID))
                {
                    if (PackFile.MapPack.Reader.GetByteArrayByDirectory($"Map\\{PointMouseSroRegioDown.Y}\\{PointMouseSroRegioDown.X}.m", out byte[] mFile))
                    {
                        BinaryFiles.PackFile.Map.m.MeshFile mfi = new BinaryFiles.PackFile.Map.m.MeshFile(mFile, (byte)PointMouseSroRegioDown.X, (byte)PointMouseSroRegioDown.Y);
                        PackFile.MapPack.AllmFiles.Add((short)regionID, mfi);
                    }
                }
                if (PackFile.MapPack.AllmFiles.ContainsKey(regionID))
                {
                    if (PackFile.MapPack.AllmFiles[regionID].GetHightByfPoint(RegX, RegY, out float Z))
                    {
                        if (ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"/warp {regionID} {RegX} {Z} {RegY}\n\nX:{PointMouseSroRegioDown.X}\nY:{PointMouseSroRegioDown.Y}", "Add new Position?"))
                        {
                            string str = ServerFrameworkRes.BasicControls.vSroMessageBox.GetInput("Enter the Name of your Point inside the InputBox.", "Add new location", "Pos Name:");
                            NewPosDic.Add(str, new NewPosition() { RegionID = (short)regionID, Position = new System.Numerics.Vector3(RegX, RegY, Z) });
                            Invalidate();
                        }
                    }
                }
                else
                {
                    ServerFrameworkRes.BasicControls.vSroMessageBox.Show($"/warp {regionID} {RegX} 0 {RegY}\n\nFailed to get Z coordinate\nUse Charakter Position to get hight.\n\nX:{PointMouseSroRegioDown.X}\nY:{PointMouseSroRegioDown.Y}");
                }

                IEnumerable<int> rangeXCoordPanel = Enumerable.Range(e.X - 6, 12);
                IEnumerable<int> rangeYCoordPanel = Enumerable.Range(e.Y - 6, 12);

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

        /// <summary>
        /// On Mouse Move it calculates the neccesary informations from each spawn below the cursor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (ShowToolTip)
            {
                IEnumerable<int> rangeXCoordPanel = Enumerable.Range(e.X - 8, 16);
                IEnumerable<int> rangeYCoordPanel = Enumerable.Range(e.Y - 8, 16);

                StrBuilder.Clear();
                foreach (Interface.InterfaceSpawn spawn in WorldSpawn.Where(spwn =>
                rangeXCoordPanel.Contains((spwn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spwn.XLocation / (1920f / PictureSize), 0))
                && rangeYCoordPanel.Contains(((((spwn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spwn.ZLocation / (1920f / PictureSize)) * -1))))
                {
                    switch (spawn.SpawnType)
                    {
                        case SpawnType.None:
                            break;

                        case SpawnType.Monster when ShowMonster:
                            StrBuilder.AppendLine($"CodeName: {((Monster)spawn).CodeName128}");
                            break;

                        case SpawnType.Npc when ShowNpc://TODO: cast each type as its own
                            StrBuilder.AppendLine($"CodeName: {((Npc)spawn).CodeName128}");
                            break;

                        case SpawnType.Unique when ShowUniqueMonster:
                            StrBuilder.AppendLine($"CodeName: {((Monster)spawn).CodeName128}");
                            break;

                        case SpawnType.Teleport when ShowTeleport:
                            StrBuilder.AppendLine($"Teleport: {spawn.ID}");
                            break;

                        case SpawnType.Player when ShowPlayer:
                            StrBuilder.AppendLine($"{ ((Player)spawn).CharName16}\n Level:{((Player)spawn).CurLevel}\n HP:{((Player)spawn).HP}\n MP:{((Player)spawn).MP}");
                            break;

                        default:
                            break;
                    }
                }

                //if (ShowPlayer)
                //    foreach (var player in ClientFrameworkRes.Database.SRO_VT_SHARD._Char.Where(ch => rangeXCoordPanel.Contains((((ch.Value.LatestRegion % 256) * PictureSize + PointZeroLocation.X) + ((int)Math.Round(ch.Value.PosX / (1920f / PictureSize), 0)))) && rangeYCoordPanel.Contains((((((ch.Value.LatestRegion / 256) * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + ((int)Math.Round((ch.Value.PosZ / (1920f / PictureSize)) * -1)))))
                //        StrBuilder.AppendLine($"{player.Value.CharName16}\n Level:{player.Value.CurLevel}\n HP:{player.Value.HP}\n MP:{player.Value.MP}");

                tip.Show(StrBuilder.ToString(), Parent, e.X + 20, e.Y + 2, 5000);
            }
        }

        /// <summary>
        /// On mouse up. Required for moving the view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Location != PointMouseDown && e.Button == MouseButtons.Left)
            {
                Delta.X = e.Location.X - PointMouseDown.X; Delta.Y = e.Location.Y - PointMouseDown.Y;
                PointZeroLocation.X += Delta.X;
                PointZeroLocation.Y += Delta.Y;

                if (PointZeroLocation.X > 0)
                {
                    PointZeroLocation.X = 0;
                }

                if (PointZeroLocation.Y > 0)
                {
                    PointZeroLocation.Y = 0;
                }

                if (PointZeroLocation.X < -PictureSize * 256 + Width)
                {
                    PointZeroLocation.X = -PictureSize * 256 + Width;
                }

                if (PointZeroLocation.Y < -PictureSize * 128 + Height)
                {
                    PointZeroLocation.Y = -PictureSize * 128 + Height;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// on scroll for zoom. TODO: keep position on scroll to Mouse Cursor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && PictureSize <= 15)
            {
                PictureSize = 15;
                return;
            }
            else if (e.Delta > 0 && PictureSize > 900)
            {
                return;
            }

            PointMouseSroRegioDown.X = ((PointZeroLocation.X - e.X) / PictureSize) * -1;
            PointMouseSroRegioDown.Y = ((PointZeroLocation.Y - e.Y) / PictureSize) * -1;

            PictureSize = e.Delta < 0 ? PictureSize - 10 : PictureSize + 10;
            if (PictureSize < 15)
                PictureSize = 15;
            PointZeroLocation.X = e.Delta < 0 ? PointZeroLocation.X + PointMouseSroRegioDown.X * 10 : PointZeroLocation.X - PointMouseSroRegioDown.X * 10;
            PointZeroLocation.Y = e.Delta < 0 ? PointZeroLocation.Y + PointMouseSroRegioDown.Y * 10 : PointZeroLocation.Y - PointMouseSroRegioDown.Y * 10;

            if (PointZeroLocation.X > 0)
            {
                PointZeroLocation.X = 0;
            }

            if (PointZeroLocation.Y > 0)
            {
                PointZeroLocation.Y = 0;
            }

            if (PointZeroLocation.X < -PictureSize * 256 + Width)
            {
                PointZeroLocation.X = -PictureSize * 256 + Width;
            }

            if (PointZeroLocation.Y < -PictureSize * 128 + Height)
            {
                PointZeroLocation.Y = -PictureSize * 128 + Height;
            }

            Invalidate();
        }

        /// <summary>
        /// When the panel gets repainted it after invalidate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            int
                minX = -PictureSize,
                maxX = Width + PictureSize,
                minY = -PictureSize,
                maxY = Height + PictureSize;
            IEnumerable<int> xRange = Enumerable.Range(-PictureSize, Width + PictureSize);
            IEnumerable<int> yRange = Enumerable.Range(-PictureSize, Height + PictureSize);

            var v1 = Rectangle.Empty;
            v1.Width = Width / PictureSize + 1;
            v1.Height = Height / PictureSize + 3;
            v1.X = -PointZeroLocation.X / PictureSize;
            v1.Y = (PointZeroLocation.Y / PictureSize) + 128;

            for (int x = 0; x < 256; x++)
            {
                PointRegionXY.X = x;
                PointPanel.X = ((x * PictureSize)) + PointZeroLocation.X;

                for (int z = 0; z < 128; z++)
                {
                    PointRegionXY.Y = z;
                    PointPanel.Y = ((((z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) - PictureSize;

                    if (xRange.Contains(PointPanel.X) && yRange.Contains(PointPanel.Y))
                    {
                        drawSize.Width = PictureSize;
                        drawSize.Height = PictureSize;
                        drawRec.Location = PointPanel;
                        drawRec.Size = drawSize;

                        if (AllUnusedRegionGraphics.TryGetValue(PointRegionXY, out RegionGraphic unassignedregion) && ShowRegionsUnassigned)
                        {
                            e.Graphics.DrawImage(unassignedregion.RegionLayer, PointPanel.X, PointPanel.Y, PictureSize, PictureSize);
                            e.Graphics.DrawRectangle(Pens.Blue, drawRec);
                            if (PictureSize > 100)
                                TextRenderer.DrawText(e.Graphics, $"\n\nNo RegionID in DB", Font, PointPanel, Color.Red);
                        }
                        else
                        {
                            e.Graphics.DrawRectangle(Pens.Red, drawRec);
                        }
                        if (PictureSize > 100)
                        {
                            TextRenderer.DrawText(e.Graphics, $"\n\n\n\tX: {PointRegionXY.X} Z: {PointRegionXY.Y} \n", Font, PointPanel, Color.AliceBlue);
                        }
                    }
                }
            }

            if (showRegionDb)
            {
                foreach (var cont in World.Continents.Values)
                {
                    var regions = cont.GetRegions(v1);
                    foreach (var reg in regions)
                    {
                        PointPanel.X = ((reg.RegionID.X * PictureSize)) + PointZeroLocation.X;
                        PointPanel.Y = ((((reg.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) - PictureSize;
                        drawSize.Width = PictureSize;
                        drawSize.Height = PictureSize;
                        drawRec.Location = PointPanel;
                        drawRec.Size = drawSize;
                        if (reg.HasLayer)
                        {
                            e.Graphics.DrawImage(reg.RegionLayer, PointPanel.X, PointPanel.Y, PictureSize, PictureSize);
                            e.Graphics.DrawRectangle(Pens.White, drawRec);
                        }
                        else if (!reg.HasLayer && showRegionDBnoDDJ)
                        {
                            e.Graphics.DrawRectangle(Pens.Green, drawRec);
                            if (PictureSize > 50)
                            {
                                TextRenderer.DrawText(e.Graphics, $"\n\nNo ddj file", Font, PointPanel, Color.Red);
                            }
                        }

                        if (PictureSize > 100)
                            TextRenderer.DrawText(e.Graphics, $"X: {reg.RegionID.X} Z: {reg.RegionID.Z} \nRegionID: {reg.RegionID.RegionID}", Font, PointPanel, Color.White);
                    }
                }
            }

            if (Initialized)
            {
                foreach (var spawn in WorldSpawn)
                {
                    PointPanel.X = (spawn.RegionID.X * PictureSize) + PointZeroLocation.X;
                    PointPanel.Y = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) - PictureSize;
                    if ((PointPanel.X > minX && PointPanel.X < maxX) && (PointPanel.Y > minY && PointPanel.Y < maxY))
                        switch (spawn.SpawnType)
                        {
                            case SpawnType.None:
                                continue;

                            case SpawnType.Monster when showMonster:
                                int spawnLocationX = (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0);//+ mob.Value.Location.X;
                                int spawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1);// mob.Value.Location.Y;
                                e.Graphics.DrawImage(ImageMonster, spawnLocationX - ImageMonster.Width / 2, spawnLocationY - ImageMonster.Width / 2, ImageMonster.Width, ImageMonster.Height);

                                if (showNestGenRadius)
                                {
                                    e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize));
                                }

                                if (showNestRadius)
                                    e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NRadius / (1920 / PictureSize), ((Monster)spawn).NRadius / (1920 / PictureSize));

                                break;

                            case SpawnType.Npc when showNpc:
                                e.Graphics.DrawImage(ImageNpc, (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0) - (ImageNpc.Width / 2), ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1) - (ImageNpc.Width / 2), ImageNpc.Width, ImageNpc.Height);
                                break;

                            case SpawnType.Unique when showUniqueMonster:
                                int uspawnLocationX = (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0) - (ImageMonster.Width / 2);
                                int uspawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1) - (ImageMonster.Width / 2);
                                e.Graphics.DrawImage(ImageMonsterUnique, uspawnLocationX - ImageMonsterUnique.Width / 2, uspawnLocationY - ImageMonsterUnique.Width / 2, ImageMonsterUnique.Width, ImageMonsterUnique.Height);

                                if (showNestRadius)
                                    e.Graphics.DrawEllipse(Pens.Green, uspawnLocationX - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NRadius / (1920 / PictureSize), ((Monster)spawn).NRadius / (1920 / PictureSize));

                                if (showNestGenRadius)
                                    e.Graphics.DrawEllipse(Pens.Yellow, uspawnLocationX - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize));

                                break;

                            case SpawnType.Teleport when showTeleport:
                                e.Graphics.DrawImage(ImageTeleport, (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0), ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1), ImageTeleport.Width, ImageTeleport.Height);
                                break;

                            case SpawnType.Player when showPlayer:
                                e.Graphics.DrawImage(ImagePlayer, (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0), (((((((Player)spawn).RegionID.Z) * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((((Player)spawn).ZLocation / (1920f / PictureSize)) * -1), ImagePlayer.Width, ImagePlayer.Height);
                                break;

                            default:
                                break;
                        }
                }

                /*
                foreach (Interface.InterfaceSpawn spawn in Spawns)
                {
                    PointPanel.X = (spawn.RegionID.X * PictureSize) + PointZeroLocation.X;
                    PointPanel.Y = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) - PictureSize;

                    if ((PointPanel.X > minX && PointPanel.X < maxX) && (PointPanel.Y > minY && PointPanel.Y < maxY))
                        switch (spawn.SpawnType)
                        {
                            case SpawnType.None:
                                break;

                            case SpawnType.Monster when showMonster:
                                int spawnLocationX = (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0);//+ mob.Value.Location.X;
                                int spawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1);// mob.Value.Location.Y;
                                e.Graphics.DrawImage(ImageMonster, spawnLocationX - ImageMonster.Width / 2, spawnLocationY - ImageMonster.Width / 2, ImageMonster.Width, ImageMonster.Height);

                                if (showNestGenRadius)
                                {
                                    e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize));
                                }

                                if (showNestRadius)
                                {
                                    e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NRadius / (1920 / PictureSize), ((Monster)spawn).NRadius / (1920 / PictureSize));
                                }

                                break;

                            case SpawnType.Npc when showNpc:
                                e.Graphics.DrawImage(ImageNpc, (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0) - (ImageNpc.Width / 2), ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1) - (ImageNpc.Width / 2), ImageNpc.Width, ImageNpc.Height);
                                break;

                            case SpawnType.Unique when showUniqueMonster:
                                int uspawnLocationX = (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0) - (ImageMonster.Width / 2);
                                int uspawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1) - (ImageMonster.Width / 2);
                                e.Graphics.DrawImage(ImageMonsterUnique, uspawnLocationX - ImageMonsterUnique.Width / 2, uspawnLocationY - ImageMonsterUnique.Width / 2, ImageMonsterUnique.Width, ImageMonsterUnique.Height);

                                if (showNestRadius)
                                    e.Graphics.DrawEllipse(Pens.Green, uspawnLocationX - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((((Monster)spawn).NRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NRadius / (1920 / PictureSize), ((Monster)spawn).NRadius / (1920 / PictureSize));

                                if (showNestGenRadius)
                                    e.Graphics.DrawEllipse(Pens.Yellow, uspawnLocationX - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((((Monster)spawn).NGenerateRadius / (1920 / PictureSize)) / 2), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize), ((Monster)spawn).NGenerateRadius / (1920 / PictureSize));

                                break;

                            case SpawnType.Teleport when showTeleport:
                                e.Graphics.DrawImage(ImageTeleport, (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / PictureSize), 0), ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / PictureSize)) * -1), ImageTeleport.Width, ImageTeleport.Height);
                                break;

                            case SpawnType.Player when showPlayer:
                                break;

                            default:
                                break;
                        }
                }

                if (ShowPlayer)
                {
                    foreach (IChar item in ClientFrameworkRes.Database.SRO_VT_SHARD._Char.Values)
                    {
                        e.Graphics.DrawImage(ImagePlayer, ((item.LatestRegion % 256) * PictureSize + PointZeroLocation.X) + (int)Math.Round(item.PosX / (1920f / PictureSize), 0), (((((item.LatestRegion / 256) * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((item.PosZ / (1920f / PictureSize)) * -1), ImagePlayer.Width, ImagePlayer.Height);
                    }
                }
                */
                foreach (KeyValuePair<string, NewPosition> item in NewPosDic)
                {
                    e.Graphics.DrawImage(ImageOwnPoint, new PointF((Convert.ToSingle((item.Value.RegionID % 256) * PictureSize + PointZeroLocation.X)) + (item.Value.Position.X / (1920f / PictureSize)), Convert.ToSingle(((((item.Value.RegionID / 256) * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + ((item.Value.Position.Y / (1920f / PictureSize)) * -1)));
                }
            }

            TextRenderer.DrawText(e.Graphics, $"ViewPoint: X: {PointOfView.X} Y: {PointOfView.Y} \tZoom: {PictureSize}", Font, Point.Empty, Color.White);
        }

        /// <summary>
        /// Initializes all required components for the WorldMap viewer
        /// </summary>
        private void InitializeComponents()
        {
            Initialized = false;
            DoubleBuffered = true;
            Dock = DockStyle.Fill;

            Paint += GraphicsPanel_Paint;
            MouseUp += GraphicsPanel_MouseUp;
            MouseDown += GraphicsPanel_MouseDown;
            MouseWheel += GraphicsPanel_MouseWheel;
            MouseMove += GraphicsPanel_MouseMove;

            InitializeSpawnImage(NpcIconPath, 8, out ImageNpc);
            InitializeSpawnImage(PlayerIconPath, 8, out ImagePlayer);
            InitializeSpawnImage(MonsterIconPath, 8, out ImageMonster);
            InitializeSpawnImage(UMonsterIconPath, 8, out ImageMonsterUnique);
            InitializeSpawnImage(TeleportIconPath, 16, out ImageTeleport);
            InitializeSpawnImage(OwnPointIconPath, 8, out ImageOwnPoint);

            InitializeWorldGraphics();
            InitializeSpawnGraphics();
            //Task.Run(() => InitializeWorldGraphics());
            //Task.Run(() => InitializeSpawnGraphics());
        }

        /// <summary>
        /// Defines weather the spawn is a monster, npc or smthing else...
        /// </summary>
        private void InitializeSpawnGraphics()
        {
            WorldSpawn = new CWorldSpawn();

            //  Spawns.Clear();

            /*
                        foreach (var nest in ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest.Values)
                        {
                            var spawn = new Spawn(nest);
                            if (!spawn.SpawnType.Equals(SpawnType.None))
                            {
                                switch (spawn.SpawnType)
                                {
                                    case SpawnType.Unique:
                                    case SpawnType.Monster:
                                        Spawns.Add(Spawn.FromSpawn<Monster>(spawn));
                                        break;

                                    case SpawnType.Npc:
                                        Spawns.Add(Spawn.FromSpawn<Npc>(spawn));
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }

                        foreach (RefTeleport teleport in ClientFrameworkRes.Database.SRO_VT_SHARD._RefTeleport.Values)
                        {
                            if (teleport.AssocRefObjID > 0)
                                Spawns.Add(new Spawn(teleport));
                        }

                        foreach (IChar ichar in ClientFrameworkRes.Database.SRO_VT_SHARD._Char.Values)
                        {
                            Spawns.Add(Spawn.FromSpawn<Player>(new Spawn(ichar)));
                        }
            */
            Initialized = true;
        }

        /// <summary>
        /// Initializes all Spawn Images to the Panel.
        /// </summary>
        /// <param name="pk2PathString"></param>
        /// <param name="ImageSize"></param>
        /// <param name="image"></param>
        private void InitializeSpawnImage(string pk2PathString, int ImageSize, out Bitmap image)
        {
            if (!PackFile.MediaPack.DDJFiles.ContainsKey(pk2PathString))
            {
                if (PackFile.MediaPack.Reader.GetByteArrayByDirectory(pk2PathString, out byte[] file))
                {
                    DDJImage DDJFile = new DDJImage(file);
                    PackFile.MediaPack.DDJFiles.Add(pk2PathString, DDJFile);
                }

                //if (ClientFrameworkRes.Client.Media.MediaPk2.GetByteArrayByDirectory(pk2PathString, out byte[] file))
                //{
                //    DDJImage DDJFile = new DDJImage(file);
                //    ClientFrameworkRes.Client.Media.DDJFiles.Add(pk2PathString, DDJFile);
                //}
            }

            image = PackFile.MediaPack.DDJFiles[pk2PathString].BitmapImage;
        }

        /// <summary>
        /// Initialize the entired _RefRegion map into the application for faster loadup.
        /// </summary>
        private void InitializeWorldGraphics()
        {
            var allRegions = ClientFrameworkRes.Database.SRO_VT_SHARD._RefRegion.Values;
            World = new CWorld(allRegions); // TODO: make fields for the unmanaged Regions inside CWorld...

            //Add images which are not present inside the database
            AllUnusedRegionGraphics.Clear();
            Point p = Point.Empty;
            for (int i = 0; i < 255; i++)
            {
                for (int i2 = 0; i2 < 255; i2++)
                {
                    p.X = i; p.Y = i2;

                    string str = $"{ClientFrameworkRes.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{i}x{i2}.JPG";
                    if (System.IO.File.Exists(str) && !World.ContainsRegion(p))
                    {
                        int rID = Convert.ToInt32($"{i2.ToString("X")}{i.ToString("X")}", 16);
                        RegionGraphic regLayer = new RegionGraphic((short)rID, "Unassigned");
                        if (regLayer.HasLayer)
                        {
                            AllUnusedRegionGraphics.Add(p, regLayer);
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}