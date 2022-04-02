using BinaryFiles.PackFile;
using System.Collections.Concurrent;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    internal class MapGuidePanel : Panel
    {
        #region Fields

        private const string FilePath = "Media\\interface\\worldmap\\map";
        private readonly ConcurrentDictionary<Point, Bitmap> imgDic = new ConcurrentDictionary<Point, Bitmap>();
        private readonly ConcurrentDictionary<Point, CGuideRegion> MapPool = new ConcurrentDictionary<Point, CGuideRegion>();
        private Point DrawStartPoint;
        private Point LastMousePosition;

        #endregion Fields

        #region Constructors

        internal MapGuidePanel()
        {
            DoubleBuffered = true;
            Size = new Size(652, 424);

            Paint += MapGuidePanel_Paint;
            MouseUp += MapGuidePanel_MouseUp;
            MouseDown += MapGuidePanel_MouseDown;
            InitializeMapImages();
        }

        #endregion Constructors

        #region Methods

        private void InitializeMapImages()
        {
            bool filesExist = PackFile.MediaPack.Reader.GetFilesInFolder(FilePath, out PackFile.Pk2File[] files);

            foreach (PackFile.Pk2File i in files)
            {
                string name = i.name;

                if (!name.StartsWith("map_world_"))
                {
                    continue;
                }

                string[] Coordinates = name.Replace("map_world_", "").Replace(".ddj", "").Split('x');

                if (byte.TryParse(Coordinates[0], out byte x) && byte.TryParse(Coordinates[1], out byte y))
                {
                    if (PackFile.MediaPack.Reader.GetByteArrayByDirectory(System.IO.Path.Combine(FilePath, i.name), out byte[] file))
                    {
                        imgDic.TryAdd(new Point(x, y), new DDJImage(file).BitmapImage);
                    }
                }
            }
        }

        private void MapGuidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                LastMousePosition = e.Location;
            }
        }

        private void MapGuidePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                DrawStartPoint.X = DrawStartPoint.X + (e.X - LastMousePosition.X);
                DrawStartPoint.Y = DrawStartPoint.Y + (e.Y - LastMousePosition.Y);
                Invalidate();
            }
        }

        private void MapGuidePanel_Paint(object sender, PaintEventArgs e)
        {
            int minX = 255, maxY = 0;
            foreach (Point poinnt in imgDic.Keys)
            {
                if (minX > poinnt.X)
                {
                    minX = poinnt.X;
                }

                if (maxY < poinnt.Y)
                {
                    maxY = poinnt.Y;
                }
            }
            var coordinatePoint = Point.Empty;
            var drawPoint = Point.Empty;

            for (int x = 1; x <= 256; x += 4)
            {
                for (int z = 1; z <= 256; z += 4)
                {
                    coordinatePoint.X = x;
                    coordinatePoint.Y = z;
                    if (imgDic.ContainsKey(coordinatePoint))
                    {

                        drawPoint.X = DrawStartPoint.X + (((x - minX) * (imgDic[coordinatePoint].Width / 4)));
                        drawPoint.Y = DrawStartPoint.Y + (((maxY - z)) * (imgDic[coordinatePoint].Height / 4));
                        //   e.Graphics.DrawImage(imgDic[coordinatePoint], drawPoint);
                        //   TextRenderer.DrawText(e.Graphics, $"X:{x} Z:{z}", Font, drawPoint, Color.Red);
                    }
                }
            }
            foreach (System.Collections.Generic.KeyValuePair<Point, Bitmap> item in imgDic)
            {
                drawPoint.X = DrawStartPoint.X + (((item.Key.X - minX) * (item.Value.Width / 4)));
                drawPoint.Y = DrawStartPoint.Y + (((item.Key.Y - maxY) * -1) * (item.Value.Height / 4));
                e.Graphics.DrawImage(item.Value, drawPoint);
                TextRenderer.DrawText(e.Graphics, $"X:{item.Key.X} Z:{item.Key.Y}", Font, drawPoint, Color.Red);

            }

            /*
               var allfiles = Directory.GetFiles("D:\\projects\\resources\\map2");
            imgDic = new Dictionary<Point, Image>(allfiles.Length - 1);

            foreach (var i in allfiles)
            {
                var name = Path.GetFileNameWithoutExtension(i);

                if (!name.StartsWith("map_world_"))
                    continue;

                var Coordinates = name.Replace("map_world_", "").Split("x");

                if (byte.TryParse(Coordinates[0], out byte x) && byte.TryParse(Coordinates[1], out byte y))
                    imgDic.TryAdd(new Point(x, y), Image.FromFile(i));
            }
             */
        }

        #endregion Methods
    }
}