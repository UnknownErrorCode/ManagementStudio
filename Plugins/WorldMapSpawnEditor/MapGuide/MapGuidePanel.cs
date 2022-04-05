using BinaryFiles.PackFile;
using PackFile.Media.Textdata;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    internal class MapGuidePanel : Panel
    {
        #region Fields
        private const string FilePath = "Media\\interface\\worldmap\\map";
        private static readonly ConcurrentDictionary<Point, Bitmap> Pk2ImageDic = new ConcurrentDictionary<Point, Bitmap>();
        private readonly ConcurrentDictionary<Point, CGuideRegion> LocalPNGMapPoolImageDic = new ConcurrentDictionary<Point, CGuideRegion>();
        
        private Worldmap_Mapinfo worldmap_Mapinfo;

        private WorldMapInfoSection ActiveSection;
        Worldmap_Mapinfo_WorldStruct CurrentViewWorld;
        Worldmap_Mapinfo_WorldStruct CurrentViewDungeon;

        private Point DrawStartPoint = Point.Empty,
            LastMousePosition = Point.Empty,
            coordinatePoint = Point.Empty,
            drawPoint = Point.Empty;
        private bool IsDragging;
        int newX, newY,
            minX = 0,
            minY = 0,
            maxX = 0,
            maxY = 0;
        #endregion Fields

        #region Constructors






        internal MapGuidePanel(bool usePk2Image = true)
        {
            UsePk2Image = usePk2Image;
            DoubleBuffered = true;
            Size = new Size(725, 350);

            Paint += MapGuidePanel_Paint;
            MouseUp += MapGuidePanel_MouseUp;
            MouseDown += MapGuidePanel_MouseDown;
            MouseMove += MapGuidePanel_MouseMove;

            if (!PackFile.MediaPack.GetWorldmap_Mapinfo(out worldmap_Mapinfo))
                return;

            if (worldmap_Mapinfo.TryGetMainWorldInfo(out CurrentViewWorld))
                ActiveSection = WorldMapInfoSection.wLocalMap;

            InitializeMapImages(UsePk2Image);

        }
        private void MapGuidePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (LastMousePosition == e.Location)
            {
                return;
            }
            if (IsDragging && e.Button == MouseButtons.Left)
            {

                newX = DrawStartPoint.X + (e.X - LastMousePosition.X);
                newY = DrawStartPoint.Y + (e.Y - LastMousePosition.Y);
                if (newX <= 0 && newX > (CurrentViewWorld.TotalSize_x * -1) + Width)
                {
                    DrawStartPoint.X = DrawStartPoint.X + (e.X - LastMousePosition.X);
                }
                if (newY <= 0 && newY > (CurrentViewWorld.TotalSize_y * -1) + Height)
                {
                    DrawStartPoint.Y = DrawStartPoint.Y + (e.Y - LastMousePosition.Y);
                }



                LastMousePosition = e.Location;

                Invalidate();
            }
        }

        #endregion Constructors

        public Point ViewPoint
        {
            get => DrawStartPoint; set { DrawStartPoint = value; Invalidate(); }
        }

        public bool UsePk2Image { get; }
        #region Methods

        private void InitializeMapImages(bool pk2 = true)
        {

            if (pk2)
            {
                PackFile.PackFileManager.ExtractRegionIcons();

                string[] pics = Directory.GetFiles(Path.Combine(ClientFrameworkRes.Config.StaticConfig.ClientExtracted, FilePath), "map_world_*");


                foreach (string item in pics)
                {
                    string[] Coordinates = item.Replace(Path.Combine(ClientFrameworkRes.Config.StaticConfig.ClientExtracted, FilePath, "map_world_"), "").Replace(".dds", "").Split('x');
                    if (byte.TryParse(Coordinates[0], out byte x) && byte.TryParse(Coordinates[1], out byte y))
                    {
                        var pointer = new Point(x, y);
                        if (Pk2ImageDic.ContainsKey(pointer))
                            continue;
                        JMXddjFile imgdds = new JMXddjFile(File.OpenRead(item));
                        //Image img = Image.FromFile(item);
                        Pk2ImageDic.TryAdd(pointer, imgdds.BitmapImage);

                        //if (PackFile.MediaPack.Reader.GetByteArrayByDirectory(System.IO.Path.Combine(FilePath, i.name), out byte[] file))
                        //{
                        //    imgDic.TryAdd(pointer, new JMXddjFile(file).BitmapImage);
                        //}
                    }
                }
            }
            else
            {
                string[] pics = Directory.GetFiles(Path.Combine(ClientFrameworkRes.Config.StaticConfig.ClientExtracted, FilePath), "map_world_*.png");
                foreach (string item in pics)
                {
                    string[] Coordinates = item.Replace(Path.Combine(ClientFrameworkRes.Config.StaticConfig.ClientExtracted, FilePath, "map_world_"), "").Replace(".png", "").Split('x');
                    if (!byte.TryParse(Coordinates[0], out byte x) || !byte.TryParse(Coordinates[1], out byte y))
                    {
                        continue;
                    }
                    var pointer = new Point(x, y);
                    if (LocalPNGMapPoolImageDic.ContainsKey(pointer))
                        continue;
                    Bitmap imgdds = (Bitmap) Image.FromFile(item);
                    //Image img = Image.FromFile(item);
                    LocalPNGMapPoolImageDic.TryAdd(pointer, new CGuideRegion("worldmap", x, y, item));
                }
            }



         
        }

        private void MapGuidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                IsDragging = true;
                LastMousePosition = e.Location;
            }
        }

        private void MapGuidePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                IsDragging = false;
            }
        }
        private void MapGuidePanel_Paint(object sender, PaintEventArgs e)
        {
            switch (ActiveSection)
            {
                case WorldMapInfoSection.None:
                    return;
                case WorldMapInfoSection.wLocalMap:
                    minX = CurrentViewWorld.left;
                    maxX = CurrentViewWorld.right;
                    minY = CurrentViewWorld.bottom;
                    maxY = CurrentViewWorld.top;
                    break;
                case WorldMapInfoSection.Dungeonmap:
                    break;
                default:
                    break;
            }


            for (int x = minX; x <= maxX; x += 4)
            {
                for (int z = maxY; z >= minY; z -= 4)
                {
                    coordinatePoint.X = x;
                    coordinatePoint.Y = z;
                    if (Pk2ImageDic.ContainsKey(coordinatePoint))
                    {
                        drawPoint.X = DrawStartPoint.X + (((x - minX) * (Pk2ImageDic[coordinatePoint].Width / 4)));
                        drawPoint.Y = DrawStartPoint.Y + (((maxY - z)) * (Pk2ImageDic[coordinatePoint].Height / 4));
                        
                        e.Graphics.DrawImage(UsePk2Image? Pk2ImageDic[coordinatePoint]: LocalPNGMapPoolImageDic[coordinatePoint].RegionLayer, drawPoint);
                        TextRenderer.DrawText(e.Graphics, $"X:{x} Z:{z}", Font, drawPoint, Color.Red);
                    }
                }
            }

        }

        #endregion Methods
    }
}