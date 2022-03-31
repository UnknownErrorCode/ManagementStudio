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
            bool filesExist = ClientDataStorage.Client.Media.MediaPk2.GetFilesInFolder(FilePath, out Structs.Pk2.Pk2File[] files);

            foreach (Structs.Pk2.Pk2File i in files)
            {
                string name = i.name;

                if (!name.StartsWith("map_world_"))
                {
                    continue;
                }

                string[] Coordinates = name.Replace("map_world_", "").Replace(".ddj", "").Split('x');

                if (byte.TryParse(Coordinates[0], out byte x) && byte.TryParse(Coordinates[1], out byte y))
                {
                    if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory(System.IO.Path.Combine(FilePath, i.name), out byte[] file))
                    {
                        imgDic.TryAdd(new Point(x, y), new ClientDataStorage.Client.Files.DDJImage(file).BitmapImage);
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
            foreach (System.Collections.Generic.KeyValuePair<Point, Bitmap> item in imgDic)
            {
                e.Graphics.DrawImage(item.Value, item.Key);
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