using ClientDataStorage.Client.Files;
using Editors.Teleport;
using Structs.Database;
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

        #region Private Fields

        private const string MonsterIconPath = "Media\\interface\\minimap\\mm_sign_monster.ddj";

        private const string NpcIconPath = "Media\\interface\\minimap\\mm_sign_npc.ddj";

        private const string OwnPointIconPath = "Media\\interface\\minimap\\mm_sign_animal.ddj";

        private const string PlayerIconPath = "Media\\interface\\minimap\\mm_sign_otherplayer.ddj";

        private const string TeleportIconPath = "Media\\interface\\worldmap\\map\\xy_gate.ddj";

        private const string UMonsterIconPath = "Media\\interface\\minimap\\mm_sign_unique.ddj";

        private readonly Dictionary<int, IChar> AllPlayer = new Dictionary<int, IChar>();

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap existing in the DB.
        /// </summary>
        private readonly Dictionary<Point, RegionGraphic> AllRegionGraphics = new Dictionary<Point, RegionGraphic>();

        private readonly Dictionary<int, Teleport> AllTeleports = new Dictionary<int, Teleport>();

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap that does not existing in the DB but -m file is aviable.
        /// </summary>
        private readonly Dictionary<Point, RegionGraphic> AllUnusedRegionGraphics = new Dictionary<Point, RegionGraphic>();

        private readonly Dictionary<string, NewPosition> NewPosDic = new Dictionary<string, NewPosition>();

        private readonly List<Spawn> Spawns = new List<Spawn>();

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

        /// <summary>
        /// Indicates weather the tooltip should be shown or not.
        /// </summary>
        private bool hasToolTip = false;

        private Bitmap ImageMonster;

        private Bitmap ImageMonsterUnique;
        private Bitmap ImageNpc;

        private Bitmap ImageOwnPoint;

        private Bitmap ImagePlayer;
        private Bitmap ImageTeleport;

        /// <summary>
        /// Weather the Spawn Editor should be open on click.
        /// </summary>
        private bool openEditorOnClick = false;

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

        private bool showDbRegions = true;

        private bool showMonster = false;

        private bool showNestGenRadius = false;

        private bool showNestRadius = false;

        private bool showNpc = true;

        private bool showPlayer = false;

        private bool showTeleport = false;

        private bool showRegionsUnassigned = false;

        private bool showUniqueMonster = false;

        #endregion Private Fields

        #region Internal Constructors

        internal GraphicsPanel()
        {
            InitializeComponents();
        }

        #endregion Internal Constructors

        #region Internal Properties

        internal bool HasToolTip { get => hasToolTip; set => hasToolTip = value; }

        /// <summary>
        /// Defines weather the MapViewer is initialized successfully or not.
        /// </summary>
        internal bool Initialized { get; private set; }
        internal bool OpenEditorOnClick { get => openEditorOnClick; set => openEditorOnClick = value; }
        internal Point PointOfView { get => PointZeroLocation; set { PointZeroLocation = value; Invalidate(); } }
        internal int RegionPixelSize { get => PictureSize; set { PictureSize = value; Invalidate(); } }
        internal bool ShowDbRegions { get => showDbRegions; set { showDbRegions = value; Invalidate(); } }
        internal bool ShowMonster { get => showMonster; set { showMonster = value; Invalidate(); } }
        internal bool ShowNestGenRadius { get => showNestGenRadius; set { showNestGenRadius = value; Invalidate(); } }
        internal bool ShowNestRadius { get => showNestRadius; set { showNestRadius = value; Invalidate(); } }
        internal bool ShowNpc { get => showNpc; set { showNpc = value; Invalidate(); } }
        internal bool ShowPlayer { get => showPlayer; set { showPlayer = value; Invalidate(); } }
        internal bool ShowTeleport { get => showTeleport; set { showTeleport = value; Invalidate(); } }
        internal bool ShowUnassignedRegions { get => showRegionsUnassigned; set { showRegionsUnassigned = value; Invalidate(); } }
        internal bool ShowUniqueMonster { get => showUniqueMonster; set { showUniqueMonster = value; Invalidate(); } }

        #endregion Internal Properties

        #region Private Methods

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

                int regionID = Convert.ToInt32(strin, 16);

                float fRegX = ((PointMouseSroRegioDown.X) * PictureSize + (PointZeroLocation.X - e.X)) * -1;
                float RegX = (float)Math.Round(fRegX * (1920f / PictureSize), 0);

                int fRegX2 = ((PointMouseSroRegioDown.X) * PictureSize + (PointZeroLocation.X - e.X)) * -1;
                int RegX2 = (int)Math.Round(fRegX * (1920f / PictureSize), 0);

                float fRegY = ((128 * PictureSize) + (PointZeroLocation.Y - e.Y)) - ((PointMouseSroRegioDown.Y) * PictureSize);
                float RegY = (float)Math.Round(fRegY * (1920f / PictureSize));

                if (!ClientDataStorage.Client.Map.AllmFiles.ContainsKey(PointMouseSroRegioDown))
                {
                    if (ClientDataStorage.Client.Map.MapPk2.GetByteArrayByDirectory($"Map\\{PointMouseSroRegioDown.Y}\\{PointMouseSroRegioDown.X}.m", out byte[] mFile))
                    {
                        mFile mfi = new mFile(mFile, (byte)PointMouseSroRegioDown.X, (byte)PointMouseSroRegioDown.Y);
                        ClientDataStorage.Client.Map.AllmFiles.Add(PointMouseSroRegioDown, mfi);
                    }
                }
                if (ClientDataStorage.Client.Map.AllmFiles.ContainsKey(PointMouseSroRegioDown))
                {
                    if (ClientDataStorage.Client.Map.AllmFiles[PointMouseSroRegioDown].GetHightByfPoint(RegX, RegY, out float Z))
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
            if (HasToolTip)
            {
                IEnumerable<int> rangeXCoordPanel = Enumerable.Range(e.X - 8, 16);
                IEnumerable<int> rangeYCoordPanel = Enumerable.Range(e.Y - 8, 16);

                StrBuilder.Clear();
                foreach (Spawn spawn in Spawns.Where(spwn =>
                rangeXCoordPanel.Contains((spwn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spwn.xLocation / (1920f / PictureSize), 0))
                && rangeYCoordPanel.Contains(((((spwn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spwn.yLocation / (1920f / PictureSize)) * -1))))
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
            if (e.Delta < 0 && PictureSize < 10)
            {
                return;
            }
            else if (e.Delta > 0 && PictureSize > 900)
            {
                return;
            }

            PointMouseSroRegioDown.X = ((PointZeroLocation.X - e.X) / PictureSize) * -1;
            PointMouseSroRegioDown.Y = ((PointZeroLocation.Y - e.Y) / PictureSize) * -1;

            PictureSize = e.Delta < 0 ? PictureSize - 10 : PictureSize + 10;
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
            IEnumerable<int> xRange = Enumerable.Range(-PictureSize, Width + PictureSize);
            IEnumerable<int> yRange = Enumerable.Range(-PictureSize, Height + PictureSize);

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
                        if (AllRegionGraphics.TryGetValue(PointRegionXY, out RegionGraphic region) && ShowDbRegions)
                        {
                            e.Graphics.DrawImage(region.RegionLayer, PointPanel.X, PointPanel.Y, PictureSize, PictureSize);
                        }
                        else if (AllUnusedRegionGraphics.TryGetValue(PointRegionXY, out RegionGraphic unassignedregion) && ShowUnassignedRegions)
                        {
                            e.Graphics.DrawImage(unassignedregion.RegionLayer, PointPanel.X, PointPanel.Y, PictureSize, PictureSize);
                        }
                        else
                        {
                            drawSize.Width = PictureSize;
                            drawSize.Height = PictureSize;
                            drawRec.Location = PointPanel;
                            drawRec.Size = drawSize;
                            e.Graphics.DrawRectangle(Pens.Red, drawRec);
                            if (PictureSize > 128)
                            {
                                TextRenderer.DrawText(e.Graphics, $"X: {PointRegionXY.X} Z: {PointRegionXY.Y} \n", Font, PointPanel, Color.AliceBlue);
                            }
                            //e.Graphics.DrawString($"X: {regionPoint.X} Z: {regionPoint.Y} \n", this.Font, Brushes.AliceBlue, panelPoint);
                        }
                    }
                }
            }
            if (Initialized)
            {
                foreach (Spawn spawn in Spawns)
                {
                    switch (spawn.spawnType)
                    {
                        case SpawnType.None:
                            break;

                        case SpawnType.Monster when ShowMonster:
                            int spawnLocationX = (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.xLocation / (1920f / PictureSize), 0);//+ mob.Value.Location.X;
                            int spawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.yLocation / (1920f / PictureSize)) * -1);// mob.Value.Location.Y;
                            e.Graphics.DrawImage(ImageMonster, spawnLocationX - ImageMonster.Width / 2, spawnLocationY - ImageMonster.Width / 2, ImageMonster.Width, ImageMonster.Height);

                            if (ShowNestGenRadius)
                            {
                                e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), spawn.nGenerateRadius / (1920 / PictureSize), spawn.nGenerateRadius / (1920 / PictureSize));
                            }

                            if (ShowNestRadius)
                            {
                                e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((spawn.nRadius / (1920 / PictureSize)) / 2), spawnLocationY - ((spawn.nRadius / (1920 / PictureSize)) / 2), spawn.nRadius / (1920 / PictureSize), spawn.nRadius / (1920 / PictureSize));
                            }

                            break;

                        case SpawnType.Npc when ShowNpc:
                            e.Graphics.DrawImage(ImageNpc, (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.xLocation / (1920f / PictureSize), 0) - (ImageNpc.Width / 2), ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.yLocation / (1920f / PictureSize)) * -1) - (ImageNpc.Width / 2), ImageNpc.Width, ImageNpc.Height);
                            break;

                        case SpawnType.Unique when ShowUniqueMonster:
                            int uspawnLocationX = (spawn.RegionID.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.xLocation / (1920f / PictureSize), 0) - (ImageMonster.Width / 2);
                            int uspawnLocationY = ((((spawn.RegionID.Z * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.yLocation / (1920f / PictureSize)) * -1) - (ImageMonster.Width / 2);
                            e.Graphics.DrawImage(ImageMonsterUnique, uspawnLocationX - ImageMonsterUnique.Width / 2, uspawnLocationY - ImageMonsterUnique.Width / 2, ImageMonsterUnique.Width, ImageMonsterUnique.Height);

                            if (ShowNestRadius)
                            {
                                e.Graphics.DrawEllipse(Pens.Green, uspawnLocationX - ((spawn.nRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((spawn.nRadius / (1920 / PictureSize)) / 2), spawn.nRadius / (1920 / PictureSize), spawn.nRadius / (1920 / PictureSize));
                            }

                            if (ShowNestGenRadius)
                            {
                                e.Graphics.DrawEllipse(Pens.Yellow, uspawnLocationX - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), uspawnLocationY - ((spawn.nGenerateRadius / (1920 / PictureSize)) / 2), spawn.nGenerateRadius / (1920 / PictureSize), spawn.nGenerateRadius / (1920 / PictureSize));
                            }

                            break;

                        case SpawnType.Teleport:
                            break;

                        case SpawnType.Player:
                            break;

                        default:
                            break;
                    }
                }

                foreach (KeyValuePair<string, NewPosition> item in NewPosDic)
                {
                    e.Graphics.DrawImage(ImageOwnPoint, new PointF((Convert.ToSingle((item.Value.RegionID % 256) * PictureSize + PointZeroLocation.X)) + (item.Value.Position.X / (1920f / PictureSize)), Convert.ToSingle(((((item.Value.RegionID / 256) * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + ((item.Value.Position.Y / (1920f / PictureSize)) * -1)));
                }

                if (ShowTeleport)
                {
                    foreach (Teleport teleport in AllTeleports.Values)
                    {
                        e.Graphics.DrawImage(ImageTeleport, (teleport.X * PictureSize + PointZeroLocation.X) + (int)Math.Round(teleport.Location.X / (1920f / PictureSize), 0), ((((teleport.Y * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((teleport.Location.Y / (1920f / PictureSize)) * -1), ImageTeleport.Width, ImageTeleport.Height);
                    }
                }

                if (ShowPlayer)
                {
                    foreach (IChar item in ClientDataStorage.Database.SRO_VT_SHARD._Char.Values)
                    {
                        e.Graphics.DrawImage(ImagePlayer, ((item.LatestRegion % 256) * PictureSize + PointZeroLocation.X) + (int)Math.Round(item.PosX / (1920f / PictureSize), 0), (((((item.LatestRegion / 256) * PictureSize) - (128 * PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((item.PosZ / (1920f / PictureSize)) * -1), ImagePlayer.Width, ImagePlayer.Height);
                    }
                }
            }
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
            //  AllNpcs.Clear();
            //  AllMonsters.Clear();
            //  AllUniqueMonsters.Clear();
            Spawns.Clear();
            foreach (KeyValuePair<int, TabRefNest> nest in ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest)
            {
                Spawns.Add(new Spawn(nest.Key, nest.Value.nRegionDBID, nest.Value.fLocalPosX, nest.Value.fLocalPosZ, nest.Value.fLocalPosY, nest.Value.nRadius, nest.Value.nGenerateRadius));
            }

            foreach (RefTeleport teleport in ClientDataStorage.Database.SRO_VT_SHARD._RefTeleport.Values)
            {
                if (teleport.AssocRefObjID > 0)
                {
                    Teleport tele = new Teleport(new SingleTeleport(teleport));
                    AllTeleports.Add(tele.TeleportData.Teleport.ID, tele);
                }
            }
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
            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey(pk2PathString))
            {
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory(pk2PathString, out byte[] file))
                {
                    DDJImage DDJFile = new DDJImage(file);
                    ClientDataStorage.Client.Media.DDJFiles.Add(pk2PathString, DDJFile);
                }
            }

            image = ClientDataStorage.Client.Media.DDJFiles[pk2PathString].BitmapImage;
        }

        /// <summary>
        /// Initialize the entired _RefRegion map into the application for faster loadup.
        /// </summary>
        private void InitializeWorldGraphics()
        {
            var allRegions = ClientDataStorage.Database.SRO_VT_SHARD._RefRegion;
            Point point = new Point(0, 0);
            AllRegionGraphics.Clear();
            foreach (var region in allRegions)
            {
                RegionGraphic rGraphic = new RegionGraphic(region.Key);
                if (rGraphic.HasLayer)
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
            AllUnusedRegionGraphics.Clear();
            Point p = new Point(0, 0);
            for (int i = 0; i < 255; i++)
            {
                for (int i2 = 0; i2 < 255; i2++)
                {
                    p.X = i; p.Y = i2;

                    string str = $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{i}x{i2}.JPG";
                    if (System.IO.File.Exists(str) && !AllRegionGraphics.ContainsKey(p))
                    {
                        int rID = Convert.ToInt32($"{i2.ToString("X")}{i.ToString("X")}", 16);
                        RegionGraphic regLayer = new RegionGraphic((short)rID);
                        if (regLayer.HasLayer)
                        {
                            AllUnusedRegionGraphics.Add(p, regLayer);
                        }
                    }
                }
            }
        }

        #endregion Private Methods

    }
}