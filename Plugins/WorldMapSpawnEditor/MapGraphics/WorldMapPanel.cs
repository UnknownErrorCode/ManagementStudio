using BinaryFiles.PackFile;
using Editors.Spawn;
using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal sealed class WorldMapPanel : Panel
    {
        [DllImport("CHelper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HoverXHelper(int x, int picsize, int viewX, float posX);

        [DllImport("CHelper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HoverZHelper(int z, int picsize, int viewZ, float posZ);

        [DllImport("CHelper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ExceedViewX(int x, int picsize, int width);

        [DllImport("CHelper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ExceedViewY(int z, int picsize, int heigth);

        [DllImport("CHelper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetSroPosX(int x, int picsize, int viewX, int clickX);

        [DllImport("CHelper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetSroPosY(int z, int picsize, int viewY, int clickY);

        #region Fields

        private const string MonsterIconPath = "Media\\interface\\minimap\\mm_sign_monster.ddj";
        private const string NpcIconPath = "Media\\interface\\minimap\\mm_sign_npc.ddj";
        private const string OwnPointIconPath = "Media\\interface\\minimap\\mm_sign_animal.ddj";
        private const string PlayerIconPath = "Media\\interface\\minimap\\mm_sign_otherplayer.ddj";
        private const string TeleportIconPath = "Media\\interface\\worldmap\\map\\xy_gate.ddj";
        private const string UMonsterIconPath = "Media\\interface\\minimap\\mm_sign_unique.ddj";

        private readonly ContextMenuStrip ContextMenu = new ContextMenuStrip();

        /// <summary>
        /// String builder for tooltip text help.
        /// </summary>
        private readonly StringBuilder StrBuilder = new StringBuilder();

        /// <summary>
        /// Unique tooltip used for anyting that requires a Tip to display to avoid creating duplicate tooltips.
        /// </summary>
        private readonly ToolTip tip = new ToolTip();

        private System.Windows.Forms.ContextMenuStrip contextMenuStripRegionClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateSpawn;
        private System.Windows.Forms.ToolStripMenuItem saveCoordinateToolStripMenuItem;

        /// <summary>
        /// Contains all configs for the paint event.
        /// </summary>
        private WorldMapPanelBase Base = new WorldMapPanelBase();

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
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point PointMouseDown = Point.Empty;

        /// <summary>
        /// The Location of the mouse while dragging and swiping.
        /// </summary>
        private Point wRegionID = Point.Empty;

        private Point PointPanel = Point.Empty;
        private Point PointRegionXY = Point.Empty;
        private Structs.SVector3 sVector;

        /// <summary>
        /// The start Position for Drawing.
        /// </summary>
        private Point PointZeroLocation = Point.Empty;

        private CWorld World;
        private CWorldSpawn WorldSpawn;

        #endregion Fields

        #region Constructors

        internal WorldMapPanel()
        {
            InitializeComponents();
        }

        #endregion Constructors

        #region Properties

        public bool ShowRegionDBnoDDJ
        { get => Base.showRegionDBnoDDJ; set { Base.showRegionDBnoDDJ = value; Invalidate(); } }

        public bool ShowMeshBlocks
        { get => Base.showMeshBlocks; set { Base.showMeshBlocks = value; Invalidate(); } }

        public bool ShowMeshCells { get => Base.showMeshCells; set => Base.showMeshCells = value; }

        internal string[] Continents => World.Continents.Keys.ToArray();

        internal Point PointOfView
        { get => PointZeroLocation; set { PointZeroLocation = value; Invalidate(); } }

        internal int RegionPixelSize
        { get => Base.PictureSize; set { Base.PictureSize = value; Invalidate(); } }

        internal bool ShowEditorOnClick { get => Base.showEditorOnClick; set => Base.showEditorOnClick = value; }

        internal bool ShowMonster
        { get => Base.showMonster; set { Base.showMonster = value; Invalidate(); } }

        internal bool ShowNestGenRadius
        { get => Base.showNestGenRadius; set { Base.showNestGenRadius = value; Invalidate(); } }

        internal bool ShowNestRadius
        { get => Base.showNestRadius; set { Base.showNestRadius = value; Invalidate(); } }

        internal bool ShowNpc
        { get => Base.showNpc; set { Base.showNpc = value; Invalidate(); } }

        internal bool ShowPlayer
        { get => Base.showPlayer; set { Base.showPlayer = value; Invalidate(); } }

        internal bool ShowRegionsDb
        { get => Base.showRegionDb; set { Base.showRegionDb = value; Invalidate(); } }

        internal bool ShowRegionsUnassigned
        { get => Base.showRegionsUnassigned; set { Base.showRegionsUnassigned = value; Invalidate(); } }

        internal bool ShowTeleport
        { get => Base.showTeleport; set { Base.showTeleport = value; Invalidate(); } }

        internal bool ShowToolTip { get => Base.showToolTip; set => Base.showToolTip = value; }

        internal bool ShowUniqueMonster
        { get => Base.showUniqueMonster; set { Base.showUniqueMonster = value; Invalidate(); } }

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
                wRegionID.X = ((PointZeroLocation.X - e.X) / Base.PictureSize) * -1;
                wRegionID.Y = ((PointZeroLocation.Y - e.Y) / Base.PictureSize) + 127;

                short regionID = Structs.WRegionID.GetRegionID(wRegionID.X, wRegionID.Y);

                var regex = GetSroPosX(wRegionID.X, Base.PictureSize, PointZeroLocation.X, e.X);
                var regez = GetSroPosY(wRegionID.Y, Base.PictureSize, PointZeroLocation.Y, e.Y);
                sVector.X = regex;
                sVector.Y = regez;
                if (PackFile.MapPack.TryGetMeshZ((byte)wRegionID.X, (byte)wRegionID.Y, regionID, regex, regez, out sVector.Z))
                {
                    if (ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"/warp {regionID} {regex} {sVector.Z} {regez}\n\nX:{wRegionID.X}\nY:{wRegionID.Y}", "Add new Position?"))
                    {
                        string str = ServerFrameworkRes.BasicControls.vSroMessageBox.GetInput("Enter the Name of your Point inside the InputBox.", "Add new location", "Pos Name:");
                        if (str.Length > 0)
                            PositionStorage.StorePosition(str, new NewPosition() { Text = str, RegionID = (short)regionID, Position = new System.Numerics.Vector3(regex, regez, sVector.Z) });
                        Invalidate();
                        PluginFramework.BasicControls.GenericSelectForm.SelectObjStruct<NewPosition>(PositionStorage.Collection, out NewPosition pos);
                        if (PluginFramework.BasicControls.GenericSelectForm.SelectObjStruct(PluginFramework.Database.SRO_VT_SHARD._Char, out Structs.Database.IChar ichar))
                        {
                        }
                    }
                }
                else
                {
                    ServerFrameworkRes.BasicControls.vSroMessageBox.Show($"/warp {regionID} {regex} 0 {regez}\n\nFailed to get Z coordinate\nUse Charakter Position to get hight.\n\nX:{wRegionID.X}\nY:{wRegionID.Y}");
                }

                IEnumerable<int> rangeXCoordPanel = Enumerable.Range(e.X - 6, 12);
                IEnumerable<int> rangeYCoordPanel = Enumerable.Range(e.Y - 6, 12);

                // TODO: Reimplement the SpawnEditor on Click
                if (!Base.showEditorOnClick)
                    return;

                foreach (var swn in WorldSpawn.Where(ch => rangeXCoordPanel.Contains(
                        HoverXHelper((int)ch.RegionID.X, Base.PictureSize, PointZeroLocation.X, ch.XLocation)) && rangeYCoordPanel.Contains(HoverZHelper((int)ch.RegionID.Z, Base.PictureSize, PointZeroLocation.Y, ch.ZLocation))))
                {
                    switch (swn.SpawnType)
                    {
                        case SpawnType.None:
                            break;

                        case SpawnType.Monster when Base.showMonster && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {((Monster)swn).CodeName128}", "SpawnEditor"):

                            using (SpawnEditor Editor = new SpawnEditor(new NestSpawnProperty(PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[swn.ID])))
                                Editor.ShowDialog();
                            break;

                        case SpawnType.Npc when Base.showNpc:
                            if (ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for monster {((Npc)swn).CodeName128}", "SpawnEditor"))
                                using (SpawnEditor Editor = new SpawnEditor(new NestSpawnProperty(PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[swn.ID])))
                                    Editor.ShowDialog();
                            break;

                        case SpawnType.Unique when Base.showUniqueMonster && ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"Open Editor for unique {((Monster)swn).CodeName128}", "SpawnEditor"):

                            using (SpawnEditor Editor = new SpawnEditor(new NestSpawnProperty(PluginFramework.Database.SRO_VT_SHARD.Tab_RefNest[swn.ID])))
                                Editor.ShowDialog();
                            break;

                        case SpawnType.Teleport:
                            break;

                        case SpawnType.Player:
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// On Mouse Move it calculates the neccesary informations from each spawn below the cursor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!ShowToolTip)
                return;

            IEnumerable<int> rangeXCoordPanel = Enumerable.Range(e.X - 8, 16);
            IEnumerable<int> rangeYCoordPanel = Enumerable.Range(e.Y - 8, 16);

            StrBuilder.Clear();
            foreach (Interface.InterfaceSpawn spawn in WorldSpawn.Where(spwn =>
            rangeXCoordPanel.Contains(HoverXHelper(spwn.RegionID.X, Base.PictureSize, PointZeroLocation.X, spwn.XLocation))
            && rangeYCoordPanel.Contains(HoverZHelper(spwn.RegionID.Z, Base.PictureSize, PointZeroLocation.Y, spwn.ZLocation))))
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
                        StrBuilder.AppendLine($"Teleport: {((Teleport)spawn).ID}");
                        break;

                    case SpawnType.Player when ShowPlayer:
                        StrBuilder.AppendLine($"{ ((Player)spawn).CharName16}\n Level:{((Player)spawn).CurLevel}\n HP:{((Player)spawn).HP}\n MP:{((Player)spawn).MP}");
                        break;

                    default:
                        break;
                }
            }

            tip.Show(StrBuilder.ToString(), Parent, e.X + 20, e.Y + 2, 5000);
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
                Delta.X = e.Location.X - PointMouseDown.X;
                Delta.Y = e.Location.Y - PointMouseDown.Y;
                PointZeroLocation.X += Delta.X;
                PointZeroLocation.Y += Delta.Y;

                if (PointZeroLocation.X > 0)
                    PointZeroLocation.X = 0;

                if (PointZeroLocation.Y > 0)
                    PointZeroLocation.Y = 0;

                if (PointZeroLocation.X < -Base.PictureSize * 256 + Width)
                    PointZeroLocation.X = -Base.PictureSize * 256 + Width;

                if (PointZeroLocation.Y < -Base.PictureSize * 128 + Height)
                    PointZeroLocation.Y = -Base.PictureSize * 128 + Height;

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
            if (e.Delta < 0 && Base.PictureSize <= 15)
            {
                Base.PictureSize = 15;
                return;
            }
            else if (e.Delta > 0 && Base.PictureSize > 900)
            {
                return;
            }

            wRegionID.X = ((PointZeroLocation.X - e.X) / Base.PictureSize) * -1;
            wRegionID.Y = ((PointZeroLocation.Y - e.Y) / Base.PictureSize) * -1;

            Base.PictureSize = e.Delta < 0 ? Base.PictureSize - 10 : Base.PictureSize + 10;
            if (Base.PictureSize < 15)
                Base.PictureSize = 15;
            PointZeroLocation.X = e.Delta < 0 ? PointZeroLocation.X + wRegionID.X * 10 : PointZeroLocation.X - wRegionID.X * 10;
            PointZeroLocation.Y = e.Delta < 0 ? PointZeroLocation.Y + wRegionID.Y * 10 : PointZeroLocation.Y - wRegionID.Y * 10;

            if (PointZeroLocation.X > 0)
            {
                PointZeroLocation.X = 0;
            }

            if (PointZeroLocation.Y > 0)
            {
                PointZeroLocation.Y = 0;
            }

            if (PointZeroLocation.X < -Base.PictureSize * 256 + Width)
            {
                PointZeroLocation.X = -Base.PictureSize * 256 + Width;
            }

            if (PointZeroLocation.Y < -Base.PictureSize * 128 + Height)
            {
                PointZeroLocation.Y = -Base.PictureSize * 128 + Height;
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
                minX = -Base.PictureSize,
                maxX = Width + Base.PictureSize,
                minY = -Base.PictureSize,
                maxY = Height + Base.PictureSize;

            if (Base.showRegionsUnassigned)
            {
                var range = new Rectangle(-PointZeroLocation.X / Base.PictureSize, (PointZeroLocation.Y / Base.PictureSize) + 128, -PointZeroLocation.X / Base.PictureSize + (Width / Base.PictureSize) + 1, ((PointZeroLocation.Y / Base.PictureSize) + 128) - ((Height / Base.PictureSize) + 3));

                var uregSpan = World.UnassignedRegionsSpan(range);
                foreach (var reg in uregSpan)
                {
                    PointPanel.X = ((reg.RegionID.X * Base.PictureSize)) + PointZeroLocation.X;
                    PointPanel.Y = ((((reg.RegionID.Z * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y) - Base.PictureSize;
                    drawSize.Width = Base.PictureSize;
                    drawSize.Height = Base.PictureSize;
                    drawRec.Location = PointPanel;
                    drawRec.Size = drawSize;
                    e.Graphics.DrawImage(Image.FromFile(reg.TexturePath), PointPanel.X, PointPanel.Y, Base.PictureSize, Base.PictureSize);
                    e.Graphics.DrawRectangle(Pens.Orange, drawRec);
                    if (Base.PictureSize > 100)
                        TextRenderer.DrawText(e.Graphics, $"X: {reg.RegionID.X} Z: {reg.RegionID.Z} \nRegionID: {reg.RegionID.RegionID}\nNo RegionID in DB", Font, PointPanel, Color.White);
                }
            }

            if (Base.showRegionDb)
            {
                foreach (var cont in World.Continents.Values)
                {
                    var v1 = new Rectangle(-PointZeroLocation.X / Base.PictureSize, (PointZeroLocation.Y / Base.PictureSize) + 128, Width / Base.PictureSize + 1, Height / Base.PictureSize + 3);
                    var regions = cont.GetRegions(v1);
                    foreach (var reg in regions)
                    {
                        PointPanel.X = ((reg.RegionID.X * Base.PictureSize)) + PointZeroLocation.X;
                        PointPanel.Y = ((((reg.RegionID.Z * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y) - Base.PictureSize;
                        drawSize.Width = Base.PictureSize;
                        drawSize.Height = Base.PictureSize;
                        drawRec.Location = PointPanel;
                        drawRec.Size = drawSize;
                        if (reg.HasLayer)
                        {
                            e.Graphics.DrawImage(Image.FromFile(reg.TexturePath), PointPanel.X, PointPanel.Y, Base.PictureSize, Base.PictureSize);
                            // e.Graphics.DrawRectangle(Pens.White, drawRec);
                        }
                        else if (!reg.HasLayer && Base.showRegionDBnoDDJ)
                        {
                            e.Graphics.DrawRectangle(Pens.Green, drawRec);
                            if (Base.PictureSize > 50)
                            {
                                TextRenderer.DrawText(e.Graphics, $"\n\nNo ddj file", Font, PointPanel, Color.Red);
                            }
                        }
                        if (Base.showMeshBlocks && Base.PictureSize > 400)
                        {
                            Rectangle rec = Rectangle.Empty;
                            Point blockTextPoint = Point.Empty;
                            for (int y = 0; y < 6; y++)
                            {
                                for (int x = 0; x < 6; x++)
                                {
                                    rec.X = PointPanel.X + (int)(x * (Base.PictureSize / 6f));
                                    rec.Y = PointPanel.Y + (int)(y * (Base.PictureSize / 6f));
                                    rec.Width = (Base.PictureSize / 6);
                                    rec.Height = (Base.PictureSize / 6);
                                    e.Graphics.DrawRectangle(Pens.GreenYellow, rec);

                                    blockTextPoint.X = rec.X;
                                    blockTextPoint.Y = x == 0 && y == 0 ? rec.Y + 30 : rec.Y;
                                    TextRenderer.DrawText(e.Graphics, $"Block: X: {x} Z: {(y - 5) * -1}", Font, blockTextPoint, Color.White);
                                }
                            }
                            e.Graphics.DrawRectangle(Pens.White, drawRec);
                        }

                        if (Base.PictureSize > 100)
                            TextRenderer.DrawText(e.Graphics, $"X: {reg.RegionID.X} Z: {reg.RegionID.Z} \nRegionID: {reg.RegionID.RegionID}", Font, PointPanel, Color.White);
                    }
                }
            }
            TextRenderer.DrawText(e.Graphics, $"ViewPoint: X: {PointOfView.X} Y: {PointOfView.Y} \tZoom: {Base.PictureSize}", Font, Point.Empty, Color.White);

            if (!Initialized)
                return;

            foreach (var spawn in WorldSpawn)
            {
                PointPanel.X = (spawn.RegionID.X * Base.PictureSize) + PointZeroLocation.X;
                PointPanel.Y = ((((spawn.RegionID.Z * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y);// - Base.PictureSize;
                if ((PointPanel.X > minX && PointPanel.X < maxX) && (PointPanel.Y > minY && PointPanel.Y < maxY))
                    switch (spawn.SpawnType)
                    {
                        case SpawnType.None:
                            continue;

                        case SpawnType.Monster when Base.showMonster:
                            int spawnLocationX = PointPanel.X + (int)Math.Round(spawn.XLocation / (1920f / Base.PictureSize), 0);//+ mob.Value.Location.X;
                            int spawnLocationY = PointPanel.Y + (int)Math.Round((spawn.ZLocation / (1920f / Base.PictureSize)) * -1);// mob.Value.Location.Y;
                            e.Graphics.DrawImage(ImageMonster, spawnLocationX - ImageMonster.Width / 2, spawnLocationY - ImageMonster.Width / 2, ImageMonster.Width, ImageMonster.Height);

                            if (Base.showNestGenRadius)
                                e.Graphics.DrawEllipse(Pens.Red, spawnLocationX - ((((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize)) / 2), spawnLocationY - ((((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize)) / 2), ((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize), ((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize));

                            if (Base.showNestRadius)
                                e.Graphics.DrawEllipse(Pens.Gray, spawnLocationX - ((((Monster)spawn).NRadius / (1920 / Base.PictureSize)) / 2), spawnLocationY - ((((Monster)spawn).NRadius / (1920 / Base.PictureSize)) / 2), ((Monster)spawn).NRadius / (1920 / Base.PictureSize), ((Monster)spawn).NRadius / (1920 / Base.PictureSize));

                            break;

                        case SpawnType.Npc when Base.showNpc:
                            e.Graphics.DrawImage(ImageNpc, (spawn.RegionID.X * Base.PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / Base.PictureSize), 0) - (ImageNpc.Width / 2), ((((spawn.RegionID.Z * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / Base.PictureSize)) * -1) - (ImageNpc.Width / 2), ImageNpc.Width, ImageNpc.Height);
                            break;

                        case SpawnType.Unique when Base.showUniqueMonster:
                            int uspawnLocationX = (spawn.RegionID.X * Base.PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / Base.PictureSize), 0) - (ImageMonster.Width / 2);
                            int uspawnLocationY = ((((spawn.RegionID.Z * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / Base.PictureSize)) * -1) - (ImageMonster.Width / 2);
                            e.Graphics.DrawImage(ImageMonsterUnique, uspawnLocationX - ImageMonsterUnique.Width / 2, uspawnLocationY - ImageMonsterUnique.Width / 2, ImageMonsterUnique.Width, ImageMonsterUnique.Height);

                            if (Base.showNestRadius)
                                e.Graphics.DrawEllipse(Pens.Green, uspawnLocationX - ((((Monster)spawn).NRadius / (1920 / Base.PictureSize)) / 2), uspawnLocationY - ((((Monster)spawn).NRadius / (1920 / Base.PictureSize)) / 2), ((Monster)spawn).NRadius / (1920 / Base.PictureSize), ((Monster)spawn).NRadius / (1920 / Base.PictureSize));

                            if (Base.showNestGenRadius)
                                e.Graphics.DrawEllipse(Pens.Yellow, uspawnLocationX - ((((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize)) / 2), uspawnLocationY - ((((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize)) / 2), ((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize), ((Monster)spawn).NGenerateRadius / (1920 / Base.PictureSize));

                            break;

                        case SpawnType.Teleport when Base.showTeleport:
                            e.Graphics.DrawImage(ImageTeleport, (spawn.RegionID.X * Base.PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / Base.PictureSize), 0), ((((spawn.RegionID.Z * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((spawn.ZLocation / (1920f / Base.PictureSize)) * -1), ImageTeleport.Width, ImageTeleport.Height);
                            break;

                        case SpawnType.Player when Base.showPlayer:
                            e.Graphics.DrawImage(ImagePlayer, (spawn.RegionID.X * Base.PictureSize + PointZeroLocation.X) + (int)Math.Round(spawn.XLocation / (1920f / Base.PictureSize), 0), (((((((Player)spawn).RegionID.Z) * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y) + (int)Math.Round((((Player)spawn).ZLocation / (1920f / Base.PictureSize)) * -1), ImagePlayer.Width, ImagePlayer.Height);
                            break;

                        default:
                            break;
                    }
            }

            foreach (NewPosition item in PositionStorage.Collection.Values)
            {
                e.Graphics.DrawImage(ImageOwnPoint, new PointF((Convert.ToSingle((item.RegionID % 256) * Base.PictureSize + PointZeroLocation.X)) + (item.Position.X / (1920f / Base.PictureSize)), Convert.ToSingle(((((item.RegionID / 256) * Base.PictureSize) - (128 * Base.PictureSize)) * -1) + PointZeroLocation.Y) + ((item.Position.Y / (1920f / Base.PictureSize)) * -1)));
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
            Stopwatch watch = new Stopwatch();
            ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.loading, "Loading gameworld...");
            watch.Start();

            InitializeWorldGraphics();
            watch.Stop();
            ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.success, $"World initialized in {watch.ElapsedMilliseconds} ms!");
            ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.loading, "Loading spawns...!");

            watch.Reset();
            watch.Start();
            InitializeSpawnGraphics();
            watch.Stop();

            ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.success, $"Spawns initialized in {watch.ElapsedMilliseconds} ms!");

            this.contextMenuStripRegionClick = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItemCreateSpawn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCoordinateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            //
            // contextMenuStripRegionClick
            //
            this.contextMenuStripRegionClick.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.contextMenuStripRegionClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateSpawn,
            this.saveCoordinateToolStripMenuItem});
            this.contextMenuStripRegionClick.Name = "contextMenuStripRegionClick";
            this.contextMenuStripRegionClick.Size = new System.Drawing.Size(181, 70);
            //
            // toolStripMenuItemCreateSpawn
            //
            this.toolStripMenuItemCreateSpawn.BackgroundImage = global::WorldMapSpawnEditor.Properties.Resources.sys_button;
            this.toolStripMenuItemCreateSpawn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripMenuItemCreateSpawn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStripMenuItemCreateSpawn.Name = "toolStripMenuItemCreateSpawn";
            this.toolStripMenuItemCreateSpawn.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemCreateSpawn.Text = "Create spawn";
            //
            // saveCoordinateToolStripMenuItem
            //
            this.saveCoordinateToolStripMenuItem.BackgroundImage = global::WorldMapSpawnEditor.Properties.Resources.sys_button;
            this.saveCoordinateToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveCoordinateToolStripMenuItem.Name = "saveCoordinateToolStripMenuItem";
            this.saveCoordinateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveCoordinateToolStripMenuItem.Text = "Save Coordinate";
            this.saveCoordinateToolStripMenuItem.Click += new System.EventHandler(this.saveCoordinateToolStripMenuItem_Click);
        }

        private void saveCoordinateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            short regionID = Structs.WRegionID.GetRegionID(wRegionID.X, wRegionID.Y);

            if (ServerFrameworkRes.BasicControls.vSroMessageBox.YesOrNo($"/warp {regionID} {sVector.X} {sVector.Y} {sVector.Z}\n\nX:{wRegionID.X}\nY:{wRegionID.Y}", "Add new Position?"))
            {
                string str = ServerFrameworkRes.BasicControls.vSroMessageBox.GetInput("Enter the Name of your Point inside the InputBox.", "Add new location", "Pos Name:");
                if (str.Length > 0)
                    PositionStorage.StorePosition(str, new NewPosition() { Text = str, RegionID = (short)regionID, Position = new System.Numerics.Vector3(regex, regez, Z) });
                Invalidate();
                PluginFramework.BasicControls.GenericSelectForm.SelectObjStruct<NewPosition>(PositionStorage.Collection, out NewPosition pos);
                if (PluginFramework.BasicControls.GenericSelectForm.SelectObjStruct(PluginFramework.Database.SRO_VT_SHARD._Char, out Structs.Database.IChar ichar))
                {
                }
            }
            else
            {
                ServerFrameworkRes.BasicControls.vSroMessageBox.Show($"/warp {regionID} {regex} 0 {regez}\n\nFailed to get Z coordinate\nUse Charakter Position to get hight.\n\nX:{wRegionID.X}\nY:{wRegionID.Y}");
            }
        }

        /// <summary>
        /// Defines weather the spawn is a monster, npc or smthing else...
        /// </summary>
        private void InitializeSpawnGraphics()
        {
            WorldSpawn = new CWorldSpawn();

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
                    JMXddjFile DDJFile = new JMXddjFile(file);
                    PackFile.MediaPack.DDJFiles.Add(pk2PathString, DDJFile);
                }
            }

            image = PackFile.MediaPack.DDJFiles[pk2PathString].BitmapImage;
        }

        /// <summary>
        /// Initialize the entired _RefRegion map into the application for faster loadup.
        /// </summary>
        private void InitializeWorldGraphics()
        {
            var allRegions = PluginFramework.Database.SRO_VT_SHARD._RefRegion.Values;
            World = new CWorld(allRegions);
        }

        #endregion Methods
    }
}